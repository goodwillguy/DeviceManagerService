var CardReaderService = CardReaderService || {};

CardReaderService.SubscribeForSwipeEvent = function (callbackFunction) {



    var callback = callbackFunction;
    var uri = 'ws://localhost:169/IWebCardReaderSubscribe?Name=localhost';

    var def = new $.Deferred();

    callbackFunction(WebSocketEventEnum.Connecting, '');
    var websocket = new WebSocket(uri);

    websocket.onopen = function () {
        //window.focus();
        //$('#echoForm').hide();
        //$('#outputArea').show();
        ////websocket.send("the time is " + new Date());
        ////window.setInterval(function()
        ////{
        ////   websocket.send("the time is " + new Date());
        ////}, 1000);                
        //$('#messages').html(
        //    '<div>Connected. Waiting for messages...</div>');

        // alert('connected waiting for response');
        def.resolve(WebSocketEventEnum.Connected);


    };

    setInterval(function () {
        if (websocket.readyState) {
            debugger;
            websocket.send("KeepAlive");
        }
    }.bind(this), 30000);


    websocket.onerror = function () {
        def.resolve(WebSocketEventEnum.Disconnected);
    }

    websocket.onclose = function () {
        callback(WebSocketEventEnum.Disconnected, '');
    };

    websocket.onmessage = function (event) {
        callback(WebSocketEventEnum.ReceivedEvent, event.data);
        //$("#messages").append(event.data + "<br>");
    };



    return def.promise();
};