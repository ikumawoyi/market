using CallScheduler.Enums;
using CallScheduler.Models;
using System.Collections.Generic;

namespace CallScheduler.Interfaces
{
    public interface ICallService
    {
        IEnumerable<Call> GetAll();
        IEnumerable<InitiatedCall> GetInitiatedCalls();
        IEnumerable<CallTimeline> GetCallTimelines();
        BasicResponse Initiate(InitiatedCall initiatedcall);
        BasicResponse Assign(Call call);
        Call Create(Call call);
        Call CreateTimeline(Call call);
        Call UpdateInitiatedCall(Call call);
        Call Schedule(Call call);
        Call GetById(int id);
        Call GetByCON(string con);
        InitiatedCall GetInitiatedCallById(int id);
        InitiatedCall GetInitiatedCallByCON(string con);
        BasicResponse Update(Call call);
        BasicResponse UpdateStatus(Call call);
        BasicResponse Delete(int id);
        IEnumerable<Call> GetByAssignerId(int assignerid);
        IEnumerable<Call> GetByEngineerId(int engineerid);
        IEnumerable<Call> GetByStatus(CallStatus callstatus);
        IEnumerable<Call> GetBySLACompleted();
        IEnumerable<CallTimeline> GetTimeline(int callid);
        IEnumerable<Part> GetParts(int callid);
    }
}
