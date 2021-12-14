using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5
{
    public class Printer
    {

        public void IAmPrinting(Program.Cheque obj)
        {
            Console.WriteLine(obj.ToString());
        }
        public void IAmPrinting(Program.Receqipt obj)
        {
            Console.WriteLine(obj.ToString());
        }
        public void IAmPrinting(Program.Waybill obj)
        {
            Console.WriteLine(obj.ToString());
        }
        public void IAmPrinting(Printer obj)
        {
            Console.WriteLine(obj.ToString());
        }

    }
}
