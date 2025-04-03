using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class ComputerFactory : DeviceFactory
    {
        public override Device CreateDevice()
        {
            Console.Write("Введіть назву комп'ютера: ");
            string name = Console.ReadLine();
            Console.Write("Підключено до енергоживлення? (true/false): ");
            bool powered = bool.Parse(Console.ReadLine());
            Console.Write("ПЗ встановлено? (true/false): ");
            bool software = bool.Parse(Console.ReadLine());
            Console.Write("Підключення до мережі? (true/false): ");
            bool network = bool.Parse(Console.ReadLine());
            Console.Write("Є гарнітура? (true/false): ");
            bool headphones = bool.Parse(Console.ReadLine());

            return new Computer(name, powered, software, network, headphones);
        }
    }
}
