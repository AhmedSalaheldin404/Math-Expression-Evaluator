using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc.project.mathexp.ConsoleApp
{
    public static class app
    {
        public static void Main(string[] args)  
        {
            while (true)
            {
                
                Console.WriteLine("enter math expression");
                var input = Console.ReadLine();
                var expr = expparser.parse(input);
                Console.WriteLine($"left side = {expr.leftsideop}, operation = {expr.mathoperation}, right side = {expr.rightsideop}");
                Console.WriteLine($"{input}={Evaluatedexpression(expr)}");
            }
        }

        private static object Evaluatedexpression(math expr)
        {
           if(expr.mathoperation==mathoperation.addition)
                return expr.leftsideop + expr.rightsideop;
           else if (expr.mathoperation==mathoperation.subtract)
                return expr.leftsideop - expr.rightsideop;
           else if (expr.mathoperation==mathoperation.sin)
                return Math.Sin(expr.rightsideop);
           else if ( expr.mathoperation==mathoperation.cos)
                   return Math.Cos(expr.rightsideop);
        else if (expr.mathoperation == mathoperation.tan)
                return Math.Tan(expr.rightsideop);
           else if (expr.mathoperation==mathoperation.divide)
                return expr.leftsideop / expr.rightsideop;
           else if (expr.mathoperation==mathoperation.modulus)
                return expr.leftsideop % expr.rightsideop;
           else if (expr.mathoperation== mathoperation.multiply)
                return expr.leftsideop * expr.rightsideop;
           else if (expr.mathoperation == mathoperation.power) 
                return Math.Pow(expr.leftsideop,expr.rightsideop);
            return 0;
    
        }
    }
}
