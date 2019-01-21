/// <reference path="../jquery-3.3.1.min.js" />




var CategoryViewModel = function CategoryViewModel() {
    debugger;
    var self = this;
    self.catId = ko.observable('');
    self.fishCategory = ko.observable('');

    //self.Reset = function () {
    //    self.UserID("");
    //    self.Password("");
    //    $("#txtUserID").focus();

    //}



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

   
};

$(document).ready(function () {
 
    ko.applyBindings(new CategoryViewModel());

});