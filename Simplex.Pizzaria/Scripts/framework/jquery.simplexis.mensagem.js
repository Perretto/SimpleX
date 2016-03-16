function notification(parameters){ 
    var messageTitle = parameters.messageTitle;
    var messageText = parameters.messageText;
    var type = parameters.type;
    var icon = parameters.icon;

    alert(messageTitle + " - " + messageText);
}