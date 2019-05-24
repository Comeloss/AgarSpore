using System;
using UnityEngine;

[Serializable]
public class ServerRequestMessage
{
    [SerializeField]
    public int messageType;

    public int MessageType
    {
        get { return messageType; }
        set { messageType = value; }
    }

    [SerializeField]
    public string data;

    public string Data
    {
        get { return data; }
        set { data = value; }
    }
}

[Serializable]
public class ServerMethodRequestMessage
{
    [SerializeField]
    public string methodName;

    public string MethodName
    {
        get { return methodName; }
        set { methodName = value; }
    }

    [SerializeField]
    public UpdateRequestData[] arguments;

    public UpdateRequestData[] Arguments
    {
        get { return arguments; }
        set { arguments = value; }
    }

}