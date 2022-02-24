using AgeaProject.Data;
using AgeaProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewComponents
{
    public class ContactHeaderViewComponent :ViewComponent
    {
        private readonly DataContext _db;
        public ContactHeaderViewComponent(DataContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ContactUs contactUs = _db.ContactUs.OrderByDescending(a => a.Id).FirstOrDefault();
            return View(contactUs);
        }
    }
}
