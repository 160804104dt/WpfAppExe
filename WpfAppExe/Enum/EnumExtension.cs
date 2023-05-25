using System;
using System.Collections.Generic;
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
    }
}
