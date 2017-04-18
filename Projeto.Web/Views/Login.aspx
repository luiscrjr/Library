<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Projeto.Web.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <!-- Sumário de validação -->
    <asp:ValidationSummary
        ID="sumarioValidacao"
        runat="server"
        ForeColor="Red"
        DisplayMode="BulletList"
        EnableClientScript="true"
    />

    <div class="row" id="centro">
        <div class="col-md-4">  
                      
        <h3>Acesse com seu login</h3>   
        <br />

            <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" placeholder="Usuário" autofocus/>
            <asp:RequiredFieldValidator 
                ID="requiredLogin"    
                runat="server"
                ControlToValidate="txtLogin"
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, informe o login de acesso"
                ForeColor="Red"
                Display="Dynamic"
            />
            <br />
            
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" placeholder="Senha"/>
            <asp:RequiredFieldValidator 
                ID="requiredSenha"    
                runat="server"
                ControlToValidate="txtSenha"
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, informe a senha"
                ForeColor="Red"
                Display="Dynamic"
            />
            <br />

            <asp:Button ID="btnAcesso" runat="server" CssClass="btn btn-primary btn-block" Text="Acessar Sistema" OnClick="btnAcesso_Click" />

            <asp:Label ID="lblMensagem" runat="server" />

            <br />
            <h3>OU</h3>
            <br />
            <a class="text-center" href="/Views/CreateUser.aspx"><h4>Crie sua conta</h4></a>

        </div>
    </div>

</asp:Content>
