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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            EspecialidadLogic EL = new EspecialidadLogic();

            this.dgvEspecialidades.DataSource = EL.GetAll();
        }

        private void Especialidades_Load_1(object sender, EventArgs e)
        {
            Listar();
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

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ED = new EspecialidadDesktop(AplicationForm.ModoForm.Alta);
           
            ED.ShowDialog();

            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count != 0)
            {

                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadDesktop ED = new EspecialidadDesktop(AplicationForm.ModoForm.Modificacion);

                ED.ShowDialog();
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count != 0)
            {

                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadDesktop ED = new EspecialidadDesktop(AplicationForm.ModoForm.Baja);

                ED.ShowDialog();
            }
        }

    }
}
