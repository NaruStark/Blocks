using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip destroySound;

    // Cached reference
    Level level;
    GameStatus gamestatus;

    private void Start()
    {
        gamestatus = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position, 1);
        Destroy(gameObject);
        level.BlockDestroyed();
        gamestatus.AddScore();
    }
}
