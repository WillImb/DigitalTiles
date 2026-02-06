using UnityEngine;

public class MousePan : MonoBehaviour
{
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {

            Camera.main.transform.position += new Vector3(-Input.GetAxis("Mouse X"), -Input.GetAxis("Mouse Y")) * Time.deltaTime * 100;
        
        
        }

    }
}
