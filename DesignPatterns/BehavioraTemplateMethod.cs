using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioraTemplateMethod
{
    public abstract class Game
    {
        public void Run()
        {
            Start();
            while (!HaveWinner)
                TakeTurn();
            Console.WriteLine($"Player {WinningPlayer} wins.");
        }

        protected abstract void Start();
        protected abstract bool HaveWinner { get; }
        protected abstract void TakeTurn();
        protected abstract int WinningPlayer { get; }

        protected int currentPlayer;
        protected readonly int numberOfPlayers;

        public Game(int numberOfPlayers)
        {
            this.numberOfPlayers = numberOfPlayers;
        }
    }

    // simulate a game of chess
    public class Chess : Game
    {
        private int maxTurns = 10;
        private int turn = 1;

        public Chess() : base(2)
        {

        }

        protected override void Start()
        {
            Console.WriteLine($"Starting a game of chess with {numberOfPlayers} players");
        }

        protected override bool HaveWinner => turn == maxTurns;

        protected override void TakeTurn()
        {
            Console.WriteLine($"Turn {turn++} taken by player {currentPlayer}.");
            currentPlayer = (currentPlayer + 1) % numberOfPlayers;
        }

        protected override int WinningPlayer => currentPlayer;
    }

    public class Demo
    {
        //public static void Main(string[] args)
        //{
        //    var chess = new Chess();
        //    chess.Run();
        //}
    }
}
