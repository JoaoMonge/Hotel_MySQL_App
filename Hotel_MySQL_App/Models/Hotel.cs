using System;
namespace Hotel_MySQL_App.Models;

public class Hotel
{
	private HoteisContext context;

	public string Sigla_Hotel { get; set; }
	public string Designacao { get; set; }
    public string Localizacao { get; set; }
    public DateTime CreatedAt { get; set; }
}

