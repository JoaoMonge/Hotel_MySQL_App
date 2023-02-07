using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_MySQL_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_MySQL_App.Pages
{
	public class CreateHotelModel : PageModel
    {


        public void OnGet()
        {

           

        }

        public void OnPost()
        {
            Hotel hotel = new Hotel();
            hotel.Sigla_Hotel = Request.Form["sigla"];
            hotel.Designacao = Request.Form["designacao"];
            hotel.Localizacao = Request.Form["localizacao"];

            HoteisContext context = new HoteisContext();

            context.createHotel(hotel);
                

            OnGet();
        }
    }
}
