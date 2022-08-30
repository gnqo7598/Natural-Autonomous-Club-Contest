using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardManager : MonoBehaviour
{
    public int length = 8;
    public int height = 8;
    public GameObject Player;
    public GameObject Destination;
    public GameObject Tile;

    private Transform boardHolder;
    private List<Vector3> gridPositions = new List<Vector3>();

    void InitializeList()
    {
        gridPositions.Clear();

        for(int x = 0; x < length; x++)
        {
            for(int y = 0; y < height; y++)
            {
                gridPositions.Add(new Vector3(x, y, 0f));
                if (x == 0 && y == 0 || x == length - 1 && y == height - 1)
                    gridPositions.Remove(new Vector3(x, y, 0f));
            }
        }
    }

    void BoardSetup()
    {
        boardHolder = new GameObject("Board").transform;

        for(int x = 0; x < length; x++)
        {
            for(int y = 0; y < height; y++)
            {
                GameObject TileArray = Instantiate(Tile, new Vector3(x, y, 0f), Quaternion.identity);

                TileArray.transform.SetParent(boardHolder);
            }
        }
    }

    public void SetupScene()
    {
        BoardSetup();
        InitializeList();
        Instantiate(Destination, new Vector3(length - 1, height - 1, 0f), Quaternion.identity);
        Instantiate(Player, new Vector3(0, 0, 0f), Quaternion.identity);
    }

}
