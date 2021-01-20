using FeelGreatIn8.Models;
using System;
using System.IO;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FeelGreatIn8.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {

        #region Instances

        private readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "Data.txt");

        #endregion

        #region Properties

        private Day day;
        public Day Day
        {
            get { return day; }
            set
            {
                if (value != day)
                {
                    SetProperty(ref day, value);
                }
            }
        }

        public IList<Day> Days { get; set; }

        #endregion

        #region Commands

        #endregion

        #region Constructor

        public TaskViewModel()
        {
            Title = "Feel Great In 8";

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        #endregion

        #region Class Methods

        internal void ChangeFruitVeg(double newValue)
        {
            Day.FruitVeg = (int)newValue;
        }

        internal void ChangeFood(double newValue)
        {
            Day.Food = (int)newValue;
        }

        internal void ChangeWater(double newValue)
        {
            Day.Water = (int)newValue;
        }

        internal void OnAppearing()
        {
            var text = File.ReadAllText(filePath);
            Days = JsonConvert.DeserializeObject<List<Day>>(text);
            if (Days != null)
            {
                var result = Days.FirstOrDefault(x => x.Date.Day == DateTimeOffset.Now.Day &&
                                                  x.Date.Month == DateTimeOffset.Now.Month &&
                                                  x.Date.Year == DateTimeOffset.Now.Year);
                if (result != null)
                {
                    Day = result;
                }
                else
                {
                    Day = new Day();
                    Days.Add(Day);
                }
            }
            else
            {
                Day = new Day();
                Days = new List<Day>();
                Days.Add(Day);
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



        #endregion

        #region EventHandlers



        #endregion
    }
}