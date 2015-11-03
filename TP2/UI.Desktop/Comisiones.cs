using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            ComisionLogic CL = new ComisionLogic();

            List<Comision> l = CL.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop CD = new ComisionDesktop(AplicationForm.ModoForm.Alta);

            CD.ShowDialog();

            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count != 0)
            {

                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;

                ComisionDesktop CD = new ComisionDesktop(ID, AplicationForm.ModoForm.Modificacion);

                CD.ShowDialog();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvComisiones.SelectedRows.Count != 0)
            {
                int ID = ((Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;

                ComisionDesktop CD = new ComisionDesktop(ID, AplicationForm.ModoForm.Baja);

                CD.ShowDialog();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult DR = (MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo));

            if (DR == DialogResult.Yes) this.Close();
        }

    }
}
