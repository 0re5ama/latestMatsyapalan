﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainbyA.Master" AutoEventWireup="true" CodeBehind="FishSizeSetup.aspx.cs" Inherits="Matshyapalan.Modules.Fishery.CategorySetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper row">
        <div class="col-md-10 frm pull-right animated slideInRight">
            <br />

            <div class="row">
                <div class="col-md-12">
                    <legend>Fish Category Setup</legend>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    Fish Category<span class="mandatory">*</span>
                </div>
                <div class="col-md-5">
                    <input type="text" class="form-control" id="txtfishCategory" data-bind="value: SizeName " />
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-8">
                </div>
                <div class="col-md-4">
                    <button id="btnAdd" class="btn btn-primary" data-bind="click: Add" >Add</button>
                    <button id="btnCancel" data-bind="click: ClearControls" class="btn btn-primary">Cancel</button>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-10">
                    <table class="table table-bordered fixed-header">
                        <thead>
                            <tr>
                                <th style="width: 10%;">S.No
                                </th>

                                <th>Size
                                </th>
                                <th>Action
                                </th>
                            </tr>
                        </thead>
                        <tbody data-bind="foreach: FishSizes">
                            <tr>
                                <td style="width: 10%;">
                                    <span data-bind="text: ($index() + 1)"><span data-bind=" text: SizeId" style="width: 100px; visibility: hidden;" /></span>
                                </td>

                                <td>
                                    <span data-bind="text: SizeName"></span>
                                </td>

                                <td>
                                    <%--<span data-bind="text: Action"></span>--%>
                                    <a data-bind="click: $root.EditFishZize" id="edit">
                                       Edit</a>
                                   <%-- <a data-bind="click: $root.DeleteExpenseHeadType">
                                        <span class="glyphicon glyphicon-trash" title="Delete" rel="tooltip"></span></td>--%>
                                    </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-8">
                </div>
                <div class="col-md-4">
                    <button id="btnSubmit" class="btn btn-primary" data-bind="click: SaveFishSize">Save</button>



                </div>
            </div>
        </div>
    </div>
    <%--<script src="../../scripts/Fishery/CategorySetup.js"></script>--%>
    <script src="../../scripts/Fishery/FishSizeSetup.js"></script>
</asp:Content>
