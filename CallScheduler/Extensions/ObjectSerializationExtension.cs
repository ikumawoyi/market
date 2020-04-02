using CallScheduler.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace CallScheduler.Extensions
{
    public static class ObjectSerializationExtension
    {
        public static string Stringify(this object any) => JsonConvert.SerializeObject(any);
        public static string SensitiveStringify(this object obj) =>
            JsonConvert.SerializeObject(obj, new JsonSerializerSettings { ContractResolver = new JsonPropertiesResolver() });
        public static TOut Parse<TOut>(this string any) =>
            JsonConvert.DeserializeObject<TOut>(any, new JsonSerializerSettings
            {
                Error = delegate (object sender, ErrorEventArgs args)
                {
                    // Logger.LogInfo($"{args.ErrorContext.Error.Message}");
                    args.ErrorContext.Handled = true;
                },
                Converters = { new IsoDateTimeConverter() }
            });
        public static Dictionary<string, string> ToDictionary(this object any) => any.Stringify().Parse<Dictionary<string, string>>();
    }

}
