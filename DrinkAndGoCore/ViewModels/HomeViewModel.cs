﻿using DrinkAndGoCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DrinkAndGoCore.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }
    }
}
