
function ExpenseHeadType(data) {

	var self = this;
	self.SizeName = ko.observable(data.SizeName);
	//self.ExpenseHeadTypeID = ko.observable(data.ExpenseHeadTypeID);
	////self.ExpenseHeadTypeID = ko.observable("kuchb");
	//self.DescriptionInNepali = ko.observable(data.DescriptionInNepali);
	//self.DescriptionInEnglish = ko.observable(data.DescriptionInEnglish);
	//if (data.Visibility == "true") {
	//    self.Visibility = ko.observable(true);
	//}
	//else {
	//    self.Visibility = ko.observable(false);

	//}

	//self.Status = ko.observable(data.Status);
	//self.EntryBy = ko.observable(data.EntryBy);
	//self.EntryDate = ko.observable(data.EntryDate);
	//self.Action = ko.observable(data.Action);

};

function FishSize(data) {

	var self = this;
	self.SizeName = ko.observable(data.SizeName);
	self.SizeId = ko.observable(data.SizeId);
	self.Action = ko.observable(data.Action); 
	self.EntryBy = ko.observable(data.EntryBy); 
	self.EntryDate = ko.observable(data.EntryDate);

};


//model view 
function FishSizeSetupViewModel() {
	var self = this;
	self.SizeId = ko.observable();
	self.SizeName = ko.observable();   
	self.Action = ko.observable("A");
	self.EntryDate = ko.observable(null);
	self.role = ko.observable($("#roleid").text());
	self.EntryBy = ko.observable($("#user").text());
	self.FishSizes = ko.observableArray([]);
	self.EntryDate = ko.observable();
	self.SelectedItem = ko.observable();

	//..to get the data
	self.GetFishCategoryType = function () {
		$.ajax({
			dataType: "json",
			cache: false,
			async: false,

			url: '/Handler/Fishery/FishSizeSetupHandler.ashx',
			data: { 'method': 'GetFishCategoryType', 'ExpItmId': null, 'Visibility': null, 'p_rc': null, 'role': self.role() },
			contentType: "application/json; charset=utf-8",
			success: function (result) {
				var o = ko.toJS(result.ResponseData);

				var mappedTask = $.map(o, function (item) {
					return new FishSize(item)
				});

				self.FishSizes(mappedTask);

			},
			error: function (err) {

			}
		});
	}


	self.GetFishCategoryType();

	//to add to table
	self.Add = function () {

		var errMsg = "";
		var add = self.SelectedItem();


		//-----------in case to edit/update----------

		if (add != undefined) {
			add.SizeId(self.SizeId());
			add.SizeName(self.SizeName());
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

			if (self.Validation()) {

				var errMsg = "";
				var objFocus = null;
				var pro;

				add = {
					SizeId: self.SizeId(),
					// DescriptionInNepali: self.DescriptionInNepali(),
					SizeName: self.SizeName(),
					//Visibility: self.Visibility(),

					EntryBy: self.EntryBy(),
					EntryDate: null,
					Action: "A"
				};

				self.FishSizes.push(new FishSize(add));
			}
		}
	}



	self.SaveFishSize = function () {
		if (self.Validation()) {
			var obj = ko.toJS(self.FishSizes());
			var obj1 = [];

			for (var i = 0; i < obj.length; i++) {
				var kd = {
					SizeId: obj[i].SizeId,
					SizeName: obj[i].SizeName,
					EntryBy: obj[i].EntryBy,
					EntryDate: obj[i].EntryDate,
					Action: obj[i].Action
				};
				obj1.push(kd);
			}
			var k = JSON.stringify(ko.toJS(obj1));
			var url = '/Handler/Fishery/FishSizeSetupHandler.ashx';
			var method = "SaveFishSize";
			var data = { 'method': method, 'args': k, 'role': self.role() };
			$.post(url, data, function (result) {
				var obj = jQuery.parseJSON(result);
				if (obj.IsSucess) {
					msg(obj.Message);
					self.GetFishCategoryType();
				}
				else {
					msg(obj.Message, "WARNING");
				}
			});
			self.ClearControls
		}

	}


	self.EditFishZize = function (d) {
		self.SizeId(d.SizeId());
		self.SizeName(d.SizeName());

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
	self.DeleteExpenseHeadType = function (expheadtype) {
		Confirm('के तपाईं हटाउन निश्चित हुनुहुन्छ ?', 'Confirmation Dialog', function (r) {
			if (r) {
				waitMsg("Deleting");
				waitMsg.show();

				$.ajax({
					dataType: "json",
					cache: false,
					url: '../../Handlers/CAMPAIGNMANAGEMENT/ExpenseHeadItemEntry.ashx',
					data: { 'method': 'DeleteExpenseHeadType', 'expenseHeadTypeId': expheadtype.ExpenseHeadTypeID, 'role': self.role() },
					success: function (result) {
						waitMsg.hide();



						if (result.IsSucess) {
							self.ExpenseHeads.remove(expheadtype);
							msg(result.ResponseData);
						}
						else {
							if (!result.IsToken)
								msg(result.Message, "WARNING", null, ClearSession);
							else
								msg(result.Message, "WARNING");
						}

					},
					error: function (err) {
						waitMsg.hide();
						msg(err.status + " - " + err.statusText, "FAILURE");
					}
				});
			}
		});
	};


	self.Validation = function () {
		debugger;
		var errMsg = "";
		var objFocus = null;

		if (self.SizeName()) {
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

		self.SizeName(null);
		self.SelectedItem(null);
		self.Action(null);

		$("#btnAdd").text("Add");

	}

}


$(document).ready(function () {   
	ko.applyBindings(new FishSizeSetupViewModel());
});



