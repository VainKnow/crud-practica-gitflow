using CrudProductos;

var productos = new List<Producto>();
var siguienteId = 1;
var opcion = "";

while (opcion != "0")
{
    Console.WriteLine("\n=== CRUD DE PRODUCTOS ===");
    Console.WriteLine("1. Crear producto");
    Console.WriteLine("2. Listar productos");
    Console.WriteLine("3. Editar producto");
    Console.WriteLine("4. Eliminar producto");
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
    else if (opcion == "3")
    {
        EditarProducto();
    }
    else if (opcion == "4")
    {
        EliminarProducto();
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

void EditarProducto()
{
    Console.Write("Id del producto a editar: ");
    int.TryParse(Console.ReadLine(), out var id);

    var producto = productos.FirstOrDefault(p => p.Id == id);
    if (producto == null)
    {
        Console.WriteLine("No existe un producto con ese Id.");
        return;
    }

    Console.Write($"Nuevo nombre ({producto.Nombre}): ");
    var nombre = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(nombre))
    {
        producto.Nombre = nombre;
    }

    Console.Write($"Nuevo precio ({producto.Precio}): ");
    if (decimal.TryParse(Console.ReadLine(), out var precio))
    {
        producto.Precio = precio;
    }

    Console.Write($"Nuevo stock ({producto.Stock}): ");
    if (int.TryParse(Console.ReadLine(), out var stock))
    {
        producto.Stock = stock;
    }

    Console.WriteLine("Producto actualizado.");
}

void EliminarProducto()
{
    Console.Write("Id del producto a eliminar: ");
    int.TryParse(Console.ReadLine(), out var id);

    var producto = productos.FirstOrDefault(p => p.Id == id);
    if (producto == null)
    {
        Console.WriteLine("No existe un producto con ese Id.");
        return;
    }

    productos.Remove(producto);
    Console.WriteLine("Producto eliminado.");
}