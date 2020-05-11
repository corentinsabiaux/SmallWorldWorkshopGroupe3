﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    #region Singleton
    public static GameManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("More than one instance of GameData found!");
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
        InitiGame();
    }

    #endregion

    public enum GamePhase
    {
        FirstTurn,
        ClassicTurn,
    }

    public List<Player> players;
    public List<int> playersToRedeploy;
    public GameObject[] playerFloat = new GameObject[5]; //les 4 flottants en eux même, le 5 est reservé au placeholder.
    //0 = cactus
    //1 = salamandre
    //2 = automate
    //3 = skeleton
    //4 = placeholder
    public Vector3[] playerFloatXYZ = new Vector3[4]; //la location pour les 4 flottants
    public Deck powerAndRaceDeck;
    public Board board;
    public int gameTurn;
    public int activePlayerNumber;
    public int selectedCase;
    public int selectedNumber;
    public GamePhase gamePhase;
    public delegate void OnNextTurn();
    public OnNextTurn onNextTurnCallback;
    public delegate void OnUiChange();
    public OnUiChange onUiChangeCallBack;
    public delegate void onEndGame();
    public onEndGame onEndGameCallback;
    public int SceneToLoad;//permet de choisir la scene a charger via les build settings
    public GameObject token;// appelle l'objet 3d
    public Texture[] albedo = new Texture[4];// appelle les 4 couleurs de joueurs
    public GameObject[] turnPlayerByLight = new GameObject[4]; //On appelle les 4 spots qui éclairent les tours des joueurs quand c'est leurs tours.



    // Start is called before the first frame update
    void Start() {   }
    // Update is called once per frame
    void Update(){   }

    void InitiGame()
    {
        board = new Board();
        powerAndRaceDeck = new Deck();
        players = new List<Player>() { new Player(1), new Player(2), new Player(3), new Player(4) };
        playersToRedeploy = new List<int>();
        gameTurn = 1;
        activePlayerNumber = 1;
        gamePhase = GamePhase.FirstTurn;
        selectedCase = -1;
        selectedNumber = 0;

    }
    public int RollTheDice()
    {
        switch (Random.Range(1, 7))
        {
            case 1:
                return 0;
            case 2:
                return 1;
            case 3:
                return 0;
            case 4:
                return 2;
            case 5:
                return 0;
            case 6:
                return 3;
            default:
                return 0;
        }
    }

    public void NextPlayer()
    {
        if (activePlayerNumber == players.Count)
        {
            if (gameTurn == 10)
            {
                EndOfGame();
                SceneManager.LoadScene(SceneToLoad);//charge la scene
            }
            else
            {
                if (gamePhase == GamePhase.ClassicTurn)
                {
                    NextTurn();
                }
                activePlayerNumber = 1;
                gamePhase = GamePhase.ClassicTurn;
            }

        }
        else
        {
            activePlayerNumber++;
        }
        refreshUis();

    }
    public void refreshUis()
    {
        onUiChangeCallBack?.Invoke();
    }
    public void NextTurn()
    {
        gameTurn++;
        onNextTurnCallback?.Invoke();
        refreshUis();
    }

    public void EndOfGame(){
        onEndGameCallback?.Invoke();
    }

    
   

}
