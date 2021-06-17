using ProductVertificationDesktopApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductVertificationDesktopApp.Service
{
    public class RegularExpression: IRegularExpression
    {
        public string[] RegularExpression1(string s)
        {
            string[] k = new string[2];
            Regex re = new Regex(@"(?<data>\w+)");
            int i = 0;
            foreach (Match item in re.Matches(s)) 
            {
                Group group = item.Groups["data"];
                k[i] = group.Captures[0].Value;
                i++;
            };
            return k;
        }
    }

}
