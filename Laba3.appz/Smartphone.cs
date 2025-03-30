using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class Smartphone : Device
    {
        public Battery Battery;
        public Smartphone(string name, bool isPowered, bool isSoftwareInstalled, bool isNetworkConnected, bool hasHeadphones, int battery)
            : base(name, isPowered, isSoftwareInstalled, isNetworkConnected, hasHeadphones)
        {
            Battery = new Battery(battery);
        }

        public override void Use(List<string> actions)
        {
            int workingHours = Battery.CalcHours();
            if (!actions.All(CheckRequirements)) return;

            if (!IsPowered)
            {
                Battery.ConsumeCharge(actions);
                if (Battery.GetRemainingHours() < 0) return;
            }

            Console.WriteLine($"{Name} виконує дії: {string.Join(", ", actions)}");
            Console.ReadLine();
        }

        public override void DisplayDeviceInfo()
        {
            Console.WriteLine($"Пристрій: {Name}\nПідключено до електромережі: {IsPowered}\nПЗ встановлено: {IsSoftwareInstalled}\nПідключення до мережі: {IsNetworkConnected}\nГарнітура: {HasHeadphones}\nРобочих годин: {Battery.GetRemainingHours()}");
        }
    }
}
