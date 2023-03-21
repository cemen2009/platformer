using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    private string enemyTag = "Enemy";
    private string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(enemyTag) || collision.gameObject.CompareTag(playerTag))
            Destroy(collision.gameObject);
    }
}
