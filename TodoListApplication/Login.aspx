<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TodoListApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Sayfası</title>
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/vendors/css/vendors.min.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/vendors/css/vendors.min.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/bootstrap.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/bootstrap-extended.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/colors.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/components.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/core/menu/menu-types/horizontal-menu.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/plugins/forms/form-validation.css" />
    <webopt:BundleReference runat="server" Path="~/Content/app-assets/css/pages/authentication.css" />
</head>
<body>
    <form id="form1" runat="server" class="horizontal-layout horizontal-menu blank-page navbar-floating footer-static" data-open="hover" data-menu="horizontal-menu" data-col="blank-page">
        <div class="app-content content ">
            <div class="content-wrapper">
                <div class="content-body">
                    <div class="auth-wrapper auth-basic px-2">
                        <div class="auth-inner my-2">
                            <!-- Login basic -->
                            <div class="card mb-0">
                                <div class="card-body">
                                    <p class="card-text mb-2">ToDo List uygulamasına hoşgeldiniz. Uygulamayı Kullanabilmek için Lütfen Giriş Yapınız.</p>

                                    <div id="auth-login-form" class="auth-login-form mt-2">
                                        <div class="mb-1">
                                            <div class="form-group">
                                                <label class="form-label" for="giris-adi">Giriş Adı</label>
                                                <input runat="server" class="form-control" id="giris_adi" type="text" placeholder="Giriş Adı" autofocus="" tabindex="1" />
                                                <asp:RequiredFieldValidator ID="vgiris_adi" runat="server" ControlToValidate="giris_adi" Display="Static"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="mb-1">
                                            <div class="form-group">
                                                <div class="d-flex justify-content-between">
                                                    <label class="form-label" for="sifre">Şifre</label>

                                                </div>
                                                <div class="input-group input-group-merge form-password-toggle">
                                                    <input runat="server" type="password" class="form-control form-control-merge" id="sifre" tabindex="2" placeholder="Şifre" />
                                                    <asp:RequiredFieldValidator ID="vsifre" runat="server" ControlToValidate="sifre" Display="Static"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <input id="cmdLogin" onserverclick="cmdLogin_ServerClick" runat="server" type="submit" value="Giriş Yap" class="btn btn-primary btn-block" />

                                        <asp:Label ID="lblMsg" runat="server" Font-Names="Verdana" Font-Size="10" ForeColor="Red"></asp:Label>
                                    </div>


                                </div>
                            </div>
                            <!-- /Login basic -->
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
