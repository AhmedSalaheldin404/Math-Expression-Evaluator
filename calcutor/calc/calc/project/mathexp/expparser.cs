 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc.project.mathexp
{
    public static class expparser
    {
        private const string mathsymbols = "+%^*/%";
       
        public static  math parse(string input)
        {
            input = input.Trim();
            var expr = new math();
            string token = "";
            bool leftsideinitialized=false;
            for (var i = 0; i < input.Length; i++) {
                var currentchar = input[i];
                if (char.IsDigit(currentchar))
                {
                    token += currentchar;
                    if (i==input.Length-1 && leftsideinitialized) {
                        expr.rightsideop = double.Parse(token);
                        break;
                    }
                }
                else if (mathsymbols.Contains(currentchar))
                {
                    if (!leftsideinitialized)
                    {
                        expr.leftsideop = double.Parse(token);
                        leftsideinitialized = true;
                        
                    }
                    expr.mathoperation = parsemathoperation(currentchar.ToString());
                    token = "";
                }
                else if (currentchar == '-' && i>0)
                {
                    if (expr.mathoperation == mathoperation.None)
                    {
                        expr.mathoperation=mathoperation.subtract;
                        expr.leftsideop = double.Parse(token);
                        leftsideinitialized = true;
                        token ="";
                    }
                    else
                        token += currentchar;

                }
                else if (char.IsLetter(currentchar))
                {
                    token += currentchar;
                    leftsideinitialized = true;
                }
                else if (currentchar == ' ')
                {
                    if (!leftsideinitialized)
                    {
                        expr.leftsideop = double.Parse(token);
                        leftsideinitialized=true;
                        token = "";

                    }
                    else if (expr.mathoperation == mathoperation.None)
                    {
                        expr.mathoperation = parsemathoperation(token);
                        token = "";

                    }
                }
                else
                    token += currentchar;
            }
                return expr;
        }

        private static mathoperation parsemathoperation(string token)
        {
            switch (token.ToLower()) {
                case "+":
                    return mathoperation.addition;
                    case "-":
                    return mathoperation.subtract;
                    case "*":
                    return mathoperation.multiply;
                    case "/": return mathoperation.divide;
                    case "%":
                case "mod":
                    return mathoperation.modulus;
                case "pow":
                case "^":
                    return mathoperation.power;
                case "sin":
                    return mathoperation.sin;
                case "cos":
                    return mathoperation.cos;
                case "tan":
                    return mathoperation.tan;
                    default:
                    return mathoperation.None;



            }
        }
    }
}
