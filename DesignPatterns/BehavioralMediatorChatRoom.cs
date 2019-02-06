using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralMediatorChatRoom
{
    public class Person
    {
        public string Name { get; set; }
        public ChatRoom Room { get; set; }
        private List<string> chatLog = new List<string>();

        public Person(string name)
        {
            Name = name;
        }

        public void Receive(string sender, string message)
        {
            string s = $"{sender}: {message}";
            Console.WriteLine($"[{Name}'s chat session] {s}");
            chatLog.Add(s);
        }

        public void Say(string message)
        {
            Room.Broadcast(Name, message);
        }

        public void PrivateMessage(string who, string message)
        {
            Room.Message(Name, who, message);
        }
    }

    public class ChatRoom
    {
        private List<Person> people = new List<Person>();

        public void Broadcast(string source, string message)
        {
            foreach(var p in people)
            {
                if(p.Name != source)
                {
                    p.Receive(source, message);
                }
            }
        }

        public void Join(Person p)
        {
            string joinMsg = $"{p.Name} joins the chat";
            Broadcast("room", joinMsg);

            p.Room = this;
            people.Add(p);
        }

        public void Message(string source, string destination, string message)
        {
            people.FirstOrDefault(p => p.Name == destination)?.Receive(source, message);
        }
    }

    public class Demo
    {
        //public static void Main(string[] args)
        //{
        //    var room = new ChatRoom();

        //    var john = new Person("John");
        //    var jane = new Person("Jane");

        //    room.Join(john);
        //    room.Join(jane);

        //    var simon = new Person("Simon");
        //    room.Join(simon);
        //    simon.Say("Hi Everyone!");

        //    jane.PrivateMessage("Simon", "Glad you could join us!");
        //}
    }
}
