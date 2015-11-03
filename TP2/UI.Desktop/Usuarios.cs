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
    public partial class Usuarios : Form
        {
        public Usuarios()
            {
            InitializeComponent();
            }

        private void tlUsuarios_Paint( object sender, PaintEventArgs e )
            {

            }

        public void Listar()
            {
            UsuarioLogic UL = new UsuarioLogic();
            this.dgvUsuarios.AutoGenerateColumns = true;
            List<Usuario> l = UL.GetAll();
            this.dgvUsuarios.DataSource = l;
            }

        private void Usuarios_Load( object sender, EventArgs e )
            {
            Listar();
            }

        private void btnActualizar_Click( object sender, EventArgs e )
            {
            Listar();
            }

        private void btnSalir_Click( object sender, EventArgs e )
            {    
            
            DialogResult DR = (MessageBox.Show("Seguro que dese salir?", "Salir", MessageBoxButtons.YesNo));

            if (DR == DialogResult.Yes) this.Close();        

            }

        private void tsbNuevo_Click( object sender, EventArgs e )
            {
            UsuarioDesktop UD = new UsuarioDesktop(AplicationForm.ModoForm.Alta);
            UD.Text = "Alta usuario";
            UD.ShowDialog();

            this.Listar();
            }

        private void tsbEditar_Click( object sender, EventArgs e )
            {
            if (this.dgvUsuarios.SelectedRows.Count != 0)
                {

                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

                UsuarioDesktop UD = new UsuarioDesktop(ID, AplicationForm.ModoForm.Modificacion);
                UD.Text = "Editar usuario";
                UD.ShowDialog();
                this.Listar();
                }
  
            }

        private void tsbEliminar_Click( object sender, EventArgs e )
            {
            if (this.dgvUsuarios.SelectedRows.Count != 0)
                {

                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

                UsuarioDesktop UD = new UsuarioDesktop(ID, AplicationForm.ModoForm.Baja);
                UD.Text = "Eliminar usuario";
                UD.ShowDialog();
                }
            }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        }
    }
