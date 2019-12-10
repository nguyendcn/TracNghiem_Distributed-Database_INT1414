using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TracNghiem_CSDLPT.Share;

namespace TestFunc
{
    class Program
    {
        static void Main(string[] args)
        {

            //object a = ErrorCode.GetPropertyValue("Ox0001");
            //System.Console.Out.WriteLine("Data: " + a.ToString());

            Type type = typeof(ErrorCode);


            foreach (var p in type.GetFields())
            {
                Debug.WriteLine("Code: " + p.Name);

                if (p.Name.Equals("Ox0001"))
                    Debug.WriteLine("Data: " + p.GetValue(null));
                
            }

            Console.ReadLine();

        }
    }
}
