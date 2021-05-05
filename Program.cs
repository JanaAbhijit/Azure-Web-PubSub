using System;
using Azure.Messaging.WebPubSub;
using Websocket.Client;

var webPubSubServiceClient = new WebPubSubServiceClient("Endpoint=https://azurepubsubdemo.webpubsub.azure.com;AccessKey=tGXgGGnOSpnCSiVdZIZ+P1L19/YWBjcqNjEf+xEgD/0=;Version=1.0;", "Hub");
var url = webPubSubServiceClient.GetClientAccessUri();
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("Connecting with Client....");
using (var websocketClient = new WebsocketClient(url))
{
    Console.ForegroundColor = ConsoleColor.Green;
    websocketClient.MessageReceived.Subscribe(receivedMessage => Console.WriteLine($"Message received: {receivedMessage}"));
    await websocketClient.Start();
    Console.WriteLine("Connected.. Waiting for Message");
    Console.Read();
}

