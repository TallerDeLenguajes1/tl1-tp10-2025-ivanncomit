// See https://aka.ms/new-console-template for more information
using EspacioTareas;
using System.Text.Json;

HttpClient cliente = new HttpClient();
string url = "https://jsonplaceholder.typicode.com/todos/";

Console.WriteLine("Obteniendo tareas desde la API...");
string responseJson = await cliente.GetStringAsync(url);

List<Tarea> tareas = JsonSerializer.Deserialize<List<Tarea>>(responseJson);

Console.WriteLine("\n--- TAREAS PENDIENTES ---");

foreach (var tarea in tareas)
{
    if (!tarea.completed)
    {
        Console.WriteLine($"Título: {tarea.title} | Estado: Pendiente");
    }
}

Console.WriteLine("\n--- TAREAS COMPLETADAS ---");
foreach (var tarea in tareas.FindAll(t => t.completed))
{
    if (tarea.completed)
    {
        Console.WriteLine($"Título: {tarea.title} | Estado: Completada");
    }
}

// Guardar archivo JSON localmente
string outputJson = JsonSerializer.Serialize(tareas, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("../tareas.json", outputJson);
Console.WriteLine("\nArchivo 'tareas.json' guardado en el directorio de ejecución.");