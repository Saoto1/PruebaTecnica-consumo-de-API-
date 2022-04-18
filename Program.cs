using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PruebaTecnica_consumo_de_API_
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string linea,url= "https://gorest.co.in/public/v2/users", json;
            int desicion;

            HttpClient client = new HttpClient();
            var responsehttp = await client.GetAsync(url);

            Console.WriteLine("¿Desea realizar la busqueda por Id(1),Genero(2),Estado(3),Obtener todos los registros(cualquier caracter)?:");
            linea = Console.ReadLine();
            desicion = Int32.Parse(linea);

            if (desicion==1)
            {


                if (desicion==2)
                {
                    if (desicion==3)
                    {

                    }
                }
            }
            else
            {

            }



        }
    }
}
