using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web
{
    public class BasePage : System.Web.UI.Page
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        public enum FormModes { Alta, Baja, Modificacion }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        
    }
}