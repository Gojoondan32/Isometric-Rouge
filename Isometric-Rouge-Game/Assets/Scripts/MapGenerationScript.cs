using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerationScript : MonoBehaviour
{
    public GameObject gridObject;

    private int worldSizeX = 100;

    private int worldSizeZ = 100;

    private int gridOffset = 10;

    private void Start()
    {
        for(int x = 0; x < worldSizeX; x++ ) {
            for( int z = 0; z < worldSizeZ; z++) {

                Vector3 pos = new Vector3((x - (worldSizeX/2)) * gridOffset , 0, (z - (worldSizeZ/2)) * gridOffset);
                GameObject block = Instantiate(gridObject, pos, Quaternion.identity) as GameObject;

                block.transform.SetParent(this.transform);
            }
        }
    }
}
