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
            int[] p = { 5, 9, 40 };
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

            int craneIndex = 0;
            for (int i = cranes[0].From; i < cranes[cranes.Count - 1].To; i++)
            {
                if (i == b || i == e)
                    continue;
                if ((i >= b && i <= e) || (i >= e && i <= b))
                {
                    if (craneIndex != cranes.Count - 1)
                    {
                        if (i == cranes[craneIndex].To && i + 1 == cranes[craneIndex + 1].From)
                            return false;
                    }
                    if (coveredFields.Add(i))
                        return false;
                }
                if (i == cranes[craneIndex].To)
                    craneIndex++;
                if (i == cranes[craneIndex].To && craneIndex == cranes.Count - 1)
                    break;
            }

            return true;
        }
    }
}
