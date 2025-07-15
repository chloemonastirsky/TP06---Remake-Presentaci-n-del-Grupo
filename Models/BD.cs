using Microsoft.Data.SqlClient;
using Dapper;

public static class BD{
    private static string conexion = @"Server=localhost; DataBase=Presentacion; Integrated Security = True; TrustServerCertificate=True";

    public static int Login(string email, string contraseña){
        int encontrado=0;
        using(SqlConnection connection = new SqlConnection){
            string query = "select Contraseña from Usuario where email="+email;
            encontrado= connection.QueryFirstOrDefault<int>(query, new {pContraseña=contraseña});

        }

        if(encontrado==null){
            encontrado=-1;
        }

        return encontrado;
    }

    public static Usuario GetUsuario(int id){
        Usuario usuarioMostrar=null;

    }
}