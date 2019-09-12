<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMoreImages.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Add More Images" Inherits="SmartCityASP.AddMoreImages" %>


<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add More Images
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add More Images</li>
                    </ol>
                </section>

                <!-- Main content -->
                <section class="content">
                    <!-- Info boxes -->
                    <div class="row">

                        <!-- left column -->
                        <div class="col-md-6">
                            <!-- general form elements -->
                            <div class="box box-primary">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Add More Images</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <div role="form">
                                    <div class="box-body">
                                        <div class="form-group">
                                            <label>
                                                <asp:Label ID="lblRegId" runat="server" Text="Unique ID : 107"></asp:Label>
                                            </label>
                                        </div>

                                        <div class="form-group">
                                            <label>Select Shop *</label>
                                            <%--<asp:TextBox ID="txtCaption" class="form-control" required="required" placeholder="Enter Caption Text" runat="server"></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlShopName" runat="server" CssClass="form-control" AutoPostBack="true" required="required" Style="width: 100%;"></asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblImageFileUpload">Image File Upload *</label>
                                            <asp:FileUpload ID="ImageFileUpload" runat="server" AllowMultiple="true" />
                                        </div>

                                    </div>
                                    <!-- /.box-body -->

                                    <div class="box-footer">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>
                            </div>
                            <!-- /.box -->
                        </div>
                        <!--/.col (left) -->
                    </div>
                    <!-- /.row -->
                    <div class="row">
                        <div class="col-md-6">
                            <select class="form-control">
                                <option>Select Number of Records</option>
                                <option>1-5</option>
                                <option>1-10</option>
                                <option>1-15</option>
                                <option>1-20</option>
                                <option>1-25</option>
                                <option>1-30</option>
                                <option>1-35</option>
                                <option>1-40</option>
                                <option>1-45</option>
                                <option>1-50</option>
                            </select>
                        </div>
                        <div class="col-md-5">
                            <div class="input-group">
                                <span class="input-group-addon" id="basic-addon1" style="cursor: pointer;">
                                    <%--<i class="glyphicon glyphicon-search"></i>--%>
                                    <asp:HiddenField ID="hdnQuery" runat="server" />
                                    <asp:Button ID="btnSearch" runat="server" formnovalidate="formnovalidate" OnClick="btnSearch_Click" CssClass="glyphicon glyphicon-search" Text="Search" Font-Bold="true" />
                                </span>
                                <%--<input type="text" id="search-box" class="form-control" placeholder="Search by Name" aria-describedby="basic-addon1">--%>
                                <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search by Shop Name in English" aria-describedby="basic-addon1"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="clearfix">&nbsp;</div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">

                                <asp:GridView ID="gvSliderImages" runat="server" AutoGenerateColumns="false" OnRowCommand="gvSliderImages_RowCommand" AllowPaging="true" OnPageIndexChanging="gvSliderImages_PageIndexChanging" PageSize="10" DataKeyNames="PK_ImageId" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="PK_ImageId" />
                                        <asp:BoundField HeaderText="ShopName" DataField="ShopName" />
                                        <asp:BoundField HeaderText="ImageName" DataField="ImageName" />
                                        <asp:TemplateField HeaderText="Images">
                                            <ItemTemplate>
                                                <asp:Image ID="imagPCate" runat="server" ImageUrl='<%#Eval("ImagePath") %>' Height="50" Width="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ImageId") %>' CommandName="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>

                </section>
                <!-- /.content -->
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->

</asp:Content>
