using System;
using Player;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private PlayerProperties player;
        private ColorMode _colorMode;

        private String ScorePercentage
        {
            get => GameStats.Instance.TileNumbersPercentage(_colorMode) +  "%";
        }
    
        void Start()
        {
            _colorMode = player.ColorMode;
        }

        void Update()
        {
            scoreText.text = ScorePercentage;
        }
    }
}
