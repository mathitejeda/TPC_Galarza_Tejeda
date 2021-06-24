<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTicket.aspx.cs" Inherits="VistaWeb.CrearTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col p-2">
        <asp:Label runat="server" ID="confirmacionEstado"></asp:Label>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th scope="row">Cliente</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlCliente" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ErrorMessage="Cliente requerido" ControlToValidate="ddlCliente"></asp:RequiredFieldValidator></td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <th scope="row">Producto</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTipoRemito" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Tipo de remito requerido" ControlToValidate="ddlTipoRemito"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th scope="row">Tipo de Servicio</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlArticulo" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                   
                <tr>
                    <th scope="row">Técnico Asignado</th>
                    <td colspan="2">
                        <asp:DropDownList cssClass="form-control" ID="ddlTransportista" runat="server" AppendDataBoundItems ="true">
                            <asp:ListItem Text=""></asp:ListItem>
                        </asp:DropDownList>
                    <td colspan="2">
                        </td>
                </tr>
                <tr>
                    <th scope="row">Observaciones</th>
                    <td colspan="2">
                        <asp:TextBox runat="server" ID="tbObservaciones" CssClass="form-control" MaxLength="299" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ErrorMessage="Observaciones requeridas" ControlToValidate="tbObservaciones"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                
            </tbody>
        </table>
        <%--<asp:Button runat="server" cssClass="btn btn-primary" Text="Alta" ID="btnAlta" OnClick="btnAlta_Click" />--%>
        </div>
</asp:Content>
