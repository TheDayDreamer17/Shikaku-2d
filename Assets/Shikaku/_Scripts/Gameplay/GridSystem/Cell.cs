using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    public int xIndex,yIndex;
    public bool isFilled=false;
    public bool IsEmpty=>!isFilled;

    public Cell(int x,int y)
    {
        xIndex=x;
        yIndex=y;
    }

    public override string ToString()
    {
        return $"xindex{xIndex} yIndex {yIndex}";
    }
}

public class GridNavigation
{
    public static readonly Vector2Int RIGHT = Vector2Int.right;
    public static readonly Vector2Int LEFT = Vector2Int.left;
    public static readonly Vector2Int UP = Vector2Int.up;
    public static readonly Vector2Int DOWN = Vector2Int.down;

    public static readonly Vector2Int RIGHT_UP = RIGHT + UP;
    public static readonly Vector2Int LEFT_UP = LEFT + UP;
    public static readonly Vector2Int RIGHT_DOWN = RIGHT + DOWN;
    public static readonly Vector2Int LEFT_DOWN =LEFT + DOWN;

    public static Vector2Int[] GetAllAdjacent()
    {
        return new Vector2Int[] { RIGHT, UP, LEFT, DOWN };
    }
}
