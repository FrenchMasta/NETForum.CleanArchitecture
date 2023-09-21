using System.ComponentModel;

namespace Domain.Helpers;

public static class EnumHelper
{
    public static string GetEnumDescription(Enum value)
    {
        var fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo == null)
        {
            return string.Empty;
        }

        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString();
    }

    public static T GetEnumValueFromDescription<T>(string description) where T : Enum
    {
        foreach (T enumValue in Enum.GetValues(typeof(T)))
        {
            if (GetEnumDescription(enumValue) == description)
            {
                return enumValue;
            }
        }

        throw new ArgumentException($"Enum value with description '{description}' not found.");
    }
}