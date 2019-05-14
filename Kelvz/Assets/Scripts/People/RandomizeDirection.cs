using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeDirection : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private int getDirection()
    {
        if (Random.value>=0.5)
        {
            return -1;
        }
            return 1;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        var localScale = transform.localScale;
        localScale = new Vector3(localScale.x*getDirection(), localScale.y, localScale.z);
        transform.localScale = localScale;
    }
    
}