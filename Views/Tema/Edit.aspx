<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCLaboratorio.Models.Tema>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit</title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
    <center>
    <h3>
        Actualizar datos del Tema existente
    </h3>
    </center>

        <fieldset>
            <legend>Datos</legend>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Nombre) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Nombre) %>
                <%: Html.ValidationMessageFor(model => model.Nombre) %>
            </div>
            
            <p>
                <input type="submit" value="Guardar" />
            </p>
        </fieldset>

    <% } %>

    <center>
    <div>
        <%: Html.ActionLink("Cancelar", "Index") %>
    </div>
    </center>

</body>
</html>

