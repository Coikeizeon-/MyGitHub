using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// 加
    /// </summary>
    [Opt("+")]
    public abstract class AddExpression : Expression
    {
        /// <summary>
        /// 获取结果值
        /// </summary>
        /// <returns></returns>
        public override double GetValue()
        {
            return base.leftValue + base.rightValue;
        }

    }
    /// <summary>
    /// 减
    /// </summary>
    [Opt("-")]
    public abstract class MinusExpression : Expression
    {
        /// <summary>
        /// 获取结果值
        /// </summary>
        /// <returns></returns>
        public override double GetValue()
        {
            return base.leftValue - base.rightValue;
        }

    }
    /// <summary>
    /// 乘
    /// </summary>
    [Opt("*")]
    public abstract class MutiplyExpression : Expression
    {
        /// <summary>
        /// 获取结果值
        /// </summary>
        /// <returns></returns>
        public override double GetValue()
        {
            return base.leftValue * base.rightValue;
        }

    }
    /// <summary>
    /// 除
    /// </summary>
    [Opt("/")]
    public abstract class DivideExpression : Expression
    {
        /// <summary>
        /// 获取结果值
        /// </summary>
        /// <returns></returns>
        public override double GetValue()
        {
            if (base.rightValue == 0)
            {
                return 0;
            }
            return base.leftValue / base.rightValue;
        }

    }
}
