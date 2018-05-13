using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 表达式
    /// </summary>
    public   class Expression
    {
        protected string opt
        {
            get
            {
                var optAttr= Attribute.GetCustomAttribute(this.GetType(), typeof(OptAttribute));
                if (optAttr == null)
                {
                    return string.Empty;
                }
               return  ((OptAttribute)optAttr).opt;
            }
        }
        private double _leftValue;
        public double leftValue
        {
            get
            {
                return _leftValue;
            }
            set
            {
                try
                {
                    _leftValue = Convert.ToDouble(value);
                }
                catch
                {
                    _leftValue = 0;
                }
            }
        }
        private double _rightValue;
        public double rightValue
        {
            get
            {
                return _rightValue;
            }
            set
            {
                try
                {
                    _rightValue = Convert.ToDouble(value);
                }
                catch
                {
                    _rightValue = 0;
                }
            }
        }
        public Expression() { }
        public Expression(double leftVal, double rightVal)
        {
            leftValue = leftVal;
            rightValue = rightVal;
        }
       
        public Expression SetValue(double leftVal, double rightVal)
        {
            leftValue = leftVal;
            rightValue = rightVal;
            return this;
        }
        /// <summary>
        /// 获取结果值
        /// </summary>
        /// <returns></returns>
        public virtual double GetValue()
        {
            return 0;
        }

    }
}
