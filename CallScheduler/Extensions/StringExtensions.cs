using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CallScheduler.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidPhone(this string phone) => Regex.IsMatch(phone ?? string.Empty, "^\\d{6,13}$");
        public static int? ToInt(this string text)
        {
            if (text == null) return null;
            var match = Regex.Match(text, @"[0-9]*");
            if (string.IsNullOrWhiteSpace(match.Value))
                return null;
            return int.Parse(match.Value);
        }
        public static long? ToLong(this string text)
        {
            if (text == null) return null;
            var match = Regex.Match(text, @"[0-9]*");
            if (string.IsNullOrWhiteSpace(match.Value))
                return null;
            return long.Parse(match.Value);
        }
        public static decimal? ToDecimal(this string text)
        {
            decimal.TryParse(text, out var result);
            return result;
        }
        public static bool ToBool(this string text) => text.Equals("true", StringComparison.OrdinalIgnoreCase);

        public static string Hash(this string text)
        {
            //using (var md5Hash = MD5.Create())
            //{
            //    var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
            //    var sBuilder = new StringBuilder();
            //    foreach (var t in data)
            //        sBuilder.Append(t.ToString("x2"));
            //    return sBuilder.ToString();
            //}
            return text.Hash(MD5.Create());
        }
        public static string Hash512(this string text)
        {
            //using (var algorithm = SHA512.Create())
            //{
            //    var data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            //    var sBuilder = new StringBuilder();
            //    foreach (var t in data)
            //        sBuilder.Append(t.ToString("x2"));
            //    return sBuilder.ToString();
            //}
            return text.Hash(SHA512.Create());
        }

        public static string Hash(this string text, HashAlgorithm algo)
        {
            using (var algorithm = algo)
            {
                var data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
                var sBuilder = new StringBuilder();
                foreach (var t in data)
                    sBuilder.Append(t.ToString("x2"));
                return sBuilder.ToString();
            }
        }
        // public static string GenerateCode(this string text, int length = 6) => Utils.GenerateCode(length);
        public static string Capitalize(this string text) => text.ToUpper()[0] + text.Substring(1).ToLower();
        public static bool IsValidEmail(this string text) => Utils.EmailRegex.Match(text).Length > 0;
        public static bool IsSame(this string text, string str) => text?.Trim()?.ToLower() == str?.Trim()?.ToLower();
        public static string InnerTrim(this string text) => Regex.Replace($"{text}", @"\s+", " ").Trim();
        public static string InnerTrimNoSpace(this string text) => Regex.Replace($"{text}", @"\s+", string.Empty).Trim();
        public static string Last(this string text, int size)
        {
            if (text.Length < size) throw new IndexOutOfRangeException("Size cannot be less than string length");
            return text.Substring(text.Length - size, size);
        }
        public static string First(this string text, int size)
        {
            if (text.Length < size) return text;
            return text.Substring(0, size);
        }

        public static void ExtractTime(this string time, out int hour, out int minute)
        {
            hour = minute = 0;
            if (string.IsNullOrWhiteSpace(time)) return;

            var splits = time.Split(':');
            if (splits.Length > 1)
            {
                hour = splits[0].ToInt() ?? 0;
                minute = splits[1].ToInt() ?? 0;
            }
            else hour = time.ToInt() ?? 0;
            if (hour < 0 || hour > 23) hour = (int)((uint)hour % 24);
            if (minute < 0 || minute > 59) minute = (int)((uint)minute % 60);
        }

        public static string SanitizePhone(this string phone)
        {
            phone = Regex
                .Replace($"{phone}", @"\s+", string.Empty);
            phone = Regex
                .Replace($"{phone}", @"\(", string.Empty);
            phone = Regex
                .Replace($"{phone}", @"\)", string.Empty);
            phone = phone.Trim();
            if (phone.StartsWith("+") || phone.StartsWith("0"))
                phone = phone.Remove(0, 1);
            if (phone.StartsWith("234"))
                phone = phone.Remove(0, 3);
            if (phone.Length > 10)
                phone = phone.Last(10);
            return (phone.Length > 10 ? phone.Last(10) : phone).PadLeft(11, '0');
        }
        public static string TrimAndSanitizePhone(this string phone) => phone.Trim().SanitizePhone();

        public static string Sanitize(this string text) => text?.Trim() == "null" ? null : text?.Trim();
        public static string SanitizeXml(this string text) => text.Replace("&", "@:@");
        public static string UnSanitizeXml(this string text) => text.Replace("@:@", "&");
        public static string Mask(this string text, int start, int length, char mask) =>
            text.Substring(0, start) + "".PadRight(length, mask) +
            text.Substring(start + length, text.Length - (start + length));
        // public static string MaskSensitiveInfo(this string text, char mask = '*') => Utils.SensitiveRegex.Aggregate(text, (current, regex) => current.Mask(regex, mask));

        public static string Mask(this string text, Regex regex, char mask = '*') => regex.Replace(text, match =>
        {
            var group = match.Groups[1];
            var length = @group.Value.Length;
            if (length == 0) return match.Value;
            if (length > 12) length = 12;
            return match.Value.Replace(@group.Value, string.Empty.PadRight(length, mask));
        });

        public static string AsNullIfEmpty(this string text) => string.IsNullOrWhiteSpace(text) ? null : text;

        /// <summary>Searches the specified input string for the first occurrence of the specified regular expression.</summary>
        /// <returns>The first match of the specfied regular expression.</returns>
        /// <param name="text">The string to search for a match. </param>
        /// <param name="pattern">The regular expression pattern to match. </param>
        /// <exception cref="T:System.ArgumentException">A regular expression parsing error occurred.</exception>
        /// <exception cref="T:System.ArgumentNullException">
        /// <paramref name="text" /> or <paramref name="pattern" /> is null.</exception>
        /// <exception cref="T:System.Text.RegularExpressions.RegexMatchTimeoutException">A time-out occurred. For more information about time-outs, see the Remarks section.</exception>
        public static string Extract(this string text, string pattern)
        {
            if (text == null) return null;
            var match = Regex.Match(text, pattern);
            return match.Value;
        }

        // public static string EncryptText(this string text, WordArray key) => Cryptography.TripleDES.Encrypt<NoPadding, ECB>(text, key, null);
        // public static string DecryptText(this string text, WordArray key) => Cryptography.TripleDES.Decrypt<NoPadding, ECB>(text, key, null);

        public static string Encode(this string text) => string.IsNullOrWhiteSpace(text) ? null : System.Web.HttpUtility.HtmlEncode(text);

        //public static string Populate(this string template, Dictionary<string, string> dict)
        //{
        //    var matches = Regex.Matches(template, "{{([A-Za-z0-9]+)}}");
        //    var msg = template;
        //    try
        //    {
        //        foreach (Match match in matches)
        //        {
        //            var property = match.Groups[1].ToString();
        //            var val = dict.GetValue(property) ?? string.Empty;
        //            msg = msg.Replace(match.Value, val);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //        WaterMe.Providers.Logger.LogError(e);
        //        throw;
        //    }
        //    return msg;
        //}
        public static string Populate(this string template, object obj)
        {
            var matches = Regex.Matches(template, "{{([A-Za-z0-9]+)}}");
            var type = obj.GetType();
            var msg = template;
            try
            {
                foreach (Match match in matches)
                {
                    var property = match.Value.Replace("{{", "").Replace("}}", "");
                    var val = string.Empty;
                    try { val = type.GetProperty(property)?.GetValue(obj).ToString(); } catch { }
                    msg = msg.Replace(match.Value, val);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return msg;
        }
    }

}
