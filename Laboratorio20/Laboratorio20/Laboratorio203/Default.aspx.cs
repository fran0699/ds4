using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Laboratorio203
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = @"Server=.\sqlexpress;Database=productos;trusted_Connection=true;";

        private bool EsNuevo
        {
            get
            {
                object valor = ViewState["EsNuevo"];
                return valor != null && (bool)valor;
            }
            set
            {
                ViewState["EsNuevo"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;

                tsbNuevo.Enabled = true;
                tsbGuardar.Enabled = false;
                tsbCancelar.Enabled = false;
                tsbEliminar.Enabled = false;

                txtId.Enabled = false;
                tsbBuscar.Enabled = true;
                txtNombre.Enabled = false;
                txtPrecio.Enabled = false;
                txtStock.Enabled = false;

                EsNuevo = false;
            }
        }

        // Mostrar mensaje genérico (error o información)
        private void MostrarMensaje(string mensaje, bool esError)
        {
            lblError.Text = mensaje;
            lblError.ForeColor = esError ? Color.Red : Color.Green;
            lblError.Visible = true;
        }

        private void MostrarError(string mensaje)
        {
            MostrarMensaje(mensaje, true);
        }

        private void MostrarInfo(string mensaje)
        {
            MostrarMensaje(mensaje, false);
        }

        private void OcultarMensaje()
        {
            lblError.Text = "";
            lblError.Visible = false;
        }


        protected void tsbNuevo_Click(object sender, ImageClickEventArgs e)
        {
            OcultarMensaje();

            tsbNuevo.Enabled = false;
            tsbGuardar.Enabled = true;
            tsbCancelar.Enabled = true;
            tsbEliminar.Enabled = false;
            tstId.Enabled = false;

            txtId.Enabled = false;
            tsbBuscar.Enabled = false;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtStock.Enabled = true;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            txtNombre.Focus();

            EsNuevo = true;
        }

        protected void tsbGuardar_Click(object sender, ImageClickEventArgs e)
        {
            OcultarMensaje();

            if (EsNuevo)
            {
                string sql = "INSERT INTO LAPTOPS (NOMBRE, PRECIO, STOCK) " +
                             "VALUES ('" + txtNombre.Text + "', '" + txtPrecio.Text + "', '" + txtStock.Text + "')";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MostrarInfo("Registro ingresado correctamente.");
                    }
                    else
                    {
                        MostrarError("No se pudo insertar el registro.");
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("Error al insertar: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                string sql = "UPDATE LAPTOPS SET NOMBRE='" + txtNombre.Text +
                             "', PRECIO='" + txtPrecio.Text +
                             "', STOCK='" + txtStock.Text +
                             "' WHERE id='" + txtId.Text + "'";

                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0)
                    {
                        MostrarInfo("Registro actualizado correctamente.");
                    }
                    else
                    {
                        MostrarError("No se encontró un registro con ese Id para actualizar.");
                    }
                }
                catch (Exception ex)
                {
                    MostrarError("Error al actualizar: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            tstId.Enabled = true;

            txtId.Enabled = false;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            EsNuevo = false;
        }

        protected void tsbCancelar_Click(object sender, ImageClickEventArgs e)
        {
            OcultarMensaje();

            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;
            tstId.Enabled = true;

            txtId.Enabled = false;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            EsNuevo = false;

            MostrarInfo("Operación cancelada.");
        }

        protected void tsbEliminar_Click(object sender, ImageClickEventArgs e)
        {
            OcultarMensaje();

            string sql = "DELETE FROM LAPTOPS WHERE id='" + this.txtId.Text + "'";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            try
            {
                int filasAfectadas = cmd.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MostrarInfo("Registro eliminado correctamente.");
                }
                else
                {
                    MostrarError("No se encontró un registro con ese Id para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al eliminar: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            tsbNuevo.Enabled = true;
            tsbGuardar.Enabled = false;
            tsbCancelar.Enabled = false;
            tsbEliminar.Enabled = false;

            txtId.Enabled = false;
            tsbBuscar.Enabled = true;
            txtNombre.Enabled = false;
            txtPrecio.Enabled = false;
            txtStock.Enabled = false;

            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
            EsNuevo = false;
        }

        protected void tsbBuscar_Click(object sender, ImageClickEventArgs e)
        {
            OcultarMensaje();

            string sql = "SELECT * FROM LAPTOPS WHERE ID=" + tstId.Text;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader reader;
            con.Open();

            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tsbNuevo.Enabled = false;
                    tsbGuardar.Enabled = true;
                    tsbCancelar.Enabled = true;
                    tsbEliminar.Enabled = true;

                    txtId.Enabled = false;
                    tsbBuscar.Enabled = false;
                    txtNombre.Enabled = true;
                    txtPrecio.Enabled = true;
                    txtStock.Enabled = true;

                    txtId.Text = reader[0].ToString();
                    txtNombre.Text = reader[1].ToString();
                    txtPrecio.Text = reader[2].ToString();
                    txtStock.Text = reader[3].ToString();

                    txtNombre.Focus();
                    EsNuevo = false;

                    MostrarInfo("Registro cargado correctamente.");
                }
                else
                {
                    MostrarError("Ningún registro encontrado con el Id ingresado.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error al buscar: " + ex.Message);
            }
            finally
            {
                con.Close();
            }

            tstId.Text = "";
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}