using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public static CreateGrid instance;

    public GameObject tilePrefab;
    public List<GameObject> tiles = new List<GameObject>();
    public float sideLength;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < sideLength; i++)
        {
            for (int j = 0; j < sideLength; j++)
            {
                tiles.Add(Instantiate(tilePrefab, transform.position + new Vector3(j- ((sideLength - 1) / 2), i-((sideLength-1)/2)) , Quaternion.identity));
                tiles[tiles.Count-1].GetComponent<Tile>().x = j;
                tiles[tiles.Count-1].GetComponent<Tile>().y = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegenerateGrid()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            Tile currentTile = tiles[i].GetComponent<Tile>();
            if(currentTile.curState != Tile.state.none)
            {
                currentTile.curState = Tile.state.none;
                currentTile.ChangeColor();
            }
        }
    }
}
