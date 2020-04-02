using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CallScheduler.Helpers
{
    public class JsonPropertiesResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            //Return properties that aren't sensitive
            return objectType.GetRuntimeProperties()
                .Where(pi => !Utils.SensitiveProperties.Contains(pi.Name))
                .ToList<MemberInfo>();
        }
    }
}
