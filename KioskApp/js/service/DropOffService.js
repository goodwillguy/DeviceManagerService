/// <reference path="~/Scripts/jquery-2.1.4.js" />
var DropOffService = DropOffService || {};

DropOffService.DropOffParcel = function (lockerBankCode, agentId, consignmentno, residentId, availableLockerId) {

    var def = $.Deferred();

    var url = WebApiHost.HostName + "/api/parcel/dropoffParcel";

    var data = {
        AgentId: agentId,
        LockerBankCode: lockerBankCode,
        OperatorId: agentId,
        ParcelConsignmentNumber: consignmentno,
        ResidentId: residentId,
        LockerId: availableLockerId
    };


    $.post(url, data)
    .done(function (val) {

        def.resolve();

    }.bind(this))
    .fail(function () {
        def.reject();
    }.bind(this));

    return def.promise();

};