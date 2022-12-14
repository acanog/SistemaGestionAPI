using SistemaGestionAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionAPI.ADO
{
    public class ADO_ProductoVendido
    {
        public static List<Producto> TraerProductoVendido(int idUsuarioProducto)
        {


            var listaProductosVendidos = new List<Producto>();

            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 3
                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "select p.Id,Descripciones,Costo,PrecioVenta,pv.Stock,IdUsuario from Producto as p inner join ProductoVendido as pv on pv.IdProducto = p.Id where idUsuario = @idUsuarioProducto";
                cmd3.Parameters.Add(new SqlParameter("idUsuarioProducto", idUsuarioProducto));


                var param3 = new SqlParameter("@idUsuarioPV", SqlDbType.Int);
                param3.Value = idUsuarioProducto;

                var reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    var producVend = new Producto();

                    producVend.Id = Convert.ToInt32(reader3.GetValue(0));
                    producVend.Descripcion = reader3.GetValue(1).ToString();
                    producVend.Costo = Convert.ToDouble(reader3.GetValue(2));
                    producVend.PrecioVenta = Convert.ToDouble(reader3.GetValue(3));
                    producVend.Stock = Convert.ToInt32(reader3.GetValue(4));
                    producVend.IdUsuario = Convert.ToInt32(reader3.GetValue(5));

                    listaProductosVendidos.Add(producVend);

                }

                reader3.Close();
                connection.Close();

                return listaProductosVendidos;


            }

        }
        public static Int32 EliminarProductoVendido(long idProducto)
        {
            int productoVendidoEliminado;
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 2
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "delete ProductoVendido where IdProducto=@Id";
                cmd4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = idProducto;
                connection.Close();
                productoVendidoEliminado = Convert.ToInt32(cmd4.ExecuteNonQuery());

            }

            return productoVendidoEliminado;
        }
    }
}
