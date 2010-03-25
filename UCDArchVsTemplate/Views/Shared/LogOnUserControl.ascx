<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ Log Off <%--<%= Html.ActionLink("Log Off", "LogOff", "Account") %>--%> ]
<%
    }
    else {
%> 
        [ Log On <%--<%= Html.ActionLink("Log On", "LogOn", "Account") %>--%> ]
<%
    }
%>
