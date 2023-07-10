using System.Data.SqlClient;
using Dapper;
namespace TP06Elecciones_Gayoso_TorreWalsh;
public class BD{
     private static string ConnectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=True;";
    private static List<Partido> ListPartidos = new List<Partido>();
    private static List<Candidato> ListCandidatos = new List<Candidato>();
    public static void AgregarCandidato(Candidato candidato){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSER INTO Candidato(ID_Candidato,ID_Partido,Apellido,Nombre,Nacimiento,Foto,Postulacion) VALUES (@pID_Candidato,@pID_Partido,@pApellido,@pNombre,@pNacimiento,@pFoto,@pPostulacion)";
            db.Execute(sql, new { pID_Candidato = candidato.IdCandidato, pID_Partido = candidato.IdPartido, pApellido = candidato.Apellido, pNombre = candidato.Nombre, pNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion});
        }
        //agregar candidato a BD
    }
    public static int EliminarCandidato(int idCandidato)
    {     
        int regEliminado = 0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Candidato WHERE ID_Candidato = @pidCandidato";
            regEliminado = db.Execute(sql, new { pidCandidato = idCandidato });
        }
        return regEliminado;
    }
    public static Partido VerInfoPartido(int idPartido){
        List<Partido> ListPartidos = null;
        for(int i=0; i<ListPartidos.Count(); i++){
            if(ListPartidos[i].IdPartido==idPartido)
            return ListPartidos[i];
        }
        return null;
    }
    public static Candidato VerInfoCandidato(int idCandidato){
        List<Candidato> ListCandidatos = null;
        for(int i=0; i<ListCandidatos.Count(); i++){
            if(ListCandidatos[i].IdCandidato==idCandidato)
            return ListCandidatos[i];
        }
        return null;
    }
    public static List<Partido> ListarPartidos()
    {
        List <Partido> ListPartidos = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Partido";
            ListPartidos = db.Query<Partido>(sql).ToList();
        }
        return ListPartidos;
    }
    //List<Candidato> llama a la clase
    public static List<Candidato> ListarCandidatos(int IdPartido)
    {
       List <Candidato> ListCandidatos = new List<Candidato>();
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE ID_Partido = @IdPartido";
            ListCandidatos = db.Query<Candidato>(sql, new{IDPartido=IdPartido}).ToList();
        }
        return ListCandidatos;
    }
    //db,db.Query --> conexion base de datos
}