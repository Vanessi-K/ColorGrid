using UnityEngine;

namespace Grid
{
    public class Node
    {
        public readonly bool Walkable;
        public Vector3 WorldPosition;
        public readonly int GridX;
        public readonly int GridY;
        public GameObject Tile;
        
        public Node(bool walkable, Vector3 worldPosition, int gridX, int gridY)
        {
            Walkable = walkable;
            WorldPosition = worldPosition;
            GridX = gridX;
            GridY = gridY;
        }

        public override string ToString()
        {
            return "("+ GridX + "|" + GridY + "): " + Walkable;
        }
    }
}