using BestHTTP.WebSocket;
using UnityEngine;
using System;

namespace Assets.GlebScript
{
    public class ConnectionManager : Singleton<ConnectionManager>
    {
        private WebSocket _webSocket;
        public string UserId;

        void Start()
        {
            _webSocket = new WebSocket(new Uri("ws://192.168.88.178:5000/messages"));

            _webSocket.OnOpen += OnWebSocketOpen;
            _webSocket.OnMessage += OnMessageReceived;
            _webSocket.OnBinary += OnBinaryMessageReceived;
            _webSocket.OnClosed += OnWebSocketClosed;
            _webSocket.OnError += OnError;
            _webSocket.OnErrorDesc += OnErrorDesc;

            Connect();
        }

        void OnDestroy()
        {
            Disconnect();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SendUpdate(1, 1, 1);
            }
        }

        #region WebSocket Events

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

            var serverResponse = JsonUtility.FromJson<ServerResponseMessage>(message);

            HandleServerResponse(serverResponse);
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

            Disconnect();
        }

        private void OnErrorDesc(WebSocket ws, string error)
        {
            Debug.Log("Error: " + error);
        }

        #endregion

        #region Response

        private void HandleServerResponse(ServerResponseMessage serverResponse)
        {
            if (serverResponse == null)
            {
                Debug.Log("Error: null server response");
                return;
            }

            if (serverResponse.MessageType == 2)
            {
                UserId = serverResponse.Data;
            }
            else if (serverResponse.MessageType == 1)
            {
                var serverResponseArguments = JsonUtility.FromJson<ServerArgumentsResponse>(serverResponse.Data);

                if (serverResponseArguments == null)
                {
                    Debug.Log("Error: null server response arguments");
                    return;
                }

                switch (serverResponseArguments.MethodName)
                {
                    case "Update":
                        OnServerUpdateMethod(serverResponseArguments.Arguments[0]);
                        break;
                }
            }
        }

        private void OnServerUpdateMethod(UpdateResponseData data)
        {
            //var updateData = JsonUtility.FromJson<UpdateResponseData>(data);

            Debug.Log("OnServerUpdateMethod: " + data.Players[0].PlayerId);
        }

        #endregion

        #region Request

        public void Connect()
        {
            if (!_webSocket.IsOpen)
            {
                _webSocket.Open();
            }
            else
            {
                Debug.Log("Error: web socket already open");
            }
        }

        public void Disconnect()
        {
            //if (!_webSocket.IsOpen) return;

            _webSocket.Close();
        }

        public void SendUpdate(float x, float y, float r)
        {
            var data = new ServerMethodRequestMessage()
            {
                methodName = "Update",
                arguments = new[]
                {
                    new UpdateRequestData()
                    {
                        x = x,
                        y = y,
                        r = r
                    }

                }
            };

            var requestData = new ServerRequestMessage()
            {
                messageType = 0,
                data = JsonUtility.ToJson(data)
            };

            string message = JsonUtility.ToJson(data);//JsonUtility.ToJson(requestData);

            Debug.Log("SendUpdate message: " + message);

            _webSocket.Send(message);
        }

        #endregion
    }
}
