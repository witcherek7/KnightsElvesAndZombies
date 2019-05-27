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
    [SerializeField] private float attackDelay = 1.0f;
    [SerializeField] private float time_to_attack = 0f;
    //

    private Animator _animator;
    private GameObject self;
    [SerializeField] private float attack_range = 5f;
    [SerializeField] private float building_size = 10f;
    public GameObject other_obj;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
        
//        StartCoroutine(Idle());
    }
    private void Update() {
        time_to_attack -= Time.deltaTime;
        _animator.SetFloat("time_to_attack", time_to_attack);
    }


    private void TakeDamage(int amount){
        health -= amount;
        _animator.SetFloat("life", health);
        Debug.Log("\t\tSkeleton Life: "+health);

    }

    private void Destroy(){
        Destroy(gameObject);
    }

    public void Attack_trigger()
    {
        if (other_obj)
        {
            float distance = Vector3.Distance(other_obj.transform.position, this.transform.position);

            // Debug.Log(other_obj.name.ToString());
            if (other_obj.CompareTag("Troop") || other_obj.CompareTag("Creatures"))
            {

                // Debug.Log("szkieleton napotkał ziomeczka");
                if(distance < attack_range )
                {
                    if (time_to_attack < 0)
                    {
                        // Debug.Log("szkieleton atakuje ziomeczka");
                        Attack(other_obj);
                        time_to_attack = attackDelay;
                    }
                }
            }
        
            else if (other_obj.CompareTag("building_trigger") || other_obj.CompareTag("tower_trigger"))
            {
                var obj = other_obj.transform.parent.gameObject;
                // Debug.Log("parent name: "+obj.name);
                // Debug.Log("parent position: "+obj.transform.position.x);
                // distance = Vector3.Distance(other_obj.transform.parent.gameObject.transform.position, this.transform.position);
                // if(distance < attack_range + building_size )
                // {
                    Debug.Log("szkieleton napotkał budynek, dystans mniejszy od zasięgu: " + distance);
                    if (time_to_attack < 0)
                    {
                        Debug.Log("szkieleton atakuje budynek");
                        Attack(obj);
                        time_to_attack = attackDelay;
                    }
                        
                // }      
            }

            else if (other_obj.CompareTag("Building") || other_obj.CompareTag("Tower")) {
                // distance = Vector3.Distance(other_obj.transform.position, this.transform.position);
                // if (distance < attack_range+building_size){
                    Debug.Log("szkieleton napotkał budynek BUILDING, dystans mnieszy od zasięgu "+distance);
                    if (time_to_attack < 0){
                        Debug.Log("szkieleton atakuje BUDYNEK");
                        Attack(other_obj);
                    }
                // }
            }
        }

    }
    public void Attack(GameObject other_obj){
        other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
        // Debug.Log("Archer attacked: -"+attack_strength);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        other_obj = other.gameObject;
        float distance = Vector3.Distance(other.transform.position, transform.position);
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        other_obj = other.gameObject;
        // Debug.Log("szkieleton striggerowany przez obiekt "+ other_obj.name.ToString());
        if (other_obj){
            float distance = Vector3.Distance(other.transform.position, transform.position);
            if (distance<attack_range){
                var tag = other.gameObject.tag;
            // jeśli nie koliduje, to idzie w lewo, jeśli koliduje to:
                if (other.gameObject.CompareTag("Troop"))
                {
                    _animator.SetTrigger("attack");
                }
                else if (other.gameObject.CompareTag("Creatures"))
                {
                _animator.SetTrigger("attack");
                }

                else if (other.gameObject.CompareTag("Building") || other.gameObject.CompareTag("building_trigger") || other.gameObject.CompareTag("tower_trigger"))
                {
                _animator.SetTrigger("attack");
                }
            }
        }
    }
}
