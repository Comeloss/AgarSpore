using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Managers
{
    public class PlayersManager
    {
       public event Action<MdlPlayer> NewPlayerSpawned;
       public event Action<string> PlayerRemoved;
        
        private Dictionary<string ,MdlPlayer> players = new Dictionary<string, MdlPlayer>();
        
        public void UpdateGame(MdlPlayer[] playersUpdated)
        {
            foreach (var mdlPlayer in playersUpdated)
            {
                if (players.ContainsKey(mdlPlayer.Id))
                {
                    players[mdlPlayer.Id].UpdatePlayer(mdlPlayer.Position, mdlPlayer.Rotation);
                    continue;
                }

                players.Add(mdlPlayer.Id, mdlPlayer);
                NewPlayerSpawned?.Invoke(mdlPlayer);
            }

            var existingPlayers = players.Keys.ToList();
            
            foreach (var playerId in existingPlayers)
            {
                if (playersUpdated.Any(p => p.Id == playerId))
                {
                    continue;
                }

                players.Remove(playerId);
                
                PlayerRemoved?.Invoke(playerId);
            }
        }
    }
}
