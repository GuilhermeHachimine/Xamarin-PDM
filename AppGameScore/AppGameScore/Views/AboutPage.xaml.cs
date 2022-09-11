using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppGameScore.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            Setup();
        }

        private List<Event> AllEvents { get; set; }

        private List<Event> GetEvents()
        {
            return new List<Event>()
            {
                new Event{ EventTitle = "Eleições 2022", BgColor = "#EB9999", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(180, 23, 45, 59).Ticks)},
                new Event{ EventTitle = "Natal 2022", BgColor = "#96338F", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(200, 1, 22, 10).Ticks)},
                new Event{ EventTitle = "7 de Setembro", BgColor = "#8251AE", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(132, 11, 15, 0).Ticks)},
                new Event{ EventTitle = "Páscoa", BgColor = "#6787FF", Date = new DateTime(DateTime.Now.Ticks + new TimeSpan(14, 17, 29, 45).Ticks)},
            };
        }

        private void Setup()
        {
            AllEvents = GetEvents();
            eventList.ItemsSource = AllEvents;

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                foreach (var evt in AllEvents)
                {
                    var timespan = evt.Date - DateTime.Now;
                    evt.Timespan = timespan;
                }

                eventList.ItemsSource = null;
                eventList.ItemsSource = AllEvents;

                return true;
            });
        }
    }

    public class Event
    {
        public DateTime Date { get; set; }
        public string EventTitle { get; set; }
        public TimeSpan Timespan { get; set; }
        public string Days => Timespan.Days.ToString("00");
        public string Hours => Timespan.Hours.ToString("00");
        public string Minutes => Timespan.Minutes.ToString("00");
        public string Seconds => Timespan.Seconds.ToString("00");
        public string BgColor { get; set; }
    }
}
