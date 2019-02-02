<%@ Page Title="" Language="C#" MasterPageFile="~/MainbyA.Master" AutoEventWireup="true" CodeBehind="EmployeeRegistration.aspx.cs" Inherits="Matshyapalan.Modules.Employee.EmployeeRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper row">
        <div class="col-md-10 frm pull-right animated slideInRight">


            <div class="row">
                <div class="col-md-12">
                    <legend>Employee Registration</legend>
                    <hr />
                </div>
            </div>

            <div class="row">


                <div class="col-md-2">
                    Employee Name<span class="mandatory">*</span>
                </div>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="txtEmployeeName" data-bind="value: EName" />
                </div>
                <div class="col-md-2">
                    Mobile No<span class="mandatory">*</span>
                </div>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="txtMobileNo" data-bind="value: MobileNo" />
                </div>



            </div>



                <div class="row">


                <div class="col-md-2">
                    Address<span class="mandatory">*</span>
                </div>
                <div class="col-md-4">
                     <input type="text" class="form-control" id="txtAddress" data-bind="value: Address" />
                </div>
                <div class="col-md-2">
                  Joining Date<span class="mandatory">*</span>
                </div>
                <div class="col-md-4">
                     <input type="text" class="form-control" id="txtJoiningDate" data-bind="value: JoiningDate" />
                </div>



            </div>

            
                <div class="row">


                <div class="col-md-2">
                     Salary <span class="mandatory">*</span>
                </div>
                <div class="col-md-4">
                    <input type="text" class="form-control" id="txtSalary" data-bind="value: Salary" />
                </div>
              



            </div>

         
        
          
            <br />
            <br />
            <div class="row">
                <div class="col-md-8">
                </div>
                <div class="col-md-4">
                    <button id="btnAdd" class="btn btn-primary" data-bind="click: AddEmployee">Add</button>
                    <button id="btnCancel" class="btn btn-primary" data-bind="click: ClearControls">Cancel</button>
                </div>
            </div>
            <br />

            <div class="row">
                <div class="col-md-12">
                    <table class="table table-bordered fixed-header">
                        <thead>
                            <tr>
                                <th style="width: 10%;">S.No
                                    </th>

                                <th>Employee Name
                                    </th>
                                     <th>Employee Address
                                    </th>
                                     <th>Employee Joining Date
                                    </th>
                                <th>Action
                                    </th>
                            </tr>
                        </thead>
                        <tbody data-bind="foreach: Employees">
                            <tr>
                                <td style="width: 10%;">
                                    <span data-bind="text: ($index() + 1)"><span data-bind="    text: EmployeeID" style="width: 100px; visibility: hidden;" /></span>
                                </td>

                                <td>
                                    <span data-bind="text: EName"></span>
                                </td>
                                  <td>
                                    <span data-bind="text: Address"></span>
                                </td>
                                  <td>
                                    <span data-bind="text: JoiningDate"></span>
                                </td>

                                <td>
                                    <%--<span data-bind="text: Action"></span>--%>
                                    <a data-bind="click: $root.EditEmployee" id="edit">
                                        Edit</a>
                                    <a data-bind="click: $root.DeleteEmployee">
                                     Delete</td>
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
                    <button id="btnSubmit" class="btn btn-primary" data-bind="click: SaveEmployee">Save</button>



                </div>
            </div>
            <script src="../../scripts/Employee/Employee.js"></script>
          



        </div>
    </div>

</asp:Content>
