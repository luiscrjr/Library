<%@ Page Title="" Language="C#" MasterPageFile="~/RestrictedArea/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="FindBook.aspx.cs" Inherits="Projeto.Web.RestrictedArea.FindBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conteudoPrincipal" runat="server">

    <br /><br />
    <h3 class="text-center">Consultar Livros</h3>
    <br />
         <div>
             
             <div class="row">
                <div class="col-md-10">
                 <asp:TextBox ID="txtFindBooks" runat="server" CssClass="form-control" placeholder="Insira o título desejado ou deixe vazio para listar todos." autofocus/>
                </div>
                <div class="col-md-2">
                     <asp:Button ID="btnFind" runat="server" CssClass="btn btn-primary btn-block" Text="Pesquisar" OnClick="btnFind_Click"/>
                        <br /><br />
                </div>
        
                 <div class="col-md-12">
                    <!-- Componente do .aspx para exibir consultas de registros.. -->
                    <asp:GridView ID="gridBooks" runat="server" GridLines="None" 
                        CssClass="table table-hover" AutoGenerateColumns="false">

             <Columns>

                 <asp:TemplateField HeaderText="Título">
                 <ItemTemplate>
                 <%# Eval("Title") %>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Código Isbn">
                 <ItemTemplate>
                 <%# Eval("Isbn") %>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Gênero">
                 <ItemTemplate>
                 <%# Eval("Gender") %>
                 </ItemTemplate>
                 </asp:TemplateField>
        
                 <asp:TemplateField HeaderText="Autor">
                 <ItemTemplate>
                 <%# Eval("Author") %>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Editora">
                 <ItemTemplate>
                 <%# Eval("Publishing") %>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Sinopse">
                 <ItemTemplate>
                 <%# Eval("Synopsis") %>
                 </ItemTemplate>
                 </asp:TemplateField>
                 <asp:TemplateField HeaderText="Operações">
                 <ItemTemplate>

                 <a href='/RestrictedArea/ModifyBook.aspx?id=<%# Eval("BookId") %>' class="btn btn-primary btn-sm">
                 Atualizar
                 </a>
                 <a href='/RestrictedArea/DeleteBook.aspx?id=<%# Eval("BookId") %>' class="btn btn-danger btn-sm">
                 Excluir
                 </a>
                 </ItemTemplate>
                 </asp:TemplateField>
             </Columns>

         </asp:GridView>

        <hr />
         <asp:Label ID="lblMensagem" runat="server" />
        <hr />

        </div>
             </div>

         </div>
     

</asp:Content>
