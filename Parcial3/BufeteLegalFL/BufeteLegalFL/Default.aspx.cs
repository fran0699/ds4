using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BufeteLegalFL
{
    public partial class Default : System.Web.UI.Page
    {
        // Cadena de conexión obtenida desde el Web.config
        string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionBufete"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // En el primer cargado de la página quiero mostrar los casos
                CargarCasosDesdeBaseDatos();
            }
        }

        private void CargarCasosDesdeBaseDatos()
        {
            // Uso un try-catch por si ocurre algún error de conexión o consulta
            try
            {
                // Abro la conexión con la base de datos
                using (SqlConnection conexionSql = new SqlConnection(cadenaConexion))
                {
                    // Esta consulta une casos con clientes y abogados para mostrar nombres descriptivos
                    string consultaCasos = @"
                        SELECT 
                            c.CodigoCaso,
                            c.Titulo,
                            cli.NombreCompleto AS NombreCliente,
                            abo.NombreCompleto AS NombreAbogado,
                            c.FechaInicio,
                            c.FechaVencimiento,
                            c.Estado
                        FROM FL_Casos c
                        INNER JOIN FL_Clientes cli ON c.IdCliente = cli.IdCliente
                        INNER JOIN FL_Abogados abo ON c.IdAbogadoAsignado = abo.IdAbogado;";

                    // Creo el comando SQL con la consulta y la conexión
                    using (SqlCommand comando = new SqlCommand(consultaCasos, conexionSql))
                    {
                        // El SqlDataAdapter me permite ejecutar la consulta y llenar un DataTable
                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            DataTable tablaCasos = new DataTable();

                            // Aquí ejecuto la consulta y lleno la tabla en memoria
                            adaptador.Fill(tablaCasos);

                            // Enlazo el GridView a la tabla para mostrar los datos
                            gvCasos.DataSource = tablaCasos;
                            gvCasos.DataBind();
                        }
                    }
                }

                // Si todo sale bien, muestro un mensaje en verde
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Los casos se cargaron correctamente desde la base de datos.";
            }
            catch (Exception ex)
            {
                // Si ocurre un error, lo muestro en rojo para saber qué pasó
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "Error al cargar los casos: " + ex.Message;
            }
        }
    }
}
