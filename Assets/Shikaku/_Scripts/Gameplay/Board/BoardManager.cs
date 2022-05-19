using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private Camera _boardCamera;
    public Board board;
    private Board _board;

    [ContextMenu("CreateLevel")]
    public void StartLevel()
    {
        _board = Instantiate(board, Vector3.zero, Quaternion.identity);

        SetupCamera(_board.width, _board.height);

        _board.Init();
    }

    private void Start()
    {
        StartLevel();
    }
    void SetupCamera(int width, int height)
    {
        _boardCamera.transform.position = new Vector3((width - 1) / 2f, (height - 1) / 2f, -10f);

        float aspectRatio = (float)(_boardCamera.pixelWidth) / (float)(_boardCamera.pixelHeight);

        float borderSizeHorizontal = 1.0f;
        float borderSizeVertical = 2.5f;

        float verticalSize = height / 2f + borderSizeVertical;
        float horizontalSize = (width / 2f + borderSizeHorizontal) / aspectRatio;
        _boardCamera.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
    }
}
