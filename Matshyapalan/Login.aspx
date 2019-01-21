<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Matshyapalan.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <%----%>
         <%-- <img class="mb-4" src="../../assets/brand/bootstrap-solid.svg" alt="" width="72" height="72">--%>
      <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
      <label for="inputEmail" class="sr-only">Email address</label>
      <input type="email" id="inputEmail" class="form-control" data-bind="value: UserName" placeholder="Email address" required autofocus>
      <label for="inputPassword" class="sr-only">Password</label>
      <input type="password" id="inputPassword" class="form-control" data-bind="value: Password" placeholder="Password" required>
      <div class="checkbox mb-3">
        <label>
          <input type="checkbox" value="remember-me"> Remember me
        </label>
      </div>
      <input class="btn btn-lg btn-primary btn-block" id="btnLogin" name="btnLogin" value="Login" type="submit" data-bind="click:LoginUser">
     <%-- <button class="btn btn-lg btn-primary btn-block" type="submit" bind-data="click: LoginUser">Sign in</button>--%>
      <p class="mt-5 mb-3 text-muted">&copy; 2017-2018</p>
    <script src="scripts/Login.js"></script>
</asp:Content>
