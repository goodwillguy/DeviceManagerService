/// <reference path="~/Scripts/knockout-3.3.0.debug.js" />

var WorkFlow = WorkFlow || {};

WorkFlow.AwaitLogin = 0;

WorkFlow.AgentWork = 1;

WorkFlow.ScanParcel = 2;
WorkFlow.SelectResident = 3;

WorkFlow.Dropoff = 4;

WorkFlow.DropoffConfimation = 5;


var DropoffController = (function () {

    function DropoffController() {
        this.SwipeController = null;
        this.AgentController = null;
        this.currentWorkFlow = ko.observable(WorkFlow.ScanParcel);
    }

    return DropoffController;

}());