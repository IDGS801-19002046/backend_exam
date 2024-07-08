using System;
using System.Collections.Generic;

namespace Examen.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public string? Marca { get; set; }

    public string? Imagen { get; set; }

    public string? Categoria { get; set; }

    public string? Talla { get; set; }
}
