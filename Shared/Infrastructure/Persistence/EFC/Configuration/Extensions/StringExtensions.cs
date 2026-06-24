using Humanizer;

namespace Pc27414u202319440.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

/// <summary>
/// String extensions for persistence naming conventions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string to snake case.
    /// </summary>
    /// <param name="text">The string to convert.</param>
    /// <returns>The snake case representation.</returns>
    public static string ToSnakeCase(this string text)
    {
        return new string(Convert(text.GetEnumerator()).ToArray());

        static IEnumerable<char> Convert(CharEnumerator enumerator)
        {
            if (!enumerator.MoveNext()) yield break;

            yield return char.ToLower(enumerator.Current);

            while (enumerator.MoveNext())
            {
                if (char.IsUpper(enumerator.Current))
                {
                    yield return '_';
                    yield return char.ToLower(enumerator.Current);
                }
                else
                {
                    yield return enumerator.Current;
                }
            }
        }
    }

    /// <summary>
    /// Pluralizes a string.
    /// </summary>
    /// <param name="text">The string to pluralize.</param>
    /// <returns>The pluralized string.</returns>
    public static string ToPlural(this string text) => text.Pluralize(false);
}
