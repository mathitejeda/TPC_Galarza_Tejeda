<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VistaWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap core JavaScript -->
    <script src="js/jquery.min.js"></script>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <% if (true)
        { %>
            <a href="CrearTicket.aspx" class="btn btn-primary btn-user">Crear Ticket</a>
      <%  } %>    
    
    <table class="table">
        <thead class="thead-dark">
            <tr>
                <th scope="col">Nro Ticket</th>
                <th scope="col">Estado</th>
                <th scope="col">Tecnico Asignado</th>
                <th scope="col">Fecha Ingreso</th>
                <th scope="col">Producto</th>
                <th scope="col"></th>
                
               
            </tr>
        </thead>
        <tbody>
			<asp:Repeater runat="server" ID="repeater">
				<ItemTemplate>
                    <tr>
                        <th scope="row"><%#Eval("idTicket") %></th>
                        <td><%#Eval("estado") %></td>
                        <td><%#Eval("tecnico") %></td>
                        <td><%#Eval("fechaIngreso") %></td>
                        <td><%#Eval("producto") %></td>
                <td>
                    <a href="TicketDetalle.aspx?id=<%#Eval("idTicket") %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
                    </tr>
				</ItemTemplate>
			</asp:Repeater>
        </tbody>
    </table>

</asp:Content>
