using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3.appz
{
    public class StateReporter : IObserver<string>
    {
        private IDisposable unsubscriber;
        private string instName;

        public StateReporter(string name)
        {
            this.instName = name;
        }
        public virtual void Subscribe(IObservable<string> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }

        public virtual void OnCompleted()
        {
        }

        public virtual void OnError(Exception e)
        {
        }

        public virtual void OnNext(string msg)
        {
            Console.WriteLine("Спостерігач: " + msg);
            Console.ReadLine();
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
    }
}
