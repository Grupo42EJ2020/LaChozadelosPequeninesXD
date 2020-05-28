<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCLaboratorio.Models.Empleado>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>EmpleadoCreate</title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <h1>

    <form method="post">

    <%--<label for= "IdCurso">IdCurso</label>
    <input type= "text" id="IdCurso" name= "IdCurso"/> --%>

    
    <label for= "Nombre">Nombre</label>
    <input type= "text" id="Nombre" name= "Nombre"/>


    <label for= "Direccion">Direccion</label>
    <input type= "text"  id="Direccion" name= "Direccion"/>


    
      
     <% using (Html.BeginForm()) { %>
        <p>
            
		    <input type= "submit" name = "grabar" Value= "registrar empleado"/>
		    <%: Html.ActionLink("Regresa a la lista anterior", "Empleado") %>
        </p>
    <% } %>
    </form>
    </h1>
</body>
</html>

