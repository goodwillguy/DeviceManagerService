/// <reference path="~/Scripts/jquery-2.1.4.js" />
var LockerBankIdentifer = LockerBankIdentifer || {};


LockerBankIdentifer.CurrentLockerBankId = "";

LockerBankIdentifer.GetLockerBankIdentifier = function () {

    var url = "http://localhost:169/ILockerBankIdentifier/GetLockerBankCode";

    $.getJSON(url, "", function (data) {
        LockerBankIdentifer.CurrentLockerBankId = data;

    }.bind(this));

};

LockerBankIdentifer.GetAllLockers = function (lockerBankCode) {
    var def = $.Deferred();
    var url = WebApiHost.HostName + "/api/locker/getLayout?lockerBankCode=" + lockerBankCode + "";

    $.getJSON(url, '', function (layout) {
        def.resolve(layout);
    }.bind(this));



    //var data = [{ "Key": 3, "Value": [{ "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L8", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L7", "Size": "Medium", "Column": 3 }, { "LockerNumber": "L9", "Size": "Medium", "Column": 3 }] }, { "Key": 1, "Value": [{ "LockerNumber": "L2", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L1", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }, { "LockerNumber": "L3", "Size": "Medium", "Column": 1 }] }, { "Key": 2, "Value": [{ "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L5", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L6", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }, { "LockerNumber": "L4", "Size": "Medium", "Column": 2 }] }];

    //def.resolve(data);
    return def.promise();
};


LockerBankIdentifer.GetAvailableLockerForParcel = function (lockerBankCode,parcelSize) {

    var def = $.Deferred();
    var url = WebApiHost.HostName + "/api/locker/getAvailableLocker?lockerBankCode=" + lockerBankCode + "&parcelSize=1";

    $.getJSON(url, '', function (lockerData) {
        def.resolve(lockerData);
    }.bind(this));

    return def.promise();

};

LockerBankIdentifer.ReopenLocker = function (lockerData) {

    var def = $.Deferred();
    var url = WebApiHost.HostName + "/api/locker/reopenLocker?lockerBankCode=" + lockerBankCode + "&lockerId=" + lockerData.LockerId;

    $.getJSON(url, '', function (lockerData) {
        def.resolve(lockerData);
    }.bind(this));

    return def.promise();

};
LockerBankIdentifer.GetLockerBankIdentifier();