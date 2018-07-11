﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace New_code
{
    public partial class Form1 : Form
    {
        class row
        {
            public double time;
            public double altitude;
            public double velocity;
            public double acceleration;
        }

        List<row> table = new List<row>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void calculateVelocity()
        {
            for (int i = 1; i < table.Count; i++)
            {
                double dQ = table[i].altitude - table[i - 1].altitude;
                double dt = table[i].time - table[i - 1].time;
                table[i].velocity = dQ / dt;
            }
        }

        private void calculateAcceleration()
        {
            for (int i = 2; i < table.Count; i++)
            {
                double dI = table[i].velocity- table[i - 1].altitude;
                double dt = table[i].time - table[i - 1].time;
                table[i].velocity = dI / dt;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "csv Files|*.csv";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string line = sr.ReadLine();
                        while (!sr.EndOfStream)
                        {
                            table.Add(new row());
                            string[] r = sr.ReadLine().Split(',');
                            table.Last().time = double.Parse(r[0]);
                            table.Last().charge = double.Parse(r[1]);
                        }
                    }
                    calculateVelocity();
                    calculateAcceleration();
                }
                catch (IOException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " failed to open file.");
                }
                catch (FormatException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " is not in the required format");
                }
                catch (IndexOutOfRangeException)
                {
                    MessageBox.Show(openFileDialog1.FileName + " is not in the required format");
                }
                catch (DivideByZeroException)
                {
                    MessageBox.Show(openFileDialog1.FileName
        {

   }
                }

        private void altitudeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
            Series series = new Series
            {
                Name = "altitude",
                Color = Color.Red,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline,
                BorderWidth = 2
            };
            chart1.Series.Add(series);
            foreach (row r in table.Skip(1))
            {
                series.Points.AddXY(r.time, r.altitude);
            }
            chart1.ChartAreas[0].AxisX.Title = "time /s";
            chart1.ChartAreas[0].AxisY.Title = "altitude /A";
            chart1.ChartAreas[0].RecalculateAxesScale


        }

        private void velocityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                chart1.Series.Clear();
                chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
                Series series = new Series
                {
                    Name = "velocity",
                    Color = Color.Blue,
                    IsVisibleInLegend = false,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Spline,
                    BorderWidth = 2
                };
                chart1.Series.Add(series);
                foreach (row r in table.Skip(1))
                {
                    series.Points.AddXY(r.time, r.velocity);
                }
                chart1.ChartAreas[0].AxisX.Title = "time /s";
                chart1.ChartAreas[0].AxisY.Title = "velocity /A";
                chart1.ChartAreas[0].RecalculateAxesScale();
 
        {

        }