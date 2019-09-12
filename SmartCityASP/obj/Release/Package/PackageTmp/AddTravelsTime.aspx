<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddTravelsTime.aspx.cs" MasterPageFile="~/UserSite.Master" Title="TravelsTime" Inherits="SmartCityASP.AddTravelsTime" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Travels TimeTables
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add Travels TimeTables</li>
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
                                    <h3 class="box-title">Add Travels TimeTables</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <div class="form">
                                    <div class="box-body">

                                        <div class="form-group">
                                            <label for="lblRegId">
                                                <asp:Label ID="lblTimeTable" runat="server" Text="Travel TimeTable ID : 105"></asp:Label>
                                            </label>
                                        </div>

                                        <div class="form-group">
                                            <label>Select Route </label>
                                            <asp:DropDownList ID="ddlRoute" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                            <label for="lblTime">Enter Time</label>
                                            <asp:TextBox ID="txtTime" runat="server" class="form-control" required="required" PlaceHolder="eg. 11 AM"></asp:TextBox>
                                        </div>

                                        <%--<div class="form-group">
                                            <label>Select Travel Type</label>
                                            <select class="form-control select2" style="width: 100%;">
                                                <option selected="selected">Alabama</option>
                                                <option>Alaska</option>
                                                <option>California</option>
                                                <option>Delaware</option>
                                                <option>Tennessee</option>
                                                <option>Texas</option>
                                                <option>Washington</option>
                                            </select>
                                        </div>--%>

                                        <%--<div class="form-group">
                                            <label>Select Travel SubType</label>
                                            <select class="form-control select2" style="width: 100%;">
                                                <option selected="selected">Alabama</option>
                                                <option>Alaska</option>
                                                <option>California</option>
                                                <option>Delaware</option>
                                                <option>Tennessee</option>
                                                <option>Texas</option>
                                                <option>Washington</option>
                                            </select>
                                        </div>--%>


                                        <div class="form-group">
                                            <label>Select Day Pahar</label>
                                            <asp:DropDownList ID="ddlPahar" runat="server" CssClass="form-control select2" required="required" Style="width: 100%;">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">सकाळी (Morning)</asp:ListItem>
                                                <asp:ListItem Value="2">दुपारी (Afternoon)</asp:ListItem>
                                                <asp:ListItem Value="3">संध्याकाळी (Evening)</asp:ListItem>
                                                <asp:ListItem Value="4">रात्री (Night)</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div class="form-group">
                                            <label>Enter Bus Description</label>
                                            <asp:TextBox ID="txtTravelDesc" runat="server" required="required" class="form-control" TextMode="MultiLine" PlaceHolder="Enter Bus Information as Bus Number and all"></asp:TextBox>
                                        </div>

                                    </div>
                                    <!-- /.box-body -->
                                    <div class="box-footer">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
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

                                <asp:GridView ID="gvTravelsDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvTravelsDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvTravelsDetails_PageIndexChanging" PageSize="10" DataKeyNames="PK_TravelId" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="PK_TravelId" />
                                        <asp:BoundField HeaderText="Route" DataField="FK_RouteId" />
                                        <asp:BoundField HeaderText="DayPahar" DataField="DayPaharName" />
                                        <asp:BoundField HeaderText="Time" DataField="Time" />
                                        <asp:BoundField HeaderText="BusInformation" DataField="Description" />

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_TravelId") %>' CommandName="EditRow"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_TravelId") %>' CommandName="Delete"></asp:LinkButton>
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
