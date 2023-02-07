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
        //Acessivel pelo cshtml através da variável Model
        public IEnumerable<Hotel> Hotels { get; set; }


        public void OnGet()
        {
            //O Context vai ser ligação entre o .Net e a nossa base de dados MySQL
            HoteisContext context = new HoteisContext();
            //Preenche a variável Hotels que está a ser chamada o cshtml e irá mostrar a tabela de resultados ao utilizador
            Hotels = context.GetAllHotels();

        }
    }
}
