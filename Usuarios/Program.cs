// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using EspacioUsuarios;

HttpClient cliente = new HttpClient();
string url = "https://jsonplaceholder.typicode.com/users";

Console.WriteLine("Obteniendo tareas desde la API...");
string responseJson = await cliente.GetStringAsync(url);


List<Usuario> usuarios = JsonSerializer.Deserialize<List<Usuario>>(responseJson);

Console.WriteLine("\n--- Primeros 5 usuarios ---");

int contador = 5;


foreach (var user in usuarios)
{
    if (contador > 0)
    {
        Console.WriteLine($"\nNombre: {user.name}\nCorreo: {user.email}\nDireccion: {user.address.city} | {user.address.street} | {user.address.suite}\n");
        contador--;
    }
}
