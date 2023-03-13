using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public char[] tokens = new char[] { ',', '\n' }; 
        
        public StringCalculator()
        {

        }

        public int Calculate(string arg)
        {
            int result = 0;

            if (IsEmptyString(arg))
                return result;
            
            if (TryParseOneNumber(arg, out result))
                return result;

            if (TryParseAndAdd(arg, out result))
                return result;

            return 0;
        }

        private bool IsEmptyString(string arg)
        {
            return arg.Equals("");
        }

        private bool TryParseOneNumber(string arg, out int result)
        {
            return int.TryParse(arg, out result);
        }

        private bool TryParseAndAdd(string arg, out int result)
        {
            result = 0;
            string[] components = Tokenize(arg);
            
            for (int i = 0; i < components.Length; ++i)
            {
                int component;
                bool isDoneComponent = int.TryParse(components[i], out component);
                if (isDoneComponent)
                {
                    if (component < 0) throw new Exception("Negative Number");
                    else if (component > 1000) continue;
                    else result += component;
                }
                else continue;
            }
            return true;
        }

        private string[] Tokenize(string arg) {

            List<char> tokensList = tokens.ToList();
            if (arg.Contains("//")) {
                tokensList.Add(arg[2]);
            }
            string[] components = arg.Split(tokensList.ToArray());
            return components;
        } 
    }
}
