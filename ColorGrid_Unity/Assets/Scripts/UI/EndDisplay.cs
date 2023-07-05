using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [Serializable]
    public class EndPlayerElement
    {
        public int playerIndex;
        public Image dieMessage;
        public Image winMessage;
        public TMP_Text scoreText;
    }

    public class EndDisplay : MonoBehaviour
    {
        [SerializeField] private EndPlayerElement[] endPlayerElements;
        private int _highestScore;
        private Image _highestScoreWinElement;
    
        void Start()
        {
            foreach (EndPlayerElement endPlayerElement in endPlayerElements)
            {
                PlayerStats playerStats = GameStats.Instance.Player(endPlayerElement.playerIndex);
                endPlayerElement.scoreText.text = playerStats.Score + "%";
            
                if (playerStats.Score == _highestScore && !playerStats.Died)
                {
                    endPlayerElement.winMessage.gameObject.SetActive(false);
                    _highestScoreWinElement?.gameObject.SetActive(false);
                }
            
                if (playerStats.Score > _highestScore && !playerStats.Died)
                {
                    _highestScore = playerStats.Score;
                    _highestScoreWinElement?.gameObject.SetActive(false);
                    _highestScoreWinElement = endPlayerElement.winMessage;
                    _highestScoreWinElement.gameObject.SetActive(true);
                }
                else
                {
                    endPlayerElement.winMessage.gameObject.SetActive(false);
                }
            
                endPlayerElement.dieMessage.gameObject.SetActive(playerStats.Died);
            }
        }
    }
}