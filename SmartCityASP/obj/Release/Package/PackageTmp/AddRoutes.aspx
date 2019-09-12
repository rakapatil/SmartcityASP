<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRoutes.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Travel Routes" Inherits="SmartCityASP.AddRoutes" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Routes
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add Routes</li>
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
                                    <h3 class="box-title">Add Travels Routes</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <div role="form">
                                    <div class="box-body">
                                        <div class="form-group">
                                            <label for="lblRegId">
                                                <asp:Label ID="lblRegId" runat="server" Text="Route ID : 105"></asp:Label>
                                            </label>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblSourceM">Enter Source Place in Marathi *</label>
                                            <asp:TextBox ID="txtSourceM" runat="server" class="form-control" required="required" placeholder="Enter Source in Marathi"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblDestinationM">Enter Destination Place in Marathi *</label>
                                            <asp:TextBox ID="txtDestinationM" runat="server" class="form-control" required="required" placeholder="Enter Destination in Marathi"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblSourceE">Enter Source Place in English *</label>
                                            <asp:TextBox ID="txtSourceE" runat="server" class="form-control" required="required" placeholder="Enter Source in Marathi"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblDestinationE">Enter Destination Place in English *</label>
                                            <asp:TextBox ID="txtDestinationE" runat="server" class="form-control" required="required" placeholder="Enter Destination in Marathi"></asp:TextBox>
                                        </div>

                                    </div>
                                    <!-- /.box-body -->

                                    <div class="box-footer">
                                        <asp:Button ID="btnSubmit" Text="Submit" class="btn btn-primary" runat="server" OnClick="btnSubmit_Click" />
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

                                <asp:GridView ID="gvRouteDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvRouteDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvRouteDetails_PageIndexChanging" PageSize="10" DataKeyNames="PK_RouteId" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="PK_RouteId" />
                                        <asp:BoundField HeaderText="SourcePlace_M" DataField="SourcePlace_M" />
                                        <asp:BoundField HeaderText="SourcePlace_E" DataField="SourcePlace_E" />
                                        <asp:BoundField HeaderText="DestinationPlace_M" DataField="DestinationPlace_M" />
                                        <asp:BoundField HeaderText="DestinationPlace_E" DataField="DestinationPlace_E" />
                                        <%--<asp:BoundField HeaderText="InsertDate" DataField="InsertDate" />--%>
                                        <%--<asp:TemplateField HeaderText="Images">
                                            <ItemTemplate>
                                                <asp:Image ID="imagPCate" runat="server" ImageUrl='<%#Eval("ImagePath") %>' Height="50" Width="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_RouteId") %>' CommandName="EditRow"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_RouteId") %>' CommandName="Delete"></asp:LinkButton>
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

