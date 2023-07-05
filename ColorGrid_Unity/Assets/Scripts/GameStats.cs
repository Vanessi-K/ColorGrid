using System;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats
{
    public Material PlayerMaterial;
    public PlayerProperties Player;
    public bool Died;
    public int Score;
}

public class GameStats : MonoBehaviour
{
    private Grid.Grid _grid;
    private int _maxNodes;
    private Array _colorModeValues;
    private Dictionary<int, int> _tileColorValues = new Dictionary<int, int>();
    public static GameStats Instance;
    private PlayerStats[] _players;
    
    public PlayerStats Player(int playerIndex)
    {
        return _players[playerIndex];
    }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _players = new PlayerStats[2];
            _players[0] = new PlayerStats();
            _players[1] = new PlayerStats();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        _grid = Grid.Grid.Instance;
        _maxNodes = _grid.MaxSize;
        _colorModeValues = Enum.GetValues(typeof(ColorMode));

        foreach (int colorMode in _colorModeValues)
        {
            _tileColorValues.Add(colorMode, 0);
        }
        
        UpdateTileColorStats();
    }

    public void UpdateTileColorStats()
    {
        foreach (ColorMode colorMode in _colorModeValues)
        {
            _tileColorValues[(int)colorMode] = Grid.Grid.Instance.NumberOfNodes(colorMode);
        }
    }
    
    public int TileNumbersPercentage(ColorMode colorMode)
    {
        return _tileColorValues[(int)colorMode] * 100 / _maxNodes;
    }
    
    public void GameOver()
    {
        foreach (PlayerStats player in _players)
        {
            player.Score = TileNumbersPercentage(player.Player.ColorMode);
        }

        SceneManager.LoadScene("EndScene");
    }
}
