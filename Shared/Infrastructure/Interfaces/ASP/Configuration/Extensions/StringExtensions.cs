using System.Text.RegularExpressions;

namespace Pc27414u202319440.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;

/// <summary>
/// String utility extensions for ASP.NET Core infrastructure.
/// </summary>
public static partial class StringExtensions
{
    /// <summary>
    /// Converts a PascalCase or camelCase string to kebab-case.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The kebab-case representation.</returns>
    public static string ToKebabCase(this string text)
    {
        if (string.IsNullOrEmpty(text)) return text;

        return KebabCaseRegex().Replace(text, "-$1")
            .Trim()
            .ToLowerInvariant();
    }

    [GeneratedRegex("(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", RegexOptions.Compiled)]
    private static partial Regex KebabCaseRegex();
}
