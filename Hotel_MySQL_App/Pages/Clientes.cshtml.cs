using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_MySQL_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hotel_MySQL_App.Pages
{
	public class ClientesModel : PageModel
    {
        public IEnumerable<Cliente> clientes { get; set;}

        public void OnGet()
        {
            HoteisContext context = new HoteisContext();
            clientes = context.GetAllClientes();
        }
    }
}
