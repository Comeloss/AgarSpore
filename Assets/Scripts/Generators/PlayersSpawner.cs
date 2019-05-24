using System.Collections.Generic;
using Controllers;
using Managers;
using Models;
using UnityEngine;

namespace Generators
{
    public class PlayersSpawner : MonoBehaviour
    {
        [SerializeField] private PlayerController spore;

        private PlayersManager playersManager;

        private Dictionary<string, PlayerController> controllers = new Dictionary<string, PlayerController>();
        
        void SpawnPlayer(MdlPlayer player)
        {
            var playerController = Instantiate(spore, transform);
            playerController.Init(player);
            
            controllers.Add(player.Id, playerController);
        }
        
        void DestroyPlayer(string playerId)
        {
            if(!controllers.ContainsKey(playerId))
            {
                return;
            }

            Destroy(controllers[playerId].gameObject);

            controllers.Remove(playerId);
        }

        public void Init(PlayersManager pManager)
        {
            playersManager = pManager;
            playersManager.NewPlayerSpawned += SpawnPlayer;
            playersManager.PlayerRemoved += DestroyPlayer;
        }
    }
}
