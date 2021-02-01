using FeelGreatIn8.Core;
using FeelGreatIn8.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        private int position;
        public int Position
        {
            get { return position; }
            set
            {
                if (value != position)
                {
                    if (position < 0)
                    {
                        value = 0;
                    }
                    SetProperty(ref position, value);
                }
            }
        }

        #endregion

        #region Commands

        public Command ResetCommand { get; set; }

        #endregion

        #region Constructor

        public TaskViewModel()
        {
            //Defaults
            Title = "Feel Great In 8";

            //Make sure directory is there
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            //Sub to the message from settings
            ResetCommand = new Command(ResetMethod);
        }

        #endregion

        #region Class Methods

        internal void OnAppearing()
        {
            //Get file data
            var text = File.ReadAllText(filePath);
            var result = JsonConvert.DeserializeObject<List<Day>>(text);

            //Fill in assigned data.
            if (Days == null)
            {
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
                    Days = new ObservableRangeCollection<Day>(template);
                }
                else
                {
                    Days = new ObservableRangeCollection<Day>(result);
                }
            }

            //Select latest day
            var today = DateTime.Now.DayOfWeek.ToString();
            var currentDay = Days.FirstOrDefault(x => today.Contains(x.DayName));
            var index = Days.IndexOf(currentDay);
            if (index >= 0) 
            {
                Position = index;
            }
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

        private void ResetMethod(object obj)
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

        #endregion

        #region EventHandlers



        #endregion
    }
}