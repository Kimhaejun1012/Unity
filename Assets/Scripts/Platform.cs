using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] obstacles;
    private bool stepped = false;



    private void OnEnable()
    {
        stepped = false;

        foreach(var go in obstacles)
        {
            go.SetActive(Random.value < 0.3f); // 30퍼센트 확률로 true value가 0.0 ~ 1.0 사이
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
