using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript : MonoBehaviour
{
    bool isBaught = false;
    public Color newColor = Color.red;
    private void OnMouseDown()
    {
        newColor = Color.white;
        Renderer renderer = GetComponent<SpriteRenderer>();
        renderer.material.color = newColor;
        isBaught = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Renderer renderer = GetComponent<SpriteRenderer>();
        renderer.material.color = newColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

   
}
