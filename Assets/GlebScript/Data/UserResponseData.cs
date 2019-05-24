using System;
using UnityEngine;

[Serializable]
public class UserResponseData
{
    [SerializeField]
    public string id;

    public string UserId
    {
        get { return id; }
        set { id = value; }
    }
}