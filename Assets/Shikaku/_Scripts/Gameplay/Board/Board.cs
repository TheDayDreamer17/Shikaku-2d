using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{


    public int width, height;

    private Grid _grid;

    private Cell[,] _userOccupiedSpace;
    private int _area;
    int _tempArea;
    List<FactorData> multiplers = new List<FactorData>();
    List<SpacesData> allotedSpaces = new List<SpacesData>();
    int[] possibleFactors;
    public void Init()
    {
        _grid = new Grid(width, height);

        _area = width * height;
        FillBoard();
    }

    private void FillBoard()
    {


        GetPosibleCombinations();

    }



    private void GetPosibleCombinations()
    {
        _tempArea = _area;
        Debug.Log($"_tempArea {_tempArea}");
        possibleFactors = new int[width - 1];



        for (int i = 2, j = 0; j < possibleFactors.Length; i++, j++)
        {
            possibleFactors[j] = i;
        }

        // int datas = TestMultiplier(possibleFactors.Length - 1, 1);
        // multiplers.Add(possibleFactors[possibleFactors.Length - 1], datas);
        // Debug.Log("<color=red>" + $" index {possibleFactors[possibleFactors.Length - 1]} value {datas}" + " </color> ");
        // Debug.Log($"_tempArea {_tempArea}");
        // datas = TestMultiplier(possibleFactors.Length - 2, 3);
        // multiplers.Add(possibleFactors[possibleFactors.Length - 2], datas);
        // Debug.Log("<color=red>" + $" index {possibleFactors[possibleFactors.Length - 2]} value {datas}" + " </color> ");
        // Debug.Log($"_tempArea {_tempArea}");
        for (int i = possibleFactors.Length - 1; i >= 0; i--)
        {
            int data;
            if (i == 0)
                data = FindMultiplier(i, false);
            else
                data = FindMultiplier(i);
            multiplers.Add(new FactorData(possibleFactors[i], data));
            Debug.Log("<color=red>" + $" index {possibleFactors[i]} value {data}" + " </color> ");
            Debug.Log($"_tempArea {_tempArea}");
        }
        GenerateAreas();
    }

    private int FindMultiplier(int dataIndex, bool random = true)
    {
        int data = possibleFactors[dataIndex];
        if (_tempArea == 0 || _tempArea < data)
        {
            // Debug.Log("temp area is 0");
            return 0;
        }
        int remainder = _tempArea % data;
        int quotient = _tempArea / data;

        if (remainder == 1)
        {
            if (quotient == 1)
            {
                Debug.Log($"quotient {quotient}");
                return 0;
            }
            quotient -= data;
        }

        if (random)
        {
            int randomQuotient = UnityEngine.Random.Range(1, quotient + 1);
            _tempArea -= randomQuotient * data;
            quotient = randomQuotient;
        }
        else
            _tempArea -= quotient * data;
        if (!isDivisibleByNext(dataIndex))
        {
            _tempArea += quotient * data;
            return FindMultiplier(dataIndex, random);
        }
        return quotient;
    }

    private int TestMultiplier(int dataIndex, int value, bool random = true)
    {
        int data = possibleFactors[dataIndex];

        _tempArea -= value * data;

        return value;
    }

    private bool isDivisibleByNext(int data)
    {
        if (data - 1 < 0)
            return true;
        else
        {
            if (_tempArea % possibleFactors[data - 1] != 0)
                return false;
            else
                return true;
        }
    }

    private void GenerateAreas()
    {
        for (int i = 0; i < multiplers.Count; i++)
        {
            for (int j = 0; j < multiplers[i].multipler; j++)
            {
                AssignArea(multiplers[i].factor);

            }
        }
    }

    private void AssignArea(int areaValue)
    {
        Vector2Int randomCellIndex = _grid.GetRandomCell();
        Vector2Int[] indices = _grid.TryGetSpaces(randomCellIndex, areaValue);
        if (indices.Length == 0)
            AssignArea(areaValue);
        else
        {
            allotedSpaces.Add(new SpacesData(areaValue, indices));
            int randomIndex = Random.Range(0, indices.Length);
            new GameObject().transform.position = new Vector3(indices[randomIndex].x, indices[randomIndex].y);
        }


    }


}

public class FactorData
{

    public int factor;
    public int multipler;


    public FactorData(int factorValue, int multiplerValue)
    {
        factor = factorValue;
        multipler = multiplerValue;
    }
}

public class SpacesData
{
    public int multipler;
    public Vector2Int[] indices;
    public bool isMarked = false;
    public SpacesData(int multiplerValue, Vector2Int[] indicesValue)
    {

        multipler = multiplerValue;
        indices = indicesValue;
    }
}