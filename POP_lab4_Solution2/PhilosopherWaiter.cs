using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution2
{
    public class PhilosopherWaiter
    {
        private readonly TableWaiter table;
        private readonly int leftFork;
        private readonly int rightFork;
        private readonly int id;
        private readonly Thread worker;

        public PhilosopherWaiter(int id, TableWaiter table)
        {
            this.id = id;
            this.table = table;
            rightFork = id;
            leftFork = (id + 1) % 5;

            worker = new Thread(Run);
            worker.Start();
        }

        public Thread Worker => worker;

        private void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Philosopher " + id + " is thinking (" + (i + 1) + ")");

                try
                {
                    table.AcquireForks(rightFork, leftFork);
                    Console.WriteLine("Philosopher " + id + " is eating (" + (i + 1) + ")");
                    table.ReleaseForks(leftFork, rightFork);
                }
                catch (ThreadInterruptedException)
                {
                    Thread.CurrentThread.Interrupt();
                }
            }

            Console.WriteLine("Philosopher " + id + " finished.");
        }
    }
}
