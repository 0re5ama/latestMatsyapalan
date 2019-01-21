<%@ Page Title="" Language="C#" MasterPageFile="~/MainbyA.Master" AutoEventWireup="true" CodeBehind="ExpenseEntry.aspx.cs" Inherits="Matshyapalan.Modules.Fishery.ExpenseEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="wrapper row">
        <div class="col-md-10 frm pull-right animated slideInRight">

            <form class="form-horizontal" runat="server" id="Form1" role="form">
                <div class="row">
                    <div class="col-md-12">
                        <legend>Expenses</legend>
                        <hr />
                    </div>
                </div>

                <div class="row">
                    <div class="col-md-2">
                        Select Action<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-1">
                    </div>
                    <%--It can be ExpenseEntry or View Expense selecting date range--%>
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
                        Select Expense Type<span class="mandatory">*</span>
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
                        <input type="text" class="form-control" id="txtpond" data-bind="value: pond" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Remarks<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtRemarks" data-bind="value: Remarks" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        Expense Amount<span class="mandatory">*</span>
                    </div>
                    <div class="col-md-5">
                        <input type="text" class="form-control" id="txtExpenseAmount" data-bind="value: ExpenseAmount" />
                    </div>
                </div>
                <div class="row">
                <div class="col-md-3">
                    <div class="row">
                        <div class="col-md-12">
                            <h4>
                                File Upload</h4>
                            <span class="mandatory">*</span>: <span class="mandatory">(Max 2 MB)</span>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <input id="upFinDoc" type="file" name="image" style="color: transparent; width: 100px;" />
                        </div>
                    </div>
                </div>
                <div class="col-md-2">

                <a style="cursor: pointer" data-bind="click: ShowFinDoc"><span data-bind="text: FinDocFileName">
                                    </span></a>
                    <%--<fieldset>
                        <div class="img">
                            <img alt="" id="upImage" width="150px" height="140px" data-bind="attr: {src: FinDocFile}"
                                class="DocPreview" data-content="Preview Uploaded File!!!" />
                        </div>
                    </fieldset>--%>
                </div>
            </div>

                <%--if action is Expense Entry--%>


                <%--if action is Expense Entry--%>

                <%--date picker is required--%>

                <%--if action is Expense Entry--%>

                
                <br />
                <br />
                <div class="row">
                    <div class="col-md-8">
                    </div>
                    <div class="col-md-4">
                        <button id="btnAdd" class="btn btn-primary" data-bind="click: Add">Add</button>
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
