using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer1_Action : MonoBehaviour
{
    public int health = 100;
    public int attack_strength = 10;
    [SerializeField] private int attack_range = 10;
    [SerializeField] private float attackDelay = 1f;
    [SerializeField] private float time_to_attack = -1f;
    private Animator _animator;
    private GameObject self;
    private GameObject other_obj;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
    }
    private void Update() {
        time_to_attack -= Time.deltaTime;
        _animator.SetFloat("time_to_attack", time_to_attack);
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            _animator.SetTrigger("attack");
        }

        // tu przyjmowanie hita jakoś? MOże wywołanie funkcji, jeśli otrzymujemy atak od osoby, z którą się akurat bijemy?
        // tu śmierć, 
        // if (other wykonał na nas atak):
        //      {_animator.SetFloat("life", other.strength)}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other_obj = other.gameObject;
        
    }

    // Update is called once per frame

    public void TakeDamage(int amount){
        health -= amount;
        _animator.SetFloat("life", health);

    }
    // public void Attack(GameObject other_obj){
    //     other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
    // }

    // public void EndAttack(GameObject other){
    //     float distance = Vector3.Distance(other.transform.position, this.transform.position);
    //     if(distance < attack_range && time_to_attack < 0){
    //         other.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
    //         time_to_attack = attackDelay;
    //         Debug.Log("Archer attacked: -"+attack_strength);

    //     }
    // }
    public void Attack_trigger()
    {
        if (other_obj){
            Debug.Log(other_obj.name.ToString());
            float distance = Vector3.Distance(other_obj.transform.position, this.transform.position);
            if(distance < attack_range ){
                if (time_to_attack < 0){
                    // Debug.Log("waiting for "+time_to_attack.ToString());
                    Attack(other_obj);
                    time_to_attack = attackDelay;
                }
            }
        }
    }
    public void Attack(GameObject other_obj){
        other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
        Debug.Log("Archer attacked: -"+attack_strength);
    }
}
