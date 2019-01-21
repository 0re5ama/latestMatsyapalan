<%@ Page Title="" Language="C#" MasterPageFile="~/MainbyA.Master" AutoEventWireup="true" CodeBehind="SalesEntry.aspx.cs" Inherits="Matshyapalan.Modules.Fishery.SalesEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper row">
        <div class="col-md-10 frm pull-right animated slideInRight">

            <form class="form-horizontal" runat="server" id="Form1" role="form">
                <div class="row">
                    <div class="col-md-12">
                        <legend>Sales</legend>
                        <hr />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        Select Action<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-1">
                    </div>
                    <%--It can be Sales Entry or View Sales --%>
                    <div class="col-md-2 margin-left-0 dropdown">

                        <select id="Select2" class="dropdown-select" data-bind='options: Parties, optionsText: "PartyNameNep",
    optionsValue: $data, value: SelectedParty,
    optionsCaption: "------छान्नुहोस्-------", event: { change: PartyChange }'>
                        </select>
                    </div>
                </div>

                <%--if action is Expense Entry--%>

                <div class="row">
                    <div class="col-md-2">
                        Select sales  Type<span class="mandatory">*</span>
                        <%-- it can be baby sales or adult sales--%>
                    </div>
                    <div class="col-md-1">
                    </div>

                    <div class="col-md-2 margin-left-0 dropdown">

                        <select id="Select2" class="dropdown-select" data-bind='options: Parties, optionsText: "PartyNameNep",
    optionsValue: $data, value: SelectedParty,
    optionsCaption: "------छान्नुहोस्-------", event: { change: PartyChange }'>
                        </select>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Pond<span class="mandatory">*</span>
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
                        Fish Size<span class="mandatory">*</span>
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
                        Fish Breed<span class="mandatory">*</span>
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
                        Rate<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtRate" data-bind="value: FishRate" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Quantity<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtQuantity" data-bind="value: Quantity" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Total<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtTotal" data-bind="value: Total" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Cash<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="Cash" data-bind="value: Cash" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Due<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="Due" data-bind="value: Due" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Customer Name<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="CustomerName" data-bind="value: CustomerName" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Customer Address<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="CustomerAddress" data-bind="value: CustomerAddress" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Customer Mobile No<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="Mobile" data-bind="value: Mobile" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Due Date<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="DueDate" data-bind="value: DueDate" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Remarks<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="Remarks" data-bind="value: Remarks" />
                    </div>
                </div>




                <br />
                <br />
                <div class="row">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <button id="btnAdd" class="btn btn-primary" data-bind="click: Add">Save</button>
                        <button id="btnAddAndPrint" class="btn btn-primary" data-bind="click: Add">Save and Print</button>
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
