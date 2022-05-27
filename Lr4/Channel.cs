using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr4
{
    public class Channel
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public List<EventArgs> Events;

        public delegate void Notification(object sender, EventArgs args);

        public Notification GetNotification;

        public int EventFrequency;

        public void Start()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if(DateTime.Now.Second % EventFrequency == 0)
                    {
                        int result = new Random().Next() % this.Events.Count;
                        if(GetNotification != null)
                        {
                            GetNotification(this, Events[result]);
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            });
        }
    }
}
