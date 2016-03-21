using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobiiEyexArrangeTool
{
    class Program
    {
        static void Main(string[] args)
        {
            TobiiEyexArrangeController controller = new TobiiEyexArrangeController();
            controller.StartTobiiEyex();
            while (true)
            {
                Console.WriteLine(controller.x + "," + controller.y);
            }
        }
    }
}
