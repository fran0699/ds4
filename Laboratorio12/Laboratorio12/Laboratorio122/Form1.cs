using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio122
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPromedio_Click(object sender, EventArgs e)
        {
            if(!double.TryParse(txtbNota1.Text, out double nota1) || nota1 < 0)
            {
                MessageBox.Show("Ingrese una nota válida para nota 1 y no negativa.",
                    "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbNota1.Clear();
                txtbNota1.Focus();
                return;
            }
            if (!double.TryParse(txtbNota2.Text, out double nota2) || nota2 < 0)
            {
                MessageBox.Show("Ingrese una nota válida para nota 2 y no negativa.",
                    "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbNota2.Clear();
                txtbNota2.Focus();
                return;
            }
            if (!double.TryParse(txtbNota3.Text, out double nota3) || nota3 < 0)
            {
                MessageBox.Show("Ingrese una nota válida para nota 3 y no negativa.",
                    "Dato Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtbNota3.Clear();
                txtbNota3.Focus();
                return;
            }
            double promedio = (nota1 + nota2 + nota3) / 3;
            txtbNotaPromedio.Text = promedio.ToString("N2");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbNota1.Clear();
            txtbNota2.Clear(); 
            txtbNota3.Clear();
            txtbNotaPromedio.Clear();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
