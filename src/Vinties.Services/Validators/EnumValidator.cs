using System.ComponentModel;


namespace Vinties.Services.Validators
{
    public static class EnumValidator
    {
        private static string GetEnumDescription(this Enum enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                return attribute.Description;

            throw new ArgumentException("Not found enum");
        }

        public static string GetEnumValueByDescription<T>(this string description) where T : Enum
        {
            foreach (Enum enumItem in Enum.GetValues(typeof(T)))
            {
                if (enumItem.GetEnumDescription() == description)
                    return enumItem.GetEnumDescription();
            }
            return null ;
        }
    }
}
