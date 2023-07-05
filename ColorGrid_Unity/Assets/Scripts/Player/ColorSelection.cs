using Player;
using UI;
using UnityEngine;

namespace Player
{
    public class ColorSelection : MonoBehaviour
    {
        private int _colorIndex;
        [SerializeField] private PossiblePlayerColors possiblePlayerColors;
        [SerializeField] private PlayerProperties player;
        private Material[] _playerMaterials;
        private bool _firstUpdate = true;

        private void Start()
        {
            _playerMaterials = possiblePlayerColors.PlayerMaterials;
            _colorIndex = player.PlayerIndex;
        }

        private void Update()
        {
            while (_firstUpdate)
            {
                UpdateColors();
                _firstUpdate = false;
            }
        }

        private void OnNext()
        {
            _colorIndex++;
            if (_colorIndex >= _playerMaterials.Length)
                _colorIndex = 0;
            UpdateColors();
        }

        private void OnPrevious()
        {
            _colorIndex--;
            if (_colorIndex < 0)
                _colorIndex = _playerMaterials.Length - 1;
            UpdateColors();
        }

        private void UpdateColors()
        {
            player.UpdatePlayerMaterial(_playerMaterials[_colorIndex]);
        }
    }
}
