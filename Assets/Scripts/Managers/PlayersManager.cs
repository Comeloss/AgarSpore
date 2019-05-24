using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;

namespace Managers
{
    public class PlayersManager
    {
       public event Action<MdlPlayer> NewPlayerSpawned;
       public event Action<string> PlayerRemoved;
        
        private Dictionary<string ,MdlPlayer> players = new Dictionary<string, MdlPlayer>();
        
        public void UpdateGame(UpdateResponseData data)
        {
            foreach (var mdlPlayer in data.players)
            {        
                if (players.ContainsKey(mdlPlayer.id))
                {
                    var pos = new Vector2(mdlPlayer.x, mdlPlayer.y);   
                    players[mdlPlayer.id].UpdatePlayer(pos, mdlPlayer.r, mdlPlayer.s);
                    continue;
                }

                var player = new MdlPlayer(mdlPlayer.id); 

                players.Add(mdlPlayer.id, player);
                NewPlayerSpawned?.Invoke(player);
            }

            var existingPlayers = players.Keys.ToList();
            
            foreach (var playerId in existingPlayers)
            {
                if (data.players.Any(p => p.id == playerId))
                {
                    continue;
                }

                players.Remove(playerId);
                
                PlayerRemoved?.Invoke(playerId);
            }
        }
    }
}
