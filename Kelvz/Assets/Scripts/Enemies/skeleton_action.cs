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
    [SerializeField] private float troop_attack_range = 1f;
    [SerializeField] private float building_size = 10f;
    private Vector3 localScale;
    public GameObject other_obj;

    void Start()
    {
        localScale = transform.localScale;
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
        Debug.Log("Starting...");
//        StartCoroutine(Idle());
    }
    private void Update() {
        time_to_attack -= Time.deltaTime;
        _animator.SetFloat("time_to_attack", time_to_attack);
    }


    private void TakeDamage(int amount){
        health -= amount;
        _animator.SetFloat("life", health);
        // Debug.Log("\t\tSkeleton Life: "+health);

    }

    private void Destroy(){
        // Debug.Log("Destroying");
        Destroy(gameObject);
    }

    public void Attack_trigger()
    {
        if (other_obj && !other_obj.CompareTag("Background"))
        {
            float distance = Vector3.Distance(other_obj.transform.position, this.transform.position);
            // Debug.Log("--- Attack triggered --- \n --- --- the distance is "+distance.ToString());

            // Debug.Log(other_obj.name.ToString());
            if (other_obj.CompareTag("Troop") || other_obj.CompareTag("Creatures"))
            {

                // Debug.Log("Skeleton found TROOP or CREATURE");
                if(distance < attack_range )
                {
                    // Debug.Log("\t--- ...It is in attack range ---");
                    if (time_to_attack < 0)
                    {
                        // Debug.Log("\t--- ...Skeleton can now attack ---");
                        // Debug.Log("szkieleton atakuje ziomeczka");
                        Attack(other_obj);
                        time_to_attack = attackDelay;
                    }
                }
            }
        
            else if (other_obj.CompareTag("building_trigger") || other_obj.CompareTag("tower_trigger"))
            {
                var obj = other_obj.transform.parent.gameObject;
                // Debug.Log("Skeleton found BUILDING or TOWER trigger. Object name: "+obj.name.ToString());

                // Debug.Log("parent name: "+obj.name);
                // Debug.Log("parent position: "+obj.transform.position.x);
                // distance = Vector3.Distance(other_obj.transform.parent.gameObject.transform.position, this.transform.position);
                // if(distance < attack_range + building_size )
                // {
                    // Debug.Log("\t--- ...trigger is in distance: " + distance.ToString());
                    if (time_to_attack < 0)
                    {
                        // Debug.Log("\t--- ...skeleton can now attack the object: "+obj.name.ToString());
                        Attack(obj);
                        time_to_attack = attackDelay;
                    }
                        
                // }      
            }

            else if (other_obj.CompareTag("Building") || other_obj.CompareTag("Tower")) {
                // distance = Vector3.Distance(other_obj.transform.position, this.transform.position);
                // if (distance < attack_range+building_size){
                    // Debug.Log("Skeleton was triggered by BUILDING (not the trigger inside ), the distance is: "+distance);
                    if (time_to_attack < 0){
                        // Debug.Log("\t--- ...Skeleton can now attak BUDYNEK: "+other_obj.name.ToString());
                        Attack(other_obj);
                    }
                // }
            }
        }

    }
    public void Attack(GameObject other_obj){
        other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
        // Debug.Log("Archer attacked: -"+attack_strength);
        gameObject.GetComponent<AudioSource>().Play(0);
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        other_obj = other.gameObject;
        float distance = Vector3.Distance(other.transform.position, transform.position);
        // Debug.Log("OnTriggerEnter2D, the object is: "+other_obj.name.ToString()+"\tThe distance: "+distance.ToString());

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        other_obj = other.gameObject;


        if (other_obj && !other_obj.CompareTag("Background") && !other_obj.CompareTag("Flag")){
            // Debug.Log("OnTriggerStay2D, object: "+other_obj.name.ToString());
            float distance = Vector3.Distance(other.transform.position, transform.position);
            // Debug.Log("\t--- <otS> distance is "+distance);
            // Debug.Log("\t it is in attack range");
            var tag = other.gameObject.tag;
            if (distance<attack_range){
                // Debug.Log("\t\t\tin a Troop Range");
                if (other.gameObject.CompareTag("Troop")){
                    if(distance<troop_attack_range){
                        // Debug.Log("\t\t the Tag is Troop, triggering attack");
                        _animator.SetTrigger("attack");
                    }
                }

            // jeśli nie koliduje, to idzie w lewo, jeśli koliduje to:
                else if (other.gameObject.CompareTag("Creatures"))
                {
                    // Debug.Log("\t\t the Tag is Creatures, triggering attack");
                    _animator.SetTrigger("attack");
                }

                else if (other.gameObject.CompareTag("Building") || other.gameObject.CompareTag("building_trigger") || other.gameObject.CompareTag("tower_trigger"))
                {
                    // Debug.Log("\t\t the Tag is "+tag.ToString()+". Triggering attack");
                    _animator.SetTrigger("attack");
                }
                else if (other.gameObject.CompareTag("end_of_map")){
                    
                    // localScale = new Vector3(localScale.x*-1, localScale.y, localScale.z);
                    // transform.localScale = localScale;
                }
            }
        }
    }
}
