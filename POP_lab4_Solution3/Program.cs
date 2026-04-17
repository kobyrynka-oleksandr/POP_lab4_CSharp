namespace POP_lab4_Solution3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TableForkLimit table = new TableForkLimit();
            PhilosopherForkLimit[] philosophers = new PhilosopherForkLimit[5];

            for (int i = 0; i < 5; i++)
                philosophers[i] = new PhilosopherForkLimit(i, table);
        }
    }
}
