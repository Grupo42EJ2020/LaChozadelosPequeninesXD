<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MVCLaboratorio.Models.Tema>>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Temas</title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center>
        <h2>
            Temas registrados
        </h2>
            <p>
        <%: Html.ActionLink("Agregar nuevo", "Create") %>
    </p>
        <a href="/Home/Index">Menu Principal</a>
        </center>
    <hr />

    <table>
        <tr>
            <th>
                <center>
                    IdTema
                </center>
            </th>
            <th>
                <center> 
                    Nombre
                </center>
            </th>
            <th>
                <center>
                    Opciones
                </center>
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <center>
                    <%: item.IdTema %>
                </center>
            </td>
            <td>
                <center>
                    <%: item.Nombre %>
                </center>
            </td>
            <td>
                <center>
                    <%: Html.ActionLink("Editar", "Edit", new { id=item.IdTema }) %> |
                    <%: Html.ActionLink("Detalles", "Details", new { id = item.IdTema })%> |
                    <%: Html.ActionLink("Eliminar", "Delete", new { id = item.IdTema })%>
                </center>
            </td>
        </tr>
    
    <% } %>
    </table>

</body>
</html>

