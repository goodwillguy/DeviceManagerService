/// <reference path="~/Scripts/knockout-3.3.0.debug.js" />
/// <reference path="~/js/jquery-2.1.1.minjs" />

    var SwipeController = (function () {

        function SwipeController(connectingCallBack,connectedCallback,disconnectedCallBack,swipeEventCallback) {
            this.cardNumber = ko.observable();

            this.isValiding = ko.observable(false);

            this.isProcessingSwipe = ko.observable(false);

            this.isListeningForCardSwipe = ko.observable(false);

            this.connectingCallBack = connectingCallBack;
            this.connectedCallback = connectedCallback;
            this.disconnectedCallBack = disconnectedCallBack;

            this.swipeEventCallback = swipeEventCallback;

            this.isTimerActive = false;

            this.timer = null;

            this.startTimer();

        }

        SwipeController.prototype = {

            startTimer: function () {
                if (this.isTimerActive)
                {
                    return;
                }
                this.isTimerActive = true;
                this.timer = setInterval(this.subscribeForSwipeEvent.bind(this), 4000);
            },

            subscribeForSwipeEvent: function () {
                CardReaderService.SubscribeForSwipeEvent(this.callbackOnEvent.bind(this))
                .done(this.subscribeToCardSwipeSuccess.bind(this))
                .fail(this.subscribeToCardSwipeFailed.bind(this));


            },

            subscribeToCardSwipeSuccess: function (messageType) {
                this.callbackOnEvent(messageType, '');

            },
            callbackOnEvent :function(messageType,data)
            {

                if(messageType==WebSocketEventEnum.Connecting)
                {
                    this.connectingCallBack("Setting up system. Please Wait.")
                    return;
                }

                if (messageType == WebSocketEventEnum.Connected)
                {
                    this.isListeningForCardSwipe(true);
                    clearInterval(this.timer);
                    this.isTimerActive = false;
                    this.connectedCallback("System is ready.")
                    return;
                }

                if(messageType==WebSocketEventEnum.ReceivedEvent)
                {
                    this.receivedCardSwipe(data);
                    return;
                }

                if(messageType==WebSocketEventEnum.Disconnected)
                {
                    this.startTimer();
                    return;
                }

            },
            subscribeToCardSwipeFailed: function () {
                this.isListeningForCardSwipe(false);
            },

            receivedCardSwipe: function (cardNumber) {
                if (this.isProcessingSwipe()) {
                    return;
                }


                this.isProcessingSwipe(true);
                this.cardNumber(cardNumber);

                this.swipeEventCallback(cardNumber);

                this.isProcessingSwipe(false);


            }


        };

        return SwipeController;
    })();

