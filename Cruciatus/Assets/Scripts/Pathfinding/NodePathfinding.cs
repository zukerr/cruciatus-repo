using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePathfinding
{
    public float GCost { get; set; }
    public float HCost { get; set; }
    public float FCost { get; set; }

    public int GridX { get; private set; }
    public int GridY { get; private set; }

    public NodePathfinding Parent { get; set; }

    public NodePathfinding(int gridX, int gridY, float gCost = 0f, float hCost = 0f, NodePathfinding parent = null)
    {
        this.GCost = gCost;
        this.HCost = hCost;
        this.Parent = parent;
        this.GridX = gridX;
        this.GridY = gridY;
        FCost = gCost + hCost;
    }

    public List<Vector2Int> Neighbours()
    {
        List<Vector2Int> results = new List<Vector2Int>();
        results.Add(new Vector2Int(GridX, GridY + 1));
        results.Add(new Vector2Int(GridX + 1, GridY));
        results.Add(new Vector2Int(GridX, GridY - 1));
        results.Add(new Vector2Int(GridX - 1, GridY));
        
        if(GridPathfinding.instance.UseDiagonals)
        {
            results.Add(new Vector2Int(GridX + 1, GridY + 1));
            results.Add(new Vector2Int(GridX + 1, GridY - 1));
            results.Add(new Vector2Int(GridX - 1, GridY - 1));
            results.Add(new Vector2Int(GridX - 1, GridY + 1));
        }

        return results;
    }

    public bool MyEquals(NodePathfinding other)
    {
        if(this.GridX == other.GridX)
        {
            if(this.GridY == other.GridY)
            {
                return true;
            }
        }
        return false;
    }

    public bool DiagonalNeighbour(NodePathfinding neighbour)
    {
        if((neighbour.GridX == this.GridX + 1) && (neighbour.GridY == this.GridY + 1))
        {
            return true;
        }
        else if ((neighbour.GridX == this.GridX + 1) && (neighbour.GridY == this.GridY - 1))
        {
            return true;
        }
        else if ((neighbour.GridX == this.GridX - 1) && (neighbour.GridY == this.GridY - 1))
        {
            return true;
        }
        else if ((neighbour.GridX == this.GridX - 1) && (neighbour.GridY == this.GridY + 1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
