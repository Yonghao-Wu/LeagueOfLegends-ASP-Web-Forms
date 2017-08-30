<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RiotAPIforLOL.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>

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
            opacity:0.9;
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

    </style>
</head>
<body style="background-image: url(Pictures/ChampFence.jpg)">
    <form id="form1" runat="server">
    <div>
    <%--<img src="Pictures/LOLLOGO1.png" />--%><br />
        <center></center>
    </div>
        <br /><br /><br /><br /><br />

            <div class="center">
                <center>
                    <div style="position:relative"><img src="Pictures/LOLLOGO2.png" style="height: 100%; width: 100%"/></div>
                <table style="border-spacing:10px 20px;border-collapse:separate">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Username:" CssClass="mylbl"></asp:Label>
        
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="mytxtbox"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Password:" CssClass="mylbl"></asp:Label>
                        
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="mytxtbox" TextMode="Password"></asp:TextBox></td>
                    </tr>
                </table><br />
                    <asp:Button ID="btnSignIn" runat="server" Text="Sign In" CssClass="mybtn" OnClick="btnSignIn_Click"></asp:Button>
                    <p class="myptag">Don't have an account? <asp:LinkButton ID="lbSignUp" runat="server" CssClass="myll" OnClick="lbSignUp_Click" >Sign Up</asp:LinkButton></p>
                    </center>
            </div>
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /> <br />

        <div>
            <asp:LinkButton ID="lbAboutUs" runat="server" CssClass="myll2">About Us</asp:LinkButton><br />
            <asp:LinkButton ID="lbContactUs" runat="server" CssClass="myll2">Contact Us</asp:LinkButton>
        </div>
    </form>
</body>
</html>
