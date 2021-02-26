using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaBusy
{
    static class StopExt
    {
        public static void AddStop(this Dictionary<string, Stop> StopDict, string name, double x, double y)
        {
            StopDict.Add(name, new Stop(x, y));
        }
        public static void AddStop(this Dictionary<string, Stop> StopDict, string name, double x, double y, string n)
        {
            StopDict.Add(name, new Stop(x, y, n));
        }
    }
    class Stop
    {
        public readonly string Name;
        public readonly int X;
        public readonly int Y;

        public Stop(double x, double y)
        {
            this.X = (int)x;
            this.Y = (int)y;
        }
        public Stop(double x, double y, string name)
        {
            this.X = (int)x;
            this.Y = (int)y;
            this.Name = name;
        }
        public override string ToString()
        {
            return (String.Format("{0},{3},X={1},Y={2}", base.ToString(), this.X, this.Y, this.Name));
        }
    }

    class Platform : Stop
    {
        public new int X
        {
            get => base.X + newX;
        }
        public new int Y
        {
            get => base.Y + newX;
        }
        public int newX;
        public int newY;
        public int Line;
        public Stop direction1;
        public Stop direction2;
        public Platform(double x, double y, string z) : base(x,y,z)
        {
            newX = (int)x;
            newY = (int)y;
        }
    }
    class Linka
    {
        public List<Stop> Zastavky = new List<Stop>();
        public int Cislo;
        public string Konecna;

        public Linka (int cislo, List<Stop>zast)
        {
            this.Cislo = cislo;
            this.Zastavky = zast;
            this.Konecna = Zastavky[Zastavky.Count - 1].Name;
        }
        public void AddReverseDirection(ref Linka lnk)
        {
            if (lnk.Zastavky[0].Name != this.Konecna)
                Zastavky.Add(lnk.Zastavky[0]);
            for(int i = 1; i < lnk.Zastavky.Count; ++i)
            {
                Zastavky.Add(lnk.Zastavky[i]);
            }
            lnk = null;
        }
    }
}
