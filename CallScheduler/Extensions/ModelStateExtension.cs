using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CallScheduler.Extensions
{
    public static class ModelStateExtension
    {
        public static string GetModelErrors(this ModelStateDictionary model)
        {
            return model.Select(x => x.Value).SelectMany(x => x.Errors).
                Aggregate("", (s, e) => $"{s} {e.Exception?.Message ?? e.ErrorMessage}").Trim();
        }
    }
}