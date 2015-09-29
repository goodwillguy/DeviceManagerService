/// <reference path="~/Scripts/jquery-2.1.4.js" />
var AgentValidationService = AgentValidationService || {};

AgentValidationService.ValidateAgentByCardNumber = function (lockerBankCode,agentCardNumber) {


    var parameters = "?lockerBankCode=" + lockerBankCode + "&cardNumber=" + agentCardNumber;

    var agentUrl = "http://localhost:55188/api/agent/agentForCard" + parameters;

    //var data = {
    //    lockerBankCode: lockerBankCode,
    //    cardNumber:agentCardNumber
    //};
    debugger;
    $.post(agentUrl, '')
    .done(function (agentInfo) {

        if (agentInfo != null)
        { alert('success'); }
        else
        {
            alert('failure');
        }

    }.bind(this));

};