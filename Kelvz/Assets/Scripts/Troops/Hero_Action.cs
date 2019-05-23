using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Action : MonoBehaviour
{
    private bool _wasTriggered;
    //
    public int health = 100;
    public int attack_strength = 10;
    //

    private Animator _animator;

    void Start()
    {
        // localScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);

//        StartCoroutine(Idle());
    }
    void make_damage(){
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // jeśli nie koliduje, to idzie w prawo, jeśli koliduje to:
        if (other.gameObject.CompareTag("Flag"))
        {
            _animator.SetTrigger("hero_idle");
        }
        // wypadałoby dać tak, żeby odbierać informacje o \
        // położeniu flagi i w razie co zrobić flip i wojo wraca

        if (other.gameObject.CompareTag("Enemy"))
        {
           // jeśli wróg, to nakurwiaj
           _animator.SetTrigger("hero_attack");
           // tu wyślij sygnał odbieranko życia
        }

        if (other.gameObject.CompareTag("Flag")){
            _animator.SetTrigger("hero_idle");
        }
    }
        private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")){
            _animator.SetTrigger("hero_attack");
        }
        if (other.gameObject.CompareTag("Flag"))
        {
            _animator.SetTrigger("hero_idle");
        }
    }

}