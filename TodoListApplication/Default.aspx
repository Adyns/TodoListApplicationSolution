<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TodoListApplication._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <nav class="header-navbar navbar navbar-expand-lg align-items-center floating-nav navbar-light navbar-shadow container-xxl">
        <div class="navbar-container d-flex content">

            <ul class="nav navbar-nav align-items-center ms-auto">
                <li class="nav-item dropdown dropdown-user"><a class="nav-link dropdown-toggle dropdown-user-link" id="dropdown-user" href="#" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                    <div class="user-nav d-sm-flex d-none"><span class="user-name fw-bolder"> <asp:Label ID="lblad" runat="server"></asp:Label></span><span class="user-status"> <asp:Label ID="lblrol" runat="server" ></asp:Label></span></div>
                    <span class="avatar">
                        <img class="round" src="../Content/app-assets/images/portrait/small/avatar-s-11.jpg" alt="avatar" height="40" width="40"><span class="avatar-status-online"></span></span>
                </a>
                    <div class="dropdown-menu dropdown-menu-end" aria-labelledby="dropdown-user">
                        <input id="cmdLogout" onserverclick="cmdLogout_ServerClick" runat="server" type="submit" value="Çıkış Yap" class="dropdown-item" />
                    </div>
                </li>
               
            </ul>
        </div>
    </nav>


    <div class="main-menu menu-fixed menu-light menu-accordion menu-shadow">
        <div class="navbar-header">
            <ul class="nav navbar-nav flex-row">
                <li class="nav-item me-auto"><a class="navbar-brand" href="Default.aspx">
                    <h2 class="brand-text">ToDo List</h2>
                </a></li>
            </ul>
        </div>
        <div class="shadow-bottom"></div>
        <div class="main-menu-content">
            <ul class="navigation navigation-main" id="main-menu-navigation" data-menu="menu-navigation">
                <li class=" nav-item">
                    <button type="button" class="btn btn-primary w-100" data-bs-toggle="modal" data-bs-target="#new-project-modal">
                        Proje Ekle
                    </button>
                </li>

                <li class=" navigation-header"><span>Projeler</span><i data-feather="more-horizontal"></i>
                </li>
                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>


            </ul>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server">

        <div class="app-content content todo-application">
            <div class="content-area-wrapper">
                <div class="sidebar-left">
                    <div class="sidebar">
                        <div class="sidebar-content todo-sidebar">
                            <div class="todo-app-menu">
                                <div class="add-task">
                                    <button type="button" class="btn btn-primary w-100" data-bs-toggle="modal" data-bs-target="#new-task-modal" onclick="AddRecord()">
                                        Yeni Görev Ekle
                                    </button>
                                </div>
                                <div class="sidebar-menu-list">
                                    <div class="list-group list-group-filters">

                                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>



                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content-right">
                    <div class="content-wrapper container-xxl p-0">
                        <div class="content-header row">
                        </div>
                        <div class="content-body">
                            <div class="body-content-overlay"></div>
                            <div class="todo-app-list">
                                <div class="app-fixed-search d-flex align-items-center">
                                    <div class="sidebar-toggle d-block d-lg-none ms-1">
                                        <i data-feather="menu" class="font-medium-5"></i>
                                    </div>
                                    <div class="d-flex align-content-center justify-content-between w-100">
                                        <div class="input-group input-group-merge">
                                            <input type="text" class="form-control" placeholder="Yapılacaklar Listesi" readonly />
                                        </div>
                                    </div>
                                </div>
                                <div class="todo-task-list-wrapper list-group">
                                    <ul class="todo-task-list media-list" id="todo-task-list">

                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                                    </ul>
                                </div>
                            </div>

                            <div class="modal modal-slide-in sidebar-todo-modal fade" id="new-task-modal">
                                <div class="modal-dialog sidebar-lg">
                                    <div class="modal-content p-0">
                                        <div id="form-modal-todo" class="todo-modal needs-validation">
                                            <div class="modal-header align-items-center mb-1">
                                                <h5 class="modal-title" id="GorevBaslik"></h5>
                                                <div class="todo-item-action d-flex align-items-center justify-content-between ms-auto">
                                                    <span class="todo-item-favorite cursor-pointer me-75"><i data-feather="star" class="font-medium-2"></i></span>
                                                    <i data-feather="x" class="cursor-pointer" data-bs-dismiss="modal" stroke-width="3"></i>
                                                </div>
                                            </div>
                                            <div class="modal-body flex-grow-1 pb-sm-0 pb-3">
                                                <div class="action-tags">

                                                    <div class="mb-1">
                                                        <label for="gorev_baslik" class="form-label">Başlık</label>
                                                        <asp:TextBox ID="gorev_baslik" CssClass="new-todo-item-title form-control" runat="server"></asp:TextBox>
                                                        <%--<input type="text" id="gorev_baslik" class="new-todo-item-title form-control" placeholder="Baslik" />--%>
                                                    </div>
                                                    <div class="mb-1">
                                                        <label for="gorev_aciklama" class="form-label">Açıklama</label>
                                                        <%--<textarea id="gorev_aciklama" cols="20" rows="2" class="form-control dt-full-name"></textarea>--%>
                                                        <asp:TextBox ID="gorev_aciklama" TextMode="multiline" Columns="50" Rows="2" runat="server" CssClass="form-control dt-full-name" />
                                                    </div>
                                                    <div class="mb-1">
                                                        <label>Depatman Seçin</label>
                                                        <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-select" DataTextField="adi" DataValueField="id"></asp:DropDownList>
                                                    </div>
                                                    <div class="mb-1">
                                                        <label>Kullanıcı Seçin</label>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select" DataTextField="adi_soyadi" DataValueField="id"></asp:DropDownList>
                                                    </div>
                                                    <div class="mb-1">
                                                        <label for="task-due-date" class="form-label">Due Date</label>
                                                        <asp:TextBox TextMode="Date" ID="TextBox1" runat="server" CssClass="form-control task-due-date"></asp:TextBox>
                                                    </div>
                                                    <div class="mb-1">
                                                        <label>Etiket Seçin</label>
                                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select" DataTextField="adi" DataValueField="id"></asp:DropDownList>
                                                    </div>
                                                    <div class="mb-1">
                                                        <label>Durum</label>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="my-1">
                                                    <asp:Button OnClick="Ekle_Click" ID="Ekle" runat="server" Text="Button" CssClass="btn btn-primary add-todo-item me-1" />
                                                    <%-- <button type="submit" class="btn btn-primary add-todo-item me-1">Add</button>--%>
                                                    <button type="button" class="btn btn-outline-secondary add-todo-item" data-bs-dismiss="modal">
                                                        İptal                                               
                                                    </button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="modal modal-slide-in sidebar-todo-modal fade" id="detail-task-modal">
                                <div class="modal-dialog sidebar-lg">
                                    <div class="modal-content p-0">
                                        <div class="todo-modal needs-validation">
                                            <div class="modal-header align-items-center mb-1">
                                                <h5 class="modal-title">Görev Güncelleme</h5>
                                                <div class="todo-item-action d-flex align-items-center justify-content-between ms-auto">
                                                    <span class="todo-item-favorite cursor-pointer me-75"><i data-feather="star" class="font-medium-2"></i></span>
                                                    <i data-feather="x" class="cursor-pointer" data-bs-dismiss="modal" stroke-width="3"></i>
                                                </div>
                                            </div>
                                            <div class="modal-body flex-grow-1 pb-sm-0 pb-3">
                                                <div class="action-tags">
                                                    <asp:HiddenField ID="gorev_ids" runat="server" />
                                                    <div class="mb-1">
                                                        <label>Durum Seçin</label>
                                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-select" DataTextField="adi" DataValueField="id"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="my-1">
                                                    <asp:Button OnClick="Guncelle_Click" ID="Button2" runat="server" Text="Güncelle" CssClass="btn btn-primary add-todo-item me-1" />
                                                    <%-- <button type="submit" class="btn btn-primary add-todo-item me-1">Add</button>--%>
                                                    <button type="button" class="btn btn-outline-secondary add-todo-item" data-bs-dismiss="modal">
                                                        İptal                                               
                                                    </button>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </asp:Panel>

    <div class="modal modal-slide-in sidebar-todo-modal fade" id="new-project-modal">
        <div class="modal-dialog sidebar-lg">
            <div class="modal-content p-0">
                <div id="form-modal-project" class="todo-modal needs-validation">
                    <div class="modal-header align-items-center mb-1">
                        <h5 class="modal-title">Proje Ekleme</h5>
                        <div class="todo-item-action d-flex align-items-center justify-content-between ms-auto">
                            <span class="todo-item-favorite cursor-pointer me-75"><i data-feather="star" class="font-medium-2"></i></span>
                            <i data-feather="x" class="cursor-pointer" data-bs-dismiss="modal" stroke-width="3"></i>
                        </div>
                    </div>
                    <div class="modal-body flex-grow-1 pb-sm-0 pb-3">
                        <div class="action-tags">

                            <div class="mb-1">
                                <label for="proje_adi" class="form-label">Proje Adı</label>
                                <asp:TextBox ID="proje_adi" CssClass="new-todo-item-title form-control" runat="server"></asp:TextBox>
                                <%--<input type="text" id="gorev_baslik" class="new-todo-item-title form-control" placeholder="Baslik" />--%>
                            </div>
                            <div class="mb-1">
                                <label for="proje_aciklama" class="form-label">Açıklama</label>
                                <%--<textarea id="gorev_aciklama" cols="20" rows="2" class="form-control dt-full-name"></textarea>--%>
                                <asp:TextBox ID="proje_aciklama" TextMode="multiline" Columns="50" Rows="2" runat="server" CssClass="form-control dt-full-name" />
                            </div>
                            <div class="mb-1">
                                <label>Durum</label>
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </div>
                        </div>
                        <div class="my-1">
                            <asp:Button OnClick="Proje_Ekle_Click" ID="Button1" runat="server" Text="Button" CssClass="btn btn-primary add-todo-item me-1" />
                            <%-- <button type="submit" class="btn btn-primary add-todo-item me-1">Add</button>--%>
                            <button type="button" class="btn btn-outline-secondary add-todo-item" data-bs-dismiss="modal">
                                İptal                                               
                            </button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
