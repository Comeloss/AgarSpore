using BestHTTP.WebSocket;
using UnityEngine;
using System;

namespace Assets.GlebScript
{
    public class ConnectionManager : Singleton<ConnectionManager>
    {
        // Start is called before the first frame update
        void Start()
        {
            var webSocket = new WebSocket(new Uri("ws://192.168.88.178:5000/messages"));
            webSocket.Open();

            webSocket.OnOpen += OnWebSocketOpen;
            webSocket.OnMessage += OnMessageReceived;
            webSocket.OnBinary += OnBinaryMessageReceived;
            webSocket.OnClosed += OnWebSocketClosed;
            webSocket.OnError += OnError;
            webSocket.OnErrorDesc += OnErrorDesc;
        }

        private void OnWebSocketOpen(WebSocket webSocket)
        {
            Debug.Log("WebSocket Open!");
        }

        private void OnWebSocketClosed(WebSocket webSocket, UInt16 code, string message)
        {
            Debug.Log("WebSocket Closed!");
        }

        private void OnMessageReceived(WebSocket webSocket, string message)
        {
            Debug.Log("Text Message received from server: " + message);
        }

        private void OnBinaryMessageReceived(WebSocket webSocket, byte[] message)
        {
            Debug.Log("Binary Message received from server. Length: " + message.Length);
        }

        private void OnError(WebSocket ws, Exception ex)
        {
            string errorMsg = string.Empty;
            if (ws.InternalRequest.Response != null)
                errorMsg = string.Format("Status Code from Server: {0} and Message: {1}",
                    ws.InternalRequest.Response.StatusCode,
                    ws.InternalRequest.Response.Message);

            Debug.Log("An error occured: " + (ex != null ? ex.Message : "Unknown: " + errorMsg));
        }

        private void OnErrorDesc(WebSocket ws, string error)
        {
            Debug.Log("Error: " + error);
        }

        public void MoveRotate(float x, float y, float rotation)
        {

        }
    }
}
