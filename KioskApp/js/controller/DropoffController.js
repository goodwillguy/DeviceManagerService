/// <reference path="~/Scripts/knockout-3.3.0.debug.js" />

var DropoffController = (function () {

    function DropoffController() {
        this.SwipeController = null;
        this.AgentController = null;
        this.currentWorkFlow = ko.observable(WorkFlow.AwaitLogin);


        this.IsCardSwipeProcessing = ko.observable(false);

        this.isLoading = ko.observable(true);
        this.loadingText = ko.observable("Setting up system. Please wait");

        this.AgentData = ko.observable();

        this.ErrorText = ko.observable(null);

        this.ParcelNumber = ko.observable();

        this.barCodeHasFocus = ko.observable();


        this.barCodeHasFocus.subscribe(this.ParcelfocusChanged.bind(this));

        this.ResidentsForLockerBank = ko.observableArray([]);

        this.ResidentSelected = ko.observable();
        this.LockerBankLayout = ko.observableArray([]);



        this.AvailableLocker = ko.observable();
        this.Initialise();
        // this.TestInit();


    }

    DropoffController.prototype = {

        Initialise: function () {

            this.SwipeController = new SwipeController(this.Connecting.bind(this), this.Connected.bind(this), this.Disconnected.bind(this), this.ReceivedSwipeEvent.bind(this));

            LockerBankIdentifer.GetLockerBankIdentifier();

        },

        Connecting: function (message) {

            this.ShowLoading(message);

        },

        ShowErrorMessage: function (message) {
            this.ErrorText(message);

            var timer = setInterval(function () {
                this.ErrorText(null);
                clearInterval(timer);
            }.bind(this), 5000);
        },

        ShowLoading: function (message) {
            this.loadingText(message);
            this.isLoading(true);
        },

        HideLoading: function () {
            this.loadingText('');
            this.isLoading(false);
        },
        Connected: function (message) {
            this.HideLoading();
        },

        Disconnected: function (message) {

        },

        IsLockerOpen: function (currentData) {
            var lockerClosedStyle = 'img-rounded img-responsive locker-close';
            var lockerOpenStyle = 'img-rounded img-responsive locker-open';
            if (currentData == undefined || currentData == '' || this.AvailableLocker() == undefined || this.AvailableLocker() == '') {
                return lockerClosedStyle;
            }

            if (currentData.LockerNumber == this.AvailableLocker().LockerNumber) {
                return lockerOpenStyle;
            }

            return lockerClosedStyle;
        },

        TestInit: function () {
            LockerBankIdentifer.GetAllLockers()
            .then(function (data) {
                this.LockerBankLayout(data);
                debugger;
                this.currentWorkFlow = ko.observable(WorkFlow.Dropoff);

            }.bind(this));
        },

        LoadLockerBankLayout: function () {
            if (this.LockerBankLayout() == null || this.LockerBankLayout().length == 0) {
                LockerBankIdentifer.GetAllLockers(LockerBankIdentifer.CurrentLockerBankId)
                .done(function (lockerLayout) {

                    this.LockerBankLayout(lockerLayout);

                }.bind(this));
            }
        },

        ReceivedSwipeEvent: function (cardNumber) {
            if (this.currentWorkFlow() != WorkFlow.AwaitLogin || this.IsCardSwipeProcessing()) {
                return;
            }

            this.ShowLoading("Validating Card. Please Wait.")
            this.IsCardSwipeProcessing(true);

            AgentValidationService.ValidateAgentByCardNumber(LockerBankIdentifer.CurrentLockerBankId, cardNumber)
               .done(function (data) {
                   this.AgentData(data);
                   this.ProceedToAgentLogin();

               }.bind(this))
               .fail(function (data) {
                   this.ShowErrorMessage('Invalid Agent');
               }.bind(this))
               .always(function () {
                   this.IsCardSwipeProcessing(false);
                   this.HideLoading();
               }.bind(this));
        },

        ProceedToAgentLogin: function () {
            this.currentWorkFlow(WorkFlow.AgentWork);
        },

        DropOffWorkFlowClicked: function () {
            this.LoadResidents();
            this.LoadLockerBankLayout();
            this.currentWorkFlow(WorkFlow.ScanParcel);

        },

        ParcelNumberEntered: function () {

            var parcelNumber = this.ParcelNumber();
            if (parcelNumber == undefined || parcelNumber == null || parcelNumber == '') {
                this.ShowErrorMessage("Please enter parcel number to continue.");
                return;
            }

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

        SelectLocker: function () {
            var resident = this.ResidentSelected();
            if (resident == undefined || resident == null || resident == '') {
                this.ShowErrorMessage("Please select recipient of parcel to continue.");
                return;
            }

            LockerBankIdentifer.GetAvailableLockerForParcel(LockerBankIdentifer.CurrentLockerBankId, 1)
            .done(function (availableLocker) {

                this.AvailableLocker(availableLocker);
                this.currentWorkFlow(WorkFlow.Dropoff);


            }.bind(this))
            .fail(function () {
                this.ShowErrorMessage("No Lockers available to drop off the parcel.");
            }.bind(this));


        },

        ReturnToAgentMenu: function () {
            this.ResetWorkFlow(true);
            this.currentWorkFlow(WorkFlow.AgentWork);
        },

        ReopenLocker: function () {
            if (this.AvailableLocker() == undefined || this.AvailableLocker() == null) {
                return;
            }
            LockerBankIdentifer.ReopenLocker(this.AvailableLocker())
            .done(function () {

            }.bind(this));
        },

        PerformDropOff: function () {
            this.ShowLoading("Dropping off parcel. Please wait.")
            //this.currentWorkFlow(WorkFlow.Dropoff);
            DropOffService.DropOffParcel(LockerBankIdentifer.CurrentLockerBankId, this.AgentData().AgentId, this.ParcelNumber(), this.ResidentSelected().ResidentId, this.AvailableLocker().LockerId)
            .done(function (lockerData) {
                //this.LockerData(lockerData);
                this.ResetWorkFlow();
                this.currentWorkFlow(WorkFlow.AwaitLogin);
            }.bind(this))
            .fail(function () {
                this.ResetWorkFlow(true);
                this.currentWorkFlow(WorkFlow.AgentWork);
                this.ShowErrorMessage("Could not drop off parcel. Please retry again.");
                this.HideLoading();
            }.bind(this));
        },

        SetTheLockerToOpen: function () {
            var selectedLocker = this.AvailableLocker();


        },

        ResetWorkFlow: function (keepAgent) {

            if (keepAgent != undefined && keepAgent != null && keepAgent) {
            }
            else {
                this.AgentData(null);

            }
            this.loadingText(null);
            this.isLoading(false);
            this.ErrorText(null);
            this.ParcelNumber(null);
            this.ResidentsForLockerBank(null);
            this.ResidentSelected(null);
            this.AvailableLocker(null);
            this.currentWorkFlow(WorkFlow.AwaitLogin);


        }


    };

    return DropoffController;

}());

$(document).ready(function () {

    ko.applyBindings(new DropoffController(), document.getElementById('body')[0]);
    DomReady.IsReady(true);

});
