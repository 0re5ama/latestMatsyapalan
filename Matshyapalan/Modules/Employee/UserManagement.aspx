<%@ Page Title="" Language="C#" MasterPageFile="~/MainbyA.Master" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="Matshyapalan.Modules.Employee.UserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper row">
        <div class="col-md-10 frm pull-right animated slideInRight">

            <form class="form-horizontal" runat="server" id="Form1" role="form">
                <div class="row">
                    <div class="col-md-12">
                        <legend>User Management</legend>
                        <hr />
                    </div>
                </div>

                
                <div class="row">
                    <div class="col-md-3">
                        UserId<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <select id="Select3" class="dropdown-select" data-bind='options: Parties, optionsText: "PartyNameNep",
    optionsValue: $data, value: SelectedParty,
    optionsCaption: "------छान्नुहोस्-------", event: { change: PartyChange }'>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        userName<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <select id="Select3" class="dropdown-select" data-bind='options: Parties, optionsText: "PartyNameNep",
    optionsValue: $data, value: SelectedParty,
    optionsCaption: "------छान्नुहोस्-------", event: { change: PartyChange }'>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                       Role<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <select id="Select3" class="dropdown-select" data-bind='options: Parties, optionsText: "PartyNameNep",
    optionsValue: $data, value: SelectedParty,
    optionsCaption: "------छान्नुहोस्-------", event: { change: PartyChange }'>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        UserName<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtRate" data-bind="value: FishRate" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Password<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtQuantity" data-bind="value: Quantity" />
                    </div>
                </div>
              
                <br />
                <br />
                <div class="row">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <button id="btnAdd" class="btn btn-primary" data-bind="click: Add">Save</button>
                       
                        <button id="btnCancel" class="btn btn-primary" data-bind="click: ClearControls">Cancel</button>
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

                                    <th>Breed
                                    </th>
                                    <th>कार्य
                                    </th>
                                </tr>
                            </thead>
                            <tbody data-bind="foreach: ExpenseHeads">
                                <tr>
                                    <td style="width: 10%;">
                                        <span data-bind="text: ($index() + 1)"><span data-bind="text: ExpenseHeadTypeID" style="width: 100px; visibility: hidden;" /></span>
                                    </td>

                                    <td>
                                        <span data-bind="text: fishSize"></span>
                                    </td>

                                    <td>
                                        <%--<span data-bind="text: Action"></span>--%>
                                        <a data-bind="click: $root.EditExpenseHeadType" id="edit">
                                            <span class="glyphicon glyphicon-edit" title="Edit" rel="tooltip"></span></a>
                                        <a data-bind="click: $root.DeleteExpenseHeadType">
                                            <span class="glyphicon glyphicon-trash" title="Delete" rel="tooltip"></span></td>
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
                        <button id="btnSubmit" class="btn btn-primary" data-bind="click: SaveExpenseHeadType">Save</button>



                    </div>
                </div>

                <script src="../../Scripts/CAMPAIGNMANAGEMENT/ExpenseHeadItemEntry.js" type="text/javascript"></script>


            </form>
        </div>
    </div>
</asp:Content>
