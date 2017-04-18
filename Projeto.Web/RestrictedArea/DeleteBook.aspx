<%@ Page Title="" Language="C#" MasterPageFile="~/RestrictedArea/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="DeleteBook.aspx.cs" Inherits="Projeto.Web.RestrictedArea.DeleteBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">
 

 <div class="row" id="centro">
     <h3 class="text-left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exclusão de Livro</h3>
        <hr />
 <div class="col-md-5">
 <div class="panel panel-danger">
 <div class="panel-body">
     Deseja realmente excluir este livro?
     <hr />
     <label>Código:</label>
      <strong> <asp:Label ID="lblBookId" runat="server" /> </strong>
     <br />
     <label>Título do livro:</label>
     <strong> <asp:Label ID="lblTitle" runat="server" /> </strong>
     <br />
     <label>Código Isbn:</label>
     <strong> <asp:Label ID="lblIsbn" runat="server" /> </strong>
     <br />
     <label>Gênero:</label>
     <strong> <asp:Label ID="lblGender" runat="server" /> </strong>
     <br />
     <label>Autor:</label>
     <strong> <asp:Label ID="lblAuthor" runat="server" /> </strong>
     <br />
    <label>Editora:</label>
     <strong> <asp:Label ID="lblPublishing" runat="server" /> </strong>
     <br />
     </div>
    <div class="panel-footer">
     <asp:Button ID="btnDelete" runat="server" Text="Excluir Livro" CssClass="btn btn-danger btn-block" OnClick="btnDelete_Click"/>
     <br /><br />
     <asp:Label ID="lblMensagem" runat="server" cssClass="label-success"/>
 </div>
 </div>
 </div>
 </div>

</asp:Content>
