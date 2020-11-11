﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WildFarm.Common;
using WildFarm.Models.Foods.Contracts;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string strType, int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == strType);
            if (type == null)
            {
                throw new InvalidOperationException(ExceptionMessage.INV_FOOD_TYPE);
            }

            object[] ctorParams = new object[] { quantity };

            Food food = (Food)Activator.CreateInstance(type, ctorParams);

            return food;
        }
    }
}
