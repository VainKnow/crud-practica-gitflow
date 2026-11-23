using CrudProductos;

var productos = new List<Producto>();
var siguienteId = 1;
var opcion = "";

while (opcion != "0")
{
    Console.WriteLine("\n=== CRUD DE PRODUCTOS ===");
    Console.WriteLine("1. Crear producto");
    Console.WriteLine("2. Listar productos");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opción: ");
    opcion = Console.ReadLine() ?? "";

    if (opcion == "1")
    {
        CrearProducto();
    }
    else if (opcion == "2")
    {
        ListarProductos();
    }
}

void CrearProducto()
{
    Console.Write("Nombre: ");
    var nombre = Console.ReadLine() ?? "";

    Console.Write("Precio: ");
    decimal.TryParse(Console.ReadLine(), out var precio);

    Console.Write("Stock: ");
    int.TryParse(Console.ReadLine(), out var stock);

    productos.Add(new Producto
    {
        Id = siguienteId++,
        Nombre = nombre,
        Precio = precio,
        Stock = stock
    });

    Console.WriteLine($"Producto creado. Total en memoria: {productos.Count}");
}

void ListarProductos()
{
    if (productos.Count == 0)
    {
        Console.WriteLine("No hay productos registrados.");
        return;
    }

    Console.WriteLine("\nID | Nombre | Precio | Stock");
    foreach (var p in productos)
    {
        Console.WriteLine($"{p.Id} | {p.Nombre} | {p.Precio:C} | {p.Stock}");
    }
}