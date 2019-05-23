using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnTrigger : MonoBehaviour
{
    private bool _wasTriggered;
    [SerializeField] private float waitTime = 3;
    public int health = 100;
    private Animator _animator;
    private Vector3 localScale;

//    private static readonly int Buidling = Animator.StringToHash("buidling");

    
    private int getDirection()
    {
        if (Random.value>=0.5)
        {
            return -1;
        }
        return 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
//        StartCoroutine(Idle());

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Building"))
        {
//            _animator.SetTrigger(Buidling);
            StartCoroutine(Idle());
//            _animator.SetTrigger(Buidling);

        }

        if (other.gameObject.CompareTag("Tower"))
        {
            _animator.SetTrigger("Reverse");
            localScale = new Vector3(localScale.x*-1, localScale.y, localScale.z);
            transform.localScale = localScale;
        }
    }

    IEnumerator Idle()
    {
        _animator.SetTrigger("building");
        yield return new WaitForSeconds(waitTime);
        if (getDirection() < 0)
        {
            localScale = new Vector3(localScale.x*-1, localScale.y, localScale.z);
            transform.localScale = localScale;
        }
        _animator.SetTrigger("building");

    }
    private void Update() {
        if(health<0){
            Destroy(gameObject);
        }
    }
}