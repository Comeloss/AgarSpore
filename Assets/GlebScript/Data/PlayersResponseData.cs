using System;
using UnityEngine;

[Serializable]
public class PlayersResponseData
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
    public float rotation;

    public float Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }

    [SerializeField]
    public int hp;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }
}