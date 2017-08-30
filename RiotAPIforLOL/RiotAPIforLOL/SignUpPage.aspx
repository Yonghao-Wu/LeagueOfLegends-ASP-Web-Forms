<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUpPage.aspx.cs" Inherits="RiotAPIforLOL.SignUpPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .center{
            margin: auto;
            width: 15%;
            border:1px solid #F4FA58;
            padding: 10px;
            background-color:black;
            border-style:outset;
            position: relative;
            text-align:center;
            border-radius:15px;
            opacity:0.8;
        }

        /*/*/*.center:hover{

        }

        .center:after{
            /*content: "";*/
            position: absolute;
            top: 0px;
            left: 0px;
            width: 0%;
            height: 100%;
            background-color: rgba(255,255,255,0.4);
            -webkit-transition: none;
            -moz-transition: none;
            -ms-transition: none;
            -o-transition: none;
            transition: none;
        }

        .center:hover:after{
            width: 120%;
            background-color: rgba(255,255,255,0);
            -webkit-transition: all 0.3s ease-out;
            -moz-transition: all 0.3s ease-out;
            -ms-transition: all 0.3s ease-out;
            -o-transition: all 0.3s ease-out;
            transition: all 0.3s ease-out;
        }*/*/*/

         .mybtn{
             background: linear-gradient(to bottom, #E44A12, black);
             /*background-color:#F34506;*/
             border-radius:7%;
             border-style:none;
             width:45%;
             height:50px;
             font-family:"Times New Roman";
             color:white;
             font-size:medium;
             font-weight:bold;
         }

         .mylbl{
             font-family:'Comic Sans MS';
             font-size:small;
             color:#F2F5A9;
         }

         .mytxtbox{
             font-family:'Comic Sans MS';
             font-size:small;
             border-style:outset;
             border-radius:5%;
             opacity:0.6;
             border:1px solid #F4FA58;
             border-style:inset;
             width:100%
         }

         .myptag{
             font-family:'Comic Sans MS';
             font-size:small;
             color:#F2F5A9
         }

         .myll{
             color:#DBA901;
         }
         
         .myll2{
             color:white;
             font-size:medium;
             /*font-family:'Comic Sans MS';*/
         }

         .myvalidator{
             font-size:smaller;
             font-family:'Comic Sans MS';
             color:red
         }

    </style>
</head>

<body style="background-image: url(Pictures/league3d.jpg)">
    <form id="form1" runat="server">
    <div>
        <br />
    <%--<center><img src="Pictures/LOLLOGO1.png"/></center>--%>
    </div>
    <br /><br /><br /><br /><br />
    <div class="center">
        <center>
            <div style="position:relative"><img src="Pictures/LOLLOGO2.png" style="height: 100%; width: 100%"/></div>
            <table style="border-spacing:10px 20px;border-collapse:separate">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Firstname:" CssClass="mylbl"></asp:Label><br /><asp:TextBox ID="txtFname" runat="server" CssClass="mytxtbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Lastname:" CssClass="mylbl"></asp:Label><br /><asp:TextBox ID="txtLname" runat="server" CssClass="mytxtbox"></asp:TextBox></asp:Label></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Email-Address:" CssClass="mylbl"></asp:Label><br /><asp:TextBox ID="txtemail" runat="server" CssClass="mytxtbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="League Of Legends Username:" CssClass="mylbl"></asp:Label><br /><asp:TextBox ID="txtUsername" runat="server" CssClass="mytxtbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label7" runat="server" Text="Region:" CssClass="mylbl"></asp:Label><br /><asp:DropDownList ID="cboRegion" runat="server" CssClass="mytxtbox"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label5" runat="server" Text="Password:" CssClass="mylbl"></asp:Label><br /><asp:TextBox ID="txtPassword" runat="server" CssClass="mytxtbox" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label6" runat="server" Text="Confirm Password:" CssClass="mylbl"></asp:Label><br />
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="mytxtbox" TextMode="Password"></asp:TextBox><br /> 
                        <asp:CompareValidator ID="CompareValidator1" CssClass="myvalidator" runat="server" ErrorMessage="Password does not match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator></td>
                </tr>
            </table>
            <p class="myptag">Don't have an account for League of Legends? Click <asp:LinkButton ID="lbLOLredirect" runat="server" CssClass="myll" OnClick="lbLOLredirect_Click">here</asp:LinkButton></p>
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" CssClass="mybtn" OnClick="btnConfirm_Click"></asp:Button><br />
        </center>
    </div>

    </form>
</body>
</html>
