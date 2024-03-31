using Core.Midasoft.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Midasoft.Data
{
    public class GrupoFamiliarRespository
    {
        private readonly string? _connectionString;
        public GrupoFamiliarRespository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public async Task<List<GrupoFamiliar>> GetAll()
        {
            using SqlConnection sql = new(_connectionString);
            using SqlCommand cmd = new("SP_GET_GRUPO_FAMILIAR", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            var response = new List<GrupoFamiliar>();
            await sql.OpenAsync();

            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    response.Add(MapToValue(reader));
                }
            }

            return response;
        }

        private GrupoFamiliar MapToValue(SqlDataReader reader)
        {
            return new GrupoFamiliar()
            {
                Usuario = reader["USUARIO"].ToString()?.ToUpper(),
                Cedula = (int)reader["CEDULA"],
                Nombres = reader["NOMBRES"].ToString()?.ToUpper(),
                Apellidos = reader["APELLIDOS"].ToString()?.ToUpper(),
                Genero = reader["GENERO"].ToString()?.ToUpper(),
                Parentesco = reader["PARENTESCO"].ToString()?.ToUpper(),
                Edad = reader["EDAD"].ToString()?.ToUpper(),
                MenorEdad = (bool)reader["MENOR_EDAD"],
                FechaNacimiento = (DateTime)reader["FECHA_NACIMIENTO"]
            };
        }
    }
}
