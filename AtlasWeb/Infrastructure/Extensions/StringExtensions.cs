using System;
using System.Linq;

namespace Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToLower(this string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException(nameof(input));
            return input.First().ToString().ToLowerInvariant() + String.Join(string.Empty, input.Skip(1));
        }
    }
}