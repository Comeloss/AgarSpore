using System;
using UnityEngine;

[Serializable]
public class UpdateRequestData
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
    public float r;

    public float R
    {
        get { return r; }
        set { r = value; }
    }

    [SerializeField]
    public string id;

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    [SerializeField]
    public bool s;

    public bool S
    {
        get { return s; }
        set { s = value; }
    }
}