<%@ Page Title="" Language="C#" MasterPageFile="~/MainbyA.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Matshyapalan.Modules.Fishery.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrapper row">
        <div class="col-md-10 frm pull-right animated slideInRight">
            <br />

            <div class="row">
                <label for="inputEmail" class="col-md-3">Email address</label>
                <div class="col-md-3">
                    <input type="email" id="inputEmail" class="form-control" data-bind="value: UserName" required autofocus>
                </div>
                   <label for="inputPassword" class="col-md-3 ">Password</label>
                <div class="col-md-3">
                    <input type="password" id="inputPassword" class="form-control" data-bind="value: Password" required>
                </div>
            </div>
            <br />
            <div class="row">
                <label for="inputPassword" class="col-md-3 ">Address</label>
                <div class="col-md-3">
                    <input type="text" id="inputAddress" class="form-control" data-bind="value: Address" required>
                </div>
            </div>
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
                <div class="col-md-12">
                    <table class="table table-bordered fixed-header">
                        <thead>
                            <tr>
                                <th style="width: 10%;">S.No
                                    </th>

                                <th>USer Name
                                    </th>
                                     <th> Address
                                    </th>
                                   
                                <th>Action
                                    </th>
                            </tr>
                        </thead>
                        <tbody data-bind="foreach: Users">
                            <tr>
                                <td style="width: 10%;">
                                    <span data-bind="text: ($index() + 1)"><span data-bind="    text: ID" style="width: 100px; visibility: hidden;" /></span>
                                </td>

                                <td>
                                    <span data-bind="text: UserName"></span>
                                </td>
                                  <td>
                                    <span data-bind="text: Address"></span>
                                </td>
                         

                                <td>
                                    <%--<span data-bind="text: Action"></span>--%>
                                    <a data-bind="click: $root.EditUser" id="edit">
                                        Edit</a>
                                    <a data-bind="click: $root.DeleteUser">
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
                    <button id="btnSubmit" class="btn btn-primary" data-bind="click: SaveUser">Save</button>



                </div>
            </div>

          
        </div>
    </div>

    <script src="/scripts/UserRegistration.js"></script>
</asp:Content>
