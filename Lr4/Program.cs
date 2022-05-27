using System;
using System.Collections.Generic;

namespace Lr4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var channels = CreateChannels();
            foreach (var item in channels)
                item.Start();
            while (true)
            {
                PrintMenu();
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        {
                            for(int i = 0; i < channels.Count; i++)
                            {
                                Console.WriteLine($"\t{i + 1}) {channels[i].Description}\n");
                            }
                            while (true)
                            {
                                int result;
                                if(!int.TryParse(Console.ReadLine(),out result))
                                {
                                    Console.WriteLine("Повторите ввод заного.\n");
                                    continue;
                                }
                                if(result < 1 || result > channels.Count)
                                {
                                    Console.WriteLine("Укажите доступный канал\n");
                                    continue;
                                }
                                channels[result - 1].GetNotification += EventHandler;
                                break;
                            }
                            break;
                        }
                    case "2":
                        {
                            for (int i = 0; i < channels.Count; i++)
                            {
                                Console.WriteLine($"\t{i + 1}) {channels[i].Description}\n");
                            }
                            while (true)
                            {
                                int result;
                                if (!int.TryParse(Console.ReadLine(), out result))
                                {
                                    Console.WriteLine("Повторите ввод заного.\n");
                                    continue;
                                }
                                if (result < 1 || result > channels.Count)
                                {
                                    Console.WriteLine("Укажите доступный канал\n");
                                    continue;
                                }
                                channels[result - 1].GetNotification -= EventHandler;
                                break;
                            }
                            break;
                        }
                    case "3":
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("1) Подписаться на канал");
            Console.WriteLine("2) Отписаться от канала");
            Console.WriteLine("3) Выход");
        }

        static List<Channel> CreateChannels()
        {
            List<Channel> channels = new List<Channel>()
            {
                new Channel()
                {
                    ID = 12354312,
                    Description = "Новости спорта",
                    EventFrequency = 5,
                    Events = new List<EventArgs>()
                    {
                        new EventArgs()
                        {
                            EventID = 34525324,
                            Description = "Соревнования по плаванию",
                            Message = "В Москве 22.08.22 пройдёт открытый чемпионат Москвы."
                        },
                        new EventArgs()
                        {
                            EventID = 12321321,
                            Description = "Наша Сборная",
                            Message = "Сборная по лёгкой атлетике проведёт подготовку к чемпионату мира в Италии."
                        },
                        new EventArgs()
                        {
                            EventID = 213424,
                            Description = "Футбол",
                            Message = "Валерий Карпин назначен новым тренером сборной России по футболу"
                        }
                    }
                },
                new Channel()
                {
                    ID = 14253453,
                    Description = "Местные новости",
                    EventFrequency = 10,
                    Events = new List<EventArgs>()
                    {
                        new EventArgs()
                        {
                            EventID = 12313,
                            Description = "Дороги",
                            Message = "В Ивановском районе заменят 100км дорог."
                        },
                        new EventArgs()
                        {
                            EventID = 2144535,
                            Description = "ЖКХ",
                            Message = "Тарифы на газ будут действовать до конца года."
                        }
                    }
                }
            };
            return channels;
        }

        public static void EventHandler(object sender, EventArgs args)
        {
            Console.WriteLine($"Канал {(sender as Channel).Description} опубликовал Новость: {args.Description}\nСодержание: {args.Message}");
        }
    }
}
