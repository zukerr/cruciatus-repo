using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class GridPathfinding : MonoBehaviour
{
    public static GridPathfinding instance;

    [SerializeField]
    private Tilemap tilemapBase = null;
    [SerializeField]
    private bool useDiagonals = false;

    private float tileSize = 1f;
    private float tileDiag { get { return tileSize * Mathf.Sqrt(2); } }
    private int tilesCount;
    //private List<Vector2Int> walkableTiles;
    //private List<NodePathfinding> walkableNodes;
    private NodePathfinding[,] walkableNodesArray;
    //bottom left corners of square tiles
    //private List<Vector3> worldWalkableTiles;
    private Vector3[,] worldWalkableTilesArray;
    private Grid tilemapGrid;

    public bool UseDiagonals => useDiagonals;

    private void Awake()
    {
        instance = this;
        CountTiles();
    }

    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        //walkableTiles = new List<Vector2Int>();
        //worldWalkableTiles = new List<Vector3>();
        //walkableNodes = new List<NodePathfinding>();
        Debug.Log("x: " + tilemapBase.size.x + " y: " + tilemapBase.size.y);
        Debug.Log(tilemapBase.origin);
        //CountTiles();
        /*
        foreach (Vector2Int tile in walkableTiles)
        {
            Vector3 tileWorldPos = new Vector3(tile.x + tilemapBase.origin.x, tile.y + tilemapBase.origin.y, 0);
            //Instantiate(prefab, tileWorldPos, prefab.transform.rotation);
            worldWalkableTiles.Add(tileWorldPos);
            walkableNodes.Add(new NodePathfinding(tile.x, tile.y));
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetTiles()
    {

    }

    private void CountTiles()
    {
        //walkableTiles = new List<Vector2Int>();
        //worldWalkableTiles = new List<Vector3>();
        //walkableNodes = new List<NodePathfinding>();

        BoundsInt bounds = tilemapBase.cellBounds;
        tilemapGrid = tilemapBase.layoutGrid;
        //tilemapGrid.
        TileBase[] allTiles = tilemapBase.GetTilesBlock(bounds);
        walkableNodesArray = new NodePathfinding[bounds.size.x, bounds.size.y];
        worldWalkableTilesArray = new Vector3[bounds.size.x, bounds.size.y];


        tilesCount = 0;
        for(int i = 0; i < bounds.size.x; i++)
        {
            for(int j = 0; j < bounds.size.y; j++)
            {
                /*
                if(tilemapBase.HasTile(new Vector3Int(i, j, 0)))
                {
                    tilesCount++;
                    tilemapBase.SetColor(new Vector3Int(i, j, 0), Color.green);
                }
                */
                TileBase tempTile = allTiles[i + j * bounds.size.x];
                if(tempTile != null)
                {
                    tilesCount++;
                    //walkableTiles.Add(new Vector2Int(i, j));
                    //Debug.Log("x: " + i + " y: " + j + " tile: " + tempTile.name);
                    walkableNodesArray[i, j] = new NodePathfinding(i, j);
                    worldWalkableTilesArray[i, j] = new Vector3(i + tilemapBase.origin.x, j + tilemapBase.origin.y);
                    //Vector3Int localPlace = (new Vector3Int(i, j, (int)tilemapBase.transform.position.y));
                    //Vector3 place = tilemapBase.CellToWorld(localPlace);
                    //Debug.Log("place: ")
                }
            }
        }
        //Debug.Log("Tiles count: " + tilesCount);

        /*
        foreach (Vector2Int tile in walkableTiles)
        {
            Vector3 tileWorldPos = new Vector3(tile.x + tilemapBase.origin.x, tile.y + tilemapBase.origin.y, 0);
            //Instantiate(prefab, tileWorldPos, prefab.transform.rotation);
            worldWalkableTiles.Add(tileWorldPos);
            walkableNodes.Add(new NodePathfinding(tile.x, tile.y));
        }
        */
    }

    public Vector3 GetWorldPositionOfCenterOfTile(Vector2Int tile)
    {
        /*
        for(int i = 0; i < walkableTiles.Count; i++)
        {
            if(walkableTiles[i].x == tile.x)
            {
                if(walkableTiles[i].y == tile.y)
                {
                    float halfTilesize = tileSize / 2;
                    return new Vector3(worldWalkableTiles[i].x + halfTilesize, worldWalkableTiles[i].y + halfTilesize);
                }
            }
        }
        
        return Vector3.zero;
        */
        if((tile.x < worldWalkableTilesArray.GetLength(0)) 
            && (tile.x >= 0) 
            && (tile.y < worldWalkableTilesArray.GetLength(1)) 
            && (tile.y >= 0))
        {
            float halfTilesize = tileSize / 2;
            Vector3 bottomLeft = worldWalkableTilesArray[tile.x, tile.y];
            return new Vector3(bottomLeft.x + halfTilesize, bottomLeft.y + halfTilesize);
        }
        else
        {
            return Vector3.zero;
        }
    }

    public Vector2Int GetTileFromWorldPosition(Vector3 worldPos)
    {
        /*
        for(int i = 0; i < walkableTiles.Count; i++)
        {
            if((worldPos.x > worldWalkableTiles[i].x) && (worldPos.y > worldWalkableTiles[i].y))
            {
                if((worldPos.x < worldWalkableTiles[i].x + tileSize) && (worldPos.y < worldWalkableTiles[i].y + tileSize))
                {
                    return walkableTiles[i];
                }
            }
        }
        return Vector2Int.zero;
        */
        Vector3 fromTilemapOriginToWorldPos = worldPos - tilemapBase.origin;
        int x = (int)fromTilemapOriginToWorldPos.x;
        int y = (int)fromTilemapOriginToWorldPos.y;
        return new Vector2Int(x, y);
    }

    public Vector2 GetBottomLeftOfWorldCenterTile(Vector3 centerOfTile)
    {
        return new Vector2(centerOfTile.x - (tileSize / 2), centerOfTile.y - (tileSize / 2));
    }

    public Vector2 GetTopRightOfWorldCenterTile(Vector3 centerOfTile)
    {
        return new Vector2(centerOfTile.x + (tileSize / 2), centerOfTile.y + (tileSize / 2));
    }

    private bool ExistsInWalkableTiles(Vector2Int tile)
    {
        /*
        foreach(Vector2Int t in walkableTiles)
        {
            if((t.x == tile.x) && (t.y == tile.y))
            {
                return true;
            }
        }
        return false;
        */
        if ((tile.x < worldWalkableTilesArray.GetLength(0))
            && (tile.x >= 0)
            && (tile.y < worldWalkableTilesArray.GetLength(1))
            && (tile.y >= 0))
        {
            if (walkableNodesArray[tile.x, tile.y] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    private bool NodeExistsInList(List<NodePathfinding> nodeList, NodePathfinding node)
    {
        /*
        foreach(NodePathfinding n in nodeList)
        {
            if(node.GridX == n.GridX)
            {
                if(node.GridY == n.GridY)
                {
                    return true;
                }
            }
        }
        return false;
        */
        return nodeList.Contains(node);
    }

    //A* Pathfinding Algorithm Implementation
    public List<Vector3> ExecutePathfinding(Vector3 startingPosition)
    {
        CountTiles();
        Vector3 playerPosition = PlayerCharacter.instance.transform.position;

        List<NodePathfinding> open = new List<NodePathfinding>();
        List<NodePathfinding> closed = new List<NodePathfinding>();

        Vector2Int startingTile = GetTileFromWorldPosition(startingPosition);
        Vector3 centerOfStartTile = GetWorldPositionOfCenterOfTile(startingTile);
        //NodePathfinding startNode = new NodePathfinding(startingTile.x, startingTile.y, 0, Vector3.Distance(startingPosition, playerPosition));
        //NodePathfinding startNode = GetNode(startingTile.x, startingTile.y);
        NodePathfinding startNode = walkableNodesArray[startingTile.x, startingTile.y];
        startNode.HCost = Vector3.Distance(startingPosition, playerPosition);
        open.Add(startNode);

        Vector2Int targetTile = GetTileFromWorldPosition(playerPosition);
        //NodePathfinding targetNode = new NodePathfinding(targetTile.x, targetTile.y);
        NodePathfinding targetNode = walkableNodesArray[targetTile.x, targetTile.y];

        NodePathfinding currentNode = null;
        for(int i = 0; i < tilesCount; i++)
        {
            currentNode = GetNodeWithLowestF(open);
            open.Remove(currentNode);
            closed.Add(currentNode);

            if(currentNode.MyEquals(targetNode))
            {
                //break
                i = tilesCount;
            }

            foreach(Vector2Int neighbourTile in currentNode.Neighbours())
            {
                NodePathfinding neighbourNode;
                if ((neighbourTile.x < walkableNodesArray.GetLength(0)) 
                    && (neighbourTile.x >= 0) 
                    && (neighbourTile.y < walkableNodesArray.GetLength(1)) 
                    && (neighbourTile.y >= 0))
                {
                    neighbourNode = walkableNodesArray[neighbourTile.x, neighbourTile.y];
                }
                else
                {
                    neighbourNode = null;
                }
                if(ExistsInWalkableTiles(neighbourTile) && (!NodeExistsInList(closed, neighbourNode)))
                {
                    float traverseDistance = GetTraverseNeighbourDistance(currentNode, neighbourNode);
                    float newPath = currentNode.GCost + traverseDistance;
                    if((newPath < neighbourNode.GCost) || (!NodeExistsInList(open, neighbourNode)))
                    {
                        neighbourNode.GCost = newPath;
                        Vector3 nodeWorldCenter = GetWorldPositionOfCenterOfTile(new Vector2Int(neighbourNode.GridX, neighbourNode.GridY));
                        neighbourNode.HCost = Vector3.Distance(nodeWorldCenter, playerPosition);
                        neighbourNode.FCost = neighbourNode.GCost + neighbourNode.HCost;
                        neighbourNode.Parent = currentNode;
                        if(!NodeExistsInList(open, neighbourNode))
                        {
                            open.Add(neighbourNode);
                        }
                    }
                }
            }
        }

        List<Vector3> results = new List<Vector3>();
        NodePathfinding currentResultNode = currentNode;
        while (currentResultNode.Parent != null)
        {
            results.Add(GetWorldPositionOfCenterOfTile(new Vector2Int(currentResultNode.GridX, currentResultNode.GridY)));
            currentResultNode = currentResultNode.Parent;
        }
        results.Reverse();
        return results;
    }

    private float GetTraverseNeighbourDistance(NodePathfinding nb1, NodePathfinding nb2)
    {
        return nb1.DiagonalNeighbour(nb2) ? tileDiag : tileSize;
    }

    private NodePathfinding GetNodeWithLowestF(List<NodePathfinding> nodeList)
    {
        NodePathfinding lowest = nodeList[0];
        foreach(NodePathfinding node in nodeList)
        {
            if(node.FCost < lowest.FCost)
            {
                lowest = node;
            }
        }
        return lowest;
    }

    /*
    private NodePathfinding GetNode(int x, int y)
    {
        foreach (NodePathfinding n in walkableNodes)
        {
            if (x == n.GridX)
            {
                if (y == n.GridY)
                {
                    return n;
                }
            }
        }
        return null;
    }
    */
}
