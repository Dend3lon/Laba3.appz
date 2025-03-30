using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public abstract class Device
    {
        public string Name { get; set; }
        public bool IsPowered { get; set; }
        public bool IsSoftwareInstalled { get; set; }
        public bool IsNetworkConnected { get; set; }
        public bool HasHeadphones { get; set; }

        protected Device(string name, bool isPowered, bool isSoftwareInstalled, bool isNetworkConnected, bool hasHeadphones)
        {
            Name = name;
            IsPowered = isPowered;
            IsSoftwareInstalled = isSoftwareInstalled;
            IsNetworkConnected = isNetworkConnected;
            HasHeadphones = hasHeadphones;
        }

        public event Action<string> OnStateChange;
        public void ConnectPower()
        {
            IsPowered = true;
            OnStateChange?.Invoke($"{Name} підключено до енергомережі.");
        }
        public void DisconnectPower()
        {
            IsPowered = false;
            OnStateChange?.Invoke($"{Name} відключено від енергомережі.");
        }
        public void IntstallSoftware()
        {
            IsSoftwareInstalled = true;
            OnStateChange?.Invoke($"На {Name} встановлено програмне забезпечення.");
        }

        public void DeleteSoftware()
        {
            IsSoftwareInstalled = false;
            OnStateChange?.Invoke($"З {Name} видалено програмне забезпечення.");
        }

        public void ConnectNetwork()
        {
            IsNetworkConnected = true;
            OnStateChange?.Invoke($"До {Name} підключено мережу інтернет.");
        }
        public void DisconnetNetwork()
        {
            IsNetworkConnected = false;
            OnStateChange?.Invoke($"Від {Name} відключено мережу інтернет.");
        }
        public void СonnectHeadphone()
        {
            HasHeadphones = true;
            OnStateChange?.Invoke($"До {Name} підключено звукову гарнітуру.");
        }
        public void DisconnectHeadphone()
        {
            HasHeadphones = false;
            OnStateChange?.Invoke($"Від {Name} відключено звукову гарнітуру.");
        }

        protected bool CheckRequirements(string action)
        {
            if (action == "work" && !IsSoftwareInstalled)
            {
                Console.WriteLine("Неможливо працювати без встановленого ПЗ!");
                Console.ReadLine();
                return false;
            }
            if (action == "play" && (!IsSoftwareInstalled || !IsNetworkConnected))
            {
                Console.WriteLine("Неможливо зіграти в гру без необхідного ПЗ та підключення до мережі!");
                Console.ReadLine();
                return false;
            }
            if (action == "video" && (!IsNetworkConnected || !HasHeadphones))
            {
                Console.WriteLine("Неможливо переглянути відео без ПЗ, мережі та гарнітури!");
                Console.ReadLine();
                return false;
            }
            if (action == "audio" && !HasHeadphones)
            {
                Console.WriteLine("Неможливо слухати музику без гарнітури!");
                Console.ReadLine();
                return false;
            }
            return true;
        }
        public abstract void Use(List<string> actions);

        public abstract void DisplayDeviceInfo();
    }
}
