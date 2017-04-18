<%@ Page Title="" Language="C#" MasterPageFile="~/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="Projeto.Web.Views.CreateUser" %>
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

            <h3>Crie seu usuário</h3>
            <br />

            <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" required="required" placeholder="Informe o login desejado" autofocus/>
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

            <asp:TextBox ID="txtSenha" runat="server" placeholder="Digite a Senha" required="required" CssClass="form-control" TextMode="Password" />
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

            <asp:TextBox ID="txtSenhaConfirm" runat="server" CssClass="form-control" required="required" placeholder="Confirme a Senha" TextMode="Password" />
            <asp:RequiredFieldValidator 
                ID="txtSenhaConfirmator"    
                runat="server"
                ControlToValidate="txtSenhaConfirm"                
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, confirme a senha"
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:CompareValidator
                ID="compareSenha"
                runat="server"
                ControlToValidate="txtSenhaConfirm"
                ControlToCompare="txtSenha"
                Text="Senha invalida"
                ErrorMessage="Senhas não conferem, por afvor informe novamente"
                ForeColor="Red"
                Display="Dynamic"
            />
            <br /><br />

            <asp:Button ID="btnAcesso" runat="server" CssClass="btn btn-primary btn-block" Text="Criar usuário" OnClick="btnAcesso_Click"/>
            <br /><br />

            <asp:Label ID="lblMensagem" runat="server"></asp:Label>

        </div>
    </div>

</asp:Content>
