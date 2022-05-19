using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public Cell[,] cells;

    private int _width, _height;

    public Cell this[int x, int y] => cells[x, y];

    public bool IsWithinBounds(int x, int y)
    {
        return (x >= 0 && y >= 0 && x < _width && y < _height);
    }

    public Vector2Int GetRandomCell()
    {
        int x = Random.Range(0, _width);
        int y = Random.Range(0, _height);
        if (cells[x, y].isFilled)
            return GetRandomCell();
        return new Vector2Int(x, y);
    }

    public Grid(int width, int height)
    {
        _width = width;
        _height = height;

        cells = new Cell[_width, _height];

        for (int i = 0; i < cells.GetLength(0); i++)
        {
            for (int j = 0; j < cells.GetLength(1); j++)
            {
                Cell cell = new Cell(i, j);
                cells[i, j] = cell;
            }
        }
    }

    internal void CheckHorizontalSpace(Vector2Int randomCellIndex, int areaValue, ref List<Vector2Int> indices)
    {
        int counter = 0;

        for (int i = 0; i < areaValue;)
        {
            cells[randomCellIndex.x + 1, randomCellIndex.y]
        }
    }

    internal Vector2Int[] TryGetSpaces(Vector2Int randomCellIndex, int areaValue)
    {
        List<Vector2Int> indices = new List<Vector2Int>();

        CheckHorizontalSpace(randomCellIndex, areaValue, ref indices);
        return indices.ToArray();
    }
}
