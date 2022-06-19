using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace RegExpTraining
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var xdoc = new XmlDocument();
            xdoc.Load(args[0]);
            var regexp = new Regex(xdoc.GetElementsByTagName("regtext").Item(0).InnerText, RegexOptions.IgnoreCase);

            Cwl("Начинаем разбор", 0);
            foreach(var rg in regexp.Matches(xdoc.GetElementsByTagName("testtext").Item(0).InnerText).Cast<Match>())
            {
                Cwl(rg, 1);
                foreach(var g in rg.Groups)
                {
                    Cwl(g, 2);
                }
            }
            Cwl("Разбор закончен", 0);
            Console.ReadLine();
        }

        static void Cwl(object o, int l)
        {
            var l1 = l;
            while (l1 > 0)
            {
                Console.Write("-");
                l1--;
            }
            Console.WriteLine((l > 0 ? "> " : string.Empty) + o.ToString() + Environment.NewLine);
        }
    }
}
