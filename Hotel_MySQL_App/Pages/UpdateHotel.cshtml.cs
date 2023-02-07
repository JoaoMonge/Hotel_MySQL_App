using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_MySQL_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_MySQL_App.Pages
{
	public class HotelsModel : PageModel
    {
        public IEnumerable<Hotel> Hotels { get; set; }


        public void OnGet()
        {

            HoteisContext context = new HoteisContext();
            Hotels = context.GetAllHotels();

        }
    }
}
