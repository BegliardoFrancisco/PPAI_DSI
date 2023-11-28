using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPAI2023.Pantalla
{
    public partial class frmSituacionAccion : Form
    {

        double nro;
        public frmSituacionAccion(double nro)
        {
            InitializeComponent();
            this.nro = nro; 
        }

        private void frmSituacionAccion_Load(object sender, EventArgs e)
        {
            Thread.Sleep(3500);
            imagenExito.Visible = false;
            imagenIncorrecta.Visible = false;
            if (nro < 0.50) { lblSituacion.Text = "Acción realizada con éxito";  imagenExito.Visible = true; } else { lblSituacion.Text = "La acción no se pudo realizar con exito"; imagenIncorrecta.Visible = true; }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
