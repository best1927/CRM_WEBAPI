<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="LoginPage" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title><%=Page.Title %></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="dist/css/AdminLTE.min.css" rel="stylesheet" />
    <link href="dist/css/font-awesome.min.css" rel="stylesheet" />
    <link href="Content/template.css" rel="stylesheet" />

   
</head>
<body class="lockscreen" style="background:#fff">
    <form id="form1" runat="server" autocomplete="off" defaultbutton="btnLogin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="upgWaiting" runat="server">
            <ProgressTemplate>
                <div class="divWaiting">
                    <img src="images/loading.gif" alt="" />
                    <h4>Processing...</h4>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div style="margin-top: 50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-title">
                        <asp:Label ID="lblAppName" runat="server" Text=""></asp:Label>
                        <img src="App_Themes/Logo/SmartSoftLogo.png" />
                        <%--<asp:Image ID="imgLogo" runat="server" />--%>
                        <span class="pull-right">
                            <img src="App_Themes/Logo/cpfit_72.png" alt="" />
                        </span>
                    </div>
                </div>

                <div style="padding-top: 30px" class="panel-body">
                    <div style="display: none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                    <div class="form-horizontal" role="form">
                        <asp:UpdatePanel ID="udpLogin" runat="server">
                            <ContentTemplate>
                                <asp:RequiredFieldValidator ID="rfvUserId" runat="server" ErrorMessage="" ControlToValidate="txtUserId" Display="Dynamic" CssClass="label label-danger invalid-lable"></asp:RequiredFieldValidator>
                                <asp:Panel ID="pnlUserId" runat="server" Style="margin-bottom: 25px" CssClass="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                    <asp:TextBox ID="txtUserId" runat="server" CssClass="form-control" placeholder="User Id" />

                                </asp:Panel>

                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="" ControlToValidate="txtPassword" Display="Dynamic" CssClass="label label-danger invalid-lable"></asp:RequiredFieldValidator>
                                <asp:Panel ID="pnlPassword" runat="server" Style="margin-bottom: 25px" CssClass="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" />

                                </asp:Panel>


                                <asp:Panel ID="pnlLanguage" runat="server" Style="margin-bottom: 25px" CssClass="input-group">
                                    <span class="input-group-addon"><i class="glyphicon glyphicon-globe"></i></span>
                                    <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-control">
                                    </asp:DropDownList>

                                </asp:Panel>

                                <asp:Panel ID="pnlOrg" runat="server" Style="margin-bottom: 25px" CssClass="input-group">

                                    <span class="input-group-addon"><i class="glyphicon glyphicon-home"></i></span>
                                    <asp:DropDownList ID="ddlOrgCode" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </asp:Panel>


                                <div class="form-group">
                                    <!-- Button -->
                                    <div class="col-sm-12 controls">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
                                        <asp:Button ID="btnLoginAfterSelectOrg" runat="server" Text="OK" CssClass="btn btn-success" CausesValidation="false" OnClick="btnLoginAfterSelectOrg_Click" />
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnCancel_Click" />
                                        <asp:Label ID="lblErrorMessage" Text="" runat="server" CssClass="label label-danger invalid-lable" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="border-top: 1px solid#888; padding-top: 15px; font-size: 85%;">
                                            &copy; 2014 CPF IT Center. All rights reserved.

                                    <span class="pull-right">Power by Smart Soft.</span>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnLoginAfterSelectOrg" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </form>


    
</body>
    <script type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            sessionStorage.clear();
        });
        </script>
</html>
