/// <reference path="~/Scripts/knockout-3.3.0.debug.js" />

var DropoffController = (function () {

    function DropoffController() {
        this.SwipeController = null;
        this.AgentController = null;
        this.currentWorkFlow = ko.observable(WorkFlow.AwaitLogin);


        this.IsCardSwipeProcessing = ko.observable(false);


        this.AgentData = ko.observable();

        this.ErrorText = ko.observable();

        this.ParcelNumber = ko.observable();

        this.barCodeHasFocus = ko.observable();


        this.barCodeHasFocus.subscribe(this.ParcelfocusChanged.bind(this));

        this.ResidentsForLockerBank = ko.observableArray([]);

        this.ResidentSelected = ko.observable();
        this.Initialise();


    }

    DropoffController.prototype = {

        Initialise: function () {

            this.SwipeController = new SwipeController(this.ReceivedSwipeEvent.bind(this));

            LockerBankIdentifer.GetLockerBankIdentifier();

        },

        ReceivedSwipeEvent: function (cardNumber) {
            if (this.currentWorkFlow() != WorkFlow.AwaitLogin || this.IsCardSwipeProcessing()) {
                return;
            }


            this.IsCardSwipeProcessing(true);

            AgentValidationService.ValidateAgentByCardNumber(LockerBankIdentifer.CurrentLockerBankId, cardNumber)
               .done(function (data) {
                   this.AgentData(data);
                   this.ProceedToAgentLogin();
               }.bind(this))
               .fail(function (data) {
                   this.ErrorText('Invalid Agent');
               }.bind(this))
               .always(function () {
                   this.IsCardSwipeProcessing(false);
               }.bind(this));
        },

        ProceedToAgentLogin: function () {
            this.currentWorkFlow(WorkFlow.AgentWork);
        },

        DropOffWorkFlowClicked: function () {
            this.LoadResidents();
            this.currentWorkFlow(WorkFlow.ScanParcel);

        },

        ParcelNumberEntered: function () {
            this.currentWorkFlow(WorkFlow.SelectResident);

        },


        LoadResidents: function () {
            ResidentService.GetResident(LockerBankIdentifer.CurrentLockerBankId, '')
             .done(function (data) {
                 this.ResidentsForLockerBank(data);

             }.bind(this));

        },

        SelectedResident: function (residentSelected) {
            this.ResidentSelected(residentSelected);
        },

        OnScreenPress: function (keyValue) {

            var currentVal = this.ParcelNumber();
            if (currentVal == undefined) {
                currentVal = '';
            }
            if (keyValue == 'BACK') {
                if (currentVal.length > 0) {
                    currentVal = currentVal.substring(0, currentVal.length - 1);
                }
            }
            else {
                currentVal += keyValue;
            }
            this.ParcelNumber(currentVal);


        },

        ParcelfocusChanged: function () {
            document.getElementById("barcode").focus();
        }
        ,

        PerformDropOff: function () {

            DropOffService.DropOffParcel(LockerBankIdentifer.CurrentLockerBankId, this.AgentData().AgentId, this.ParcelNumber(), this.ResidentSelected().ResidentId)
            .done(function () {
                alert('success');
            }.bind(this))
            .error(function () {
                alert('fail');
            }.bind(this));
        },

        ResetWorkFlow:function()
        {
            this.AgentData(null);
            this.ErrorText(null);
            this.ParcelNumber(null);
            this.ResidentsForLockerBank(null);
            this.ResidentSelected(null);
            this.currentWorkFlow(WorkFlow.AwaitLogin);


        }


    };

    return DropoffController;

}());

$(document).ready(function () {

    ko.applyBindings(new DropoffController(), document.getElementById('body')[0]);
    DomReady.IsReady(true);

});
