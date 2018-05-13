using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class ExpressionHandle
    {
        private List<Expression> expressionList = new List<Expression>();
        public ExpressionHandle Add(Expression exp)
        {
            expressionList.Add(exp);
            return this;
        }

        /// <summary>
        /// 处理表达式
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static double processExpression(string exp)
        {
            double resValue = 0;
            if (string.IsNullOrEmpty(exp)) return 0;
            exp = exp.Replace(" ", string.Empty);
            int bracketIndex = exp.IndexOf("[");
            if (bracketIndex >= 0)//存在中括号
            {
                if (bracketIndex == 0)//中括号在左边
                {
                    int secondBracketIndex = exp.IndexOf("]", 1);  //###bug...
                    if (secondBracketIndex == exp.Length - 1)//表达式包含在一个中括号中
                    {
                        return processExpression(exp.Substring(1, exp.Length - 2));
                    }
                    else
                    {
                        resValue = processExpression(exp.Substring(0, secondBracketIndex + 1));
                        string leftExp = exp.Substring(secondBracketIndex + 1, exp.Length - secondBracketIndex - 1);
                        string opt = leftExp.First().ToString();
                        if (optList.Keys.Contains(opt))//是否是运算符
                        {
                            leftExp = leftExp.Substring(1, leftExp.Length - 1);
                            Expression expObj = (Expression)Activator.CreateInstance(optList[opt], true);
                            resValue = expObj.SetValue(resValue, processExpression(leftExp)).GetValue();
                        }
                    }
                }
                else//中括号在左边
                {

                }
            }
            else//不存在中括号
            {

            }
            return resValue;
        }
        private static Dictionary<string,Type> optList = new Dictionary<string, Type>();
        /// <summary>
        /// 获取所有运算符
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Type> GetOptList()
        {
            if (optList.Count > 0)
            {
                return optList;
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(Expression));
            if (assembly == null)
            {
                return optList;
            }
            //取出所有类型集合
            Type[] types = assembly.GetTypes();
            if (types == null || types.Length < 1)
            {
                return optList;
            }
            foreach (var t in types)
            {
                var optAttr = Attribute.GetCustomAttribute(t, typeof(OptAttribute));
                if (optAttr == null)
                {
                    continue;
                }
                optList.Add(((OptAttribute)optAttr).opt,t);
            }
            return optList;
        }
    }
}
