using UnityEngine;

public class Game : MonoBehaviour 
{
/*    public WorldManager World;
    public PlayersManager Players;
    public GameHUD HUD;
    public PopupManager PopupManager;
    public InputSystem InputSystem;

    StatesManager stateM;
    public StatesManager StatesManager
    {
        get
        {
            return stateM ?? (stateM = new StatesManager());
        }
    }

    public AgentsManager AgentsManager;
    public AreasManager AreasManager;
    public FractionsManager FractionsManager;
    public NewsManager NewsManager;
    public PathManager PathManager;*/

    void Awake()
    {
        /*Players.Init();

        PathManager = new PathManager();
        FractionsManager = new FractionsManager(LoadFractions());
        AgentsManager = new AgentsManager(LoadAgents(), this);
        AreasManager = new AreasManager(this);
        NewsManager = new NewsManager();
        
        
        World.Init();
        HUD.Init();*/

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