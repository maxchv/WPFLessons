using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    class TextConverter
    {
        private Func<string, string> _converter;

        public TextConverter(Func<string, string> conveter)
        {
            _converter = conveter;
        }

        public string ConvertText(string inputText)
        {
            return _converter(inputText);
        }
    }
}
