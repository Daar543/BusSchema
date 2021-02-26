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
    }
    class Stop
    {
        public readonly int X;
        public readonly int Y;

        public Stop(double x, double y)
        {
            this.X = (int)x;
            this.Y = (int)y;
        }
        public override string ToString()
        {
            return (String.Format("{0},X={1},Y={2}", base.ToString(), this.X, this.Y));
        }
    }
}
