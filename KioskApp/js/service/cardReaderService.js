var CardReaderService = CardReaderService || {};

CardReaderService.SubscribeForSwipeEvent=function(callbackFunction){

    var callback = callbackFunction;
    var uri='ws://localhost:169/IWebCardReaderSubscribe?Name=localhost';

    var def = new $.Deferred();


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

        alert('connected waiting for response');
        def.resolve();
    };

    websocket.onerror=function()
    {
        def.reject();
    }

    websocket.onclose = function () {
        if (document.readyState == "complete") {
            debugger;
            var warn = $('<div>').html(
                'Connection lost. Refresh the page to start again.').
                css('color', 'red');
            //$('#messages').append(warn);
            alert(warn);
        }
    };

    websocket.onmessage = function (event) {
        callback(event.data);
        //$("#messages").append(event.data + "<br>");
    };


    return def.promise();
};