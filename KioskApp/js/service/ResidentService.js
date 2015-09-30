/// <reference path="~/Scripts/jquery-2.1.4.js" />
var ResidentService = ResidentService || {};


ResidentService.GetResident = function (lockerBankCode, searchText) {

    var def = $.Deferred();
    var url = WebApiHost.HostName + "/api/resident/GetResidents?lockerBankCode=" + lockerBankCode + "";

    $.get(url)
    .done(function (residents) {
        def.resolve(residents);
    }.bind(this))
    .fail(function () {
        def.reject();
    }.bind(this));




    return def.promise();
}