<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebGetLongestLineClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
            <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">File Download</asp:LinkButton>
            <br />
            <br />
        </div>--%>
        <h2>Get the longest line of a text file</h2>
        Browse a text file : <asp:FileUpload ID="FileUpload1" runat="server" Width="325px" />
        <br />
        <asp:Button runat="server" onclick="Button1_Click" Text="Upload File" />
        <asp:Label ID="lblInfo" runat="server" />
        <br />
        <br />
        <br />
        <br /> 
    </form>
</body>
</html>
