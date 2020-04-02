using CallScheduler.Data;
using CallScheduler.Enums;
using CallScheduler.Helpers;
using CallScheduler.Interfaces;
using CallScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CallScheduler.Services
{
    public class CallService : ICallService
    {
        private CallSchedulerDbContext _context;

        public CallService(CallSchedulerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Call> GetAll()
        {
            return _context.Calls.
                Include(i => i.Initiator).Include(i => i.Bank).
                Include(i => i.Machine).Include(i => i.Assigner).
                Include(i => i.Engineer);
        }

        public IEnumerable<InitiatedCall> GetInitiatedCalls()
        {
            return _context.InitiatedCalls;
        }

        public IEnumerable<CallTimeline> GetCallTimelines()
        {
            return _context.CallTimelines;
        }

        public BasicResponse Initiate(InitiatedCall initiatedcall)
        {
            try
            {
                var callInitiated = new InitiatedCall
                {
                    CallOrderNumber = initiatedcall.CallOrderNumber,
                    ErrorCode = initiatedcall.ErrorCode,
                    ErrorDescription = initiatedcall.ErrorDescription,
                    IsAssigned = false,
                    BankId = initiatedcall.BankId,
                    InitiatorId = initiatedcall.InitiatorId,
                    MachineId = initiatedcall.MachineId,
                    DateCreated = DateTime.Now
                };
                _context.InitiatedCalls.Add(callInitiated);
                _context.SaveChanges();
                return BasicResponse.SuccessResult("Call initiated successfully");
            }
            catch (AppException ex)
            {
                return BasicResponse.FailureResult(ex.Message);
            }
        }

        public Call Create(Call call)
        {
            _context.Calls.Add(call);
            _context.SaveChanges();
            return call;
        }

        public Call CreateTimeline(Call call)
        {
            var retCall = GetByCON(call.CallOrderNumber);
            var callTimeline = new CallTimeline
            {
                CallId = retCall.Id,
                Status = retCall.Status,
                EngineerLocation = retCall.EngineerLocation,
                CallOrderNumber = retCall.CallOrderNumber,
                DateCreated = DateTime.Now
            };
            _context.CallTimelines.Add(callTimeline);
            _context.SaveChanges();
            return retCall;
        }

        public Call UpdateInitiatedCall(Call call)
        {
            var retInitiatedCall = GetInitiatedCallByCON(call.CallOrderNumber);
            retInitiatedCall.IsAssigned = true;
            _context.InitiatedCalls.Update(retInitiatedCall);
            _context.SaveChanges();
            return call;
        }

        public BasicResponse Assign(Call call)
        {
            try
            {
                var createCall = Create(call);
                var createCalltimeline = CreateTimeline(createCall);
                var updateInitiateCall = UpdateInitiatedCall(createCalltimeline);
                var scheduleCall = Schedule(updateInitiateCall);
                return BasicResponse.SuccessResult("Call assigned successfully");
            }
            catch (AppException ex)
            {
                return BasicResponse.FailureResult(ex.Message);
            }
        }

        public Call Schedule(Call call)
        {
            var bank = call.Bank;
            if (bank != null)
            {
                var sDate = DateTime.ParseExact(bank.SLAStartTime, "HH:mm", null);
                var eDate = DateTime.ParseExact(bank.SLAEndTime, "HH:mm", null);
                var testTime = DateTime.Now.AddHours(-10);
                var calculatedRunDate = testTime.AddHours(call.SLADuration);
                // var calculatedRunDate = DateTime.Now.AddHours(call.SLADuration);
                var dateToRun = (calculatedRunDate > eDate) ? sDate.AddDays(1).Add((calculatedRunDate - eDate)) : calculatedRunDate;
                var schedule = new Schedule
                {
                    CallId = call.Id,
                    DateToRun = dateToRun,
                    // DateToRun = DateTime.Now.AddHours(call.SLADuration),
                    CallOrderNumber = call.CallOrderNumber,
                    DateCreated = DateTime.Now
                };
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
                return call;
            }
            return call;
        }

        public Call GetById(int id)
        {
            var call = _context.Calls.
                Include(i => i.Initiator).Include(i => i.Bank).
                Include(i => i.Machine).Include(i => i.Assigner).
                Include(i => i.Engineer).FirstOrDefault(c => c.Id == id);
            return call;
        }

        public InitiatedCall GetInitiatedCallById(int id)
        {
            var initiatedcall = _context.InitiatedCalls.
                Include(i => i.Initiator).Include(i => i.Bank).
                Include(i => i.Machine).FirstOrDefault(c => c.Id == id);
            return initiatedcall;
        }

        public InitiatedCall GetInitiatedCallByCON(string con)
        {
            var initiatedcall = _context.InitiatedCalls.Include(i => i.Bank).FirstOrDefault(c => c.CallOrderNumber == con);
            return initiatedcall;
        }

        public Call GetByCON(string con)
        {
            var call = _context.Calls.Include(a => a.Assigner).Include(e => e.Engineer).Include(b => b.Bank).
                FirstOrDefault(c => c.CallOrderNumber == con);
            return call;
        }

        public BasicResponse Update(Call call)
        {
            var retCall = _context.Calls.FirstOrDefault(c => c.Id == call.Id);

            // values to update

            return BasicResponse.SuccessResult("Call updated successfully");
        }

        public BasicResponse UpdateStatus(Call call)
        {
            var retCall = _context.Calls.FirstOrDefault(c => c.Id == call.Id);
            var previousCallTimeline = _context.CallTimelines.OrderByDescending(c => c.DateCreated).FirstOrDefault(c => c.CallId == call.Id);

            // new call timeline
            var callTimeline = new CallTimeline
            {
                CallId = call.Id,
                Status = call.Status,
                EngineerLocation = call.EngineerLocation,
                CallOrderNumber = call.CallOrderNumber,
                DateCreated = DateTime.Now
            };
            _context.CallTimelines.Add(callTimeline);

            // previous call timeline
            previousCallTimeline.DateChanged = DateTime.Now;
            _context.CallTimelines.Update(previousCallTimeline);

            // update call
            if (call.IsCompleted)
            {
                retCall.IsCompleted = true;
                retCall.DateCompleted = call.DateCompleted;
            }
            retCall.Status = call.Status;
            _context.Calls.Update(retCall);

            // save changes
            _context.SaveChanges();
            return BasicResponse.SuccessResult("Call status updated successfully");
        }

        public BasicResponse Delete(int id)
        {
            var call = _context.Calls.FirstOrDefault(c => c.Id == id);
            if (call != null)
            {
                _context.Calls.Remove(call);
                _context.SaveChanges();
                return BasicResponse.SuccessResult("Call does not exist");
            }
            return BasicResponse.FailureResult("Call does not exist");
        }

        public IEnumerable<Call> GetByAssignerId(int assignerid)
        {
            return _context.Calls.Where(c => c.AssignerId == assignerid);
        }

        public IEnumerable<Call> GetByEngineerId(int engineerid)
        {
            return _context.Calls.Where(c => c.EngineerId == engineerid);
        }

        public IEnumerable<Call> GetByStatus(CallStatus callstatus)
        {
            return _context.Calls.Where(c => c.Status == callstatus);
        }

        public IEnumerable<Call> GetBySLACompleted()
        {
            return _context.Calls.Where(c => c.IsCompleted);
        }

        public IEnumerable<CallTimeline> GetTimeline(int callid)
        {
            return _context.CallTimelines.Where(c => c.CallId == callid);
        }

        public IEnumerable<Part> GetParts(int callid)
        {
            var callDetails = GetById(callid);
            return _context.Parts.Where(c => c.MachineVariantId == callDetails.Machine.MachineVariantId);
        }
    }
}
