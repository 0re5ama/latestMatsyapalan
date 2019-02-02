
function ExpenseHeadType(data) {

    var self = this;
    self.SizeName = ko.observable(data.SizeName);
 
};

function User(data) {

    var self = this;
    self.UserName = ko.observable(data.UserName);
    self.Password = ko.observable(data.Password);
    self.Address = ko.observable(data.Address);
    self.ID = ko.observable(data.ID);
    self.Action = ko.observable(data.Action);
    self.EntryBy = ko.observable(data.EntryBy);
    self.EntryDate = ko.observable(data.EntryDate);

};


//model view 
function UserModel() {
    var self = this;
    self.ID = ko.observable();
    self.UserName = ko.observable();
    self.Password = ko.observable();
    self.Address = ko.observable();
    self.Action = ko.observable("A");
    self.EntryDate = ko.observable(null);
    self.role = ko.observable($("#roleid").text());
    self.EntryBy = ko.observable($("#user").text());
    self.Users = ko.observableArray([]);
    self.EntryDate = ko.observable();
    self.SelectedItem = ko.observable();

    //..to get the data
    self.GetUserss = function () {
        //$.ajax({
        //    dataType: "json",
        //    cache: false,
        //    async: false,

        //    url: '/Handler/LoginHandler.ashx',
        //    data: { 'method': 'GetUser', 'EmployeeID': null, 'Visibility': null, 'p_rc': null, 'role': self.role() },
        //    contentType: "application/json; charset=utf-8",
        //    success: function (result) {
        //        var o = ko.toJS(result.ResponseData);

        //        var mappedTask = $.map(o, function (item) {
        //            return new User(item)
        //        });

        //        self.Users(mappedTask);

        //    },
        //    error: function (err) {

        //    }
        //});

        var url = '/Handler/LoginHandler.ashx';
        var method = "GetUser";
        var data = { 'method': method };
        $.post(url, data, function (result) {
            var obj = jQuery.parseJSON(result);
            debugger;
            var o = ko.toJS(obj.ResponseData);

                    var mappedTask = $.map(o, function (item) {
                        return new User(item)
                    });

                    self.Users(mappedTask);
        });


    }


    self.GetUserss();

    //to add to table
    self.Add = function () {

        var errMsg = "";
        var add = self.SelectedItem();


        //-----------in case to edit/update----------

        if (add != undefined) {
            add.ID(self.ID());
            add.UserName(self.UserName());
            add.Password(self.Password());
            add.Address(self.Address());
            add.EntryBy(self.EntryBy());
            add.EntryDate = null;
            var action = self.Action() == "A" ? "A" : "E";
            add.Action = action;

            self.SelectedItem(null);


            self.ClearControls();

            // }
        }

            //---------in case of adding new record to table----------------
        else {

          //  if (self.Validation()) {

                var errMsg = "";
                var objFocus = null;
                var pro;

                add = {
                    ID: self.ID(),
                     Password: self.Password(),
                     UserName: self.UserName(),
                     Address: self.Address(),

                    EntryBy: self.EntryBy(),
                    EntryDate: null,
                    Action: "A"
                };

                self.Users.push(new User(add));
           // }
        }
    }



    self.SaveUser = function () {
       // if (self.Validation()) {
            var obj = ko.toJS(self.Users());
            var obj1 = [];

            for (var i = 0; i < obj.length; i++) {
                var kd = {
                    ID: obj[i].ID,
                    UserName: obj[i].UserName,
                    Password: obj[i].Password,
                    Address:obj[i].Address,
                    EntryBy: obj[i].EntryBy,
                    EntryDate: obj[i].EntryDate,
                    Action: obj[i].Action
                };
                obj1.push(kd);
            }
            var k = JSON.stringify(ko.toJS(obj1));
            var url = '/Handler/LoginHandler.ashx';
            var method = "SaveUser";
            var data = { 'method': method, 'args': k, 'role': self.role() };
            $.post(url, data, function (result) {
                var obj = jQuery.parseJSON(result);
                if (obj.IsSucess) {
                    msg(obj.Message);
                    self.GetUser();
                }
                else {
                    msg(obj.Message, "WARNING");
                }
            });
            self.ClearControls
       // }

    }


    self.EditUser = function (d) {
        debugger;
        self.ID(d.ID());
        self.UserName(d.UserName());
        self.Password(d.Password());
        self.Address(d.Address());

        if (d.Action == "A") {
            self.Action("A");
        }
        else {
            self.Action("E");
        }
        self.SelectedItem(d);
        $("#btnAdd").text("Update");

    }


    //--------------------------------------------------------------
    // To Remove Table Data
    //--------------------------------------------------------------
    self.DeleteUser = function (d) {
        debugger;
      let  obj = ko.toJS(d.ID);
                self.Users.remove(d);
                var url = '/Handler/LoginHandler.ashx';
                var method = "DeleteUser";
                var data = { 'method': method ,'useID':obj};
                $.post(url, data, function (result) {
                    var obj = jQuery.parseJSON(result);
                    debugger;
                    var o = ko.toJS(obj.ResponseData);

                    var mappedTask = $.map(o, function (item) {
                        return new User(item)
                    });

                    self.Users(mappedTask);
                });
         
      
    };


    self.Validation = function () {
        debugger;
        var errMsg = "";
        var objFocus = null;

        if (self.UserName()) {
            errMsg += "Fish Category प्रविष्टि गर्नुहोस् !!!<br>";
        }

        if (errMsg !== "") {
            msg(errMsg, "WARNING");
            return false;
        }
        else {
            return true;
        }
    }


    self.ClearControls = function () {

        self.UserName(null);
        self.Address(null);
        self.Password(null);
        self.SelectedItem(null);
        self.Action(null);

        $("#btnAdd").text("Add");

    }

}


$(document).ready(function () {
    ko.applyBindings(new UserModel());
});



