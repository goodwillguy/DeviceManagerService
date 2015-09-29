/// <reference path="~/Scripts/knockout-3.3.0.debug.js" />
/// <reference path="~/js/jquery-2.1.1.minjs" />

    var SwipeController = (function () {

        function SwipeController(swipeEventCallback) {
            this.cardNumber = ko.observable();

            this.isValiding = ko.observable(false);

            this.isProcessingSwipe = ko.observable(false);

            this.isListeningForCardSwipe = ko.observable(false);


            this.callBack = swipeEventCallback;

            this.timer = null;

            this.startTimer();

        }

        SwipeController.prototype = {

            startTimer: function () {
                this.timer = setInterval(this.subscribeForSwipeEvent.bind(this), 4000);
            },

            subscribeForSwipeEvent: function () {
                CardReaderService.SubscribeForSwipeEvent(this.receivedCardSwipe.bind(this))
                .done(this.subscribeToCardSwipeSuccess.bind(this))
                .fail(this.subscribeToCardSwipeFailed.bind(this));


            },

            subscribeToCardSwipeSuccess: function () {
                this.isListeningForCardSwipe(true);
                clearInterval(this.timer);

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

                this.callBack(cardNumber);

                this.isProcessingSwipe(false);


            }


        };

        return SwipeController;
    })();

