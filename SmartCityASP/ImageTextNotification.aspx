<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageTextNotification.aspx.cs" MasterPageFile="~/UserSite.Master" Title="ImageText Notification | SCS" Inherits="SmartCityASP.ImageTextNotification" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <section class="content-header">
                    <h1>Add Image With Text Notification Details
               
                    </h1>
                    <ol class="breadcrumb">
                        <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                        <li class="active">Add Image With Text Notification Details</li>
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
                                    <h3 class="box-title">Fill Notification Information</h3>
                                </div>
                                <!-- /.box-header -->
                                <!-- form start -->
                                <div role="form">
                                    <div class="box-body">

                                        <div class="form-group">
                                            <label>
                                                <asp:Label ID="lblRegId" runat="server" Text="News ID : 103"></asp:Label>
                                            </label>
                                        </div>

                                        <div class="form-group">
                                            <label>Enter Description *</label>
                                            <asp:TextBox ID="txtDescription" runat="server" class="form-control" TextMode="MultiLine" PlaceHolder="Enter Description in Marathi / English"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label runat="server" id="lblImageUpload">Image File Upload *</label>
                                            <asp:FileUpload ID="ImageFileUpload" runat="server" />
                                        </div>

                                    </div>
                                    <!-- /.box-body -->

                                    <div class="box-footer">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />&nbsp;&nbsp;
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

                                <asp:GridView ID="gvPCDetails" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPCDetails_RowCommand" AllowPaging="true" OnPageIndexChanging="gvPCDetails_PageIndexChanging" PageSize="10" DataKeyNames="PK_NotifId" class="table table-bordered table-striped">
                                    <Columns>
                                        <asp:BoundField HeaderText="ID" DataField="PK_NotifId" />
                                        <asp:BoundField HeaderText="Description" DataField="Description" />
                                        <asp:BoundField HeaderText="ImageName" DataField="ImageName" />
                                        <asp:TemplateField HeaderText="Images">
                                            <ItemTemplate>
                                                <asp:Image ID="imagPCate" runat="server" ImageUrl='<%#Eval("ImagePath") %>' Height="50" Width="50" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Send">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnEdit" runat="server" class="glyphicon glyphicon-edit" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_NotifId") %>' CommandName="EditRow"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnDelete" runat="server" OnClientClick="return confirm('Are you sure ? Do you want to delete.');" class="glyphicon glyphicon-trash" Style="cursor: pointer;" CommandArgument='<%#Bind("PK_NotifId") %>' CommandName="Delete"></asp:LinkButton>
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

    
    <%--<script type="text/javascript">
        $(document).ready(function () {
            
            $("#btnDemo").on('click', function () {
                debugger;
                var applicationID = "AAAAH1uXWew:APA91bEp0qnqxMfoYnz-xRMR-1FgYBNY_pCKNI8aXxwG3YcNea_xjINaSuFaKG55BhHvbf9tjhjbom3SHd2hbO82IfH8AQpkzRwL0j3XUobvCUHjERZMNKh4HYnQ0kZ0yH2FmsVBWSN3";
                var senderId = "134680631788";
                $.ajax({
                    type: 'POST',
                    url: "https://fcm.googleapis.com/fcm/send",
                    headers: {
                        Authorization: 'key=' + applicationID
                    },
                    contentType: 'application/json',
                    dataType: 'json',
                    data: JSON.stringify({ "data": { "image": "http://api.androidhive.info/images/minion.jpg", "is_background": false, "payload": { "score": "5.6", "team": "India" }, "title": "Smart Shirpur City", "message": "Hi.!!!", "timestamp": "29-14-2017" }, "to": "fuDV6ZUPXos:APA91bGxc3WYIYqcKgWl26ejXHnG2yljrcv5NEhB28maU4Ra4xeMetP5Aft5-OaXKvi8lg9n_4Hh6Guo1ZunnSRYexUFWTH18Gxm42syvJvAvz37DhjDnEBKhHIM5O51KwAhaEAAO2Bk" }),
                    success: function (response) {
                        debugger;
                        console.log(response);
                    },
                    error: function (xhr, status, error) {
                        console.log(xhr.error);
                    }
                });
            });
        });

    </script>--%>

</asp:Content>




