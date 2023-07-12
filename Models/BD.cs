using System.Data.SqlClient;
using Dapper;
namespace TP06Elecciones_Gayoso_TorreWalsh;
public class BD{
     private static string ConnectionString = @"Server=localhost;DataBase=Elecciones;Trusted_Connection=True;";
    private static List<Partido> ListPartidos = new List<Partido>();
    private static List<Candidato> ListCandidatos = new List<Candidato>();
    public static void AgregarCandidato(Candidato candidato){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSER INTO Candidato(IdCandidato,IdPartido,Apellido,Nombre,FechaNacimiento,Foto,Postulacion) VALUES (@pIdCandidato,@pIdPartido,@pApellido,@pNombre,@pFechaNacimiento,@pFoto,@pPostulacion)";
            db.Execute(sql, new { pIdCandidato = candidato.IdCandidato, pIdPartido = candidato.IdPartido, pApellido = candidato.Apellido, pNombre = candidato.Nombre, pNacimiento = candidato.FechaNacimiento, pFoto = candidato.Foto, pPostulacion = candidato.Postulacion});
        }
        //agregar candidato a BD
    }
    public static int EliminarCandidato(int idCandidato)
    {     
        int regEliminado = 0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE * FROM Candidato WHERE IdCandidato = @pidCandidato";
            regEliminado = db.Execute(sql, new { pidCandidato = idCandidato });
        }
        return regEliminado;
    }
    public static void AgregarPartido(Partido partido){
        using (SqlConnection db = new SqlConnection(ConnectionString)){
            string sql = "INSER INTO Partido(IdPartido,Nombre,Logo,SitioWeb,FechaFundacion,CantidadDiputados,CantidadSenadores) VALUES (@pIdPartido,@pNombre,@pLogo,@pSitioWeb,@pFechaFundacion,@pCantidadDiputados,@pCantidadSenadores)";
            db.Execute(sql, new { pIdPartido = partido.IdPartido, pNombre = partido.Nombre, pLogo = partido.Logo, pSitioWeb = partido.SitioWeb, pFechaFundacion = partido.FechaFundacion, pCantidadDiputados = partido.CantidadDiputados, pCantidadSenadores = partido.CantidadSenadores});
        }
        //agregar candidato a BD
    }
    public static int EliminarPartido(int idPartido){
        int regEliminado=0;
        using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "DELETE FROM Partido WHERE IdPartido = @pidPartido";
            regEliminado = db.Execute(sql, new { pidPartido = idPartido });
        }
        return regEliminado;
    }
    public static Partido VerInfoPartido(int idPartido){
        Partido infoPartido = null;
         using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Partido WHERE IdPartido = @idPartido";
            infoPartido = db.QueryFirstOrDefault<Partido>(sql, new{IdPartido=idPartido});
        }
        return infoPartido;
    }
    public static Candidato VerInfoCandidato(int idCandidato){
        Candidato infoCandidato = null;
         using (SqlConnection db = new SqlConnection(ConnectionString))
        {
            string sql = "SELECT * FROM Candidato WHERE IdCandidato = @idCandidato";
            infoCandidato = db.QueryFirstOrDefault<Candidato>(sql, new{IdCandidato=idCandidato});
        }
        return infoCandidato;
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