using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExe.Enum
{
    public static class EnumExtension
    {
        [AttributeUsage(AttributeTargets.Field)]
        public sealed class CodeAttribute : Attribute
        {
            public CodeAttribute(string code)
            {
                Code = code;
            }

            public string Code = "";
        }


        [AttributeUsage(AttributeTargets.Field)]
        public sealed class DescriptionEnAttribute : Attribute
        {
            public DescriptionEnAttribute(string descriptionEn)
            {
                DescriptionEn = descriptionEn;
            }

            public string DescriptionEn = "";
        }


        [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
        public sealed class AbbreviationAttribute : Attribute
        {
            public AbbreviationAttribute(string abbreviation)
            {
                this.Abbreviation = abbreviation;
            }

            public string Abbreviation = "";
        }


        public static string GetCode(this System.Enum value)
        {
            return value.GetAttribute<CodeAttribute>()?.Code
               ?? value.ToString();
        }

        public static string GetDescription(this System.Enum value)
        {
            return value.GetAttribute<DescriptionAttribute>()?.Description
               ?? value.ToString();
        }

        private static TAttribute GetAttribute<TAttribute>(this System.Enum value) where TAttribute : Attribute
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes
                = fieldInfo.GetCustomAttributes(typeof(TAttribute), false)
                    .Cast<TAttribute>();
            if ((attributes?.Count() ?? 0) <= 0)
                return null;
            return attributes.First();
        }

    }
}
