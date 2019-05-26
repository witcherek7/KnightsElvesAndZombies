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
            // Debug.Log(other_obj.name.ToString());
            float distance = Vector3.Distance(other_obj.transform.position, this.transform.position);
            
            if (other_obj.CompareTag("Troop"))
            {
                if(distance < attack_range )
                {
                    if (time_to_attack < 0)
                    {
                        Attack(other_obj);
                        time_to_attack = attackDelay;
                    }
                }
            }
        
            else
            {
                if(distance < attack_range + building_size )
                {
                    if (time_to_attack < 0)
                    {
                        Attack(other_obj);
                        time_to_attack = attackDelay;
                    }
                        
                }      
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
        if (other_obj){
            float distance = Vector3.Distance(other.transform.position, transform.position);
            if (distance<attack_range){
            // jeśli nie koliduje, to idzie w lewo, jeśli koliduje to:
                if (other.gameObject.CompareTag("Troop"))
                {
                    _animator.SetTrigger("attack");
                }
                if (other.gameObject.CompareTag("Creatures"))
                {
                _animator.SetTrigger("attack");
                }

                if (other.gameObject.CompareTag("Building"))
                {
                _animator.SetTrigger("attack");
                }
            }
        }
    }
}
