﻿/// <reference path="~/Scripts/jquery-2.1.4.js" />
var AgentValidationService = AgentValidationService || {};

AgentValidationService.ValidateAgentByCardNumber = function (lockerBankCode, agentCardNumber) {


    var def = $.Deferred();

    var parameters = "?lockerBankCode='" + lockerBankCode + "'&cardNumber='" + agentCardNumber + "'";

    var body = {
        lockerBankCode: lockerBankCode,
        cardNumber: agentCardNumber
    }

    var agentUrl = WebApiHost.HostName + "/api/agent/agentByCard";

    //var data = {
    //    lockerBankCode: lockerBankCode,
    //    cardNumber:agentCardNumber
    //};
    $.post(agentUrl, body)
    .done(function (agentInfo) {

        if (agentInfo != null) {
            def.resolve(agentInfo);
        }
        else {
            def.reject('');
        }

    }.bind(this))
    .fail(function (errorMessage) {
        var message = '';
        if (errorMessage != undefined && errorMessage != null) {
            message = errorMessage.responseText.split(":")[1];
        }
        def.reject(message);
    }.bind(this));




    return def.promise();

};