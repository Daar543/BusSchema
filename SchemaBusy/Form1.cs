﻿using Grafikon_Busy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchemaBusy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ActivateCoordsOfAllStops("JR/Zastavky.txt");
            g = this.CreateGraphics();
            //DrawOneLine(ref g, 50, 47, 25, 47);
            
        }
        public Color[] LineColors =
        {
            Color.Green,Color.LightBlue,Color.Red,Color.Purple,Color.Yellow,Color.Gray,Color.Orange,Color.DarkBlue,Color.Black
        };
        Dictionary<string, Stop> AllStops = new Dictionary<string, Stop>();
        Graphics g;


        /*private void AddStop(ref Dictionary<string, Stop> StopDict, string name, int x, int y)
        {
            StopDict.Add(name, new Stop(x, y));
        }*/
        private void ActivateCoordsOfAllStops(string file)
        {
            var sr = new StreamReader(file);
            string line = sr.ReadLine();
            while (line != null)
            {
                string[] linesp = line.Split('\t');
                AllStops.AddStop(linesp[0], double.Parse(linesp[1]), double.Parse(linesp[2]));
                line = sr.ReadLine();
            }
        }
        private void DrawOneTour(string[] stoplist, Color color)
        {
            int i = 0;
            Stop s1;
            Stop s2;
            while(!AllStops.TryGetValue(stoplist[i],out s1))
            {
                i++;
            }
            for(i+=1; i < stoplist.Length; ++i)
            {
                bool loaded = AllStops.TryGetValue(stoplist[i],out s2);
                if(!loaded)
                    continue;

                DrawALine(this.g, color, s1.X, s1.Y, s2.X, s2.Y);
                Point[] Tr = GetATriangleFromHeight(new Point(s1.X,s1.Y), new Point(s2.X,s2.Y),10);
                DrawALine(g, Color.Black,2, Tr[0], Tr[1]);
                DrawALine(g, Color.Black,3, Tr[1], Tr[2]);
                DrawALine(g, Color.Black,2, Tr[2], Tr[0]);
                s1 = s2; //pushes the stop to next
            }
        }
        private void DrawALine(Graphics g, Color color, float fromX, float fromY, float toX, float toY)
        {
            Pen applePen = new Pen(color);
            applePen.Width = 5;
            applePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawLine(applePen, fromX, fromY, toX, toY);
        }
        private void DrawALine(Graphics g, Color color, int PenW, float fromX, float fromY, float toX, float toY)
        {
            Pen applePen = new Pen(color);
            applePen.Width = PenW;
            applePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawLine(applePen, fromX, fromY, toX, toY);
        }
        private void DrawALine(Graphics g, Color color, Point from, Point to)
        {
            Pen applePen = new Pen(color);
            applePen.Width = 5;
            applePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawLine(applePen, from, to);
        }
        private void DrawALine(Graphics g, Color color, int PenW, Point from, Point to)
        {
            Pen applePen = new Pen(color);
            applePen.Width = PenW;
            applePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Bevel;
            g.DrawLine(applePen, from, to);
        }
        private void btnLoadTTs_Click(object sender, EventArgs e)
        {
            string[] TimeTables = txbJR.Text.Split(Environment.NewLine.ToCharArray());
            int j = 0;
            for(int i = 0; i < TimeTables.Length; ++i)
            {
                ref string line = ref TimeTables[i];
                if (line is null || line == "" || line.Length == 0)
                    continue;
                string[]requestedStops = GetStopsFromTimeTable(line);
                //DrawALine(this.g, Color.Red, 0, 0, 500, 500);
                DrawOneTour(requestedStops,LineColors[j++]);
            }
        }
        public Point[] GetATriangleFromHeight(Point vertexP, Point vertexTarg, int height)
        {

            
            
            double slope = (double)(vertexP.Y - vertexTarg.Y)/(vertexP.X - vertexTarg.X);

            double offsetfromP = height / Math.Sqrt(1 + slope * slope);
            double vertAX = (vertexP.X + (offsetfromP * (vertexP.X < vertexTarg.X ? 1 : -1))); //Increase or decrease based on how the line goes
            double vertAY = slope * (vertAX - vertexP.X) + vertexP.Y;
            Point vertexA = new Point((int)vertAX, (int)vertAY);


            double halfLength = (Math.Sqrt(3) * height) / 3;
            double perpSlope = -1 / slope;
            double perpOffset = vertexP.Y - perpSlope * vertexP.X;
            double x = vertexP.X;
            double y = vertexP.Y;
            double d = halfLength;
            double a = perpSlope;
            double b = perpOffset;

            //Solving these two equations for leftX:
            //(leftX-x)^2+(leftY-y)^2 = d^2;
            //leftY = a*leftX+b;
            double leftPointX = ((x + a * y - a * b)
                + Math.Sqrt(-(a * a * x * x) + (2 * a * x * y) - (2 * a * b * x) + (a * a * d * d) + (2 * b * y) + (d * d) - (b * b) - (y * y)))
                / (1 + a * a);
            //Another solution for quadratic equation
            double rightPointX = ((x + a * y - a * b)
                - Math.Sqrt(-(a * a * x * x) + (2 * a * x * y) - (2 * a * b * x) + (a * a * d * d) + (2 * b * y) + (d * d) -( b * b) - (y * y)))
                / (1 + a * a);

            double leftPointY = a * leftPointX + b;
            double rightPointY = a * rightPointX + b;

            Point[] triangle = new Point[4] { vertexA, new Point((int)leftPointX, (int)leftPointY), new Point((int)rightPointX, (int)rightPointY), vertexP };
            return triangle;
        }
        private string[] GetStopsFromTimeTable(string line)
        {
            TimeTableParser TimeTable;
            try
            {
                string[][] initTable = SheetLoader.RowifyTable(SheetLoader.ReadExcelInput(line, '\t'));
                TimeTable = new TimeTableParser(initTable);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Linka neexistuje", "Chybný vstup", MessageBoxButtons.RetryCancel);
                return null;
            }
            TimeTable.GetStops(out string[]givenStops);
            return givenStops;
        }

        private void btnLoadSLs_Click(object sender, EventArgs e)
        {
            /*Point[] Tr = GetATriangleFromHeight(new Point(100, 100), new Point(120, 110));
            DrawALine(g, Color.Beige, Tr[0], Tr[1]);
            DrawALine(g, Color.Beige, Tr[1], Tr[2]);
            DrawALine(g, Color.Beige, Tr[2], Tr[0]);*/
            string[] TimeTables = txbSZ.Text.Split(Environment.NewLine.ToCharArray());
            int j = 0;
            for (int i = 0; i < TimeTables.Length; ++i)
            {
                ref string line = ref TimeTables[i];
                if (line is null || line == "" || line.Length == 0)
                    continue;
                var sr = new StreamReader(line);
                List<string> reqStops = new List<string>();
                string ln = sr.ReadLine();
                while (ln != null && ln!="")
                {
                    reqStops.Add(ln);
                    ln = sr.ReadLine();
                }
                string[] requestedStops = reqStops.ToArray();
                //DrawALine(this.g, Color.Red, 0, 0, 500, 500);
                DrawOneTour(requestedStops,LineColors[j++]);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
