<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewShopDetails.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Shop Details" Inherits="SmartCityASP.ViewShopDetails" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="mainContent">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Shop Details
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Shop Information</li>
                    </ol>
                </section>

                <section class="content">

                    <div class="box box-default">
                        <div class="box-header with-border">
                            <h3 class="box-title">Shop Information</h3>

                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                                <button type="button" class="btn btn-box-tool" data-widget="remove"><i class="fa fa-remove"></i></button>
                            </div>
                        </div>
                        <!-- /.box-header -->
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-6">

                                    <div class="form-group">
                                        <label for="lblShopId">
                                            <asp:Label ID="lblShopId1" runat="server" Text="Register Shop ID : 101"></asp:Label>
                                        </label>
                                    </div>

                                    <div class="form-group">
                                        <label>Enter Messages</label>
                                        <%--<asp:DropDownList ID="ddlGrandCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGrandCategory_SelectedIndexChanged" CssClass="form-control select2" required="required" Style="width: 100%;"></asp:DropDownList>--%>

                                        <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control"></asp:TextBox>


                                    </div>

                                    <div class="form-group">
                                        <label>GCM ID Registration</label>
                                        <asp:TextBox ID="txtGCMID" runat="server" CssClass="form-control"></asp:TextBox>
                                        <%--<asp:DropDownList ID="ddlParentCategory" runat="server" OnSelectedIndexChanged="ddlParentCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control select2" required="required" Style="width: 100%;"></asp:DropDownList>--%>
                                    </div>

                                    <div class="form-group">
                                        <label>Select Child Category</label>
                                        <%--<asp:DropDownList ID="ddlChildCategory" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;"></asp:DropDownList>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblShopName_M">Enter Shop Name in मराठी</label>
                                        <%--<asp:TextBox ID="txtShopName_M" runat="server" class="form-control" required="required" placeholder="Enter in Marathi"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblOwnerName_M">Enter Owner Name in मराठी</label>
                                        <%--<asp:TextBox ID="txtOwnerName_M" runat="server" class="form-control" required="required" placeholder="Enter in Marathi"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label>Near By</label>
                                        <%--<asp:DropDownList ID="ddlNearby" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Trial</asp:ListItem>
                                            <asp:ListItem Value="2">3 Months</asp:ListItem>
                                            <asp:ListItem Value="3">3 Months</asp:ListItem>
                                            <asp:ListItem Value="4">9 Months</asp:ListItem>
                                            <asp:ListItem Value="5">12 Months</asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblOpentime">Enter Open Time</label>
                                        <%--<asp:TextBox ID="txtOpentime" runat="server" class="form-control" required="required" placeholder="Enter Open Time"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblClosetime">Enter Close Time</label>
                                        <%--<asp:TextBox ID="txtClosetime" runat="server" class="form-control" required="required" placeholder="Enter Close Time"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblDescription">Enter Description</label>
                                        <%--<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control" required="required" placeholder="Enter Description in Marathi / English"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblImageFileUpload">Image File Upload</label>
                                        <%--<asp:FileUpload ID="ImageFileUpload" runat="server" AllowMultiple="true" />--%>
                                    </div>

                                </div>
                                <!-- /.col -->
                                <div class="col-md-6">

                                    <div class="form-group">
                                        <label for="lblShopId">
                                            <asp:Label ID="lblShopId" runat="server" Text="Register Shop ID : 101"></asp:Label>
                                        </label>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblShopName_E">Enter Shop Name in English</label>
                                        <%--<asp:TextBox ID="txtShopName_E" runat="server" class="form-control" required="required" placeholder="Enter in English"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblOwnerName_E">Enter Owner Name in English</label>
                                        <%--<asp:TextBox ID="txtOwnerName_E" runat="server" class="form-control" required="required" placeholder="Enter in English"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblTelephone">Enter Telephone Number</label>
                                        <%--<asp:TextBox ID="txtTelephone" runat="server" class="form-control" required="required" placeholder="Enter Telephone / Landline Number"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblMobileNumberOne">Enter Mobile Number</label>
                                        <%--<asp:TextBox ID="txtMobileNumberOne" runat="server" class="form-control" required="required" placeholder="Enter Mobile Number"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblMobileNumberTwo">Enter Alternet Mobile Number </label>
                                        <%--<asp:TextBox ID="txtMobileNumberTwo" runat="server" class="form-control" required="required" placeholder="Enter Mobile Number"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblAddress">Enter Detail Address</label>
                                        <%--<asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control" required="required" placeholder="Enter Address in Marathi / English"></asp:TextBox>--%>
                                    </div>


                                    <div class="form-group">
                                        <label for="lblWebsite">Enter Website</label>
                                        <%--<asp:TextBox ID="txtWebsite" runat="server" class="form-control" required="required" placeholder="Enter Website"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label for="lblOffers">Enter Offers</label>
                                        <%--<asp:TextBox ID="txtOffers" runat="server" class="form-control" required="required" placeholder="Enter Offers"></asp:TextBox>--%>
                                    </div>

                                    <div class="form-group">
                                        <label>Select Package</label>
                                        <%--<asp:DropDownList ID="ddlPackage" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                            <asp:ListItem Value="1">Trial</asp:ListItem>
                                            <asp:ListItem Value="2">3 Months</asp:ListItem>
                                            <asp:ListItem Value="3">3 Months</asp:ListItem>
                                            <asp:ListItem Value="4">9 Months</asp:ListItem>
                                            <asp:ListItem Value="5">12 Months</asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>

                                </div>
                                <!-- /.col -->
                            </div>
                            <!-- /.row -->
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
                        </div>
                    </div>

                </section>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


</asp:Content>

