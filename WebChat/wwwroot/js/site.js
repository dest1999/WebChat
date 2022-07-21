// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
"use strict";
var ajaxSendMessageFunction = function () {
    document.querySelector('textarea[id="userTextMessage"]').value = "";
};

var connection = new signalR.HubConnectionBuilder().withUrl("/messageSpreader").build();

connection.on("ReceiveMessage", function (stringMessage) {
    document.getElementById("messages").value += stringMessage;
})

connection.start();
