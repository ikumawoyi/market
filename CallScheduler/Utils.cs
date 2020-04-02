using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CallScheduler
{
    public static class Utils
    {
        public static DbContextOptions<TContext> GetContextOption<TContext>() where TContext : DbContext =>
                 // new DbContextOptionsBuilder<TContext>().UseNpgsql(ConnectionString).Options;
                 new DbContextOptionsBuilder<TContext>().UseSqlServer(ConnectionString).Options;
        public static string ConnectionString { get; set; }

        public static string GetValue(this Dictionary<string, string> input, string key, bool caseInsensitiveKey = false) =>
        caseInsensitiveKey ? input.FirstOrDefault(x => x.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).Value :
        input.ContainsKey(key) ? input[key] : null;

        public static readonly string[] SensitiveProperties = { "Pin", "PIN", "Password", "NewPin", "NewPassword" };
        private const string Txt = "1234567890";
        public static string GenerateCode(int length)
        {
            var code = "";
            var rand = new Random();

            while (code.Length < length)
            {
                var t = rand.Next(0, Txt.Length - 1);
                code += Txt[t];
                if (code == "0") code = "";
            }
            return code;
        }

        public static int GetPages<TInput>(IQueryable<TInput> query, int pageSize) where TInput : class
        {
            int numberOfPages = query.Count() / pageSize;
            int remainder = query.Count() % pageSize;
            if (remainder > 0)
            {
                numberOfPages++;
            }

            return numberOfPages;
        }

        private const string Pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        public const RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
        public static readonly Regex EmailRegex = new Regex(Pattern, Options);
    }
}
