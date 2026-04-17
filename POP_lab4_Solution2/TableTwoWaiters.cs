using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_lab4_Solution2
{
    public class TableTwoWaiters
    {
        private readonly Semaphore[] forks = new Semaphore[5];
        private readonly Semaphore waiters = new Semaphore(2, 2);

        public TableTwoWaiters()
        {
            for (int i = 0; i < forks.Length; i++)
            {
                forks[i] = new Semaphore(1, 1);
            }
        }

        public void AcquireForks(int right, int left)
        {
            waiters.WaitOne();
            forks[right].WaitOne();
            forks[left].WaitOne();
        }

        public void ReleaseForks(int left, int right)
        {
            forks[left].Release();
            forks[right].Release();
            waiters.Release();
        }
    }
}
