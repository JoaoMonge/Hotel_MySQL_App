using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_MySQL_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_MySQL_App.Pages
{

	public class HotelsUpdateModel : PageModel
    {
        [BindProperty]
        public IEnumerable<Hotel> Hotels { get; set; }


        public void OnGet()
        {
            HoteisContext context = new HoteisContext();
            Hotels = context.GetAllHotels();
        }

        public void OnPost()
        {
            HoteisContext context = new HoteisContext();

            if (Request.Form["operacao"].Equals("update"))
            {
                context.updateHotel(Request.Form["primaryKey"], Request.Form["Sigla_Hotel"], Request.Form["Designacao"], Request.Form["Localizacao"], Request.Form["CreatedAt"]);
                OnGet();
            }
            else if (Request.Form["operacao"].Equals("delete"))
            {
                context.deleteHotel(Request.Form["sigla"]);
                OnGet();
            }
            else if (Request.Form["operacao"].Equals("searchByDesignacao"))
            {
                this.Hotels = context.searchHotels(Request.Form["Designacao"]);
            }
 
        }
    }
}
