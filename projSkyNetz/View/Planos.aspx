<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Planos.aspx.cs" Inherits="projSkyNetz.View.Planos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form" method="post" runat="server">
        <div class="content">
            
            <div class="banner-flex">

                <%-- Planos --%>
                <div class="banner-item" style="flex: 3;">
                    <div class="container-planos">
                        <asp:Repeater ID="rptPlanos" runat="server">
                            <ItemTemplate>
                                <div class="card-plano">
                                    <h1><%# Eval("NOME_PLANO") %></h1>
            
                                    <div>
                                        <h2><%# Eval("MINUTOS_PLANO") %> minutos livres para qualquer operadora.</h2>
                                        
                                        <br />

                                        <span class="preco-card-plano">
                                            <%# Eval("PRECO_PLANO", "{0:C}") %>
                                        </span>
                                        
                                        <br />

                                        <button class="button principal" style="font-size: 18px;">
                                            Ver Mais
                                        </button>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>

                <%-- Cotar --%>
                <div class="banner-item banner-texto" style="flex: 2;">
                    <h1 class="banner-titulo" style="color: #0A5483;">Descubra o plano ideal para você!</h1>
                    <div style="display:flex; flex-direction:column; gap:10px; margin: 20px auto;">
                        <div>
                            <div class="col-30" style="padding:0;"><h3>Origem:</h3></div>
                            <div class="col-70" style="padding:0;">
                                <asp:dropdownlist ID="ddlLocalOrigem" runat="server" CssClass="dropdownlist" style="width: 260px;" DataTextField="NOME" DataValueField="COD" OnSelectedIndexChanged="ddlLocal_SelectedIndexChanged" AutoPostBack="true" OnChange="mostrarLoading();"></asp:dropdownlist>
                            </div>
                        </div>

                        <div>
                            <div class="col-30" style="padding:0;"><h3>Destino:</h3></div>
                            <div class="col-70" style="padding:0;">
                                <asp:dropdownlist ID="ddlLocalDestino" runat="server" CssClass="dropdownlist" style="width: 260px;" DataTextField="NOME" DataValueField="COD" OnSelectedIndexChanged="ddlLocal_SelectedIndexChanged" AutoPostBack="true" OnChange="mostrarLoading();"></asp:dropdownlist>
                            </div>
                        </div>

                        <div>
                            <div class="col-30" style="padding:0;"><h3>Duração da Ligação:</h3></div>
                            <div class="col-70" style="padding:0;">
                                <asp:TextBox ID="txtDuracaoLigacao" runat="server" TextMode="Number" CssClass="textbox" style="width: 260px;" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnCotar" runat="server" CssClass="button principal" Text="Cotar" OnClick="btnCotar_Click" OnClientClick="mostrarLoading();" style="font-size: 18px;"></asp:Button>

                </div>
            </div>

            <div id="modal" class="modal">
                <div id="modal-content" class="modal-content">
                    <h1>Cotação</h1>

                </div>

            </div>

        </div>
    </form>
</asp:Content>
