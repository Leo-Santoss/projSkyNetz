<%@ Page Title="" Language="C#" MasterPageFile="~/MainMasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="projSkyNetz.View.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form" method="post" runat="server">
        <div class="content">
            
            <div class="banner-flex">
                <div class="banner-item">
                    <img class="banner-img" src="<%= ResolveUrl("~/View/Includes/Images/Man_Talking_on_the_Phone.png") %>" alt="Homem ao telefone" />
                    <h1 class="banner-titulo">FaleMais, pague muito menos!</h1>
                </div>

                <div class="banner-item banner-texto">
                    <h1 class="banner-titulo" style="color:#066699; margin-bottom: 10px;">Chegou o FaleMais!</h1>
                    <h2>
                        Com os novos planos FaleMais Skynetz, você tem franquia livre para falar à vontade. 
                        Simule agora sua ligação e veja a economia exata comparada à tarifa normal.
                    </h2>
                    <br />
                    <br />
                    <a href="Planos.aspx" class="button principal">Fazer uma cotação</a>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
