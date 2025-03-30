using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    internal class Program
    {
        static List<Device> devices = new List<Device>();
        static void Main(string[] args)
        {
            var sub = new Subscriber();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Створити пристрій\n2. Редагувати пристрій\n3. Переглянути пристрої\n4. Використовувати пристрій\n5. Вийти");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateDevice();
                        foreach (var device in devices)
                            sub.AddSub(device);
                        break;
                    case "2":
                        EditDevice();
                        break;
                    case "3":
                        DeviceInfo();
                        break;
                    case "4":
                        UseDevice();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }
        static void CreateDevice()
        {
            Console.Clear();
            Console.Write("Тип (1 - ПК, 2 - Телефон): ");
            int type = int.Parse(Console.ReadLine());
            Console.Write("Введіть назву пристрою: ");
            string name = Console.ReadLine();
            Console.Write("Підключено до енергоживлення? (true/false): ");
            bool powered = bool.Parse(Console.ReadLine());
            Console.Write("ПЗ встановлено? (true/false): ");
            bool software = bool.Parse(Console.ReadLine());
            Console.Write("Підключення до мережі? (true/false): ");
            bool network = bool.Parse(Console.ReadLine());
            Console.Write("Є гарнітура? (true/false): ");
            bool headphones = bool.Parse(Console.ReadLine());
            if (type == 1)
                devices.Add(new Computer(name, powered, software, network, headphones));
            else if (type == 2)
            {
                Console.Write("Заряд батареї: ");
                int battery = int.Parse(Console.ReadLine());
                devices.Add(new Smartphone(name, powered, software, network, headphones, battery));
            }
            else { return; }
        }

        static void EditDevice()
        {
            Console.Clear();
            ViewDevices();
            Console.Write("Виберіть пристрій за номером: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index < 0 || index >= devices.Count) { Console.WriteLine("Пристрій не знайдено!"); return; }
            Console.Clear();
            Device device = devices[index];
            Console.WriteLine("1. Змінити назву\n2.Підключити до електромережі\n3.Відключити від електромережі" +
                "\n4.Завантажити ПЗ\n5.Видалити пз\n6.Підключитись до мережі\n7.Від'єднатись від мережі" +
                "\n8.Підключити гарнітуру\n9.Від'єднати гарнітуру");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Введіть нову назву: ");
                    device.Name = Console.ReadLine();
                    break;
                case "2":
                    device.ConnectPower();
                    break;
                case "3":
                    device.DisconnectPower();
                    break;
                case "4":
                    device.IntstallSoftware();
                    break;
                case "5":
                    device.DeleteSoftware();
                    break;
                case "6":
                    device.ConnectNetwork();
                    break;
                case "7":
                    device.DisconnetNetwork();
                    break;
                case "8":
                    device.СonnectHeadphone();
                    break;
                case "9":
                    device.DisconnectHeadphone();
                    break;
                default:
                    Console.WriteLine("Невірний вибір!");
                    break;
            }
        }

        static void DeviceInfo()
        {
            Console.Clear();
            ViewDevices();
            Console.Write("Виберіть пристрій за номером: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index < 0 || index >= devices.Count) { Console.WriteLine("Пристрій не знайдено!"); return; }
            Console.Clear();
            devices[index].DisplayDeviceInfo();
            Console.ReadLine();
        }
        static void UseDevice()
        {
            Console.Clear();
            ViewDevices();
            Console.Write("Виберіть пристрій за номером: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index < 0 || index >= devices.Count) { Console.WriteLine("Пристрій не знайдено!"); return; }
            Console.Clear();
            Console.WriteLine("Вибраний пристрій " + devices[index].Name);
            Console.Write("Введіть дії через кому (work/play/video/audio): ");
            List<string> actions = Console.ReadLine().Split(',').Select(a => a.Trim()).ToList();

            devices[index].Use(actions);
        }
        static void ViewDevices()
        {
            for (int i = 0; i < devices.Count; i++)
            {
                if (devices[i] is Smartphone)
                    Console.WriteLine($"{i + 1}. Телефон: {devices[i].Name} ");
                if (devices[i] is Computer)
                    Console.WriteLine($"{i + 1}. Комп'ютер: {devices[i].Name} ");
            }
        }
    }
}
