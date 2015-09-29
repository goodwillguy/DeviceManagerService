/// <reference path="~/Scripts/jquery-2.1.4.js" />
var DropOffService = DropOffService || {};

DropOffService.DropOffParcel = function (lockerBankCode, agentId, consignmentno, residentId) {

    var def = $.Deferred();

    var url = WebApiHost.HostName + "/api/parcel/dropoffParcel";

    var data = {
        AgentId: agentId,
        LockerBankCode: lockerBankCode,
        OperatorId: agentId,
        ParcelConsignmentNumber: consignmentno,
        ResidentId: residentId
    };


    $.post(url, data, function (val) {

        if (data == "true") {
            alert("yes");
        }
        else {
            alert("no");
        }
        def.resolve();

    }.bind(this));

    return def.promise();

};