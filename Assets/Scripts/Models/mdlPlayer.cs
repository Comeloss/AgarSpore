using System;
using UnityEngine;

namespace Models
{
    public class MdlPlayer
    {
        public event Action PlayerUpdated;
        public event Action PlayerDamadged;
        public string Id { get; private set; }
        public Vector2 Position { get; private set; }
        public float Rotation { get; private set; }
        
        public bool isShooting { get; private set; }
        public int fullHp { get; private set; }
        public int currentHp 
        {
            get
            {
                return chp;
            }
            private set
            {
                if (value != chp)
                {
                    chp = value;
                    PlayerDamadged?.Invoke();
                }
            }
        }
        public int level { get; private set; } 
        public int xp { get; private set; }

        private int chp;

        public MdlPlayer(string newId, int h)
        {
            Id = newId;
            fullHp = h;
            //configurate
            level = 1;
            xp = 0;
            currentHp = h;
        }

        public void UpdatePlayer(Vector2 position, float rotation, bool isS, int h)
        {
            Position = position;
            Rotation = rotation;
            isShooting = isS;
            currentHp = h;

            if (PlayerUpdated != null)
            {
                PlayerUpdated.Invoke();
            }
        }
    }
}

