<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNews.aspx.cs" MasterPageFile="~/UserSite.Master" Title="News" Inherits="SmartCityASP.AddNews" %>

<asp:Content ID="MainContent" ContentPlaceHolderID="mainContent" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <h1>Add News Details
               
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li class="active">Add News</li>
            </ol>
        </section>

        <!-- Main content -->
        <section class="content">
            <!-- Info boxes -->

            <div class="box box-default">
                <div class="box-header with-border">
                    <h3 class="box-title">Fill News Information</h3>

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
                                <label for="lblRegId">News ID : 103</label>
                            </div>


                            <div class="form-group">
                                <label>Select Grand Category</label>
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
                                <label>Select Parent Category</label>
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
                                <label>Select Child Category</label>
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
                                <label for="lblFromDate">Enter FromDate</label>
                                <input type="date" class="form-control" id="txtFromDate" required="required">
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
                                <label for="lblImageFileUpload">Upload Images</label>
                                <input type="file" id="fileUplaodImages">
                            </div>

                        </div>
                        <!-- /.col -->
                        <div class="col-md-6">

                            <div class="form-group">
                                <label for="lblRegId">News ID : 103</label>
                            </div>

                            <div class="form-group">
                                <label for="lblNewsHeading">Enter News Heading</label>
                                <input type="text" class="form-control" id="txtNewsHeading" required="required" placeholder="Enter News Heading ">
                            </div>


                            <div class="form-group">
                                <label for="lblDescription">Enter Description</label>
                                <textarea cols="84" rows="4" id="txtDescription" class="form-control" required="required" placeholder="Enter Description in Marathi / English"></textarea>
                            </div>
                            <br />
                            <div class="form-group">
                                <label for="lblToDate">Enter ToDate</label>
                                <input type="date" class="form-control" id="txtToDate" required="required">
                            </div>

                            <div class="form-group">
                                <label for="lblVideoName">Enter Name of Video</label>
                                <input type="text" class="form-control" id="txtVideoName" required="required" placeholder="Enter Video Name">
                            </div>

                            <div class="form-group">
                                <label for="lblVideoPath">Enter Video Path</label>
                                <input type="text" class="form-control" id="txtVideoPath" required="required" placeholder="Enter Video Path">
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
