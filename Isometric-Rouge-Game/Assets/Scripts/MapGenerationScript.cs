using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour
{
    public GameObject[] gridObjects;

    private int worldSizeX = 10;

    private int worldSizeZ = 10;

    private int gridOffset = 20;

    [SerializeField]
    private int start = 0;
    [SerializeField]
    private int end = 0;

    private int CurrentChunk = 0;

    private void Start()
    {
        CalcStartandEnd();
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        for (int x = 0; x < worldSizeX; x++)
        {
            for (int z = 0; z < worldSizeZ; z++)
            {
                Vector3 pos = new Vector3((x - (worldSizeX / 2)) * gridOffset, 0, (z - (worldSizeZ / 2)) * gridOffset);
                GameObject block = Instantiate(gridObjects[SelectRoomType()], pos, Quaternion.identity) as GameObject;
                block.transform.SetParent(this.transform);

                CurrentChunk++;
            }
        }
    }
    private void CalcStartandEnd()
    {
        while (start == end)
        {
            start = Random.Range(0, 101);

            end = Random.Range(0, 101);
        }
        GenerateLevel();
    }

    private int SelectRoomType()
    {
        int GridObjType;
        if (CurrentChunk == start)
        {
            GridObjType = 1;
        }
        else if (CurrentChunk == end)
        {
            GridObjType = 2;
        }
        else {
            int Choice = Random.Range(0, 2);
            if (Choice == 0)
            {
                GridObjType = 0;
            }
            else
            {
                GridObjType = 3;
            }
        }
        return GridObjType;
    }
}
