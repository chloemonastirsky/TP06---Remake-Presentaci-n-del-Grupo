
namespace TP06;
using System.Data.SqlClient;
using Dapper;

public static class BD{
    private static string conexion = @"Server=localhost; DataBase=Presentacion; Integrated Security = True; TrustServerCertificate=True";

    public static int Login(string email, string contraseña){
        int encontrado=0;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select Usuario.Id from Usuario where email=@pemail and contraseña = @pcontraseña";
            encontrado= connection.QueryFirstOrDefault<int>(query, new {pemail = email, pcontraseña = contraseña});
        }

        if(encontrado==0){
            encontrado=-1;
        }

        return encontrado;
    }

    public static Usuario GetUsuario(int id){
        Usuario usuarioMostrar=null;

        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select Usuario.Id, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Contraseña, Usuario.FechaNacimiento, Usuario.Foto from Usuario where id=@pId";
            usuarioMostrar= connection.QueryFirstOrDefault<Usuario>(query, new {pid=id});
        }

        return usuarioMostrar;

    }

    public static List<DatoFamiliar> GetDatoFamiliar(int id) {

        List<DatoFamiliar> LDatosFliares=null;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select DatoFamiliar.IdUsuario, DatoFamiliar.Nombre, DatoFamiliar.Apellido, DatoFamiliar.Parentesco, DatoFamiliar.Descripcion from DatoFamiliar where id=@pid";
            LDatosFliares= connection.Query<DatoFamiliar>(query).ToList();
        }

        return LDatosFliares;

    }

    public static  List<DatoInteres> GetDatoInteres(int id){
        
        List<DatoInteres> LDatoInteres=null;
        using(SqlConnection connection = new SqlConnection(conexion)){
            string query = "select  DatoInteres.Id, DatoInteres.IdUsuario, DatoInteres.TipoInteres, DatoInteres.Interes from DatoInteres where id=@pid";
            LDatoInteres= connection.Query<DatoInteres>(query).ToList();
        }

        return LDatoInteres;
    }
}