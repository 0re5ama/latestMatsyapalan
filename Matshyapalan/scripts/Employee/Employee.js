/// <reference path="../../Bootstrap/js/knockout-3.4.2.js" />
function Employee(data)
{
    self = this;
    self.EmployeeID = ko.observable(data.EmployeeID);
    self.EName = ko.observable(data.EName);
    self.JoiningDate = ko.observable(data.JoiningDate);
    self.Address = ko.observable(data.Address);
    self.MobileNo = ko.observable(data.MobileNo);
    self.Salary = ko.observable(data.Salary);
    self.Status = ko.observable(data.Status);
    self.Action = ko.observable(data.Action);
   

}
var EmployeeViewModel = function () {
    var self = this;
    self.EmployeeID = ko.observable();
    self.EName = ko.observable();
    self.MobileNo = ko.observable();
    self.Address = ko.observable();
    self.JoiningDate = ko.observable();
    self.Salary = ko.observable();
    self.Employees = ko.observableArray();
    self.SelectedItem = ko.observable();
    self.Status = ko.observable();
    self.EntryBy = ko.observable();
    self.EntryDate = ko.observable();
    self.Action = ko.observable();
    self.role = ko.observable();
    self.Action = ko.observable("A");
  


    self.GetEmployee = function () {
        $.ajax({
            dataType: "json",
            cache: false,
            async: false,

            url: '/Handler/Emloyee/EmployeeHandler.ashx',
            data: { 'method': 'GetEmployee', 'EmployeeID': null, 'Visibility': null, 'p_rc': null, 'role': self.role() },
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var o = ko.toJS(result.ResponseData);

                var mappedTask = $.map(o, function (item) {
                    return new Employee(item)
                });

                self.Employees(mappedTask);

            },
            error: function (err) {

            }
        });
    }

    self.DeleteEmployee = function (d) {
        debugger;
        console.log(ko.toJS(self.EmployeeID(d.EmployeeID)));
        $.ajax({
            dataType: "json",
            cache: false,
            async: false,

            url: '/Handler/Emloyee/EmployeeHandler.ashx',
            data: { 'method': 'DeleteEmployee', 'EmpId':  self.EmployeeID(), 'Visibility': null, 'p_rc': null, 'role': self.role() },
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var o = ko.toJS(result.ResponseData);

                msg("Successfully done!","Success");

            },
            error: function (err) {

            }
        });
    }




    self.GetEmployee();
    //to add to table
    self.AddEmployee = function () {
        debugger;
        var errMsg = "";
        var add = self.SelectedItem();


        //-----------in case to edit/update----------

        if (add != undefined) {
            add.EmployeeID(self.EmployeeID);
            add.EName(self.EName());
            add.JoiningDate(self.JoiningDate());
            add.Address(self.Address());
            add.MobileNo(self.MobileNo());
            add.Salary(self.Salary());
            add.Status(self.Status());
            //add.EntryBy(self.EntryBy());
            //add.EntryDate(self.EntryDate());
            var action = self.Action() == "A" ? "A" : "E";
            add.Action = action;

            self.SelectedItem(null);


            self.ClearControls();

            // }
        }

            //---------in case of adding new record to table----------------
        else {

            if (self.Validation()) {

                var errMsg = "";
                var objFocus = null;
                var pro;

                add = {
                    EmployeeID: self.EmployeeID(),
                    EName: self.EName(),
                    JoiningDate: self.JoiningDate(),
                    Address: self.Address(),
                    MobileNo: self.MobileNo(),
                    Salary:self.Salary(),
                    Status: self.Status(),
                    EntryBy: self.EntryBy(),
                    EntryDate: null,
                    Action: "A"
                };

                self.Employees.push(new Employee(add));
                self.ClearControls();
            }
        }
    }


    self.SaveEmployee = function () {

        if (self.Validation()) {
            var obj = ko.toJS(self.Employees());
            var obj1 = [];

            for (var i = 0; i < obj.length; i++) {
                var kd = {
                    EmployeeID: obj[i].EmployeeID,
                    EName: obj[i].EName,
                    JoiningDate: obj[i].JoiningDate,
                    Address: obj[i].Address,
                    MobileNo: obj[i].MobileNo,
                    Salary: obj[i].Salary,
                    Status: obj[i].Status,
                    EntryBy: obj[i].EntryBy,
                    EntryDate: obj[i].EntryDate,
                    Action: obj[i].Action
                };
                obj1.push(kd);
            }
            var k = JSON.stringify(ko.toJS(obj1));
            var url = '/Handler/Emloyee/EmployeeHandler.ashx';
            var method = "SaveEmployee";
            var data = { 'method': method, 'args': k, 'role': self.role() };
            $.post(url, data, function (result) {
                var obj = jQuery.parseJSON(result);
                if (obj.IsSucess) {
                    msg(obj.Message);
                    self.GetEmployee(); 
                }
                else {
                    msg(obj.Message, "WARNING");
                }
            });
            self.ClearControls
        }


    };

    self.Validation = function () {
        return true;
    }

    self.ClearControls = function () {
        self.EmployeeID(null);
        self.EName(null);
        self.Address(null);
        self.Salary(null);
        self.MobileNo(null);
        self.JoiningDate(null);       
        $("#btnAdd").text("Add");

    }

    self.EditEmployee = function (d) {
        debugger;
        self.EmployeeID(d.EmployeeID());
        self.EName(d.EName());
        self.Address(d.Address());
        self.Salary(d.Salary());
        self.MobileNo(d.MobileNo());
        self.JoiningDate(d.JoiningDate());
        

        if (d.Action == "A") {
            self.Action("A");
        }
        else {
            self.Action("E");
        }
        self.SelectedItem(d);
        $("#btnAdd").text("Update");



    }


}

$(document).ready(function () {
    ko.applyBindings(new EmployeeViewModel());
});