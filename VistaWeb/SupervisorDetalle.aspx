<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SupervisorDetalle.aspx.cs" Inherits="VistaWeb.SupervisorDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <table class="table table-hover">
                <tbody>
                    <tr>
                    <th scope="row">Cliente</th>
                    <td colspan="2">
                        <asp:TextBox cssClass="form-control" ID="TextBoxCliente" runat="server"></asp:TextBox>
                     
                    </tr>
                <tr>
                    <th scope="row">Producto</th>
                    <td colspan="2">
                        <asp:TextBox cssClass="form-control" ID="TextBoxproducto" runat="server"></asp:TextBox>
                     
                    </tr>
                     <tr>
                    <th scope="row">Tipo de Servicio</th>
                    <td colspan="2">
                        <asp:TextBox cssClass="form-control" ID="TextBoxTipodeServicio" runat="server"></asp:TextBox>
                     
                    </tr>
                <tr>
                    <th scope="row">Tecnico </th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTecnicos" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""><%#Eval("Nombre) %>  </asp:ListItem>
                        </asp:DropDownList>
                    <tr>
                    <th scope="row">Observaciones</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbObservaciones" CssClass="form-control" MaxLength="299" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    
                </tr>
                
            </tbody>
        </table>
       <div class="container">
  <div class="row">
    <div class="col text-center">
        
     <asp:Button runat="server" cssClass="btn btn-primary btn-user" Text="Asignar" ID="ButtonAsignar" OnClick="btnAsignar_Click" /><class = "btn-toolbar"></class> <a href="default.aspx" class="btn btn-primary btn-user">Cancelar </a>
    </div> 
  </div>
</div>
        
     
</asp:Content>
