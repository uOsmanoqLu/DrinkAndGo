using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrinkAndGoCore.Interfaces;
using DrinkAndGoCore.Models;
using DrinkAndGoCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DrinkAndGoCore.Controllers
{
    public class DrinkController : Controller
    {

        private readonly IDrinkRepository _drinkRepository;
        private readonly ICategoryRepository _categoryRepository;

        public DrinkController(IDrinkRepository drinkRepository, ICategoryRepository categoryRepository)
        {
            _drinkRepository = drinkRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;

            string currentCategory = string.Empty;

            if(string.IsNullOrEmpty(category))
            {
                drinks = _drinkRepository.Drinks.OrderBy(n=> n.DrinkId);
                currentCategory = "All Drinks";
            }
            else{
                if (string.Equals("Alcoholic", _category, StringComparison.OrdinalIgnoreCase)) {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(p=> p.Name);
                }
                else
                {
                    drinks = _drinkRepository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(p => p.Name);
                }
                currentCategory = _category;
            }

            DrinkListViewModel vm = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCategory
            };

            return View(vm);
        }

        private DrinkListViewModel DrinkListViewModel()
        {
            throw new NotImplementedException();
        }
    }
}