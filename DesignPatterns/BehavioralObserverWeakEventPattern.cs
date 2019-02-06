using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BehavioralObserverWeakEventPattern
{
    // an event subscription can lead to a memory 
    // leak if you hold on to it past the object's
    // lifetime

    // weak events help with this

    public class Button
    {
        public event EventHandler Clicked;

        public void Fire()
        {
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Window
    {
        public Window(Button button)
        {
            button.Clicked += ButtonOnClicked;
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button clicked (Window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }

    public class Window2
    {
        public Window2(Button button)
        {
            WeakEventManager<Button, EventArgs>.AddHandler(button, "Clicked", ButtonOnClicked);
        }

        private void ButtonOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Button clicked (Window 2 Handler)");
        }

        ~Window2()
        {
            Console.WriteLine("Window 2 finalized");
        }
    }

    public class Demo
    {
        //public static void Main(string[] args)
        //{
        //    var btn = new Button();
        //    var window = new Window2(btn);
        //    var windowRef = new WeakReference(window);

        //    btn.Fire();

        //    Console.WriteLine("Setting window to null");
        //    window = null;

        //    FireGC();
        //    Console.WriteLine($"Is window alive after GC? {windowRef.IsAlive}");

        //    btn.Fire();

        //    Console.WriteLine("Setting button to null");
        //    btn = null;

        //    FireGC();
        //}

        private static void FireGC()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("GC is done!");
        }
    }
}
