using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_MySQL_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_MySQL_App.Pages
{
	public class CreateClienteModel : PageModel
    {


        public void OnGet()
        {


        }

        public void OnPost()
        {
            Cliente client = new Cliente();
            client.NomeCliente = Request.Form["nome"];
            client.NumeroCliente = Int32.Parse(Request.Form["numero"]);

            HoteisContext context = new HoteisContext();

            context.createCliente(client);
                

            OnGet();
        }
    }
}
