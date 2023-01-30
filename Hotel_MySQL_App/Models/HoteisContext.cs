using System;
using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;

namespace Hotel_MySQL_App.Models;

public class HoteisContext
{

    //Está no AppSettings.json e é onde se encontra as informações para conectar com a bds
    public string ConnectionString { get; set; }


    //Construtor recebe como parametro a connection String.
    public HoteisContext()
    {
        this.ConnectionString = "server=localhost;port=3306;database=hotel_22023;user=joaomonge;password=p@ssw0rd";
    }

    private MySqlConnection GetConnection()
    {
        return new MySqlConnection(ConnectionString);
    }

    //Obter hoteis
    public List<Hotel> GetAllHotels()
    {
        List<Hotel> hotelsList = new List<Hotel>();

        using (MySqlConnection conn = GetConnection())
        {
            //Abrir a ligação
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Hotel", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader()) {
                while (reader.Read())
                {
                    hotelsList.Add(new Hotel()
                    {
                        Sigla_Hotel = reader.GetString("Sigla_Hotel"),
                        Designacao = reader.GetString("Designacao"),
                        Localizacao = reader.GetString("Localizacao"),
                        CreatedAt = reader.GetDateTime("Created_At")
                    });
                    Console.WriteLine(reader.GetString("Sigla_Hotel"));
                }
            }
        }

        return hotelsList;
    }

    //Obter Clientes
    public List<Cliente> GetAllClientes()
    {
        List<Cliente> clientsList = new List<Cliente>();

        using (MySqlConnection conn = GetConnection())
        {
            //Abrir a ligação
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Cliente", conn);
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    clientsList.Add(new Cliente()
                    {
                        NomeCliente = reader.GetString("Nome_Cliente"),
                        NumeroCliente = reader.GetInt32("Numero_Cliente")
                   
                    });
                }
            }
        }

        return clientsList;
    }
}

