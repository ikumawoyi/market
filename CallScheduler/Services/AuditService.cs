using CallScheduler.Data;
using CallScheduler.Enums;
using CallScheduler.Extensions;
using CallScheduler.Interfaces;
using CallScheduler.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CallScheduler.Services
{
    public class AuditService : IAuditService, IAuthorizationService
    {
        private CallSchedulerDbContext Db { get; }
        // private ILoggerService Logger { get; }
        // private IPermissionService Perm { get; }

        public AuditService(CallSchedulerDbContext db)
        {
            Db = db;
            // Logger = logger;
            // Perm = perm;
        }

        public async Task CreateAudit(string action, string description)
        {
            var trail = new AuditTrail()
            {
                Action = action,
                Description = description
            };
            await Db.AuditTrails.AddAsync(trail);
            await Db.SaveChangesAsync();
        }
        public async Task CreateAudit<TEntity>(TEntity entity, AuditType action) where TEntity : class, IEntityBase, IAuditDescriptionBase
        {
            var type = entity.GetType();
            var trail = new AuditTrail()
            {
                EntityId = $"{entity.GetId()}",
                Action = Enum.GetName(typeof(AuditType), action),
                Entity = type.Name,
                Description = entity.GetAuditDescription(action)
            };
            var entry = Db.Entry(entity);

            var props = from prop in type.GetProperties()
                        let info = prop.PropertyType.GetTypeInfo()
                        let map = prop.GetCustomAttributes(typeof(NotMappedAttribute), true)
                        // let empty = prop.GetCustomAttributes(typeof(ByPassAttribute), true)
                        where prop.Name != "Id" && (info.IsValueType ||
                                                    prop.PropertyType.IsAssignableFrom(typeof(string)))
                                                && !map.Any()
                        select prop;

            switch (action)
            {
                case AuditType.Create:
                    trail.NewValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                         (s, prop) => s.AppendLine($"{prop.Name}: {entry.CurrentValues[prop.Name]}")).ToString();
                    break;
                case AuditType.Update:

                    var original = await entry.GetDatabaseValuesAsync();
                    props = from prop in props
                            where !Equals(entry.CurrentValues[prop.Name], original[prop.Name])
                            select prop;

                    trail.NewValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                        (s, prop) => s.AppendLine($"{prop.Name}: {entry.CurrentValues[prop.Name]}")).ToString();

                    trail.OriginalValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                        (s, prop) => s.AppendLine($"{prop.Name}: {original[prop.Name]}")).ToString();

                    break;
                case AuditType.Delete:
                    trail.OriginalValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                        (s, prop) => s.AppendLine($"{prop.Name}: {entry.CurrentValues[prop.Name]}")).ToString();
                    break;

                case AuditType.Authorize:
                case AuditType.Suspend:
                case AuditType.Resume:
                case AuditType.List:
                case AuditType.View:
                default:
                    break;
            }
            Db.AuditTrails.Add(trail);
            await Db.SaveChangesAsync();
        }
        public async Task CreateAuditAccount<TEntity>(TEntity entity, AuditType action) where TEntity : class, IEntityBase, IAuditDescriptionBase
        {
            var type = entity.GetType();
            var trail = new AuditTrail()
            {
                EntityId = $"{entity.GetId()}",
                Action = Enum.GetName(typeof(AuditType), action),
                Entity = type.Name,
                Description = entity.GetAuditDescription(action)
            };
            // var entry = Db.Entry(entity);

            var props = from prop in type.GetProperties()
                        let info = prop.PropertyType.GetTypeInfo()
                        let map = prop.GetCustomAttributes(typeof(NotMappedAttribute), true)
                        // let empty = prop.GetCustomAttributes(typeof(ByPassAttribute), true)
                        where prop.Name != "Id" && (info.IsValueType ||
                                                    prop.PropertyType.IsAssignableFrom(typeof(string)))
                                                && !map.Any()
                        select prop;

            switch (action)
            {
                case AuditType.Create:
                    trail.NewValues = entity.Stringify();
                    break;
                case AuditType.Update:
                case AuditType.Delete:
                case AuditType.Authorize:
                case AuditType.Suspend:
                case AuditType.Resume:
                case AuditType.List:
                case AuditType.View:
                default:
                    break;
            }
            Db.AuditTrails.Add(trail);
            await Db.SaveChangesAsync();
        }

        public async Task CreateAudit<TEntity>(TEntity entity, AuditType action, string description, string name = null) where TEntity : class, IEntityBase, IAuditDescriptionBase
        {
            var type = entity.GetType();
            var trail = new AuditTrail()
            {
                EntityId = $"{entity.GetId()}",
                Action = Enum.GetName(typeof(AuditType), action),
                Entity = name ?? type.Name,
                Description = description?.AsNullIfEmpty() ?? entity.GetAuditDescription(action)
            };
            var entry = Db.Entry(entity);

            var props = from prop in type.GetProperties()
                        let info = prop.PropertyType.GetTypeInfo()
                        let map = prop.GetCustomAttributes(typeof(NotMappedAttribute), true)
                        // let empty = prop.GetCustomAttributes(typeof(ByPassAttribute), true)
                        where prop.Name != "Id" && (info.IsValueType ||
                                                    prop.PropertyType.IsAssignableFrom(typeof(string)))
                                                && !map.Any()
                        select prop;

            switch (action)
            {
                case AuditType.Create:
                    trail.NewValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                         (s, prop) => s.AppendLine($"{prop.Name}: {entry.CurrentValues[prop.Name]}")).ToString();
                    break;
                case AuditType.Update:

                    var original = await entry.GetDatabaseValuesAsync();
                    props = from prop in props
                            where !Equals(entry.CurrentValues[prop.Name], original[prop.Name])
                            select prop;

                    trail.NewValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                        (s, prop) => s.AppendLine($"{prop.Name}: {entry.CurrentValues[prop.Name]}")).ToString();

                    trail.OriginalValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                        (s, prop) => s.AppendLine($"{prop.Name}: {original[prop.Name]}")).ToString();

                    break;
                case AuditType.Delete:
                    trail.OriginalValues = props.Aggregate(new StringBuilder(Environment.NewLine),
                        (s, prop) => s.AppendLine($"{prop.Name}: {entry.CurrentValues[prop.Name]}")).ToString();
                    break;

                case AuditType.Authorize:
                case AuditType.Suspend:
                case AuditType.Resume:
                case AuditType.List:
                case AuditType.View:
                default:
                    break;
            }
            Db.AuditTrails.Add(trail);
            await Db.SaveChangesAsync();
        }

        /// <summary>
        /// Queue up for authorization
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <param name="action"></param>
        /// <param name="desc"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task Initiate<TEntity>(TEntity entity, string action, string desc, string code, AuditType type) where TEntity : class, IEntityBase
        {
            try
            {
                var auth = new Authorization
                {
                    Action = action,
                    EntityId = entity.GetId().ToString(),
                    EntityType = typeof(TEntity).Name,
                    // Requester = Perm.CurrentUser.UserName,
                    EntityJson = entity.Stringify(),
                    Description = desc,
                    // Institution = code,
                    // Agent = $"{Perm.Scope?.Id}".AsNullIfEmpty(),
                    AuditType = type
                };
                await Db.Authorizations.AddAsync(auth);
                await Db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Logger.LogError(ex);
            }
        }
        public async Task<BasicResponse> Authorize<TEntity>(int id, bool isApproved, string checksum) where TEntity : class, IEntityBase
        {
            var authorization = await Db.Authorizations.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (authorization == null || authorization.IsApproved.HasValue)
                return BasicResponse.FailureResult("Authorization record not found.");

            var type = typeof(TEntity);
            if (authorization.EntityType != type.Name || authorization.EntityId != checksum)
                return BasicResponse.FailureResult("Invalid authorization record.");

            ////            var set = Db.Model.GetEntityTypes(x=>x.);
            //            var t = (from f in Db.Model.GetEntityTypes()
            //                where f.ClrType == type
            //                select f).FirstOrDefault();

            // authorization.Authorizer = Perm.CurrentUser.UserName;
            authorization.AuthorizeTimestamp = DateTime.Now;
            authorization.IsApproved = isApproved;

            if (isApproved)
            {

                var props = from prop in type.GetProperties()
                            let info = prop.PropertyType.GetTypeInfo()
                            let map = prop.GetCustomAttributes(typeof(NotMappedAttribute), true)
                            // let empty = prop.GetCustomAttributes(typeof(ByPassAttribute), true)
                            where prop.Name != "Id" && prop.CanWrite && (info.IsValueType ||
                                                        prop.PropertyType.IsAssignableFrom(typeof(string)))
                                                    && !map.Any()
                            select prop;

                var set = Db.Set<TEntity>();
                var obj = authorization.EntityJson.Parse<TEntity>();
                try
                {
                    TEntity current;
                    switch (authorization.AuditType)
                    {
                        case AuditType.Create:
                            await set.AddAsync(obj);
                            break;
                        case AuditType.Update:
                        case AuditType.Resume:
                        case AuditType.Suspend:
                            var key = type.GetProperty("Id").GetValue(obj);
                            current = await set.FindAsync(key);
                            if (current == null)
                                return BasicResponse.FailureResult("Original record not found.");

                            foreach (var prop in props)
                                prop.SetValue(current, prop.GetValue(obj));
                            break;
                        case AuditType.Delete:
                            //                            current = await set.FindAsync(authorization.EntityId);
                            current = await set.FindAsync(type.GetProperty("Id").GetValue(obj));
                            if (current == null)
                                return BasicResponse.FailureResult("Original record not found.");
                            set.Remove(current);
                            break;

                        case AuditType.List:
                        case AuditType.Authorize:
                        case AuditType.View:
                        default:
                            return BasicResponse.FailureResult("Invalid authorization request.");
                    }
                }
                catch (Exception e)
                { }
            }
            try
            {
                await Db.SaveChangesAsync();
                return BasicResponse.SuccessResult("Successfully authorized record.");
            }
            catch (Exception e)
            {
                // Logger.LogError(e);
                return BasicResponse.FailureResult(e.InnerMostMessage());
            }
        }
    }
}
