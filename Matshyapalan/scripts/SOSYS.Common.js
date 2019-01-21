var SOSYS = {
    init: function (self) {
        self.message = ko.observable();
        self.confirmMessage = ko.observable();
    },
    message: function (self, mesg, messageType) {
        messageType = messageType || '';
        msg(mesg, messageType.toUpperCase());
    },
    confirmMessage: function (self, msg, callback) {
        Confirm(msg, 'Confirmation Dialog', function (r) {
            if (r) {
                callback();
            }
        });
    },
    notify: function (msg, type) {
        if (type == undefined)
            type = "info";
        $.notify(msg, type);
    },
    getToken: function () {
        return $('#token').text();
    },
    getUser: function () { },
    getOffice: function () { },
    getDate: function () { return GetNepaliDate(); }

};

