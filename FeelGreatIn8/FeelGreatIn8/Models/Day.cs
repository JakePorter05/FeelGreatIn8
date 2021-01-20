using FeelGreatIn8.Core;
using System;

namespace FeelGreatIn8.Models
{
    public class Day : NotificationBase
    {
        private bool read;
        public bool Read
        {
            get { return read; }
            set
            {
                if (value != read)
                {
                    SetProperty(ref read, value);
                }
            }
        }

        private bool pray;
        public bool Pray
        {
            get { return pray; }
            set
            {
                if (value != pray)
                {
                    SetProperty(ref pray, value);
                }
            }
        }

        private int fruitVeg;
        public int FruitVeg
        {
            get { return fruitVeg; }
            set
            {
                if (value != fruitVeg)
                {
                    SetProperty(ref fruitVeg, value);
                }
            }
        }

        private int food;
        public int Food
        {
            get { return food; }
            set
            {
                if (value != food)
                {
                    SetProperty(ref food, value);
                }
            }
        }

        private int water;
        public int Water
        {
            get { return water; }
            set
            {
                if (value != water)
                {
                    SetProperty(ref water, value);
                }
            }
        }

        private int exercise;
        public int Exercise
        {
            get { return exercise; }
            set
            {
                if (value != exercise)
                {
                    SetProperty(ref exercise, value);
                }
            }
        }

        public DateTimeOffset Date { get; set; }

        public Day()
        {
            Date = DateTimeOffset.Now;
        }
    }
}