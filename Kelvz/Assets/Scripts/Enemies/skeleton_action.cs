using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton_action : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _wasTriggered;
    //
    public int health = 100;
    public int attack_strength = 10;
    //

    private Animator _animator;
    private GameObject self;

    void Start()
    {
        // localScale = transform.localScale;
        _animator = GetComponent<Animator>();
        
//        StartCoroutine(Idle());
    }

    private void Destroy(){
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Troop")){
            _animator.SetTrigger("attack");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // jeśli nie koliduje, to idzie w lewo, jeśli koliduje to:
        if (other.gameObject.CompareTag("Troop"))
        {
            _animator.SetTrigger("attack");
        }
        // wypadałoby dać tak, żeby odbierać informacje o \
        // położeniu flagi i w razie co zrobić flip i wojo wraca

        if (other.gameObject.CompareTag("Creatures"))
        {
           // jeśli wróg, to nakurwiaj
           _animator.SetTrigger("attack");
           // tu wyślij sygnał odbieranko życia
        }

        if (other.gameObject.CompareTag("Building"))
        {
           // jeśli wróg, to nakurwiaj
           _animator.SetTrigger("attack");
           // tu wyślij sygnał odbieranko życia
        }
        
    }
}
