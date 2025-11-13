using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DisplayResume.Models.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            FieldInfo? field = enumValue.GetType().GetField(enumValue.ToString());
            DisplayAttribute? attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? enumValue.ToString();
        }

        public static string GetDisplayShortName(this Enum enumValue)
        {
            FieldInfo? field = enumValue.GetType().GetField(enumValue.ToString());
            DisplayAttribute? attribute = field?.GetCustomAttribute<DisplayAttribute>();
            return attribute?.ShortName ?? enumValue.ToString();
        }

    }
}
