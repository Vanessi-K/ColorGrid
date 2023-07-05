using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Grid
{
    public class Grid : MonoBehaviour
    {
        [SerializeField] private LayerMask unwalkableMask;
        [SerializeField] private Vector2 gridWorldSize;
        [SerializeField] private float nodeRadius;
        [SerializeField] private bool displayGridGizmos;
        [SerializeField] private GameObject tile;
        private Node[,] _grid;
        private float _nodeDiameter;
        private int _gridSizeX, _gridSizeY;
        public static Grid Instance;
    
        public int MaxSize => _gridSizeX * _gridSizeY;

        private void Awake()
        {
            Instance = this;
        
            _nodeDiameter = nodeRadius * 2;
            _gridSizeX = Mathf.RoundToInt(gridWorldSize.x / _nodeDiameter);
            _gridSizeY = Mathf.RoundToInt(gridWorldSize.y / _nodeDiameter);

            CreateGrid();
            DrawGrid();
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireCube(transform.position, new Vector3(gridWorldSize.x, 1, gridWorldSize.y));
        
            if (_grid != null && displayGridGizmos)
            {
                foreach (Node node in _grid)
                {
                    Gizmos.color = node.Walkable ? Color.white : Color.red;
                    Gizmos.DrawCube(node.WorldPosition, Vector3.one * (_nodeDiameter - 0.1f));
                }
            }
        }

        private void CreateGrid()
        {
            _grid = new Node[_gridSizeX, _gridSizeY];
            // The zero | zero position will be the bottom left corner of the _grid
            Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;

            for (int x = 0; x < _gridSizeX; x++)
            {
                for (int y = 0; y < _gridSizeY; y++)
                {
                    // Starting from the bottom left (0|0) calculate the position oof the current node (x*_nodeDiameter = all nodes till this one, + nodeRadius = center of the node
                    Vector3 worldPoint = worldBottomLeft + Vector3.right * (x * _nodeDiameter + nodeRadius) + Vector3.forward * (y * _nodeDiameter + nodeRadius);
                    //ChecksSphere checks if you collide with anything in the given radius
                    bool walkable = !Physics.CheckSphere(worldPoint, nodeRadius, unwalkableMask);
                    _grid[x, y] = new Node(walkable, worldPoint, x, y);
                }
            }
        }

        private void DrawGrid()
        {
            foreach (Node node in _grid)
            {
                GameObject tileInstance = Instantiate(tile, node.WorldPosition, Quaternion.identity);
                tileInstance.transform.parent = transform;
                node.Tile = tileInstance;
            }
        }
    
        public List<Node> GetNeighbours(Node node)
        {
            List<Node> neighbours = new List<Node>();
        
            // Check all the nodes around the current node
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if(x == 0 && y == 0) continue;
                
                    int checkX = node.GridX + x;
                    int checkY = node.GridY + y;
                
                    //Check if node (at this position) is in the _grid 
                    if (checkX >= 0 && checkX < _gridSizeX && checkY >= 0 && checkY < _gridSizeY)
                    {
                        neighbours.Add(_grid[checkX, checkY]);
                    }
                }
            }
        
            return neighbours;
        }
    
        public Node NodeFromWorldPosition(Vector3 worldPosition)
        {
            // Get the percentage of the position in the grid for the axis
            float percentX = (worldPosition.x + gridWorldSize.x / 2) / gridWorldSize.x;
            float percentY = (worldPosition.z + gridWorldSize.y / 2) / gridWorldSize.y;
        
            // Normalize if value is out of the grid
            percentX = Mathf.Clamp01(percentX);
            percentY = Mathf.Clamp01(percentY);
        
            // Th minus one is needed because the array starts at zero so the last value of te size does not exist in the array
            int x = Mathf.RoundToInt((_gridSizeX - 1) * percentX);
            int y = Mathf.RoundToInt((_gridSizeY - 1) * percentY);
            Debug.Log($"{x} | {y}");
        
            return _grid[x, y];
        }

        public int NumberOfNodes(ColorMode colorMode) {
            return _grid.Cast<Node>().Count(node => node.Tile != null && node.Tile.GetComponent<LightTile>().ColorMode == colorMode);
        }
    
        public Node[] Nodes(ColorMode colorMode) {
            return _grid.Cast<Node>().Where(node => node.Tile != null && node.Tile.GetComponent<LightTile>().ColorMode == colorMode).ToArray();
        }
    
        private Node GetRandomNodeInGrid()
        {
            int x = Random.Range(0, _gridSizeX);
            int y = Random.Range(0, _gridSizeY);
            return _grid[x, y];
        }
    
        public Vector3 GetRandomPositionInGrid()
        {
            return GetRandomNodeInGrid().WorldPosition;
        }
    }
}
