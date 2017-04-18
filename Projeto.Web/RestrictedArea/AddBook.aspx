<%@ Page Title="" Language="C#" MasterPageFile="~/RestrictedArea/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="Projeto.Web.RestrictedArea.AddBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

 
    <!-- Sumário de validação -->
    <asp:ValidationSummary
        ID="sumarioValidacao"
        runat="server"
        ForeColor="Red"
        DisplayMode="BulletList"
        EnableClientScript="true"
    />
    <br /><br />
    <h3 class="text-center">Cadastro de Livros</h3>
    <hr />

    <div class="row">
        <div class="col-md-6">
            <label>Título do Livro</label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" Required="Required" autofocus/>
            <asp:RequiredFieldValidator 
                ID="requiredTitle"    
                runat="server"
                ControlToValidate="txtTitle"
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, informe o título do livro."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                 ID="regexTitle"
                runat="server"
                ControlToValidate="txtTitle"
                Text="Título inválido"
                ErrorMessage="Por favor, informe um título válido com o mínimo de 4 e o máximo de 20 caracteres."
                ForeColor="Red"
                Display="Dynamic"
                ValidationExpression="^[A-Za-zÀ-Üà-ü\s]{4,20}$"
                />
            <br />

            <label>Código Isbn:</label>
            <asp:TextBox ID="txtIsbn" runat="server" CssClass="form-control" Required="Required"/>
            <asp:RequiredFieldValidator 
                ID="requiredIsbn"    
                runat="server"
                ControlToValidate="txtIsbn"
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, informe o código Isbn"
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                 ID="regexIsbn"
                runat="server"
                 ControlToValidate="txtIsbn"
                 Text="Código Isbn inválido"
                ErrorMessage="Por favor, informe um Isbn válido contendo 13 caracteres numéricos."
                ForeColor="Red"
                Display="Dynamic"
                 ValidationExpression="^[0-9.,]{13,13}$"
             />
            <br />

            <label>Gênero:</label>
            <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" Required="Required"/>
            <asp:RequiredFieldValidator 
                ID="requiredGender"    
                runat="server"
                ControlToValidate="txtGender"                
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, informe o gênero"
                ForeColor="Red"
                Display="Dynamic"
            /> 
            <asp:RegularExpressionValidator
                 ID="regexGender"
                runat="server"
                ControlToValidate="txtGender"
                Text="Gênero inválido"
                ErrorMessage="Por favor, informe um gênero válido com o mínimo de 4 e o máximo de 20 caracteres."
                ForeColor="Red"
                Display="Dynamic"
                ValidationExpression="^[0-9A-Za-zÀ-Üà-ü\s]{4,20}$"
                />           
            <br /><br /><br />

            
            <label>Foto:</label>
            <input type="file" id="FileInput" name="myFile" runat="server" />
            <br />

        </div>
        <div class="col-md-6">

            <label>Autor:</label>
            <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control" Required="Required"/>
            <asp:RequiredFieldValidator 
                ID="requiredAuthor"    
                runat="server"
                ControlToValidate="txtAuthor"                
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, informe o nome do autor."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                 ID="regexAuthor"
                runat="server"
                ControlToValidate="txtAuthor"
                Text="Autor inválido"
                ErrorMessage="Por favor, informe um autor válido com o mínimo de 4 e o máximo de 20 caracteres não-numéricos."
                ForeColor="Red"
                Display="Dynamic"
                ValidationExpression="^[A-Za-zÀ-Üà-ü\s]{4,20}$"
             /> 
            <br />

            <label>Editora:</label>
            <asp:TextBox ID="txtPublisher" runat="server" CssClass="form-control" Required="Required"/>
            <asp:RequiredFieldValidator 
                ID="requiredPublisher"    
                runat="server"
                ControlToValidate="txtPublisher"                
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, digite o nome da editora."
                ForeColor="Red"
                Display="Dynamic"
            />
            <asp:RegularExpressionValidator
                 ID="regexPublisher"
                runat="server"
                ControlToValidate="txtPublisher"
                Text="Autor inválido"
                ErrorMessage="Por favor, informe uma editora válida com o mínimo de 4 e o máximo de 20 caracteres."
                ForeColor="Red"
                Display="Dynamic"
                ValidationExpression="^[0-9A-Za-zÀ-Üà-ü\s]{4,20}$"
             />
            <br />

            <label>Sinopse:</label>
            <asp:TextBox ID="txtSynopsis" runat="server" CssClass="form-control" TextMode="multiline" Columns="50" Rows="4" Required="Required"/>
            <asp:RequiredFieldValidator 
                ID="requiredSynopsis"    
                runat="server"
                ControlToValidate="txtSynopsis"                
                Text="Campo Obrigatório"
                ErrorMessage="Por favor, escreva uma sinopse para o livro."
                ForeColor="Red"
                Display="Dynamic"
            />
            
            <br />

        </div>

        <div class="col-md-12">
            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" Text="Cadastrar Livro" OnClick="btnAdd_Click"/>
            <br /><br />

            <asp:Label ID="lblMensagem" runat="server" CssClass="label-success"></asp:Label>
        </div>
    </div>

</asp:Content>
