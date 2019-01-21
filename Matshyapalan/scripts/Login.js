




var LoginViewModel = function LoginViewModel() {
    debugger;
    var self = this;
    self.UserID = ko.observable('');
    self.UserName = ko.observable('');

    self.Password = ko.observable('');
    $("#txtUserID").focus();

    //categorysetup//
    self.catId = ko.observable('');
    self.fishCategory = ko.observable('');
    self.SaveCat = function () {
        debugger;
        alert("knockout working");
        var user = {

            Category: self.fishCategory()
        };
        $.ajax({
            dataType: "json",
            cache: false,
            url: '../Handler/LoginHandler.ashx',
            data: { 'method': 'SaveParameter', 'args': JSON.stringify(user) },
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                if (result.IsSucess) {

                    window.location = "Admin.aspx";

                }
                else {

                    alert(result.Message);
                }
            },
            error: function (err) {
                msg(err.status + " - " + err.statusText, "WARNING");
            }
        });

    };
    //categorysetup//
    self.Reset = function () {
        self.UserID("");
        self.Password("");
        $("#txtUserID").focus();

    }



    self.LoginUser = function () {
        debugger;
       // if (self.LoginValidation()) {
            var user = {
                UserName: self.UserName(),
                Password: self.Password()
            };
            $.ajax({
                dataType: "json",
                cache: false,
                url: '../Handler/LoginHandler.ashx',
                data: { 'method': 'SaveParameter', 'args': JSON.stringify(user) },
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    if (result.IsSucess) {
                        //if (self.UserID().trim() == self.Password().trim()) {

                        //    var warnMsg = "प्रयोगकर्ता आईडी र पासवर्ड एउटै हुनु हुँदैन, पासवर्ड परिवर्तन गर्नुहोस् !!!";

                        //    msg(warnMsg, "WARNING", null, function () { window.location = "/Modules/SECURITY/ChangePassword.aspx?userID=" + self.UserID() });
                        //    return;
                        window.location = "Admin.aspx";

                        //}
                        //debugger;
                        //if (result.Message == "") {
                        //    window.location == "Admin.aspx";
                        //} else {
                        //    msg(result.Message, "Not Valid User");
                        //}
                    }
                    else {
                        // msg(result.Message, "WARNING");
                        alert(result.Message);
                    }
                },
                error: function (err) {
                    msg(err.status + " - " + err.statusText, "WARNING");
                }
            });
       // }
    };

    //self.LoginValidation = function () {
    //    var errMsg = "";
    //    var objFocus = null;

    //    if (Validate.empty(self.UserID())) {

    //        errMsg += "कृपया प्रयोगकर्ता आईडी भर्नुहोस् !!!<br>";
    //    }
    //    if (Validate.empty(self.Password())) {

    //        errMsg += "कृपया पासवर्ड भर्नुहोस् !!!<br>";
    //    }

    //    if (errMsg !== "") {
    //        msg(errMsg, "WARNING");

    //        return false;
    //    }
    //    else {
    //        return true;
    //    }
    //}
};

$(document).ready(function () {
   
    //sessionStorage.clear();
    //ClearSession();
    ko.applyBindings(new LoginViewModel());

});