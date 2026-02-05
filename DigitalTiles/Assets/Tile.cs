using UnityEngine;

public class Tile : MonoBehaviour
{
    public float value;
    public enum state
    {
        none,
        inPath,
        locked,
        dead
    }
    public state curState;
    public Color[] colors;
    
    public int x;
    public int y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnMouseEnter()
    {
        HoverTile();

    }
    private void OnMouseDown()
    {
       if(MouseManager.instance.currentPath.Count == 0 && curState == state.none)
        {
            MouseManager.instance.currentPath.Add(this);
            MouseManager.instance.headTile = this;
            
            curState = state.inPath;
            ChangeColor();
        }
    }

    void HoverTile()
    {
        if (MouseManager.instance.mouseDown && curState == state.none)
        {
            if(MouseManager.instance.currentPath.Count > 0)
            {
                Tile lastTile = MouseManager.instance.currentPath[MouseManager.instance.currentPath.Count - 1];

                if(Mathf.Abs(lastTile.x - x) == 1 && Mathf.Abs(lastTile.y - y) == 0 || Mathf.Abs(lastTile.x - x) == 0 && Mathf.Abs(lastTile.y - y) == 1)
                {
                   
                    
                }
                else
                {
                    return;
                }
                
            }
            MouseManager.instance.currentPath.Add(this);
            curState = state.inPath;
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        GetComponent<SpriteRenderer>().color = colors[(int)curState];
    }

}
