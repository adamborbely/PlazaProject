using System;
using System.Collections.Generic;
using System.Text;

namespace packagecom.codecool.plaza.api
{
    public class FoodProduct : Product
    {
        private int calories;
        private DateTime bestBefore;
        public FoodProduct(long barcode, string name, string manufacturer, int calories, DateTime bestBefore) : base(barcode, name, manufacturer)
        {
            this.calories = calories;
            this.bestBefore = bestBefore;
        }
        public FoodProduct(FoodProduct food) : base(food.GetBarcode(), food.GetName(), food.GetManufacturer())
        {
            this.calories = food.GetCalories();
            this.bestBefore = food.GetBestBefore();
        }
        public bool IsStillConsumable()
        {
            if (DateTime.Compare(bestBefore, DateTime.Now) < 0)
            {
                return false;
            }
            return true;
        }
        public DateTime GetBestBefore()
        {
            return bestBefore;
        }
        public int GetCalories()
        {
            return calories;
        }
        public override string ToString()
        {
            return "ez kaja";
        }
    }
}

