using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero_Action : MonoBehaviour
{
    private bool _wasTriggered;
    //
    public int health = 100;
    public int attack_strength = 10;
    [SerializeField] private float animation_time = 1;
    //
    private Animator _animator;
    private GameObject other_obj;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);

    }
    private void Update() {
        animation_time -= Time.deltaTime;
        _animator.SetFloat("attack_time", animation_time);
    }
    private void TakeDamage(int amount){
        health -= amount;
        _animator.SetFloat("life", health);
        Debug.Log("Hero Life: "+health);
        if(health<0){
            Destroy(gameObject);
        }
        // Debug.Log("hero got atacked, health = "+health.ToString());
    }
    private void Destroy(){
        Destroy(gameObject);
    }
    public void Attack(GameObject other_obj){
        other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
        // Debug.Log("Hero attacked: -"+attack_strength);
    }

    public void Attack_trigger(){
        // Debug.Log("waiting for "+animation_time.ToString());
        if(animation_time<0){
            animation_time = 1.0f;
            if(other_obj){
                Attack(other_obj);
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        other_obj = other.gameObject;
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
        }

        if (other.gameObject.CompareTag("Flag")){
            _animator.SetTrigger("hero_idle");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        other_obj = other.gameObject;

        if (other.gameObject.CompareTag("Enemy")){
            _animator.SetTrigger("hero_attack");
        }
        if (other.gameObject.CompareTag("Flag"))
        {
            _animator.SetTrigger("hero_idle");
        }
    }
}