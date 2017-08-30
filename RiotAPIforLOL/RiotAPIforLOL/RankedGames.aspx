<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RankedGames.aspx.cs" Inherits="RiotAPIforLOL.RankedGames" %>

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
<body style="background-image: url(Pictures/AnimatedBackgroundMaybe.gif)">
    <form id="form1" runat="server">
    <div>
        <br /><br />
        <div class="center">
            <center>
                <div style="position:relative"><img src="Pictures/LOLLOGO2.png" style="height: 100%; width: 100%"/></div>
                <br />
                <table style="border-spacing:10px 20px;border-collapse:separate">
                    <tr>
                        <asp:Label ID="Label2" runat="server" Text="Username" CssClass="mylbl"></asp:Label>
                        <asp:TextBox ID="txtusername" runat="server" CssClass="mytxtbox"></asp:TextBox>
                    </tr>
                    </table>
                <asp:Button ID="Button1" runat="server" Text="Retrieve" CssClass="mybtn" OnClick="Button1_Click1"></asp:Button><br /><br />
                <asp:Label ID="Label3" runat="server" Text="" CssClass="mylbl"></asp:Label><br />
                <asp:Label ID="Label1" runat="server" Text="" CssClass="mylbl"></asp:Label>
                <%--<asp:Literal ID="Literal1" runat="server" Text="<span style='font-weight:bold;color:#F2F5A9'>my text</span>" ></asp:Literal>--%>
            </center>
        </div>
    </div>
    </form>
</body>
</html>
