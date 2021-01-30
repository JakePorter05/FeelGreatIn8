using FeelGreatIn8.Models;
using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Xamarin.CommunityToolkit.ObjectModel;

namespace FeelGreatIn8.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {

        #region Instances

        private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "Data.txt");

        #endregion

        #region Properties

        private ObservableRangeCollection<Day> days;
        public ObservableRangeCollection<Day> Days
        {
            get { return days; }
            set
            {
                if (value != days)
                {
                    SetProperty(ref days, value);
                }
            }
        }

        private Day selectedDay;
        public Day SelectedDay
        {
            get { return selectedDay; }
            set
            {
                if (value != selectedDay)
                {
                    SetProperty(ref selectedDay, value);
                }
            }
        }

        private int position;
        public int Position
        {
            get { return position; }
            set
            {
                if (value != position)
                {
                    SetProperty(ref position, value);
                }
            }
        }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public TaskViewModel()
        {
            Title = "Feel Great In 8";
            Days = new ObservableRangeCollection<Day>();

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        #endregion

        #region Class Methods

        internal void OnAppearing()
         {
            var text = File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<List<Day>>(text);
            
            if (result == null)
            {
                var template = new List<Day>()
                {
                    new Day
                    {
                        DayName = "Monday",
                    },
                    new Day
                    {
                        DayName = "Tuesday",
                    },
                    new Day
                    {
                        DayName = "Wednesday",
                    },
                    new Day
                    {
                        DayName = "Thursday",
                    },
                    new Day
                    {
                        DayName = "Friday",
                    },
                    new Day
                    {
                        DayName = "Saturday",
                    },
                    new Day
                    {
                        DayName = "Sunday",
                    },
                };
                Days.ReplaceRange(template);
            }
            else
            {
                Days.ReplaceRange(result);
            }
            var today = DateTime.Now.DayOfWeek.ToString();
            SelectedDay = Days.FirstOrDefault(x => today.Contains(x.DayName));
            Position = Days.IndexOf(SelectedDay);
        }

        internal void Disappearing()
        {
            if (Days != null)
            {
                var text = JsonConvert.SerializeObject(Days);
                File.WriteAllText(filePath, text);
            }
        }

        #endregion

        #region CommandHandlers



        #endregion

        #region EventHandlers



        #endregion
    }
}