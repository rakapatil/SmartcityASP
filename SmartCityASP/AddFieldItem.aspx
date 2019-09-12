<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFieldItem.aspx.cs" MasterPageFile="~/UserSite.Master" Title="FieldItem | SCS" Inherits="SmartCityASP.AddFieldItem" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>

                <section class="content-header">
                    <h1>Add Field Item
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add Field Item</li>
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
                                    <h3 class="box-title">Add Field Item</h3>
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
                                            <label for="lblMarathi">Enter in Marathi *</label>
                                            <asp:TextBox ID="txtGName_M" runat="server" class="form-control" required="required" placeholder="Enter Field in Marathi"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="lblEnglish">Enter in English *</label>
                                            <asp:TextBox ID="txtGName_E" runat="server" class="form-control" required="required" placeholder="Enter Field in English"></asp:TextBox>

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
                                <asp:GridView ID="gvGCDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvGCDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvGCDetails_PageIndexChanging" PageSize="10" DataKeyNames="FieldId" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="FieldId" />
                                        <asp:BoundField HeaderText="Name_M" DataField="FieldName_M" />
                                        <asp:BoundField HeaderText="Name_E" DataField="FieldName_E" />

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("FieldId") %>' CommandName="EditRow"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("FieldId") %>' CommandName="Delete"></asp:LinkButton>
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
        </asp:UpdatePanel>
    </div>
    <!-- /.content-wrapper -->

</asp:Content>
