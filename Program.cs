using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PruebaTecnica_consumo_de_API_
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string linea,url= "https://gorest.co.in/public/v2/users";
            int desicion;

            HttpClient client = new HttpClient();
            var HttpResponse = await client.GetAsync(url);

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
                var content = await HttpResponse.Content.ReadAsStringAsync();
                List<Models.User> request = JsonSerializer.Deserialize<List<Models.User>>(content);

                foreach (var item in request)
                {
                    Console.WriteLine(item.id.ToString()+" "+ item.name+" "+ item.gender+" "+item.status);
                    
                  
                }
            }
            Console.ReadKey();


        }
    }
}
