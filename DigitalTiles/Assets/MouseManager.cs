using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public static MouseManager instance;
    public List<float> currentPath;
    public static bool mouseDown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            mouseDown = true;
        }
        else
        {
            mouseDown = false;
        }
    }

    
}
