using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Business.Entities;
using Business.Logic;



namespace UI.Desktop
    {
    public partial class UsuarioDesktop : AplicationForm
        {
        public UsuarioDesktop()
            {
            InitializeComponent();
            }

        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        
            {
            get { return _UsuarioActual; }

            set { _UsuarioActual = value; }
            }

        public override void MapearDeDatos()
            {
            this.txtID.Text = this.UsuarioActual.ID.ToString();        
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;                      
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

            switch (Modo)
                {

                case ModoForm.Alta:
                        {
                        this.btnAceptar.Text = "Guardar";
                        this.UsuarioActual.State = BusinessEntity.States.New;
                        
                        }
                    break;
                case ModoForm.Modificacion:
                        {
                        this.btnAceptar.Text = "Guardar";
                        this.UsuarioActual.State = BusinessEntity.States.Modified;                        
                        }
                    break;
                case ModoForm.Baja:
                        {
                        this.btnAceptar.Text = "Eliminar";
                        this.UsuarioActual.State = BusinessEntity.States.Deleted;
                        } 
                    break;
                case ModoForm.Consulta:
                        {
                        this.btnAceptar.Text = "Aceptar";
                        this.UsuarioActual.State = BusinessEntity.States.Unmodified;
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
                Usuario usu = new Usuario();                
                UsuarioActual = usu;
                 
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;                
                this.UsuarioActual.Clave = this.txtClave.Text;                
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;                 
                }
            else if (Modo == AplicationForm.ModoForm.Modificacion)
                {
                this.UsuarioActual.ID = Convert.ToInt32(this.txtID.Text);            
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;                              
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;  
                }
            }

        public override void GuardarCambios() 
            {
            MapearADatos();
            UsuarioLogic UL = new UsuarioLogic();
            UL.Save(UsuarioActual);
            }


        public override bool Validar()
        {
            string mensaje = "";
            bool ok = true;

            foreach (Control c in this.Controls)
            {
                if ((c is TextBox) && (c.Tag.ToString() != "ID") && (!Util.Util.IsComplete(c.Text))) mensaje += " - " + c.Tag.ToString() + "\n";
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                mensaje = "Por favor complete los siguientes campos:\n" + mensaje;
                ok = false;
            }

            if (!(this.txtClave.Text.Equals(this.txtConfirmarClave.Text)) || (this.txtClave.Text.Length < 8))
            {
                mensaje += "La contraseña ingresada no coincide o posee menos de ocho caracteres.\n";
                ok = false;
            }

            if (!string.IsNullOrEmpty(mensaje)) Notificar(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return ok;
        }

        private void btnAceptar_Click( object sender, EventArgs e )
            {
            if (Validar() == true)
                {
                GuardarCambios();

                this.Close();
                }
            }

        //Agregandole new a los metodos void damos por sabido que el miembro que modificamos oculta el miembro que se hereda de la clase base.
        
        public new  void Notificar(string titulo,string mensaje,MessageBoxButtons botones,MessageBoxIcon icono)
            {
            MessageBox.Show(titulo,mensaje, botones, icono);
            }

        public new void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono )
            {
            this.Notificar(this.Text, mensaje, botones, icono);
            }

        public UsuarioDesktop(ModoForm modo):this()
            {
            this.Modo = modo;   
            }

        public UsuarioDesktop(int ID, ModoForm modo):this()
            {
            this.Modo = modo;
            UsuarioLogic UL = new UsuarioLogic();
            UsuarioActual = UL.GetOne(ID);
            MapearDeDatos();
            }

        private void btnCancelar_Click( object sender, EventArgs e )
            {
            DialogResult DR = (MessageBox.Show("Seguro que desea cancelar el proceso?","Cancelar", MessageBoxButtons.YesNo));
            if (DR == DialogResult.Yes) this.Close();      
            }

        private void UsuarioDesktop_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet.personas' Puede moverla o quitarla según sea necesario.
            this.personasTableAdapter.Fill(this.tp2_netDataSet.personas);

        }
        }
    }
