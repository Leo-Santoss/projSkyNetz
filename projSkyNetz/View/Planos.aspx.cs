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
                DataTable dt = new PlanosDAO().SelecionarPlanos();

                if(dt != null && dt.Rows.Count > 0)
                {
                    // Carrega o repeater para o usuário visualizar melhor os planos
                    rptPlanos.DataSource = dt;
                    rptPlanos.DataBind();

                    // Carrega o dropdownlist para realizar o cálculo
                    ddlPlanoFaleMais.DataSource = dt;
                    ddlPlanoFaleMais.DataBind();
                    ddlPlanoFaleMais.Items.Insert(0, new ListItem("Selecione", "-1") { Selected = true });
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
                DataTable dt = new PlanosDAO().SelecionarCidades();

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
        private void LimparCampos()
        {
            // Campos da cotação
            ddlLocalOrigem.SelectedIndex = -1;
            ddlLocalDestino.SelectedIndex = -1;
            ddlPlanoFaleMais.SelectedIndex = -1;
            txtDuracaoLigacao.Text = string.Empty;

            // Campos do modal
            lblTarifaCotacao.Text = string.Empty;
            lblPlanoQueSeEncaixa.Text = string.Empty;
            lblValorComFaleMais.Text = string.Empty;
            lblValorSemFaleMais.Text = string.Empty;
        }


        #region Cálculos
        private float RetornaTarifa()
        {
            int dddOrigem = Convert.ToInt32(ddlLocalOrigem.SelectedValue);
            int dddDestino = Convert.ToInt32(ddlLocalDestino.SelectedValue);

            // Método que recebe os dois DDD's, e faz a requisição da tarifa no banco

            PlanosDAO dao = new PlanosDAO();
            float tarifa = dao.BuscarTarifaPorDDD(dddOrigem, dddDestino);

            // Caso não tenha encontrado a tarifa entre os locais indicados
            if (tarifa == -1) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Não foi encontrada a tarifa para esta combinação de DDD`s.', 'warning');", true);
                return 0;
            }

            return tarifa;
        }
        private void RetornaCalculoValorPorTempo()
        {
            // Método para definir o valor com e sem os planos falemais

            // Valores que serão utilizados nos cálculos
            float tarifa = RetornaTarifa();

            if (tarifa == 0)
            {
                LimparCampos();
                return;
            }

            int tempoDigitado = Convert.ToInt32(txtDuracaoLigacao.Text);
            int tempoCobertoPlano = Convert.ToInt32(ddlPlanoFaleMais.SelectedValue);

            // Valores finais
            float valorComFaleMais = 0;
            float valorSemFaleMais = tarifa * tempoDigitado;

            // Se o tempo digitado não for coberto pelo plano escolhido, subtrai o excesso e faz a multiplicação, se não, mantém o valor definido na declaração da variável
            if (tempoCobertoPlano < tempoDigitado)
            {
                int tempoNaoCoberto = tempoDigitado - tempoCobertoPlano;

                // Faz o cálculo com o acréscimo de 10%
                valorComFaleMais = tempoNaoCoberto * (tarifa * 1.1f);

                // Já que o tempo digitado é maior que o do plano selecionado, verificar se ele se encaixa em outro plano
                // O código vai passar por todos os planos e ver se algum se encaixa


                foreach(ListItem item in ddlPlanoFaleMais.Items)
                {
                    int valorItem = Convert.ToInt32(item.Value);

                    if (tempoDigitado < valorItem)
                    {
                        lblPlanoQueSeEncaixa.Text = $"O plano atual não cobre tudo. Sugerimos o plano <b> {item.Text} </b> que atenderia melhor sua necessidade.";
                        btnPlanoQueSeEncaixa.Visible = true;
                        break;
                    }
                }

            }
            else
            {
                // Caso o plano selecionado cubra o valor da ligação
                lblPlanoQueSeEncaixa.Text = $"Boa notícia! O plano selecionado cobre o valor da ligação cotada. Contrate agora e aproveite os benefícios do <b>FaleMais {tempoCobertoPlano}</b>!";
                btnPlanoQueSeEncaixa.Visible = false;
            }

            // Preenche a tarifa para o usuário conferir
            lblTarifaCotacao.Text = tarifa.ToString("C2");

            // Preenche os campos com os valores finais ja formatados no padrão monetário
            lblValorComFaleMais.Text = valorComFaleMais.ToString("C2");
            lblValorSemFaleMais.Text = valorSemFaleMais.ToString("C2");

            // Abre o modal com o resultado
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openModalCotacao", "openModalCotacao();", true);
        }
        #endregion

        #region Controles
        protected void ddlLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Valida se os locais não tem o mesmo ddd
            if (ddlLocalOrigem.SelectedValue == ddlLocalDestino.SelectedValue)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Não é possível selecionar locais com o mesmo DDD.', 'warning');", true);
                
                // Limpa os campos
                ddlLocalOrigem.SelectedValue = "-1";
                ddlLocalDestino.SelectedValue = "-1";

                return;
            }

            // Retira o loading
            ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderLoading", "esconderLoading();", true);
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
            if (string.IsNullOrEmpty(txtDuracaoLigacao.Text) && txtDuracaoLigacao.Text != "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Digite a duração da ligação desejada para continuar.', 'warning');", true);
                return;
            }

            // Validação do seletor de planos
            if (ddlPlanoFaleMais.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "swalComum('Aviso!', 'Selecione um plano FaleMais para continuar.', 'warning');", true);
                return;
            }

            RetornaCalculoValorPorTempo();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "esconderLoading", "esconderLoading();", true);

        }
        protected void btnPlanoQueSeEncaixa_Click(object sender, EventArgs e)
        {

        }
        protected void btnContratarPlano_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}