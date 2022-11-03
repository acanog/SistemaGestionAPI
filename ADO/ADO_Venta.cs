using SistemaGestionAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaGestionAPI.ADO
{
    public class ADO_Venta
    {
        public static List<Venta> TraerVentas(int IdUsuario)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {

                var listaVentas = new List<Venta>();

                connection.Open();


                //  Punto 4
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "select * from Venta where IdUsuario = @idUsuarioV";
                cmd4.Parameters.Add(new SqlParameter("idUsuarioV", IdUsuario));


                var param4 = new SqlParameter("@idUsuarioV", SqlDbType.Int);
                param4.Value = IdUsuario;

                var reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    var ventas = new Venta();

                    ventas.Id = Convert.ToInt32(reader4.GetValue(0));
                    ventas.Comentarios = reader4.GetValue(1).ToString();
                    ventas.IdUsuario = Convert.ToInt32(reader4.GetValue(2));

                    listaVentas.Add(ventas);

                }

                reader4.Close();
                connection.Close();
                return listaVentas;

            }

        }
        public static long CargarVenta(InsertarVenta venta)
        {
            var listaProductosVendidos = new List<ProductoVendido>();
            var listaProductos= new List<Producto>();
            long idVenta;
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                //  Punto 4
                SqlCommand cmd1 = connection.CreateCommand();
                cmd1.CommandText = "insert into Venta values(@Comentarios,@IdUsuario)";
                cmd1.Parameters.Add(new SqlParameter("Comentarios", SqlDbType.VarChar)).Value = venta.Venta.Comentarios;
                cmd1.Parameters.Add(new SqlParameter("IdUsuario", SqlDbType.VarChar)).Value = venta.Venta.IdUsuario;

                idVenta = Convert.ToInt64(cmd1.ExecuteScalar());

                foreach (var lista in listaProductosVendidos)
                {
                    var productovendido = new ProductoVendido();
                    SqlCommand cmd2 = connection.CreateCommand();
                    cmd2.CommandText = "insert into ProductoVendido values (Stock=@Stock,IdProducto=@IdProducto,IdVenta=@IdVenta)";
                    cmd2.Parameters.Add(new SqlParameter("Stock", SqlDbType.VarChar)).Value = productovendido.Stock;
                    cmd2.Parameters.Add(new SqlParameter("IdProducto", SqlDbType.VarChar)).Value = productovendido.IdProducto;
                    cmd2.Parameters.Add(new SqlParameter("IdVenta", SqlDbType.VarChar)).Value = productovendido.IdVenta;
                }
                foreach (var lista in listaProductos)
                {
                    var productovendido = new ProductoVendido();
                    var producto = new Producto();
                    SqlCommand cmd3 = connection.CreateCommand();
                    cmd3.CommandText = "update Producto set Stock=(Stock-@IdStockPV) where Id =@IdStock";
                    cmd3.Parameters.Add(new SqlParameter("IdStock", SqlDbType.VarChar)).Value = producto.Id;
                    cmd3.Parameters.Add(new SqlParameter("IdStockPV", SqlDbType.VarChar)).Value = productovendido.Stock;
                }


                connection.Close();
                return idVenta;

            }


        }


        
    }
}
