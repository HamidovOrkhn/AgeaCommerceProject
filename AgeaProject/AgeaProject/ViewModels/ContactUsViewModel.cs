using AgeaProject.Areas.Admin.Resources;
using AgeaProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeaProject.ViewModels
{
    public class ContactUsViewModel
    {
        public ContactUs ContactUs { get; set; }
        public List<ContactUs> ContactsUs { get; set; }
        public ContactForm ContactForm { get; set; }
        public List<ContactForm> Contactsform { get; set; }
        public PaginationDto Pagination { get; set; }
    }
}
