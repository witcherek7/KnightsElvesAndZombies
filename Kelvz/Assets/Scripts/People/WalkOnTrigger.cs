using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkOnTrigger : MonoBehaviour
{
    private bool _wasTriggered;
    [SerializeField] private float waitTime = 3;
    public int health = 50;
    private Animator _animator;
    private Vector3 localScale;

//    private static readonly int Buidling = Animator.StringToHash("buidling");

    void Start()
    {
        localScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
//        StartCoroutine(Idle());
    }
    private void Update() {

    }
    private void TakeDamage(int amount){
        health -= amount;
        _animator.SetFloat("life", health);
        if(health<0){
            Destroy(gameObject);
        }
    }

    private void Destroy(){
        Destroy(gameObject);
    }
    private int getDirection()
    {
        if (Random.value>=0.5)
        {
            return -1;
        }
        return 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("building_trigger"))
        {
//            _animator.SetTrigger(Buidling);
            StartCoroutine(Idle());
//            _animator.SetTrigger(Buidling);
        }

        if (other.gameObject.CompareTag("tower_trigger") || other.gameObject.CompareTag("Enemy"))
        {
            // _animator.SetTrigger("Reverse");
            if(localScale.x > 0){
                localScale = new Vector3(localScale.x*-1, localScale.y, localScale.z);
                transform.localScale = localScale;
            }
        }
        else if (other.gameObject.CompareTag("end_of_map")){
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

}