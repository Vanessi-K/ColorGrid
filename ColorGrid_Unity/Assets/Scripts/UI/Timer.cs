using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float playTimeInSeconds;
        [SerializeField] private TMP_Text timerText;
        private float _passedTime;

        void Update()
        {
            _passedTime += Time.deltaTime;
            UpdateTimer();
            if(_passedTime >= playTimeInSeconds)
                TimerIsUp();
        }
    
        void UpdateTimer()
        {
            TimeSpan time = TimeSpan.FromSeconds(playTimeInSeconds - _passedTime);
            timerText.text = time.ToString(@"m\:ss");
        }
    
        void TimerIsUp()
        {
            GameStats.Instance.GameOver();
        }
    }
}
