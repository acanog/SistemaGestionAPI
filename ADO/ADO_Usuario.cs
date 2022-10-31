using SistemaGestionAPI.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace SistemaGestionAPI.ADO
{
    public class ADO_Usuario
    {
        public static Usuario TraerUsuario(string nombreUsuario)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 1
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from Usuario where nombreUsuario = @nombreUsuario";
                cmd.Parameters.Add(new SqlParameter("nombreUsuario", nombreUsuario));


                //var param = new SqlParameter("@nombreUsuario", SqlDbType.VarChar);
                //param.Value = nombreUsuario;

                var reader = cmd.ExecuteReader();
                var User = new Usuario();

                while (reader.Read())
                {


                    User.Id = Convert.ToInt32(reader.GetValue(0));
                    User.Nombre = reader.GetValue(1).ToString();
                    User.Apellido = reader.GetValue(2).ToString();
                    User.NombreUsuario = reader.GetValue(3).ToString();
                    User.Contraseña = reader.GetValue(4).ToString();
                    User.Mail = reader.GetValue(5).ToString();

                }
                reader.Close();
                connection.Close();
                return User;
            }


        }
        public static Usuario IniciarSesion(string nombreUsuario, string contraseña)
        {
            SqlConnectionStringBuilder conecctionbuilder = new SqlConnectionStringBuilder();
            conecctionbuilder.DataSource = "DESKTOP-RRAI8UU";
            conecctionbuilder.InitialCatalog = "dbSistemaGestionCoder";
            conecctionbuilder.IntegratedSecurity = true;
            var cs = conecctionbuilder.ConnectionString;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();

                //  Punto 6
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "select NombreUsuario, Contraseña from Usuario where NombreUsuario=@nombreUsuario and Contraseña=@Contraseña";
                cmd2.Parameters.Add(new SqlParameter("nombreUsuario", nombreUsuario));
                cmd2.Parameters.Add(new SqlParameter("Contraseña", contraseña));

                var reader2 = cmd2.ExecuteReader();
                var User = new Usuario();
                if (reader2 != null)
                {
                    User.NombreUsuario = reader2.GetValue(3).ToString();
                    User.Contraseña = reader2.GetValue(4).ToString();
                }
                reader2.Close();
                connection.Close();
                return User;

            }

        }
        public static long CrearUsuario(Usuario usuario)
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

                //  Punto 6
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "insert into Usuario values(Nombre=@Nombre,Apellido=@Apellido,NombreUsuario=@NombreUsuario,Contraseña=@Contraseña,Mail=@Mail)";
                cmd2.Parameters.Add(new SqlParameter("Nombre", SqlDbType.VarChar)).Value = usuario.Nombre;
                cmd2.Parameters.Add(new SqlParameter("Apellido", SqlDbType.VarChar)).Value = usuario.Apellido;
                cmd2.Parameters.Add(new SqlParameter("NombreUsuario", SqlDbType.VarChar)).Value = usuario.NombreUsuario;
                cmd2.Parameters.Add(new SqlParameter("Contraseña", SqlDbType.VarChar)).Value = usuario.Contraseña;
                cmd2.Parameters.Add(new SqlParameter("Mail", SqlDbType.VarChar)).Value = usuario.Mail;
                id = Convert.ToInt64(cmd2.ExecuteScalar());

                connection.Close();
                return id;

            }

        }
        public static long ActualizarUsuario(Usuario usuario)
        {
            int usuario_Cambiado;
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
                cmd3.CommandText = "update Usuario set Nombre=@Nombre,Apellido=@Apellido,NombreUsuario=@NombreUsuario,Contraseña=Contraseña,Mail=@Mail where Id=@IdUsuario";
                cmd3.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = usuario.Nombre;
                cmd3.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar)).Value = usuario.Apellido;
                cmd3.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.VarChar)).Value = usuario.NombreUsuario;
                cmd3.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.VarChar)).Value = usuario.Contraseña;
                cmd3.Parameters.Add(new SqlParameter("@Mail", SqlDbType.VarChar)).Value = usuario.Mail;
                cmd3.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.VarChar)).Value = usuario.Id;
                connection.Close();
                usuario_Cambiado = Convert.ToInt32(cmd3.ExecuteNonQuery());

            }
            return usuario_Cambiado;

        }
        public static long BorrarUsuario(Usuario usuario)
        {
            int usuarioEliminado;
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
                cmd4.CommandText = "delete Usuario where Id=@Id";
                cmd4.Parameters.Add(new SqlParameter("@Id", SqlDbType.VarChar)).Value = usuario.Id;
                connection.Close();
                usuarioEliminado = Convert.ToInt32(cmd4.ExecuteNonQuery());

            }

            return usuarioEliminado;
        }



        

        internal static void UpdateUser(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        internal static Usuario TraerUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
