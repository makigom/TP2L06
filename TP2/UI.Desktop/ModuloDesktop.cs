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
    public partial class ModuloDesktop : AplicationForm
    {
        public ModuloDesktop()
        {
            InitializeComponent();
        }

        private Business.Entities.Modulo _ModuloActual;

        public Business.Entities.Modulo ModuloActual
        
            {
            get { return _ModuloActual; }

            set { _ModuloActual = value; }
            }

        public override void MapearDeDatos()
            {
            this.txtID.Text = this.ModuloActual.ID.ToString();        
            this.txtDescripcion.Text = this.ModuloActual.Descripcion;           
            this.txtEjecuta.Text = this.ModuloActual.Ejecuta;      

            switch (Modo)
                {
                case ModoForm.Alta:
                        {
                        this.btnAceptar.Text = "Guardar";
                        this.ModuloActual.State = BusinessEntity.States.New;
                        }
                    break;
                case ModoForm.Modificacion:
                        {
                        this.btnAceptar.Text = "Guardar";
                        this.ModuloActual.State = BusinessEntity.States.Modified;                        
                        }
                    break;
                case ModoForm.Baja:
                        {
                        this.btnAceptar.Text = "Eliminar";
                        this.ModuloActual.State = BusinessEntity.States.Deleted;
                        } 
                    break;
                case ModoForm.Consulta:
                        {
                        this.btnAceptar.Text = "Aceptar";
                        this.ModuloActual.State = BusinessEntity.States.Unmodified;
                        }
                    break;
                default:
                    break;
                }
            }

        public override void MapearADatos()
            {
            
            if (Modo == AplicationForm.ModoForm.Alta)
                {

                Business.Entities.Modulo m = new Business.Entities.Modulo();

                ModuloActual = m;
                 
                this.txtDescripcion.Text = this.ModuloActual.Descripcion;           
                this.txtEjecuta.Text = this.ModuloActual.Ejecuta;  
                 
                }
            else if (Modo == AplicationForm.ModoForm.Modificacion)
                {
                this.ModuloActual.ID = Convert.ToInt32(this.txtID.Text);            
                this.ModuloActual.Descripcion = this.txtDescripcion.Text;
                this.ModuloActual.Ejecuta = this.txtEjecuta.Text;                 
                }
            }

        public override void GuardarCambios() 
            {
            MapearADatos();

            ModuloLogic ML = new ModuloLogic();
            
            ML.Save(ModuloActual);
            }

      public override bool Validar()
            {

            int ban1=0;

             if ((this.txtDescripcion.Text == null) || (this.txtDescripcion.Text == null))
                    {
                    ban1 = 1;

                    Notificar("Error", "Todos los campos son obligatorios, por favor completelos a todos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

            if (ban1 == 1) return false;
                
            else return true;
            }
        
        public new  void Notificar(string titulo,string mensaje,MessageBoxButtons botones,MessageBoxIcon icono)
            {
            MessageBox.Show(mensaje,titulo, botones, icono);
            }

        public new void Notificar( string mensaje, MessageBoxButtons botones, MessageBoxIcon icono )
            {
            this.Notificar(this.Text, mensaje, botones, icono);
            }

        public ModuloDesktop(ModoForm modo):this()
            {
            this.Modo = modo;   
            }

        public ModuloDesktop(int ID, ModoForm modo): this()
            {
            this.Modo = modo;

            ModuloLogic ML = new ModuloLogic();

            ModuloActual = ML.GetOne(ID);
            
            MapearDeDatos();
            }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar() == true)
            {
                GuardarCambios();

                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult DR = (MessageBox.Show("Seguro que desea cancelar el proceso?", "Cancelar", MessageBoxButtons.YesNo));
            
            if (DR == DialogResult.Yes) this.Close();
        }
    }
}
