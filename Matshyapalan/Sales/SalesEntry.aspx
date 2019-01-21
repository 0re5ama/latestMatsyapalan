<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SalesEntry.aspx.cs" Inherits="Matshyapalan.Sales.SalesEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <%--  <div class="row">
        <div class="col-md-10 pull-right frm animated slideInRight">
           
                <h3>Sales Entry</h3>
                </br>
                <div class="row ">
                    <div class="col-md-2 " style="margin-left: 6px;">
                        Sales Type<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 dropdown margin-left-0">
                        <select id="ddlElectionLevel" class="dropdown-select col-md-12" data-bind='options: ElectionLevels, optionsText: "EcLevelNameNep",
    optionsValue: "EcLevelID", value: SelectedLevel,
    optionsCaption: "------छान्नुहोस्-------", event: { change: LoadSelected }'>
                        </select>
                    </div>




                </div> 

                <div class="row ">
                    <div class="col-md-2 " style="margin-left: 6px;">
                        Harvest Season<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 dropdown margin-left-0">
                        <select id="ddlElectionLevel" class="dropdown-select col-md-12" data-bind='options: ElectionLevels, optionsText: "EcLevelNameNep",
    optionsValue: "EcLevelID", value: SelectedLevel,
    optionsCaption: "------छान्नुहोस्-------", event: { change: LoadSelected }'>
                        </select>
                    </div>

                     <div class="col-md-2 " style="margin-left: 6px;">
                        Pond<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 dropdown margin-left-0">
                        <select id="ddlElectionLevel" class="dropdown-select col-md-12" data-bind='options: ElectionLevels, optionsText: "EcLevelNameNep",
    optionsValue: "EcLevelID", value: SelectedLevel,
    optionsCaption: "------छान्नुहोस्-------", event: { change: LoadSelected }'>
                        </select>
                    </div>




                </div>

                <div class="row ">
                    <div class="col-md-2 " style="margin-left: 6px;">
                        Fish Category<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 dropdown margin-left-0">
                        <select id="ddlElectionLevel" class="dropdown-select col-md-12" data-bind='options: ElectionLevels, optionsText: "EcLevelNameNep",
    optionsValue: "EcLevelID", value: SelectedLevel,
    optionsCaption: "------छान्नुहोस्-------", event: { change: LoadSelected }'>
                        </select>
                    </div>

                     <div class="col-md-2 " style="margin-left: 6px;">
                        Fish size<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 dropdown margin-left-0">
                        <select id="ddlElectionLevel" class="dropdown-select col-md-12" data-bind='options: ElectionLevels, optionsText: "EcLevelNameNep",
    optionsValue: "EcLevelID", value: SelectedLevel,
    optionsCaption: "------छान्नुहोस्-------", event: { change: LoadSelected }'>
                        </select>
                    </div>




                </div>

                <div class="row ">
                    <div class="col-md-2 " style="margin-left: 6px;">
                        Quantity<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate" placeholder="Quantity" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                     <div class="col-md-1 " style="margin-left: 6px;">
                        Rate per KG<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="Rate" placeholder="Amount" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>


                      <div class="col-md-1 " style="margin-left: 6px;">
                        Total<span class="mandatory">*</span>
                    </div>



                    <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate"  onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>




                </div>


                <div class="row" id="DivLocalLevelForm" style="margin-left: 5px;">

                    <div class="row">

                        <div class="col-md-2">
                            Cash :
                        </div>
                        <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate" placeholder="cash" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                          <div class="col-md-2">
                            Due :
                        </div>
                        <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate"  onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-2">
                            Name :
                        </div>

                        <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate" placeholder="Name" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                          <div class="col-md-2">
                            
                              mobile :
                        </div>
                        <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate" placeholder="Mobile" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                    </div>

                    <div class="row">

                        <div class="col-md-2">
                            Address :
                        </div>

                        <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate" placeholder="Address" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                          <div class="col-md-2">
                            
                              Due Date :
                        </div>
                        <div class="col-md-2 padding-left-0 ">
                            <input type="text" class="form-control" id="txtRegDate" placeholder="Due date" onkeypress="return isDateKey(event)" data-bind="value: SubmissionDate" />
                        </div>

                    </div>



                    <%--<div class="row">
                        <div class="col-md-3">
                            Upload Document<span class="mandatory">*</span>: <span class="mandatory">(Max 1
                                        MB)</span>
                        </div>
                        <div class="col-md-3">
                            <input id="upExpDoc" type="file" name="image" style="color: transparent; width: 100px;" />
                        </div>

                        <div class="col-md-3">
                                <button class="btn btn-primary" data-bind="click:previewExpDocImage ">
                                      Preview</button>
                                </div>

                        <div class="col-md-5 margin-left-0">
                            <a style="cursor: pointer" data-bind="click: ShowFinDoc"><span data-bind="    text: DocFileName"></span></a>
                        </div>



                    </div>--%>


<%--
                </div>

                <div class="row" id="btnGroup">
                    <div style="margin-left: 800px;">
                        <button class="btn btn-primary" data-bind="click: SearchCandidateExpense ">
                            Save and Print</button>
                        <button class="btn btn-primary" data-bind="click: ClearControls ">
                            Save</button>
                        <button class="btn btn-primary" data-bind="click: ClearControls ">
                            Cancle</button>
                    </div>

                    <div class="col-md-1 ">
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <div class="row">


                    <div style="margin-left: 800px;">
                        <%-- <button id="Button1" class="btn btn-primary" data-bind="click:SaveCandidateExpenseEntry">Save</button>--%>
                  <%--  </div>

                </div>

          
        </div>
    </div>--%>

</asp:Content>
