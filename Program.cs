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
            string url= "https://gorest.co.in/public/v2/users";
            int desicion;

            HttpClient client = new HttpClient();
            //var HttpResponse = await client.GetAsync(url);

            Console.WriteLine("¿Desea realizar la busqueda por Id(1),Genero(2),Estado(3),Obtener todos los registros(cualquier caracter)?:");
          var linea = Console.ReadLine();
            desicion = Int32.Parse(linea);

            if (desicion == 1)
            {

                await BuscarPorId(desicion);
            }
            if (desicion == 2)
            {
                await BuscarPorGenero(desicion);
            }
            if (desicion==3)
               {
                        await BuscarPorEstado(desicion);

                 }
              
            else
            {
                var HttpResponse = await client.GetAsync(url);
                var content = await HttpResponse.Content.ReadAsStringAsync();
                List<Models.User> request = JsonSerializer.Deserialize<List<Models.User>>(content, new JsonSerializerOptions() {PropertyNameCaseInsensitive =true });

                foreach (var item in request)
                {
                    Console.WriteLine(item.Id.ToString()+" "+ item.Name+" "+ item.Gender+" "+item.Status);
             
                }
            }
            Console.ReadLine();






            static async Task BuscarPorId( int desicion1)
            {             
                string linea,url;
                HttpClient client = new HttpClient();

                Console.WriteLine("Introduzca el Id:");
                linea = Console.ReadLine();
                desicion1 = Int32.Parse(linea);

                url = "https://gorest.co.in/public/v2/users?id=" + desicion1;
                var HttpResponse = await client.GetAsync(url);
                if (HttpResponse.IsSuccessStatusCode)
                {
                    var content = await HttpResponse.Content.ReadAsStringAsync();
                    List<Models.User> request = JsonSerializer.Deserialize<List<Models.User>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    if (request.Count > 0)
                    {
                        foreach (var item in request)
                        {
                            Console.WriteLine(item.Id.ToString() + " " + item.Name + " " + item.Gender + " " + item.Status);
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Escribiste informacion erronea");
                        Console.ReadLine();
                    }
                }
            }



            static async Task BuscarPorGenero(int desicion1)
            {
                string linea, url;
                HttpClient client = new HttpClient();

                Console.WriteLine("Introduzca el Genero(1-male 2 female):");
                linea = Console.ReadLine();
                desicion1 = Int32.Parse(linea);

                if (desicion1 == 1)
                {
                    linea = "male";
                }
                else {
                    linea = "female";
                }


                url = "https://gorest.co.in/public/v2/users?gender=" + linea;
                var HttpResponse = await client.GetAsync(url);
                if (HttpResponse.IsSuccessStatusCode)
                {
                    var content = await HttpResponse.Content.ReadAsStringAsync();
                    List<Models.User> request = JsonSerializer.Deserialize<List<Models.User>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    if (request != null)
                    {
                        foreach (var item in request)
                        {
                            Console.WriteLine(item.Id.ToString() + " " + item.Name + " " + item.Gender + " " + item.Status);
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Escribiste informacion erronea");
                        Console.ReadLine();
                    }
                }
            }



            static async Task BuscarPorEstado(int desicion1)
            {
                string linea, url;
                HttpClient client = new HttpClient();

                Console.WriteLine("Introduzca el Estado(1-active 2-inactive):");
                linea = Console.ReadLine();
                desicion1 = Int32.Parse(linea);

                if (desicion1 == 1)
                {
                    linea = "active";
                }
                else
                {
                    linea = "inactive";
                }


                url = "https://gorest.co.in/public/v2/users?status=" + linea;
                var HttpResponse = await client.GetAsync(url);
                if (HttpResponse.IsSuccessStatusCode)
                {
                    var content = await HttpResponse.Content.ReadAsStringAsync();
                    List<Models.User> request = JsonSerializer.Deserialize<List<Models.User>>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    if (request.Count > 0)
                    {
                        foreach (var item in request)
                        {
                            Console.WriteLine(item.Id.ToString() + " " + item.Name + " " + item.Gender + " " + item.Status);
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Escribiste informacion erronea");
                        Console.ReadLine();
                    }
                }
            }




        }
    }
}
