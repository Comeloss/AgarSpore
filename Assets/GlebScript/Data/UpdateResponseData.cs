using System;
using UnityEngine;

[Serializable]
public class UpdateResponseData
{
    [SerializeField]
    public PlayerResponseData[] players;

    public PlayerResponseData[] Players
    {
        get { return players; }
        set { players = value; }
    }
}

[Serializable]
public class PlayerResponseData
{
    [SerializeField]
    public string id;

    public string PlayerId
    {
        get { return id; }
        set { id = value; }
    }

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
    public int h;

    public int H
    {
        get { return h; }
        set { h = value; }
    }
}