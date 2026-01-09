using projSkyNetz.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projSkyNetz.View
{
    public partial class Planos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDados();
            }
        }

        private void CarregarDados()
        {
            #region planos
            try
            {
                DataTable dt = new PlanosDAO().Selecionar_planos();

                if(dt != null && dt.Rows.Count > 0)
                {
                    rptPlanos.DataSource = dt;
                    rptPlanos.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Erro!', 'Erro ao carregar os planos. Tente novamente mais tarde.', 'error');", true);
                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Erro!', 'Erro ao carregar os planos. Tente novamente mais tarde.', 'error');" , true);
            }
            #endregion


            #region Combos
            try
            {
                DataTable dt = new PlanosDAO().Selecionar_cidades();

                if (dt != null && dt.Rows.Count > 0)
                {
                    // Origem
                    ddlLocalOrigem.DataSource = dt;
                    ddlLocalOrigem.DataBind();
                    ddlLocalOrigem.Items.Insert(0, new ListItem("Selecione", "-1") { Selected = true });

                    // Destino
                    ddlLocalDestino.DataSource = dt;
                    ddlLocalDestino.DataBind();
                    ddlLocalDestino.Items.Insert(0, new ListItem("Selecione", "-1") { Selected = true });
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Erro!', 'Erro ao carregar os locais. Tente novamente mais tarde.', 'error');", true);
                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Erro!', 'Erro ao carregar os locais. Tente novamente mais tarde.', 'error');", true);
            }
            #endregion

        }

        protected void btnCotar_Click(object sender, EventArgs e)
        {
            // Validação dos campos de origem e destino
            if (ddlLocalOrigem.SelectedValue == "-1" || ddlLocalDestino.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Selecione a origem e o destino para continuar.', 'warning');", true);
                return;
            }
            
            // Validação do campo de duração
            if (string.IsNullOrEmpty(txtDuracaoLigacao.Text))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Digite a duração da ligação desejada para continuar.', 'warning');", true);
                return;
            }



            ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderLoading", "esconderLoading();", true);

        }

        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)sender;
            string id = ddl.ID;


            // Valida se os locais não tem o mesmo ddd
            if (ddlLocalOrigem.SelectedValue == ddlLocalDestino.SelectedValue)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Não é possível selecionar locais com o mesmo DDD.', 'warning');", true);
                
                // Limpa os campos
                ddlLocalOrigem.SelectedValue = "-1";
                ddlLocalDestino.SelectedValue = "-1";

                return;
            }

            string[] dddsAceitos011 = { "016", "017", "018" };

            if (ddlLocalOrigem.SelectedValue == "011")
                if (!dddsAceitos011.Contains(ddlLocalDestino.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Os nossos serviços não cobrem esta combinação de origem e destino, lamentamos pela inconveniência.', 'warning');", true);
                }

            string[] dddsAceitos016 = { "011" };
            if (ddlLocalOrigem.SelectedValue == "016")
                if (!dddsAceitos016.Contains(ddlLocalDestino.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Os nossos serviços não cobrem esta combinação de origem e destino, lamentamos pela inconveniência.', 'warning');", true);
                }

            switch (id)
            {
                case "ddlLocalOrigem":
                        
                    break;
                case "ddlLocalDestino":
                    break;
            }


            ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderLoading", "esconderLoading();", true);
        }
    }
}