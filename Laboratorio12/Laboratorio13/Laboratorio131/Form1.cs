using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Laboratorio131
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string connectionString = @"Server=.\sqlexpress;Database=Northwind;TrustServerCertificate=true;Integrated Security=SSPI;";
        bool conectadoABaseDeDato = true;

        private void btnConectarDesconectar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection(connectionString);
            if (conectadoABaseDeDato)
            {
                conexion.Open();
                MessageBox.Show("Se abrió la conexión con el servidor SQL Server y se eleccionó la base de datos");
                SqlCommand cmd = new SqlCommand("SELECT ProductName FROM Products", conexion);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lbProductos.Items.Add(rd["ProductName"].ToString());
                }
                rd.Close();
                conectadoABaseDeDato = false;
            }
            else
            {
                conexion.Close();
                MessageBox.Show("Se cerró la conexión.");
                lbProductos.Items.Clear();
                conectadoABaseDeDato = true;
            }

        }
    }
}
