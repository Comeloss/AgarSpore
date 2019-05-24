using System;
using UnityEngine;

[Serializable]
public class MoveRotateRequestData
{
    [SerializeField]
    public float x;

    public float X
    {
        get { return x; }
        set { X = value; }
    }

    [SerializeField]
    public float y;

    public float Y
    {
        get { return y; }
        set { y = value; }
    }

    [SerializeField]
    public float rotation;

    public float Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }
}