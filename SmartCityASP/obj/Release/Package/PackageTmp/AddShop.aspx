<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddShop.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Add Shop | SCS" Inherits="SmartCityASP.AddShop" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Shop Details
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Register Shop</li>
                    </ol>
                </section>

                <!-- Main content -->
                <section class="content">
                    <!-- Info boxes -->
                    <asp:MultiView ID="MultiView1" runat="server">
                        <asp:View ID="view1" runat="server">
                            <div class="box box-default">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Fill Shop Information</h3>

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
                                                <label runat="server" id="lblddlGrand">Select Grand Category *</label>
                                                <asp:DropDownList ID="ddlGrandCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlGrandCategory_SelectedIndexChanged" CssClass="form-control select2" required="required" Style="width: 100%;"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblddlParent">Select Parent Category *</label>
                                                <asp:DropDownList ID="ddlParentCategory" runat="server" OnSelectedIndexChanged="ddlParentCategory_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control select2" required="required" Style="width: 100%;"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblddlChild">Select Child Category *</label>
                                                <asp:DropDownList ID="ddlChildCategory" runat="server" CssClass="form-control select2" OnSelectedIndexChanged="ddlChildCategory_SelectedIndexChanged" AutoPostBack="true" required="required" Style="width: 100%;"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblddlSubChild">Select Sub ChildCategory</label>
                                                <asp:DropDownList ID="ddlSubChildCategory" runat="server" CssClass="form-control select2" Style="width: 100%;"></asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblrdb">Is Contact Only ? :</label>
                                                <asp:RadioButtonList runat="server" ID="rdbContactOnly" RepeatLayout="Flow" AutoPostBack="true" OnSelectedIndexChanged="rdbContactOnly_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblShopName_M">Enter Shop Name in मराठी *</label>
                                                <asp:TextBox ID="txtShopName_M" runat="server" class="form-control" required="required" placeholder="Enter in Marathi"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblOwnerName_M">Enter Owner Name in मराठी *</label>
                                                <asp:TextBox ID="txtOwnerName_M" runat="server" class="form-control" placeholder="Enter in Marathi"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblNearBy">Near By *</label>
                                                <asp:DropDownList ID="ddlNearby" runat="server" CssClass="form-control select2" Style="width: 100%;">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblOpenTime">Enter Open Time</label>
                                                <asp:TextBox ID="txtOpentime" runat="server" class="form-control" Text="09 AM"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblCloseTime">Enter Close Time</label>
                                                <asp:TextBox ID="txtClosetime" runat="server" class="form-control" Text="09 PM"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="lblDescription">Enter Description *</label>
                                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control" required="required" placeholder="Enter Description in Marathi / English"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblImageUpload">Image File Upload *</label>
                                                <asp:FileUpload ID="ImageFileUpload" runat="server" AllowMultiple="true" />
                                            </div>

                                        </div>
                                        <!-- /.col -->
                                        <div class="col-md-6">

                                            <div class="form-group">
                                                <label for="lblShopId">
                                                    <asp:Label ID="lblShopId" runat="server" ForeColor="White" Text="Register Shop ID : 101"></asp:Label>
                                                </label>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblShopName_E">Enter Shop Name in English *</label>
                                                <asp:TextBox ID="txtShopName_E" runat="server" class="form-control" required="required" placeholder="Enter in English"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblOwnerName_E">Enter Owner Name in English *</label>
                                                <asp:TextBox ID="txtOwnerName_E" runat="server" class="form-control" placeholder="Enter in English"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblTelephone">Enter Telephone Number</label>
                                                <asp:TextBox ID="txtTelephone" runat="server" class="form-control" MaxLength="20" onkeypress="return numbersonly(this,event)" placeholder="eg. 02566227810"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblMobileNumber">Enter Mobile Number *</label>
                                                <asp:TextBox ID="txtMobileNumberOne" runat="server" class="form-control" MaxLength="20" required="required" placeholder="e.g. 9422325020 / Toll Free Number" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblAlternetMob">Enter Alternet Mobile Number </label>
                                                <asp:TextBox ID="txtMobileNumberTwo" runat="server" class="form-control" MaxLength="10" placeholder="e.g. 9422325020" onkeypress="return numbersonly(this,event)"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblAddress">Enter Detail Address *</label>
                                                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control" placeholder="Enter Address in Marathi / English"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblWebSite">Enter Website</label>
                                                <asp:TextBox ID="txtWebsite" runat="server" class="form-control" TextMode="Url" placeholder="eg. http://www.abc.com"></asp:TextBox>
                                            </div>


                                            <div class="form-group">
                                                <label runat="server" id="lblOffers">Enter Offers</label>
                                                <asp:TextBox ID="txtOffers" runat="server" class="form-control" placeholder="Enter Offers"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblPackage">Select Package *</label>
                                                <asp:DropDownList ID="ddlPackage" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">Trial</asp:ListItem>
                                                    <asp:ListItem Value="2">3 Months</asp:ListItem>
                                                    <asp:ListItem Value="3">6 Months</asp:ListItem>
                                                    <asp:ListItem Value="4">9 Months</asp:ListItem>
                                                    <asp:ListItem Value="5">12 Months</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label runat="server" id="lblHasPaid">Is Paid ? :</label>
                                                <asp:RadioButtonList runat="server" ID="rdbIsPaid" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="0" Selected="True">No</asp:ListItem>
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
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
                        </asp:View>
                        <!-- /.box -->
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
                                        <%--<span class="input-group-addon" id="basic-addon1" style="cursor: pointer;"><i class="glyphicon glyphicon-search"></i></span>
                                        <input type="text" id="search-box" class="form-control" placeholder="Search by Name" aria-describedby="basic-addon1">--%>

                                        <span class="input-group-addon" id="basic-addon1" style="cursor: pointer;">
                                            <asp:HiddenField ID="hdnQuery" runat="server" />
                                            <asp:Button ID="btnSearch" runat="server" formnovalidate="formnovalidate" OnClick="btnSearch_Click" CssClass="glyphicon glyphicon-search" Text="Search" Font-Bold="true" />
                                        </span>
                                        <asp:TextBox runat="server" ID="txtSearch" CssClass="form-control" placeholder="Search by Shop Name in English" aria-describedby="basic-addon1"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-1">
                                    <div class="form-control">
                                        <asp:ImageButton ID="imgeBtnAddNew" runat="server" OnClick="lnkbtnBackViews_Click" ImageUrl="~/Images/Actions-list-add-icon.png" Height="25" Width="35" />
                                    </div>
                                </div>
                            </div>

                            <div class="clearfix">&nbsp;</div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <asp:GridView ID="gvShopDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvShopDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvShopDetails_PageIndexChanging" PageSize="10" DataKeyNames="PK_ShopRegId" class="table table-bordered table-striped">
                                            <Columns>
                                                <asp:BoundField HeaderText="ID" DataField="PK_ShopRegId" />
                                                <asp:BoundField HeaderText="ShopName" DataField="ShopName" />
                                                <asp:BoundField HeaderText="OwnerName" DataField="OwnerName" />
                                                <asp:BoundField HeaderText="MobileNumber" DataField="MobileNumber" />
                                                <asp:BoundField HeaderText="Description" DataField="Description" />
                                                <asp:BoundField HeaderText="PackageName" DataField="PackageName" />
                                                <asp:BoundField HeaderText="InsertDate" DataField="InsertDate" />

                                                <asp:TemplateField HeaderText="Images">
                                                    <ItemTemplate>
                                                        <asp:Image ID="imagPCate" runat="server" ImageUrl='<%#Eval("ImagePath") %>' Height="50" Width="50" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ShopRegId") %>' CommandName="EditRow"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ShopRegId") %>' CommandName="Delete"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>

                        </asp:View>
                    </asp:MultiView>
                    <!-- /.row -->
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
