using System.Data.SqlClient;
using Dapper;
namespace TP06Elecciones_Gayoso_TorreWalsh;
public class BD{
     private static string ConnectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=True;";
    public static void AgregarCandidato(Candidato candidato){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSER INTO Candidato(ID_Candidato,ID_Partido,Apellido,Nombre,Nacimiento,Foto,Postulacion) VALUES (@pID_Candidato,@pID_Partido,@pApellido,@pNombre,@pNacimiento,@pFoto,@pPostulacion)";
            db.Execute(sql, new { pID_Candidato = candidato.IdCandidato, pID_Partido = candidato.IdPartido, pApellido = candidato.Apellido, pNombre = candidato.Nombre, pNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion});
        }
        //agregar candidato a BD
    }
    public static void EliminarCandidato(int idCandidato)
    {     
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Candidato WHERE ID_Candidato = @pidCandidato";
            db.Execute(sql, new { pidCandidato = idCandidato });
        }
    }
    public static Partido VerInfoPartido(int idPartido){
        
        Partido partido = null;
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "SELECT * FROM Partido WHERE ID_Partido = @ID_Partido";
            partido = db.QueryFirstOrDefault<Partido>(sql, new { pID_Partido = idPartido});
        }
        return partido;
    }
    public static Candidato VerInfoCandidato(int idCandidato){
        Candidato candidato = null;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE ID_Candidato = @pID_Candidato";
            candidato = db.QueryFirstOrDefault<Candidato>(sql, new {pID_Candidato = idCandidato});
        }
        return candidato;
    }
    public static List<Partido> ListarPartidos(){
        List <Partido> ListPartidos = new List<Partido>();
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