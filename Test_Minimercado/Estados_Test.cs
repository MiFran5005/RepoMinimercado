using Lib_Minimercado.entidades;
using Lib_Minimercado.implementaciones;
using Microsoft.EntityFrameworkCore;

namespace Test_Minimercado
{
    [TestClass]
    public class Estados_Test
    {
        private Conexion conexion;
        private Estados entidad;

        public Estados_Test()
        {
            this.conexion = new Conexion();
            conexion.StringConexion = "server=localhost\\DEV;database=db_minimercado;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Ejecutar()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        private void Insertar()
        {
            entidad = new Estados()
            {
                TipoEstado = "Pedidos",
                Nombre = "Pendiente",
                Descripcion = "Estado pendiente de aprobación"
            };

            this.conexion.Estados!.Add(this.entidad!);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista_estados = this.conexion.Estados!.ToList();
            if (lista_estados.Count <= 0)
                throw new Exception("Lista vacia");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Entregado";
            this.entidad!.Descripcion = "Estado entregado";

            var entry = this.conexion!.Entry<Estados>(this.entidad);
            entry.State = EntityState.Modified;
            this.conexion!.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Estados!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
