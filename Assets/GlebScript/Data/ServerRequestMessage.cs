using System;
using UnityEngine;

[Serializable]
public class ServerRequestMessage
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