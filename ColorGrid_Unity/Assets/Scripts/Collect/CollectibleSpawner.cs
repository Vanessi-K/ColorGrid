using UnityEngine;

namespace Collect
{
    public class CollectibleSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject collectiblePrefab;
        [SerializeField] private float spawningInterval;
        private float _timeSinceLastSpawn;
        private Grid.Grid _grid;

        private void Start()
        {
            _grid = Grid.Grid.Instance;
        }
    
        void Update()
        {
            if (spawningInterval <= _timeSinceLastSpawn)
            {
                _timeSinceLastSpawn = 0;
                SpawnCollectible();
            }
        
            _timeSinceLastSpawn += Time.deltaTime;
        }
    
        void SpawnCollectible()
        {
            Vector3 randomPosition = _grid.GetRandomPositionInGrid();
            randomPosition.y = 0;
            Instantiate(collectiblePrefab, randomPosition, Quaternion.identity);
        }
    }
}
