using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRendererController : MonoBehaviour
{
    public bool enabledRenderer = false;
    public GameObject[] findTiles;
    List<GameObject> tileList = new List<GameObject>();

    public void Start()
    {
        findTiles = GameObject.FindGameObjectsWithTag("Tile");


        foreach (GameObject gO in findTiles)
        {
            gO.GetComponent<MeshRenderer>().enabled = false;
            tileList.Add(gO);
        }
    }

   public void EnableOrDisableRenderer()
    {
        if (!enabledRenderer)
        {
            foreach (GameObject tile in tileList)
            {
                tile.GetComponent<MeshRenderer>().enabled = true;
            }

            enabledRenderer = true;
        }
        else if (enabledRenderer)
        {
            foreach (GameObject tile in tileList)
            {
                tile.GetComponent<MeshRenderer>().enabled = false;
            }

            enabledRenderer = false;
        }
    }
}
