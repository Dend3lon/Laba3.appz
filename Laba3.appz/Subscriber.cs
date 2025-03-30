using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class Subscriber
    {
        private readonly List<Device> _list;

        public Subscriber()
        {
            _list = new List<Device>();
        }

        public void AddSub(Device device)
        {
            _list.Add(device);

            device.OnStateChange += HandleShapeChanged;
        }

        private void HandleShapeChanged(string msg)
        {
            Console.WriteLine("Підписник отримав сповіщення про: " + msg);
            Console.ReadLine();
        }
    }
}
