<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddScrollingAds.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Scrolling Ads" Inherits="SmartCityASP.AddScrollingAds" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="mainContent">

    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Scrolling Ads
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add Scrolling Ads</li>
                    </ol>
                </section>

                <!-- Main content -->
                <section class="content">
                    <!-- Info boxes -->
                    <div class="row">
                        <!-- right column -->
                        <div class="col-md-6">
                            <!-- Horizontal Form -->
                            <div class="box box-info">
                                <div class="box-header with-border">
                                    <h3 class="box-title">Add Scrolling Ads</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <div class="form">
                                    <div class="box-body">

                                        <div class="form-group">
                                            <label for="lblRegId">
                                                <asp:Label ID="lblRegId" runat="server" Text="Unique ID : 107"></asp:Label></label>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblAdDescription">Enter Ads Description *</label>
                                            <asp:TextBox ID="txtAdDescription" runat="server" class="form-control" TextMode="MultiLine" required="required" placeholder="Enter Ads Description in Marathi / English"></asp:TextBox>
                                        </div>
                                    </div>
                                    <!-- /.box-body -->
                                    <div class="box-footer">
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" OnClick="btnSubmit_Click" Text="Submit" />
                                    </div>
                                    <!-- /.box-footer -->
                                </div>
                            </div>

                        </div>
                        <!--/.col (right) -->
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

                                <asp:GridView ID="gvScrollingAds" runat="server" AutoGenerateColumns="false" OnRowCommand="gvScrollingAds_RowCommand" AllowPaging="true" OnPageIndexChanging="gvScrollingAds_PageIndexChanging" PageSize="10" DataKeyNames="PK_ScrollAdsId" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="PK_ScrollAdsId" />
                                        <asp:BoundField HeaderText="Ads Description" DataField="Description" />
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ScrollAdsId") %>' CommandName="EditRow"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_ScrollAdsId") %>' CommandName="Delete"></asp:LinkButton>
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
