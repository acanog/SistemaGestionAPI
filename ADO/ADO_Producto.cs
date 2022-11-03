using SistemaGestionAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionAPI.ADO
{
    public class ADO_Producto
    {
        public static List<Producto> TraerProducto(int idUsuarioProducto)
        {
            var listaProductos = new List<Producto>();


            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 2
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Producto where idUsuario = @idUsuarioProducto";
                cmd.Parameters.Add(new SqlParameter("@idUsuarioProducto", idUsuarioProducto));


                var param = new SqlParameter("@idUsuarioProducto", SqlDbType.Int);
                param.Value = idUsuarioProducto;

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var produc = new Producto();

                    produc.Id = Convert.ToInt32(reader.GetValue(0));
                    produc.Descripcion = reader.GetValue(1).ToString();
                    produc.Costo = Convert.ToDouble(reader.GetValue(2));
                    produc.PrecioVenta = Convert.ToDouble(reader.GetValue(3));
                    produc.Stock = Convert.ToInt32(reader.GetValue(4));
                    produc.IdUsuario = Convert.ToInt32(reader.GetValue(5));

                    listaProductos.Add(produc);

                }

                reader.Close();
                connection.Close();


                return listaProductos;

            }


        }
        public static long CrearProducto(Producto producto)
        {
            long id;
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 2
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = "insert into Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";
                cmd1.Parameters.Add(new SqlParameter("Descripciones", SqlDbType.VarChar)).Value = producto.Descripcion;
                cmd1.Parameters.Add(new SqlParameter("Costo", SqlDbType.VarChar)).Value = producto.Costo;
                cmd1.Parameters.Add(new SqlParameter("PrecioVenta", SqlDbType.VarChar)).Value = producto.PrecioVenta;
                cmd1.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar)).Value = producto.Stock;
                cmd1.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar)).Value = producto.IdUsuario;
                connection.Close();
                id = Convert.ToInt64(cmd1.ExecuteScalar());

            }
            return id;


        }
        public static long ActualizarProducto(Producto producto)
        {
            int productos_Cambiados;
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 2
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "update Producto set Descripciones=@Descripciones, Costo=@Costo, PrecioVenta=@PrecioVenta, Stock=@Stock, IdUsuario=@IdUsuario where Id=@Id";
                cmd2.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = producto.Id;
                cmd2.Parameters.Add(new SqlParameter("@Descripciones", SqlDbType.VarChar)).Value = producto.Descripcion;
                cmd2.Parameters.Add(new SqlParameter("@Costo", SqlDbType.VarChar)).Value = producto.Costo;
                cmd2.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.VarChar)).Value = producto.PrecioVenta;
                cmd2.Parameters.Add(new SqlParameter("@Stock", SqlDbType.VarChar)).Value = producto.Stock;
                cmd2.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar)).Value = producto.IdUsuario;
                connection.Close();
                productos_Cambiados = Convert.ToInt32(cmd2.ExecuteNonQuery());

            }
            return productos_Cambiados;

        }
        public static Int32 EliminarProducto(long idProducto)
        {
            int productoEliminado;
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 2
                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "delete Producto where Id=@Id";
                cmd3.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = idProducto;
                connection.Close();
                productoEliminado = Convert.ToInt32(cmd3.ExecuteNonQuery());

            }

            return productoEliminado;
        }
        
    }
}
