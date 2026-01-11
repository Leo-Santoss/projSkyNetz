using projSkyNetz.DataDAO;
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
    public partial class ContratarPlano : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica se o parâmetro veio na URL
                if (Request.QueryString["ID_PLANO"] != null)
                {
                    string idPlanoRecebido = Request.QueryString["ID_PLANO"];

                    // Converte para buscar no banco todas as informaç~oes do plano
                    if (int.TryParse(idPlanoRecebido, out int idPlano))
                    {
                        CarregarDadosDoPlano(idPlano);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Erro!', 'Não foi encontrado o plano escolhido, entre em contato com a equipe SkyNetz ou tente novamente mais tarde.', 'error');", true);
                    }
                }
                else
                {
                    // O usuário tentou acessar a página direto sem escolher um plano
                    Response.Redirect("PaginaDeSelecao.aspx");
                }
            }
        }

        private void CarregarDadosDoPlano(int idPlano)
        {
            // Seleciona os dados do plano com o id recebido via parâmetro na URL
            PlanosModel planos = new PlanosModel();

            planos = new PlanosDAO().SelecionarUmPlano(idPlano);

            // Preenche os dados do plano
            if (planos != null)
            {
                lblTituloPlano.Text = planos.NomePlano;
                lblDetalhesPlano.Text = planos.DetalhesPlano;
                lblMinutosPlano.Text = planos.MinutosPlano;
                lblPrecoPlano.Text = planos.PrecoPlano;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Erro!', 'Não foi encontrado o plano escolhido, entre em contato com a equipe SkyNetz ou tente novamente mais tarde.', 'error');", true);
                return;
            }

        }

        protected void btnAssinar_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalSobre('Sucesso!', 'Obrigado por utilizar SkyNetz!', 'success');", true);
        }
    }
}