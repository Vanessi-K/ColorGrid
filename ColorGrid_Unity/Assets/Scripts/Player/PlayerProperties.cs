using Grid;
using UI;
using UnityEngine;

namespace Player
{
    public class PlayerProperties : MonoBehaviour
    {
        [SerializeField] private GameObject playerCharacter;
        [SerializeField] private ColorMode colorMode;
        [SerializeField] private int playerIndex;
        [SerializeField] private PlayerColorUI[] playerColorUI;
        private PlayerStats _playerStats;
    
        public int PlayerIndex => playerIndex;
        public ColorMode ColorMode => colorMode;
        public Material PlayerMaterial { get; private set; }

        void Start()
        {
            _playerStats = GameStats.Instance.Player(playerIndex);
            _playerStats.Player = this;
            Material savedPlayerMaterial = _playerStats.PlayerMaterial;
            if (savedPlayerMaterial != null)
            {
                PlayerMaterial = savedPlayerMaterial;
            }
        
            playerCharacter.GetComponent<Renderer>().material = PlayerMaterial;
            UpdatePlayerUI();
        }

        public void UpdatePlayerMaterial(Material playerMaterial)
        {
            this.PlayerMaterial = playerMaterial;
            playerCharacter.GetComponent<Renderer>().material = playerMaterial;
            _playerStats.PlayerMaterial = playerMaterial;
            UpdatePlayerUI();
        
            Node[] playerColorNodes = Grid.Grid.Instance.Nodes(colorMode);
            foreach (Node node in playerColorNodes)
            {
                node.Tile.GetComponent<LightTile>().ChangeColor(playerMaterial, colorMode);
            }
        }

        private void UpdatePlayerUI()
        {
            if (PlayerMaterial == null) return;
            foreach (PlayerColorUI uiElement in playerColorUI)
            {
                uiElement.UpdateUIColor(PlayerMaterial);
            }
        }

        public void Die()
        {
            _playerStats.Died = true;
            GameStats.Instance.GameOver();
        }
    }
}
