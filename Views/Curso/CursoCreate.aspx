<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MVCLaboratorio.Models.Curso>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CursoCreate</title>
</head>
<body>
    <h1>

    <form method="post">

    <%--<label for= "IdCurso">IdCurso</label>
    <input type= "text" id="IdCurso" name= "IdCurso"/> --%>

    
    <label for= "Descripcion">Descripcion</label>
    <input type= "text" id="Descripcion" name= "Descripcion"/>


    <label for= "IdEmpleado">IdEmpleado</label>
    <input type= "text"  id="IdEmpleado" name= "IdEmpleado"/>


    
      
     <% using (Html.BeginForm()) { %>
        <p>
            
		    <input type= "submit" name = "grabar" Value= "registrar curso"/>
		    <%: Html.ActionLink("Regresa a la lista anterior", "Curso") %>
        </p>
    <% } %>
    </form>
    </h1>
</body>
</html>
