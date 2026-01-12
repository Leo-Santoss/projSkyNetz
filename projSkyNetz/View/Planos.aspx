<%@ Page Title="Planos FaleMais" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Planos.aspx.cs" Inherits="projSkyNetz.View.Planos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form" method="post" runat="server">
        <div class="content">

            <%-- Baner principal com os campos para realizar a cotação --%>
            <div class="banner-flex">

                <%-- Planos --%>
                <div class="banner-item" style="flex: 3;">
                    <div class="container-planos">
                        <asp:Repeater ID="rptPlanos" runat="server">
                            <ItemTemplate>
                                <div class="card-plano">
                                    <h1><%# Eval("NomePlano") %></h1>

                                    <div>
                                        <h2><%# Eval("MinutosPlano") %> minutos livres para qualquer DDD.</h2>

                                        <br />

                                        <span class="preco-card-plano">
                                            <%# Eval("PrecoPlano", "{0:C}") %>
                                        </span>

                                        <br />

                                        <asp:button ID="btnVerDetalhes" runat="server" class="button principal" style="font-size: 18px;" Text="Ver Mais" OnClick="btnVerDetalhes_Click" CommandArgument='<%# Eval("MinutosPlano") %>'></asp:button>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <%-- Cotar --%>
                <div class="banner-item banner-texto" style="flex: 2;">
                    <h1 class="banner-titulo" style="color: #0A5483;">Descubra o plano ideal para você!</h1>
                    <div style="display: flex; flex-direction: column; gap: 10px; margin: 20px auto;">
                        <div>
                            <div class="col-30" style="padding: 0;">
                                <h3>Origem:</h3>
                            </div>
                            <div class="col-70" style="padding: 0;">
                                <asp:DropDownList ID="ddlLocalOrigem" runat="server" CssClass="dropdownlist" Style="width: 260px;" DataTextField="ItemNome" DataValueField="ItemValor" OnSelectedIndexChanged="ddlLocal_SelectedIndexChanged" AutoPostBack="true" OnChange="mostrarLoading();"></asp:DropDownList>
                            </div>
                        </div>

                        <div>
                            <div class="col-30" style="padding: 0;">
                                <h3>Destino:</h3>
                            </div>
                            <div class="col-70" style="padding: 0;">
                                <asp:DropDownList ID="ddlLocalDestino" runat="server" CssClass="dropdownlist" Style="width: 260px;" DataTextField="ItemNome" DataValueField="ItemValor" OnSelectedIndexChanged="ddlLocal_SelectedIndexChanged" AutoPostBack="true" OnChange="mostrarLoading();"></asp:DropDownList>
                            </div>
                        </div>

                        <div>
                            <div class="col-30" style="padding: 0;">
                                <h3>Duração da Ligação:</h3>
                            </div>
                            <div class="col-70" style="padding: 0;">
                                <asp:TextBox ID="txtDuracaoLigacao" runat="server" oninput="filtroNumeros(this);" CssClass="textbox" Style="width: 260px;" MaxLength="5" placeholder="Somente números"></asp:TextBox>
                            </div>
                        </div>

                        <div>
                            <div class="col-30" style="padding: 0;">
                                <h3>Plano FaleMais:</h3>
                            </div>
                            <div class="col-70" style="padding: 0;">
                                <asp:DropDownList ID="ddlPlanoFaleMais" runat="server" CssClass="dropdownlist" Style="width: 260px;" DataTextField="NomePlano" DataValueField="MinutosPlano"></asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnCotar" runat="server" CssClass="button principal" Text="Calcular" OnClick="btnCotar_Click" OnClientClick="mostrarLoading();" Style="font-size: 18px;"></asp:Button>

                </div>
            </div>

            <%-- Modal da cotação --%>
            <div id="modalCotacao" class="modal">
                <div id="modalContent" class="conteudo-modal">

                    <div class="header-modal">
                        <h1 class="titulo-modal">Resultado da Cotação</h1>
                        <button type="button" onclick="closeModalCotacao();" class="close-modal">&times;</button>
                    </div>

                    <div class="grid-modal">

                        <div>
                            <div style="margin-bottom: 20px; color: #666; font-size: 14px; text-align: center;">
                                Tarifa base por minuto: 
                                <asp:Label ID="lblTarifaCotacao" runat="server" Style="font-weight: bold; color: #333;"></asp:Label>
                            </div>

                            <div class="sugestao-plano-modal" >
                                <h3><asp:Label ID="lblPlanoQueSeEncaixa" runat="server" Style="font-weight: bold;"></asp:Label></h3>

                                <div style="text-align: right;">
                                    <asp:Button ID="btnPlanoQueSeEncaixa" runat="server" CssClass="button secundario" Text="Ver Detalhes do Plano" OnClick="btnPlanoQueSeEncaixa_Click" OnClientClick="mostrarLoading();"></asp:Button>
                                </div>
                            </div>
                        </div>
                        <div class="grid-modal-card">
                            <div class="valores-grid-modal">
                                <div class="valores-card com-plano">
                                    <h3>Com FaleMais</h3>
                                    <asp:Label ID="lblValorComFaleMais" runat="server" CssClass="valor-destaque"></asp:Label>
                                </div>

                                <div class="valores-card">
                                    <div class="valores-card sem-plano">
                                        <h3>Sem FaleMais</h3>
                                        <asp:Label ID="lblValorSemFaleMais" runat="server" CssClass="valor-comum"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div style="text-align: center; margin-top:20px;">
                                <asp:Button ID="btnContratarPlano" runat="server" CssClass="button principal" Text="Assinar Plano" OnClick="btnContratarPlano_Click" OnClientClick="mostrarLoading();" style="font-size: 18px; width: -webkit-fill-available;"></asp:Button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Plano escolhido --%>
        <asp:hiddenField ID="hdnPlanoEscolhido" runat="server" />

        <%-- Plano que se encaixa melhor --%>
        <asp:hiddenField ID="hdnPlanoEncaixaMelhor" runat="server" />
        
        <%-- Scripts da página --%>
        <script>
            // Filtro para poder digitas somente números
            function filtroNumeros(input) {
                input.value = input.value.replace(/[^0-9]/g, '');
            }

            // Função para abrir o modal de cotação
            function openModalCotacao() {
                const modal = document.getElementById("modalCotacao");
                modal.style.display = "flex";
                setTimeout(function () {
                    modal.classList.add("show");
                }, 10);
            }

            // Função para fechar o modal de cotação
            function closeModalCotacao() {
                const modal = document.getElementById("modalCotacao");
                modal.classList.remove("show");

                setTimeout(function () {
                    modal.style.display = "none";
                }, 300);
            }
        </script>
    </form>
</asp:Content>
