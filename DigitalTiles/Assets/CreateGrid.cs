using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public static CreateGrid instance;

    public GameObject tilePrefab;
    public List<GameObject> tiles = new List<GameObject>();

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
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                tiles.Add(Instantiate(tilePrefab, transform.position + new Vector3(j-3.5f,i-3.5f) , Quaternion.identity));
                tiles[tiles.Count-1].GetComponent<Tile>().x = j;
                tiles[tiles.Count-1].GetComponent<Tile>().y = i;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
