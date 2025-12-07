using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GestorTareasWeb.Models
{
    public class TareaRepositorio
    {
        private readonly string cadenaConexion;

        public TareaRepositorio()
        {
            // Aquí leo la cadena de conexión que definí en Web.config
            cadenaConexion = ConfigurationManager.ConnectionStrings["CadenaConexionGestorTareas"].ConnectionString;
        }

        public List<Tarea> ObtenerTodasLasTareas()
        {
            var listaTareas = new List<Tarea>();

            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                string consultaSql = @"SELECT IdTarea, Titulo, Descripcion, FechaCreacion, FechaVencimiento, EstaCompletada
                                       FROM Tareas
                                       ORDER BY FechaCreacion DESC";

                using (var comandoSql = new SqlCommand(consultaSql, conexionSql))
                {
                    conexionSql.Open();

                    using (var lector = comandoSql.ExecuteReader())
                    {
                        // En este ciclo voy leyendo cada fila devuelta por la consulta
                        // y voy construyendo un objeto Tarea con esos datos.
                        while (lector.Read())
                        {
                            var tarea = new Tarea
                            {
                                IdTarea = Convert.ToInt32(lector["IdTarea"]),
                                Titulo = lector["Titulo"].ToString(),
                                Descripcion = lector["Descripcion"] == DBNull.Value ? null : lector["Descripcion"].ToString(),
                                FechaCreacion = Convert.ToDateTime(lector["FechaCreacion"]),
                                FechaVencimiento = lector["FechaVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(lector["FechaVencimiento"]),
                                EstaCompletada = Convert.ToBoolean(lector["EstaCompletada"])
                            };

                            listaTareas.Add(tarea);
                        }
                    }
                }
            }

            return listaTareas;
        }

        public Tarea ObtenerTareaPorId(int idTarea)
        {
            Tarea tareaEncontrada = null;

            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                string consultaSql = @"SELECT IdTarea, Titulo, Descripcion, FechaCreacion, FechaVencimiento, EstaCompletada
                                       FROM Tareas
                                       WHERE IdTarea = @IdTarea";

                using (var comandoSql = new SqlCommand(consultaSql, conexionSql))
                {
                    comandoSql.Parameters.AddWithValue("@IdTarea", idTarea);

                    conexionSql.Open();

                    using (var lector = comandoSql.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            tareaEncontrada = new Tarea
                            {
                                IdTarea = Convert.ToInt32(lector["IdTarea"]),
                                Titulo = lector["Titulo"].ToString(),
                                Descripcion = lector["Descripcion"] == DBNull.Value ? null : lector["Descripcion"].ToString(),
                                FechaCreacion = Convert.ToDateTime(lector["FechaCreacion"]),
                                FechaVencimiento = lector["FechaVencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(lector["FechaVencimiento"]),
                                EstaCompletada = Convert.ToBoolean(lector["EstaCompletada"])
                            };
                        }
                    }
                }
            }

            return tareaEncontrada;
        }

        public void CrearTarea(Tarea tareaNueva)
        {
            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                string comandoInsert = @"INSERT INTO Tareas (Titulo, Descripcion, FechaCreacion, FechaVencimiento, EstaCompletada)
                                         VALUES (@Titulo, @Descripcion, @FechaCreacion, @FechaVencimiento, @EstaCompletada)";

                using (var comandoSql = new SqlCommand(comandoInsert, conexionSql))
                {
                    comandoSql.Parameters.AddWithValue("@Titulo", tareaNueva.Titulo);
                    comandoSql.Parameters.AddWithValue("@Descripcion", (object)tareaNueva.Descripcion ?? DBNull.Value);
                    comandoSql.Parameters.AddWithValue("@FechaCreacion", tareaNueva.FechaCreacion);
                    comandoSql.Parameters.AddWithValue("@FechaVencimiento", (object)tareaNueva.FechaVencimiento ?? DBNull.Value);
                    comandoSql.Parameters.AddWithValue("@EstaCompletada", tareaNueva.EstaCompletada);

                    conexionSql.Open();
                    comandoSql.ExecuteNonQuery();
                }
            }
        }

        public void ActualizarTarea(Tarea tareaEditar)
        {
            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                string comandoUpdate = @"UPDATE Tareas
                                         SET Titulo = @Titulo,
                                             Descripcion = @Descripcion,
                                             FechaVencimiento = @FechaVencimiento,
                                             EstaCompletada = @EstaCompletada
                                         WHERE IdTarea = @IdTarea";

                using (var comandoSql = new SqlCommand(comandoUpdate, conexionSql))
                {
                    comandoSql.Parameters.AddWithValue("@Titulo", tareaEditar.Titulo);
                    comandoSql.Parameters.AddWithValue("@Descripcion", (object)tareaEditar.Descripcion ?? DBNull.Value);
                    comandoSql.Parameters.AddWithValue("@FechaVencimiento", (object)tareaEditar.FechaVencimiento ?? DBNull.Value);
                    comandoSql.Parameters.AddWithValue("@EstaCompletada", tareaEditar.EstaCompletada);
                    comandoSql.Parameters.AddWithValue("@IdTarea", tareaEditar.IdTarea);

                    conexionSql.Open();
                    comandoSql.ExecuteNonQuery();
                }
            }
        }

        public void EliminarTarea(int idTarea)
        {
            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                string comandoDelete = @"DELETE FROM Tareas WHERE IdTarea = @IdTarea";

                using (var comandoSql = new SqlCommand(comandoDelete, conexionSql))
                {
                    comandoSql.Parameters.AddWithValue("@IdTarea", idTarea);

                    conexionSql.Open();
                    comandoSql.ExecuteNonQuery();
                }
            }
        }

        public void CambiarEstadoTarea(int idTarea)
        {
            using (var conexionSql = new SqlConnection(cadenaConexion))
            {
                // Aquí no traigo el registro; simplemente invierto el valor de EstaCompletada en la base de datos.
                string comandoUpdate = @"UPDATE Tareas
                                         SET EstaCompletada = CASE WHEN EstaCompletada = 1 THEN 0 ELSE 1 END
                                         WHERE IdTarea = @IdTarea";

                using (var comandoSql = new SqlCommand(comandoUpdate, conexionSql))
                {
                    comandoSql.Parameters.AddWithValue("@IdTarea", idTarea);

                    conexionSql.Open();
                    comandoSql.ExecuteNonQuery();
                }
            }
        }
    }
}