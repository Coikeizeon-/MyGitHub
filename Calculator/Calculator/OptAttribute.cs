using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 运算符
    /// </summary>
    public class OptAttribute : Attribute
    {
        public string opt { get; set; } 
        public OptAttribute(string optValue)
        {
            this.opt = optValue;
        }
    }
}
