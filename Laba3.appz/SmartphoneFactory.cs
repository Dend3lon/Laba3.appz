using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class SmartphoneFactory : DeviceFactory
    {
        public override Device CreateDevice()
        {
            Console.Write("Введіть назву смартфона: ");
            string name = Console.ReadLine();
            Console.Write("Підключено до енергоживлення? (true/false): ");
            bool powered = bool.Parse(Console.ReadLine());
            Console.Write("ПЗ встановлено? (true/false): ");
            bool software = bool.Parse(Console.ReadLine());
            Console.Write("Підключення до мережі? (true/false): ");
            bool network = bool.Parse(Console.ReadLine());
            Console.Write("Є гарнітура? (true/false): ");
            bool headphones = bool.Parse(Console.ReadLine());
            Console.Write("Заряд батареї: ");
            int battery = int.Parse(Console.ReadLine());

            return new Smartphone(name, powered, software, network, headphones, battery);
        }
    }
}
