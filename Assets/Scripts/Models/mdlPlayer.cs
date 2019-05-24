using System.Numerics;

namespace Models
{
    public class MdlPlayer
    {
        private string Id;
        private Vector2 Position;
        private float rotation;
        private int hp;
        private int level;
        private int xp;

        public MdlPlayer(string newId)
        {
            Id = newId;
            //configurate
            level = 1;
            xp = 0;
            hp = 5;
            
            
        }
    }
}

