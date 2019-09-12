<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUsers.aspx.cs" MasterPageFile="~/UserSite.Master" Title="Users" Inherits="SmartCityASP.AddUsers" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Add Users Details
               
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Register User</li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <!-- Info boxes -->

            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Fill User Information</h3>

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
                                <label for="lblRegId">Register User ID : 102</label>
                            </div>

                            <div class="form-group">
                                <label for="lblOwnerName_M">Enter Owner Name in मराठी</label>
                                <input type="text" class="form-control" id="txtOwnerName_M" required="required" placeholder="Enter in Marathi">
                            </div>

                            <div class="form-group">
                                <label>Near By</label>
                                <select class="form-control select2" style="width: 100%;">
                                    <option selected="selected">Nimzari Naka</option>
                                    <option>Karwand Naka</option>
                                    <option>PanchKandil</option>
                                    <option>Vidyavihar Colony</option>
                                    <option>SPDM College</option>
                                    <option>RCPatel Engineering College</option>
                                </select>
                            </div>

                            <div class="form-group">
                                <label for="lblPincode">Enter Pincode Number</label>
                                <input type="number" class="form-control" id="txtPincode" required="required" placeholder="Enter Pincode Number">
                            </div>

                            <div class="form-group">
                                <label for="lblMobileNumberOne">Enter Mobile Number</label>
                                <input type="number" class="form-control" id="txtMobileNumberOne" required="required" placeholder="Enter Mobile Number">
                            </div>

                            <div class="form-group">
                                <label for="lblEmailId">Enter EmailId</label>
                                <input type="email" class="form-control" id="txtEmailId" required="required" placeholder="Enter Email Id">
                            </div>

                            <div class="form-group">
                                <label for="lblImageFileUpload">Upload Profile Photo</label>
                                <input type="file" id="fileUplaodImages">
                            </div>

                        </div>
                        <!-- /.col -->
                        <div class="col-md-6">

                            <div class="form-group">
                                <label for="lblRegId">Register User ID : 102</label>
                            </div>

                            <div class="form-group">
                                <label for="lblOwnerName_E">Enter Owner Name in English</label>
                                <input type="text" class="form-control" id="txtOwnerName_E" required="required" placeholder="Enter in English">
                            </div>

                            <div class="form-group">
                                <label for="lblAddress">Enter Detail Address</label>
                                <textarea cols="84" rows="4" id="txtAddress" class="form-control" required="required" placeholder="Enter Address in Marathi / English"></textarea>
                            </div>

                            <div class="form-group">
                                <label for="lblTelephone">Enter Telephone Number</label>
                                <input type="number" class="form-control" id="txtTelephone" required="required" placeholder="Enter Telephone / Landline Number">
                            </div>

                            <div class="form-group">
                                <label for="lblMobileNumberTwo">Enter Alternet Mobile Number </label>
                                <input type="number" class="form-control" id="txtMobileNumberTwo" required="required" placeholder="Enter Mobile Number">
                            </div>

                            <div class="form-group">
                                <label>Prefer Language</label>
                                <select class="form-control select2" style="width: 100%;">
                                    <option selected="selected">Marathi</option>
                                    <option>English</option>
                                </select>
                            </div>

                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.box-body -->
                <div class="box-footer">
                    <button type="submit" class="btn btn-primary">Submit</button>
                </div>
            </div>
            <!-- /.box -->

            <!-- /.row -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->


</asp:Content>
