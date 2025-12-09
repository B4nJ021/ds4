<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculadora.aspx.cs" Inherits="Laboratorio154.Calculadora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="txtNumero1" runat="server" Width="33px"></asp:TextBox>
        +<asp:TextBox ID="txtNumero2" runat="server" Width="37px"></asp:TextBox>
        <br />
        <asp:Button ID="btnSumar" runat="server" OnClick="btnSumar_Click" Text="Sumar" />
        <br />
        <br />
        Resultado: <asp:Label ID="lblResultado" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
