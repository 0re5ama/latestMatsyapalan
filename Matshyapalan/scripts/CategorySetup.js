



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



   


};

$(document).ready(function () {
    alert("hello");
    ko.applyBindings(new CategoryViewModel());

});