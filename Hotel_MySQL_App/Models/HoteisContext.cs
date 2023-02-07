using System;
using Microsoft.AspNetCore.Hosting.Server;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    //Operações CRUD - READ
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

    //Operações CRUD - UPDATE
    public void updateHotel(string primaryKey, string Sigla, string Designacao, string Localizacao, string createAt)
    {

        using (MySqlConnection conn = GetConnection())
        {
            //Abrir a ligação
            conn.Open();

            //Query
            MySqlCommand cmd = new MySqlCommand("UPDATE Hotel SET Designacao=@designacao, Localizacao=@localizacao WHERE Sigla_Hotel = @sigla;", conn);

            cmd.Parameters.AddWithValue("sigla", Sigla);
            cmd.Parameters.AddWithValue("designacao", Designacao);
            cmd.Parameters.AddWithValue("localizacao", Localizacao);

            cmd.ExecuteNonQuery();

            conn.Close();

        }
    }

    //Operação CRUD - Delete
    public void deleteHotel(string Sigla)
    {

        using (MySqlConnection conn = GetConnection())
        {
            //Abrir a ligação
            conn.Open();

            //Query
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Hotel WHERE Sigla_Hotel = @sigla;", conn);

            cmd.Parameters.AddWithValue("sigla", Sigla);

            if (cmd.ExecuteNonQuery() == 0)
            {
                throw new Exception("Não foi possível apagar");
            }

            conn.Close();

        }
    }

    //Operações CRUD - Create
    public void createHotel(Hotel hotel)
    {

        using (MySqlConnection conn = GetConnection())
        {
            //Abrir a ligação
            conn.Open();

            //Query
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Hotel (Sigla_Hotel,Designacao,Localizacao) VALUES (@sigla,@designacao,@localizacao);", conn);

            cmd.Parameters.AddWithValue("sigla", hotel.Sigla_Hotel);
            cmd.Parameters.AddWithValue("designacao", hotel.Designacao);
            cmd.Parameters.AddWithValue("localizacao", hotel.Localizacao);

            cmd.ExecuteNonQuery();

            conn.Close();

        }
    }
}

