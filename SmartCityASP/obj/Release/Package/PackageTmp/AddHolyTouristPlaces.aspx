<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHolyTouristPlaces.aspx.cs" MasterPageFile="~/UserSite.Master" Title="HolyTouristPlaces" Inherits="SmartCityASP.AddHolyTouristPlaces" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Holy and Tourist Places Details
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Holy and Tourist Places</li>
                    </ol>
                </section>

                <!-- Main content -->
                <section class="content">
                    <!-- Info boxes -->
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="view1" runat="server">
                            <div class="box box-default">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Fill Holy and Tourist Places Information</h3>

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
                                                    <asp:Label ID="lblHolyId" runat="server" Text="HolyTourist Place ID : 106"></asp:Label>
                                                </label>
                                            </div>

                                            <%--<div class="form-group">
                                                <label>Select Grand Category</label>

                                                <asp:DropDownList ID="ddlGrandCategory" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="ddlGrandCategory_SelectedIndexChanged" required="required" Style="width: 100%;">
                                                </asp:DropDownList>
                                            </div>--%>

                                            <%--<div class="form-group">
                                                <label>Select Parent Category</label>
                                                <asp:DropDownList ID="ddlParentCategory" runat="server" AutoPostBack="true" CssClass="form-control select2" OnSelectedIndexChanged="ddlParentCategory_SelectedIndexChanged" required="required" Style="width: 100%;">
                                                </asp:DropDownList>
                                            </div>--%>

                                            <%--<div class="form-group">
                                                <label>Select Child Category</label>

                                                <asp:DropDownList ID="ddlChildCategory" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                                </asp:DropDownList>
                                            </div>--%>

                                            <div class="form-group">
                                                <label for="lblPlaceName_M">Enter Place Name in मराठी</label>
                                                <asp:TextBox ID="txtPlaceName_M" runat="server" class="form-control" required="required" placeholder="Enter in Marathi"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="lblPlaceName_E">Enter Place Name in English</label>
                                                <asp:TextBox ID="txtPlaceName_E" runat="server" class="form-control" required="required" placeholder="Enter in English"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="lblHistory">Enter History</label>
                                                <asp:TextBox ID="txtHistory" runat="server" class="form-control" required="required" placeholder="Enter History in Marathi / English" TextMode="MultiLine"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="lblImageFileUpload">Image File Upload</label>
                                                <asp:FileUpload ID="ImageFileUpload" runat="server" AllowMultiple="true" />
                                            </div>

                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-6">

                                            <div class="form-group">
                                                <label for="lblShopId">
                                                    <asp:Label ID="lblHolyId1" runat="server" ForeColor="White" Text="HolyTourist Place ID : 106"></asp:Label>
                                                </label>
                                            </div>

                                            <%--<div class="form-group">
                                                <label>Near By</label>
                                                <asp:DropDownList ID="ddlNearBy" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                                </asp:DropDownList>
                                            </div>--%>


                                            <div class="form-group">
                                                <label for="lblFestivals">Enter Festivals Information</label>
                                                <asp:TextBox ID="txtFestivals" runat="server" TextMode="MultiLine" class="form-control" required="required" placeholder="Enter Festivals Info in Marathi / English"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="lblDistance">Enter Distance From City</label>
                                                <asp:TextBox ID="txtDistance" runat="server" class="form-control" required="required" placeholder="Enter Distance From City Shirpur"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label>Select Bus Route</label>
                                                <asp:DropDownList ID="ddlRoute" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label for="lblrdb">Choose Place Type :</label>
                                                <asp:RadioButtonList runat="server" ID="rdbContactOnly" CssClass="form-control" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0" Selected="True">Holy Place</asp:ListItem>
                                                    <asp:ListItem Value="1">Tourist Place</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>

                                        </div>
                                        <!-- /.col -->
                                    </div>
                                    <!-- /.row -->
                                </div>
                                <!-- /.box-body -->
                                <div class="box-footer">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnViewList" runat="server" CausesValidation="false" Text="View List" class="btn btn-default" OnClick="btnViewList_Click" formnovalidate="formnovalidate" />
                                </div>
                            </div>
                            <!-- /.box -->
                        </asp:View>
                        <asp:View ID="view2" runat="server">

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
                                <div class="col-md-1">
                                    <div class="form-control">
                                        <%--<asp:LinkButton ID="lnkbtnBackViews" runat="server" Text="AddNew" OnClick="lnkbtnBackViews_Click"></asp:LinkButton>--%>
                                        <asp:ImageButton ID="imgeBtnAddNew" runat="server" OnClick="lnkbtnBackViews_Click" ImageUrl="~/Images/Actions-list-add-icon.png" Height="25" Width="35" />
                                    </div>
                                </div>
                            </div>

                            <div class="clearfix">&nbsp;</div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvHolyPlaceDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvHolyPlaceDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvHolyPlaceDetails_PageIndexChanging" PageSize="10" DataKeyNames="PK_HTPId" class="table table-bordered table-striped">
                                            <Columns>
                                                <asp:BoundField HeaderText="ID" DataField="PK_HTPId" />
                                                <asp:BoundField HeaderText="PlaceName" DataField="HolyName" />
                                                <asp:BoundField HeaderText="NearBy" DataField="NearByName" />
                                                <asp:BoundField HeaderText="PlaceHistory" DataField="PlaceHistory" />
                                                <asp:BoundField HeaderText="PlaceFestivals" DataField="PlaceUstav" />
                                                <asp:BoundField HeaderText="Distance" DataField="DistanceFromCity" />
                                                <asp:BoundField HeaderText="InsertDate" DataField="InsertDate" />

                                                <%--<asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnView" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_HTPId") %>' CommandName="ViewRow"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Images">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imagPCate" runat="server" ImageUrl='<%#Eval("ImagePath") %>' Height="50" Width="50" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_HTPId") %>' CommandName="EditRow"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_HTPId") %>' CommandName="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>


                        </asp:View>
                    </asp:MultiView>
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
