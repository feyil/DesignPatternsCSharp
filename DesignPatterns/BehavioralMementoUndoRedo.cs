using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralMementoUndoRedo
{
    public class Memento
    {
        public int Balance { get; }

        public Memento(int balance)
        {
            Balance = balance;
        }
    }

    public class BankAccount
    {
        private int balance;
        private List<Memento> changes;
        private int current;

        public List<Memento> Changes // for testing purposes
        {
            get
            {
                return this.changes;
            }
        } 

        public int Current // for testing purposes
        {
            get
            {
                return this.current;
            }
        }

        public BankAccount(int balance)
        {
            this.balance = balance;
            changes = new List<Memento>();
            changes.Add(new Memento(balance));
        }

        public Memento Deposit(int amount)
        {
            balance += amount;
            var m = new Memento(balance);
            changes.Add(m);
            current = changes.Count - 1;
            return m;
        }

        public void Restore(Memento m)
        {
            if(m != null)
            {
                balance = m.Balance;
                changes.Add(m);
                current = changes.Count - 1;
            }
        }

        public Memento Undo()
        {
            if(current > 0)
            {
                var m = changes[--current];
                balance = m.Balance;
                return m;
            }
            return null;
        }

        public Memento Redo()
        {
            if(current + 1 < changes.Count)
            {
                var m = changes[++current];
                balance = m.Balance;
                return m;
            }
            return null;
        }

        public override string ToString()
        {
            return $"{nameof(balance)}: {balance}";
        }
    }

    public class Demo
    {
        public static void Main(string[] args)
        {
            var ba = new BankAccount(100);
            ba.Deposit(50);
            ba.Deposit(25);
            Console.WriteLine(ba);

            ba.Undo();
            Console.WriteLine($"Undo 1: {ba}");
            ba.Undo();
            Console.WriteLine($"Undo 2: {ba}");
            ba.Redo();
            ba.Redo();
            Console.WriteLine($"Redo 2: {ba}");
            ba.Undo();
            ba.Undo();
            Console.WriteLine($"Undo: {ba}");
            ba.Deposit(100);
            Console.WriteLine($"Deposit: {ba}");
            Console.WriteLine($"Changes: {ba.Changes[ba.Changes.Count - 1].Balance}");
            Console.WriteLine($"Changes: {ba.Changes[ba.Current].Balance}");
        }
    }
}
