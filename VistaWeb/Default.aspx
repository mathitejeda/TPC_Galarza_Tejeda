﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VistaWeb._Default" %>

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
                <th scope="col">Cliente</th>
                <th scope="col">Tecnico Asignado</th>
                <th scope="col">Fecha Ingreso</th>
                <th scope="col">Producto</th>
                
               
            </tr>
        </thead>
        <tbody>
            <%%>
            <%foreach (var item in listado)
                {%>
            <tr>
                <th scope="row"><% = item.IdTicket %> </th>
                <td><% = (item.Estado) %></td>
                <td><% = (item.Cliente) %></td>
                <td><% = (item.Tecnico) %></td>
                <td><% = (item.FechaIngreso) %></td>
                <td><% = (item.Producto) %></td>
                                
                <td>
                    <a href="TicketDetalle.aspx?id=<% = item.IdTicket %> " class="btn btn-primary btn-user btn-block">Ver </a>
                </td>
            </tr>
            <%}%>
        </tbody>
    </table>

</asp:Content>
