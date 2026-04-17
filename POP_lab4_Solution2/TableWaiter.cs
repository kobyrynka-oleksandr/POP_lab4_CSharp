using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution2
{
    public class TableWaiter
    {
        private readonly Semaphore[] forks = new Semaphore[5];
        private readonly Semaphore waiter = new Semaphore(4, 4);

        public TableWaiter()
        {
            for (int i = 0; i < forks.Length; i++)
            {
                forks[i] = new Semaphore(1, 1);
            }
        }

        public void AcquireForks(int right, int left)
        {
            waiter.WaitOne();
            forks[right].WaitOne();
            forks[left].WaitOne();
        }

        public void ReleaseForks(int left, int right)
        {
            forks[left].Release();
            forks[right].Release();
            waiter.Release();
        }
    }
}
