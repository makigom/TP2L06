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
    public partial class DocentesCursos : AplicationForm
    {
        public DocentesCursos()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            DocenteCursoLogic DCL = new DocenteCursoLogic();
            this.dgvDocenteCurso.DataSource = DCL.GetAll();
        }

        private void DocenteCurso_Load(object sender, EventArgs e)
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
            DocenteCursoDesktop DCD = new DocenteCursoDesktop(AplicationForm.ModoForm.Alta);
            DCD.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocenteCurso.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocenteCurso.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop DCD = new DocenteCursoDesktop(ID, AplicationForm.ModoForm.Modificacion);
                DCD.ShowDialog();
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDocenteCurso.SelectedRows.Count != 0)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDocenteCurso.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop DCD = new DocenteCursoDesktop(ID, AplicationForm.ModoForm.Baja);
                DCD.ShowDialog();
            }
        }
    }
}
