﻿using System;
using System.Numerics;

namespace Models
{
    public abstract class MdlPlayer
    {
        public event Action PlayerUpdated;
        public string Id { get; private set; }
        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; }
        public int hp { get; private set; }
        public int level { get; private set; } 
        public int xp { get; private set; }

        protected MdlPlayer(string newId)
        {
            Id = newId;
            //configurate
            level = 1;
            xp = 0;
            hp = 5;
        }

        public void UpdatePlayer(Vector2 position, float rotation)
        {
            Position = position;
            Rotation = rotation;

            PlayerUpdated?.Invoke();
        }
    }
}
