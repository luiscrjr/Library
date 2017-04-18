<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Projeto.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    Selecione a ação desejada:

    <ul>
        <li><a href="/Views/Login.aspx">Acessar Sistema</a></li>
        <li><a href="/Views/CreateUser.aspx">Criar Conta de Usuário</a></li>
    </ul>

</asp:Content>
