<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ParentCategory.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Parent Category" Inherits="SmartCityASP.ParentCategory" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Category
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add Parent Category</li>
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
                                    <h3 class="box-title">Add Parent Category</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <div role="form">
                                    <div class="box-body">

                                        <div class="form-group">
                                            <label for="lblShopId">
                                                <asp:Label ID="lblGCId" runat="server" Text="101"></asp:Label></label>
                                        </div>

                                        <div class="form-group">
                                            <label>Select Top Category</label>
                                            <asp:DropDownList ID="ddlGrandCategory" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblMarathi">Enter in Marathi</label>
                                            <asp:TextBox ID="txtPName_M" runat="server" class="form-control" required="required" placeholder="Enter Parent Catergory in Marathi"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="lblEnglish">Enter in English</label>
                                            <asp:TextBox ID="txtPName_E" runat="server" class="form-control" required="required" placeholder="Enter Parent Catergory in English"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblImgInputFile">Input Image</label>
                                            <asp:FileUpload ID="ImageUpload" runat="server" />
                                            <p class="help-block">Image Always in .jpg .jpeg .png extensions[Image Size Not More than 1 MB & Image Name Not more than 50 Charactors] </p>
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
                                <span class="input-group-addon" id="basic-addon1" style="cursor: pointer;"><i class="glyphicon glyphicon-search"></i></span>
                                <input type="text" id="search-box" class="form-control" placeholder="Search by Name" aria-describedby="basic-addon1">
                            </div>
                        </div>
                    </div>

                    <div class="clearfix">&nbsp;</div>

                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">

                                <asp:GridView ID="gvPCDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPCDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvPCDetails_PageIndexChanging" PageSize="10" DataKeyNames="PK_ID" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="PK_ID" />
                                        <asp:BoundField HeaderText="Name_M" DataField="PName_M" />
                                        <asp:BoundField HeaderText="Name_E" DataField="PName_E" />
                                        <asp:BoundField HeaderText="GrandCategoryId" DataField="GFK_ID" />
                                        <asp:BoundField HeaderText="ImageName" DataField="ImageName" />
                                        <asp:BoundField HeaderText="InsertDate" DataField="InsertDate" />
                                        <asp:TemplateField HeaderText="Images">
                                            <ItemTemplate>
                                                <asp:Image ID="imagPCate" runat="server" ImageUrl='<%#Eval("ImagePath") %>' Height="50" Width="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ID") %>' CommandName="EditRow"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ID") %>' CommandName="Delete"></asp:LinkButton>
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
