using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution3
{
    public class PhilosopherForkLimit
    {
        private readonly TableForkLimit _table;
        private readonly int _leftFork;
        private readonly int _rightFork;
        private readonly int _id;
        private readonly Thread _worker;

        public PhilosopherForkLimit(int id, TableForkLimit table)
        {
            _id = id;
            _table = table;
            _rightFork = id;
            _leftFork = (id + 1) % 5;

            _worker = new Thread(Run);
            _worker.Name = $"Philosopher-{id}";
            _worker.Start();
        }

        public Thread Worker => _worker;

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Philosopher {_id} is thinking ({i + 1})");

                try
                {
                    _table.AcquireForks(_rightFork, _leftFork);
                    Console.WriteLine($"Philosopher {_id} is eating ({i + 1})");
                    _table.ReleaseForks(_leftFork, _rightFork);
                }
                catch (ThreadInterruptedException)
                {
                    Thread.CurrentThread.Interrupt();
                }
            }

            Console.WriteLine($"Philosopher {_id} finished.");
        }
    }
}
