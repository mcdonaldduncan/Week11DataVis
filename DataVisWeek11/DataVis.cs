using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataVisWeek11
{
    public partial class DataVis : Form
    {
        internal Services service = new Services();

        public DataVis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideAll();
            chart1.Visible = true;
            try
            {
                chart1.Series.Clear();
                chart1.ChartAreas.Clear();
                chart1.Titles.Clear();

                chart1.Titles.Add("Count By State");

                var Area1 = chart1.ChartAreas.Add("Area1");
                Area1.AxisX.Title = "State";
                Area1.AxisY.Title = "Frequency";
                Area1.AxisX.TitleAlignment = StringAlignment.Center;
                Area1.AxisY.TitleAlignment = StringAlignment.Center;

                Area1.AxisX.Interval = 1;

                var chartSeries = chart1.Series.Add("Location Count");
                chartSeries.ChartType = SeriesChartType.Column;
                chartSeries.IsValueShownAsLabel = true;

                List<DataModel> results = service.GetRequest("get-by-state").Result;

                foreach (var point in results)
                {
                    chartSeries.Points.AddXY(point.X, point._Y);
                }

            }
            catch (Exception ex)
            {

                service.errors.Add(new Error(ex.Message, ex.Source));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HideAll();
            chart2.Visible = true;
            try
            {
                chart2.Series.Clear();
                chart2.ChartAreas.Clear();
                chart2.Titles.Clear();

                chart2.Titles.Add("Count By 200 HP");

                var Area1 = chart2.ChartAreas.Add("Area1");
                Area1.AxisX.Title = "Increment";
                Area1.AxisY.Title = "Frequency";
                Area1.AxisX.TitleAlignment = StringAlignment.Center;
                Area1.AxisY.TitleAlignment = StringAlignment.Center;


                var chartSeries = chart2.Series.Add("Range Frequency");
                chartSeries.ChartType = SeriesChartType.Column;
                chartSeries.IsValueShownAsLabel = true;

                List<DataModel> results = service.GetRequest("get-by-HP").Result;

                chartSeries.Points.AddXY("0-200", results.Where(x => x._X <= 200).Sum(y => y._Y));
                chartSeries.Points.AddXY("200-400", results.Where(x => x._X <= 400 && x._X > 200).Sum(y => y._Y));
                chartSeries.Points.AddXY("400-600", results.Where(x => x._X <= 600 && x._X > 400).Sum(y => y._Y));
                chartSeries.Points.AddXY("600-800", results.Where(x => x._X <= 800 && x._X > 600).Sum(y => y._Y));
                chartSeries.Points.AddXY("800-1000", results.Where(x => x._X <= 1000 && x._X > 800).Sum(y => y._Y));

            }
            catch (Exception ex)
            {

                service.errors.Add(new Error(ex.Message, ex.Source));
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            HideAll();
            chart3.Visible = true;
            try
            {
                chart3.Series.Clear();
                chart3.ChartAreas.Clear();
                chart3.Titles.Clear();
                     
                chart3.Titles.Add("HP by MP");

                var Area1 = chart3.ChartAreas.Add("Area1");
                Area1.AxisX.Title = "MP";
                Area1.AxisY.Title = "HP";
                Area1.AxisX.TitleAlignment = StringAlignment.Center;
                Area1.AxisY.TitleAlignment = StringAlignment.Center;

                var chartSeries = chart3.Series.Add("Top HP/MP");
                chartSeries.ChartType = SeriesChartType.Point;
                chartSeries.IsValueShownAsLabel = true;

                List<DataModel> results = service.GetRequest("get-HPMP").Result;

                foreach (var point in results)
                {
                    chartSeries.Points.AddXY(point._X, point._Y);
                }

            }
            catch (Exception ex)
            {

                service.errors.Add(new Error(ex.Message, ex.Source));
            }
        }
        
        private void HideAll()
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
        }

    }
}
