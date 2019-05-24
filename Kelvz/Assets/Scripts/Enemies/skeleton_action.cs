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
    [SerializeField] private float attack_range = 5f;
    public GameObject other_obj;


    private void TakeDamage(int amount){
        health -= amount;
        Debug.Log("--------------------------------SH: "+health);
        _animator.SetFloat("life", health);
    }

    private void Destroy(){
        Destroy(gameObject);
    }
    public void EndAttack(GameObject other_obj){
        float distance = Vector3.Distance(other_obj.transform.position, this.transform.position);
        if(distance < attack_range){
            Debug.Log("szkieleton zadaje obrazenia dla: "+other_obj.name.ToString());
            Debug.Log(other_obj.name);
            other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
        }
    }
// // // // //
    void Start()
    {
        // localScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
        
//        StartCoroutine(Idle());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        float distance = Vector3.Distance(other.transform.position, transform.position);

        if(distance<=attack_range){
        if (other.gameObject.CompareTag("Troop")){
            _animator.SetTrigger("attack");
        }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        other_obj = other.gameObject;
        float distance = Vector3.Distance(other.transform.position, transform.position);
        if (distance<attack_range){
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
}
