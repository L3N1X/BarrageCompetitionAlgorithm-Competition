using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrageCompetition_CranesAlgorithm
{
    internal class Program
    {

        public class Crane
        {
            public Crane(int at, int arm)
            {
                this.At = at;
                this.Arm = arm;
            }
            public int From { get => At - Arm; }
            public int To { get => At + Arm; }
            public int At { get; set; }
            public int Arm { get; set; }
        }

        static void Main(string[] args)
        {
            int[] p = { 5, 9, 14 };
            int[] a = { 2, 3, 2 };
            int b = 3;
            int e = 16;

            if (Solution(p, a, b, e))
                Console.WriteLine("B can be transfered to E");
            else
                Console.WriteLine("B can't be transfered to E");

        }
        public static bool Solution(int[] p, int[] a, int b, int e)
        {
            IList<Crane> cranes = new List<Crane>();
            ISet<int> coveredFields = new HashSet<int>();

            for (int i = 0; i < a.Length; i++)
            {
                cranes.Add(new Crane(p[i], a[i]));
                for (int j = cranes[i].From; j <= cranes[i].To; j++)
                    coveredFields.Add(j);
            }

            cranes.ToList().Sort((left, right) => left.At.CompareTo(right.At));

            for (int i = 0; i < cranes.Count; i++)
            {
                for (int j = cranes[i].From; j <= cranes[i].To; j++)
                {
                    if (j == b || j == e)
                        continue;
                    if ((j >= b && j <= e) || (j >= e && j <= b))
                    {
                        if(i != cranes.Count - 1)
                        {
                            if (j == cranes[i].To && j + 1 == cranes[i + 1].From)
                                return false;
                        }
                        if (coveredFields.Add(j))
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
