using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class Computer : Device
    {
        public Computer(string name, bool isPowered, bool isSoftwareInstalled, bool isNetworkConnected, bool hasHeadphones)
            : base(name, isPowered, isSoftwareInstalled, isNetworkConnected, hasHeadphones) { }

        public override void Use(List<string> actions)
        {
            if (!actions.All(CheckRequirements)) return;
            if (IsPowered) return;

            Console.WriteLine($"{Name}  виконує дії: {string.Join(", ", actions)}");
            Console.ReadLine();
        }

        public override void DisplayDeviceInfo()
        {
            Console.WriteLine($"Пристрій: {Name}\nПідключено до електромережі: {IsPowered}\nПЗ встановлено: {IsSoftwareInstalled}\nПідключення до мережі: {IsNetworkConnected}\nГарнітура: {HasHeadphones}");
        }
    }
}
