<%@ Page Title="Contratar Plano" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="ContratarPlano.aspx.cs" Inherits="projSkyNetz.View.ContratarPlano" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form" method="post" runat="server">

        <div class="content">
            <div class="banner-flex">
                <%-- Planos --%>

                <div class="banner-item" style="flex: 1;">
                    <img src="Includes/Images/Logo/Logo-azul-branco.png" class="banner-logo" alt="logo SkyNetz" />
                </div>

                <div class="banner-item" style="flex: 4;">
                    <h1 class="banner-titulo">Assine já e obtenha os benefícios ainda hoje!</h1>

                    <div style="background-color: #F8F8EC; border-radius: 15px; padding: 20px;">
                        <div class="banner-flex" style="background-color: #F8F8EC;">

                            <%-- Detalhes plano --%>
                            <div class="banner-item banner-assinar detalhes-assinar" style="flex: 1; display: flex; flex-direction: column; gap: 10px; margin: 20px auto;">
                                <asp:Label ID="lblTituloPlano" runat="server" CssClass="titulo-plano"></asp:Label>

                                <asp:Label ID="lblDetalhesPlano" runat="server" CssClass="detalhes-plano"></asp:Label>

                                <p class="detalhes-plano">Minutos Incluídos no plano: <b><asp:Label ID="lblMinutosPlano" runat="server"></asp:Label></b></p>

                                <asp:Label ID="lblPrecoPlano" runat="server" CssClass="preco-plano"></asp:Label>
                            </div>

                            <%-- Formulário para assinar --%>
                            <div class="banner-item banner-assinar" style="flex: 1; display: flex; flex-direction: column; gap: 10px; margin: 20px auto;">
                                <h1>Insira seus dados:</h1>
                                <div>
                                    <div class="col-40" style="text-align:left; padding: 0;">
                                        <h3>Nome Completo:</h3>
                                    </div>
                                    <div class="col-60" style="text-align:left; padding: 0;">
                                        <asp:TextBox ID="txtNomeUsr" runat="server" CssClass="textbox" Style="width: 260px;" MaxLength="100" placeholder="Digite seu nome"></asp:TextBox>
                                    </div>
                                </div>

                                <div>
                                    <div class="col-40" style="text-align:left; padding: 0;">
                                        <h3>Email:</h3>
                                    </div>
                                    <div class="col-60" style="text-align:left; padding: 0;">
                                        <asp:TextBox ID="txtEmailUsr" runat="server" CssClass="textbox" Style="width: 260px;" MaxLength="100" placeholder="Digite seu email" TextMode="Email"></asp:TextBox>
                                    </div>
                                </div>

                                <div>
                                    <div class="col-40" style="text-align:left; padding: 0;">
                                        <h3>Telefone:</h3>
                                    </div>
                                    <div class="col-60" style="text-align:left; padding: 0;">
                                        <asp:TextBox ID="txtTelefoneUsr" runat="server" TextMode="phone" CssClass="textbox" Style="width: 260px;" MaxLength="13" placeholder="Exemplo: 12 12345-6789 "></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div style="text-align:center;">
                            <asp:Button ID="btnAssinar" runat="server" CssClass="button principal btn-assinar" Text="Assinar" OnClick="btnAssinar_Click" OnClientClick="mostrarLoading();" Style="font-size: 18px;"></asp:Button>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </form>
</asp:Content>
