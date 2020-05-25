﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Empleado</title>
</head>
<body>
     <table>
        <tr>
            <th></th>
            <th>
                IdEmpleado
            </th>
            <th>
                Nombre
            </th>

            <th>
                Direccion
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: Html.ActionLink("Editar", "EmpleadoEdit", new { id=item.IdEmpleado }) %> |
                <%: Html.ActionLink("Detalles", "EmpleadoDetails", new { id = item.IdEmpleado })%> |
                <%: Html.ActionLink("Eliminar", "EmpleadoDelete", new { id = item.IdEmpleado })%>
            </td>
            <td>
                <%: item.IdEmpleado %>
            </td>
            <td>
                <%: item.Nombre %>
            </td>
            <th>
                <%: item.Direccion %>
            </th>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Agregar", "EmpleadoCreate") %>
    </p>
    <a href="/Home/Index">Menu Principal</a>
</body>
</html>
