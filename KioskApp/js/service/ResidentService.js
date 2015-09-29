/// <reference path="~/Scripts/jquery-2.1.4.js" />
var ResidentService = ResidentService || {};


ResidentService.GetResident = function (lockerBankCode, searchText) {

    var def = $.Deferred();
    var url = WebApiHost.HostName + "/api/resident/GetResidents?lockerBankCode='" + lockerBankCode + "'";

    $.getJSON(url, '', function (residents) {
        def.resolve(residents);
    }.bind(this));




    def.promise();
}