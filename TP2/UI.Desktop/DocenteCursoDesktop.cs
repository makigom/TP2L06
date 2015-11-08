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
    public partial class DocenteCursoDesktop : AplicationForm
    {
        public DocenteCursoDesktop()
            {
            InitializeComponent();

            CursoLogic CL = new CursoLogic();
            this.cbIDCurso.DataSource = CL.GetAll();
            this.cbIDCurso.DisplayMember = "id_curso";
            this.cbIDCurso.ValueMember = "id_curso";

            DocenteCursoLogic DCL = new DocenteCursoLogic();
            this.cbTipoCargo.DataSource = DCL.GetAll();
            this.cbTipoCargo.DisplayMember = "tipo_persona";
            this.cbTipoCargo.ValueMember = "cargo";
            }

        private DocenteCurso _DocenteCursoActual;

        public DocenteCurso DocenteCursoActual
        
            {
                get { return _DocenteCursoActual; }

                set { _DocenteCursoActual = value; }
            }

        public override void MapearDeDatos()
            {
            this.txtIDDictado.Text = this.DocenteCursoActual.ID.ToString();
            this.txtIDDocente.Text = this.DocenteCursoActual.IDDocente.ToString();
            this.cbIDCurso.Text = this.DocenteCursoActual.IDCurso.ToString();
            this.cbTipoCargo.Text = this.DocenteCursoActual.TipoCargo.ToString();

            switch (Modo)
                {
                case ModoForm.Alta:
                        {
                        this.btnAceptar.Text = "Guardar";
                        this.DocenteCursoActual.State = BusinessEntity.States.New;
                        }
                    break;
                case ModoForm.Modificacion:
                        {
                        this.btnAceptar.Text = "Guardar";
                        this.DocenteCursoActual.State = BusinessEntity.States.Modified;                        
                        }
                    break;
                case ModoForm.Baja:
                        {
                        this.btnAceptar.Text = "Eliminar";
                        this.DocenteCursoActual.State = BusinessEntity.States.Deleted;
                        } 
                    break;
                case ModoForm.Consulta:
                        {
                        this.btnAceptar.Text = "Aceptar";
                        this.DocenteCursoActual.State = BusinessEntity.States.Unmodified;
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
                DocenteCurso dca = new DocenteCurso();
                DocenteCursoActual = dca;

                this.DocenteCursoActual.IDDocente = Convert.ToInt32(this.txtIDDocente.Text);
                this.DocenteCursoActual.IDCurso = Convert.ToInt32(this.cbIDCurso.SelectedValue);
                this.DocenteCursoActual.TipoCargo = Convert.ToInt32(this.cbTipoCargo.SelectedValue);                
                }
            else if (Modo == AplicationForm.ModoForm.Modificacion)
                {
                    this.DocenteCursoActual.ID = Convert.ToInt32(this.txtIDDictado.Text);
                    this.DocenteCursoActual.IDDocente = Convert.ToInt32(this.txtIDDocente.Text);
                    this.DocenteCursoActual.IDCurso = Convert.ToInt32(this.cbIDCurso.SelectedValue);
                    this.DocenteCursoActual.TipoCargo = Convert.ToInt32(this.cbTipoCargo.SelectedValue); 
                }
            }

        public override void GuardarCambios() 
            {
            MapearADatos();
            DocenteCursoLogic DCL = new DocenteCursoLogic();
            DCL.Save(DocenteCursoActual);
            }

          public override bool Validar()
            {
                string mensaje = "";
                bool ok = true;

                foreach (Control c in this.Controls)
                {
                    if ((c is TextBox || c is ComboBox) && (c.Tag.ToString() != "ID") && (!Util.Util.IsComplete(c.Text))) mensaje += " - " + c.Tag.ToString() + "\n";
                }

                if (!string.IsNullOrEmpty(mensaje))
                {
                    mensaje = "Por favor complete los siguientes campos:\n" + mensaje;
                    ok = false;
                }

                if (!string.IsNullOrEmpty(mensaje)) Notificar(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ok;
            }

        public new  void Notificar(string titulo,string mensaje,MessageBoxButtons botones,MessageBoxIcon icono)
            {
            MessageBox.Show(titulo, mensaje,botones, icono);
            }

        public new void Notificar( string mensaje, MessageBoxButtons botones, MessageBoxIcon icono )
            {
            this.Notificar(this.Text, mensaje, botones, icono);
            }


        public DocenteCursoDesktop(ModoForm modo):this()
            {
            this.Modo = modo;   
            }

        public DocenteCursoDesktop(int ID, ModoForm modo): this()
            {
            this.Modo = modo;
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DocenteCursoActual = dcl.GetOne(ID);
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
