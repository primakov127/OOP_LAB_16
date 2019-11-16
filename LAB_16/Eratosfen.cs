using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LAB_16
{
    class Eratosfen
    {
        List<int> simple = new List<int>();

        public void EratosfenT(int MaxNumber)
        {
            simple = new List<int>();
            for (int i = 1; i < MaxNumber; i++)
                simple.Add(i);
            DoEratosfen();
        }

        public void EratosfenT(int MaxNumber, ref CancellationToken token)
        {
            simple = new List<int>();
            for (int i = 1; i < MaxNumber; i++)
                simple.Add(i);
            DoEratosfen(ref token);
        }

        int Step(int Prime, int startFrom)
        {
            int i = startFrom + 1;
            int Removed = 0;
            while (i < simple.Count)
                if (simple[i] % Prime == 0)
                {
                    simple.RemoveAt(i);
                    Removed++;
                }
                else
                    i++;
            return Removed;
        }

        void DoEratosfen(ref CancellationToken token)
        {
            int i = 1;
            while (i < simple.Count)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Операция прервана токеном");
                    return;
                }
                Step(simple[i], i);
                i++;
            }
        }

        void DoEratosfen()
        {
            int i = 1;
            while (i < simple.Count)
            {
                Step(simple[i], i);
                i++;
            }
        }

        public int[] Simple
        {
            get
            {
                return simple.ToArray();
            }
        }

    }
}
