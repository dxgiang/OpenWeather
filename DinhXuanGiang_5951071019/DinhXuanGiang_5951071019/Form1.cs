using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DinhXuanGiang_5951071019
{
    public partial class Form1 : Form
    {
        const string APPID = "cf7307c2ea4a39103e5961c6898440d1";
        string cityID = "1566083";
        public Form1()
        {
            InitializeComponent();
            getWeather("1566083");
            //geForecast("1566083");

        }
        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                //&units=metric&cnt=6
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric&cnt=6", city, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<WeatherInfo.root>(json);
                WeatherInfo.root outPut = result;

                lbl_textCity.Text = string.Format("{0}", outPut.name);
                lbl_Country.Text = string.Format("{0}", outPut.sys.country);
                lbl_DoCe.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);
            }
        }
        //void geForecast(string city)
        //{
        //    string url = string.Format("http://api.openweathermap.org/data/2.5/weather?id={0}&appid={1}&units=metric&cnt", city, APPID);
        //    using (WebClient web = new WebClient())
        //    {
        //        var json = web.DownloadString(url);
        //        var Object = JsonConvert.DeserializeObject<WeatherForecasts>(json);
        //        WeatherForecasts forecasts = Object;

        //        lbl_Con.Text = string.Format("{0}", forecasts.list[1].weather[0].main);
        //        lbl_Des.Text = string.Format("{0}", forecasts.list[1].weather[0].descriptions);
        //        lbl_Des2.Text = string.Format("{0} \u00B0" + "C", forecasts.list[1].temp);
        //        lbl_speed.Text = string.Format("{0}", forecasts.list[1].speed);

        //    }
        //}
    }
}
