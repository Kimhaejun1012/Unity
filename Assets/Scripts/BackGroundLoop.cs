using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;
    private void Awake()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        width = boxCollider.size.x;
    }

    private void Update()
    {
        if(transform.position.x < -width) 
        {
            Reposition();
        }
    }

    // Update is called once per frame
    private void Reposition()
    {
        var offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
