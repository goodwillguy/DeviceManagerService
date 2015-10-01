/// <reference path="~/Scripts/jquery-2.1.4.js" />
var ResidentService = ResidentService || {};


ResidentService.GetResident = function (lockerBankCode, searchText) {

    var def = $.Deferred();
    var url = WebApiHost.HostName + "/api/resident/GetResidents?lockerBankCode=" + lockerBankCode + "";

    $.get(url)
    .done(function (residents) {
        def.resolve(residents);
    }.bind(this))
   .fail(function (errorMessage) {
       var message = '';
       if (errorMessage != undefined && errorMessage != null) {
           message = errorMessage.responseText.split(":")[1];
       }
       def.reject(message);
   }.bind(this));




    return def.promise();
}