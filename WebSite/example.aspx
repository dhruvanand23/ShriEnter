<%@ Page Language="C#" AutoEventWireup="true" CodeFile="example.aspx.cs" Inherits="WebSite.example" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <table >
            <tr>                
                <td style ="width:1000px"><center><h1>Purchase Order</h1></center></td>                
                <td style ="width:300px">   
                    <table style="border: 1px solid black;">
                        <tr><td>Date: <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></td></tr>
                        <tr><td>POId: <asp:Label ID="lblPoid" runat="server" Text=""></asp:Label></td></tr>
                     </table>
                </td>                
            </tr>
         </table>
        <br />
         <table style="border: 1px solid black;">
            <tr>
                <td style ="width:750px"><p><b>Shri Enterprises</b><br />
                    Shop No. 1&amp;2, Doke Building,<br />
                    Thergaon Bridge, Chinchwad,<br />
                    Pune- 411033<br />
                    9922910640/9922922541
                    </p>
                </td>
                            
                <td style ="width:750px">
                    <p><b>Supp Name</b><br />
                    Address<br />
                    Phone No<br />
                    GST No.
                    </p>
                </td>
             </tr>
         </table>
            
                    
                

          
        
    </form>
</body>
</html>
