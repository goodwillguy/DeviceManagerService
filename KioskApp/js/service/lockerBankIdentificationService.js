/// <reference path="~/Scripts/jquery-2.1.4.js" />
var LockerBankIdentifer = LockerBankIdentifer || {};


LockerBankIdentifer.CurrentLockerBankId = "";

LockerBankIdentifer.GetLockerBankIdentifier = function () {

    var url = "http://localhost:169/ILockerBankIdentifier/GetLockerBankCode";

    $.getJSON(url, "", function (data) {
        LockerBankIdentifer.CurrentLockerBankId = data;

    }.bind(this));

};

LockerBankIdentifer.GetLockerBankIdentifier();