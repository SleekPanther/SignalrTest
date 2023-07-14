$(function () {
    console.log('sync flightplan')
    let connection = $.connection.stockTickerHub;  //camel case name of c# class
    let connection2 = $.hubConnection();
    let hubProxy = connection.createHubProxy('chatHub');    //not sure if needed

    //https://learn.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/hubs-api-guide-server#how-to-call-client-methods-from-the-hub-class
    connection.client.updateSyncStatus = function (message) {
        console.log('Received signalr message', message);
        $('#messageContainer').append('<p>' + message + '</p>');
    };

    //chatgpt
    //hubProxy.on('sendMessage', function (message) {
    //    console.log('Received signalr message', message);
    //    $('#messageContainer').append('<p>' + message + '</p>');
    //});

    //microsoft, probably call server
    //hubProxy.server.sendMessage().done(function (message) {
    //    console.log('Received another signalr message', message);
    //    $('#messageContainer').append('<p>' + message + '</p>');
    //});

    //$.connection.hub.start().done(function () {
    connection.start().done(function () {
        console.log('Connected to SignalR hub.');
    })
    .fail(function (error) {
        console.log('Error connecting to SignalR hub: ' + error);
    });
});

////SignalR script to update the chat page and send messages
//$(function () {
//    // Reference the auto-generated proxy for the hub.
//    let chat = $.connection.chatHub;
//    // Create a function that the hub can call back to display messages.
//    chat.client.addNewMessageToPage = function (name, message) {
//        // Add the message to the page.
//        $('#syncingStatus').innerHTML = `<strong>${name} </strong>: ${message}`;
//    };

//    // Get the user name and store it to prepend to messages.
//    $('#displayname').val(prompt('Enter your name:', ''));
//    // Set initial focus to message input box.  
//    $('#message').focus();

//    // Start the connection.
//    $.connection.hub.start().done(function () {
//        $('#sendmessage').click(function () {
//            // Call the Send method on the hub.
//            chat.server.send($('#displayname').val(), $('#message').val());
//            // Clear text box and reset focus for next comment. 
//            $('#message').val('').focus();
//        });
//    }).fail(function () {
//        console.error("Hub error");
//    })
//});

//// This optional function html-encodes messages for display in the page.
//function htmlEncode(value) {
//    let encodedValue = $('<div />').text(value).html();
//    return encodedValue;
//}