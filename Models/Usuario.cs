
namespace TP06;
public class Usuario{

    public int Id {get; private set;}
    public string Nombre { get; private set; }
    public string Apellido{ get; private set; }
    public string Email {get; private set;}
    public string Contraseña {get; private set;}
    public DateTime FechaNacimiento { get; private set; }
    public string Foto {get; private set;}

    public Usuario(int Id, string Nombre, string Apellido, string Email, string Contraseña, DateTime FechaNacimiento, string Foto){
    }
    public int obtenerEdad(){
        DateTime fechaHoy= DateTime.Today;
        int edad;

        edad = (fechaHoy.Year)-(FechaNacimiento.Year);

        int dias = (fechaHoy-FechaNacimiento).Days;

        if(dias>0){
            edad=edad-1;
        }else{
            edad=edad;
        }
        
        return edad;
    }


}