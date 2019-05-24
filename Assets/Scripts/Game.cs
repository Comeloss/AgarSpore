using Generators;
using Managers;
using UnityEngine;

public class Game : Singleton<Game>
{
    public PlayersSpawner PlayersSpawner;
    
    public PlayersManager PlayersManager;

    public GameManager GameManager;
    
    
    void Awake()
    {
        GameManager = new GameManager();
        
        PlayersManager = new PlayersManager();

        PlayersSpawner.Init(PlayersManager);
    }
}


public class GameElement : MonoBehaviour 
{
    Game gm;
    protected Game game
    {
        get
        {
            return gm ?? GetGame();  
        }
    }

    Game GetGame()
    {
        gm = FindObjectOfType<Game>();
        if (gm != null)
        {
            return gm;
        }

        Debug.LogError("No Game found in Scene!");
        return gm;
    }
}