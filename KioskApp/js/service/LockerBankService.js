/// <reference path="~/Scripts/jquery-2.1.4.js" />
var LockerBankService = LockerBankService || {};

LockerBankService.DeviceManagerUrl = "http://localhost:169/IDeviceManager";

LockerBankService.OpenLocker=function(serialNumber)
{
    var def = $.Deferred();

    var url = LockerBankService.DeviceManagerUrl + "/Open";

    var data = {
        SerialNumber: serialNumber
    };

    $.ajax({
        url: url,
        type: "POST",
        data: JSON.stringify(data),
        contentType: "application/json",
        dataType: 'json'
    })
    .done(function (data) {
        def.resolve(data);
    }.bind(this))
    .fail(function (errorMessage) {

        def.reject('');

    }.bind(this));

    return def.promise();

}