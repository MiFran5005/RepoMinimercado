Console.WriteLine("Minimercado");

public class Proveedores
{
    public int id { get; set; }
    public String? codigo { get; set; }
    public String? nombre { get; set; }
    public String? telefono { get; set; }
    public String? direccion { get; set; }

    public List<Productos> productos { get; set; }
    public List<Pedidos> pedidos { get; set; }
}

public class Estantes
{
    public int id { get; set; }
    public String? codigo { get; set; }
    public String? nombre { get; set; }
    public String? capacidad { get; set; }
    public String? ubicacion { get; set; }

    public List<Productos> productos { get; set; }
}

public class Categorias
{
    public int id { get; set; }
    public String? nombre { get; set; }
    public String? descripcion { get; set; }

    public List<Productos> productos { get; set; }
}

public class Marcas
{
    public int id { get; set; }
    public String? nombre { get; set; }
    public String? descripcion { get; set; }

    public List<Productos> productos { get; set; }
}

public class Inventarios
{
    public int id { get; set; }
    public int cantidad { get; set; }
    public DateTime actualizacion { get; set; }
    public int minimo { get; set; }
    public int maximo { get; set; }

    public List<Productos> productos { get; set; }
}

public class Contratos 
{
    public int id { get; set; }
    public String? fechaInicio { get; set; }
    public String? fechaFin { get; set; }
    public String? tipoContrato { get; set; }
    public String? descripcion { get; set; } 

    public List<Empleados_cargos> empleados_cargos { get; set; }
}

public class Clientes
{
    public int id { get; set; }
    public String? codigo { get; set; }
    public String? nombre { get; set; }
    public String? cedula { get; set; }
    public String? telefono { get; set; }

    public List<Detalles> detalles { get; set; }
}

public class MetodosPagos
{
    public int id { get; set; }
    public String? nombre { get; set; }

    public List<Detalles> detalles { get; set; }
}

public class Estados
{
    public int id { get; set; }
    public String? tipoEstado { get; set; }
    public String? nombre { get; set; }
    public String? descripcion { get; set; }

    public List<Detalles> detalles { get; set; }
}

public class Salarios
{
    public int id { get; set; }
    public int valor { get; set; }

    public List<Cargos> cargos { get; set;}
}

public class Horarios
{
    public int id { get; set; }
    public String? horaInicio { get; set; }
    public String? horaFinal { get; set; }
    public String? dia { get; set; }
    public String? turno { get; set; }

    public List<Cargos> cargos { get; set; }
}

public class Cargos
{
    public int id { get; set; }
    public String? tipoEmpleado { get; set; }
    public int salario { get; set; }
    public String? horario { get; set; }
    public String? descripcion { get; set; }

    public List<Empleados_cargos> empleados_cargos { get; set; }

    public Salarios? _salario { get; set; }
    public Horarios? _horario { get; set; }
}

public class Empleados
{
    public int id { get; set; }
    public String? nombre { get; set; }
    public String? cedula { get; set; }
    public String? telefono { get; set; }
    public String? carnet { get; set; }

    public List<Facturas> facturas { get; set; }
    public List<Pedidos> pedidos { get; set; }
    public List<Domicilios> domicilios { get; set; }
    public List<Empleados_cargos> empleados_cargos { get; set; }
}

public class Domicilios
{
    public int id { get; set; }
    public String? empleado { get; set; }
    public String? vehiculo { get; set; }
    public DateTime fecha { get; set; }
    public String? descripcion { get; set; } 

    public Empleados? _empleado { get; set; }
    public Vehiculos? _vehiculo { get; set; } 
}

public class Vehiculos
{
    public int id { get; set; }
    public String? codigo { get; set; }
    public String? nombre { get; set; }
    public String? placa { get; set; }
    public String? tipo { get; set; }

    public List<Domicilios> domicilios { get; set; } 
}

public class Empleados_cargos
{
    public int id { get; set; }
    public String? cargo { get; set; }
    public String? empleado { get; set; } 
    public String? contrato { get; set; }
    public DateTime fechaAsignacion { get; set; }

    public Empleados? _empleado { get; set; }
    public Cargos? _cargo { get; set; }
    public Contratos? _contrato { get; set; } 
}

public class Productos
{
    public int id { get; set; }
    public String? codigo { get; set; }
    public String? nombre { get; set; }
    public decimal precio { get; set; } 
    public decimal iva { get; set; }
    public String? proveedor { get; set; } 
    public String? estante { get; set; }
    public String? inventario { get; set; }
    
    public String? marca { get; set; } 
    public String? categoria { get; set; } 

    public List<Detalles> detalles { get; set; }

    public Proveedores? _proveedor { get; set; }
    public Estantes? _estante { get; set; }
    public Inventarios? _inventario { get; set; }
    
    public Categorias? _categoria { get; set; } 
    public Marcas? _marca { get; set; } 
}

public class Facturas
{
    public int id { get; set; }
    public int cantidad { get; set; }
    public int total { get; set; }
    public DateTime fecha { get; set; }
    public String? empleado { get; set; }

    public List<Detalles> detalles { get; set; }

    public Empleados? _empleado { get; set; }
}

public class Detalles
{
    public int id { get; set; }
    public String? factura { get; set; }
    public String? producto { get; set; }
    public String? cliente { get; set; }
    public String? domicilio { get; set; }
    public String? estado { get; set; }
    public String? metodoPago { get; set; } 

    public Productos? _producto { get; set; }
    public Clientes? _cliente { get; set; }
    public MetodosPagos? _metodo { get; set; }
    public Estados? _estado { get; set; }
    public Facturas? _factura { get; set; }
    public Domicilios? _domicilio { get; set; } 
}

public class Pedidos
{
    public int id { get; set; }
    public int cantidad { get; set; }
    public int total { get; set; }
    public String? empleado { get; set; }
    public DateTime fecha { get; set; }
    public String? proveedor { get; set; }

    public Proveedores? _proveedor { get; set; }
    public Empleados? _empleado { get; set; }
}