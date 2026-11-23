using CrudProductos;

var productos = new List<Producto>();
var siguienteId = 1;
var opcion = "";

while (opcion != "0")
{
    Console.WriteLine("\n=== CRUD DE PRODUCTOS ===");
    Console.WriteLine("1. Crear producto");
    Console.WriteLine("0. Salir");
    Console.Write("Elige una opción: ");
    opcion = Console.ReadLine() ?? "";

    if (opcion == "1")
    {
        CrearProducto();
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