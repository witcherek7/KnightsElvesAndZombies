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
    void setDirection(Vector3 flag_pos){
        float myPosition = this.transform.position.x;
        float deltaPos = flag_pos.x - this.transform.position.x; 
        // Debug.Log("received position x of flag: "+flag_pos.x);
        // Debug.Log("my position x: "+myPosition);
        // Debug.Log("deltaPos = "+deltaPos);
        
        if (gameObject.transform.localScale.x > 0){
            // Debug.Log("patrzy w prawo");
            if(deltaPos < 0){
                // Debug.Log("flaga po lewej, obracam w lewo");
                gameObject.transform.localScale *= new Vector2(-1,1);
            }
            else {
                // Debug.Log("flaga po prawej");
            }
        }
        else if (gameObject.transform.localScale.x < 0){
            // Debug.Log("patrzy w lewo");

            if(deltaPos > 0){
                // Debug.Log("flaga po prawej, obracam w prawo");
                gameObject.transform.localScale *= new Vector2(-1,1);
            }
            else {
                // Debug.Log("flaga po lewej");

            }
        }
    }

    public void TakeDamage(int amount){
        health -= amount;
        _animator.SetFloat("life", health);
        Debug.Log("\tArcher life is "+health);

    }
    private void Destroy()
    {
        // Debug.Log("Archer is dead!");
        Destroy(gameObject);
    }
    public void Attack(GameObject other_obj){
        other_obj.SendMessage("TakeDamage", attack_strength, SendMessageOptions.DontRequireReceiver);
        // Debug.Log("Archer attacked: -"+attack_strength);
        gameObject.GetComponent<AudioSource>().Play(0); 
    }
    public void Attack_trigger()
    {
        if (other_obj){
            // Debug.Log(other_obj.name.ToString());
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
        private void OnTriggerEnter2D(Collider2D other)
    {
        other_obj = other.gameObject;
        
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        other_obj = other.gameObject;
        if(other.gameObject.CompareTag("Enemy"))
        {
            _animator.SetTrigger("attack");
        }
        else if (other.gameObject.CompareTag("flag_trigger")){
            _animator.SetBool("isFlag", true);
        }
        else if (!other.gameObject.CompareTag("flag_trigger")){
            _animator.SetBool("isFlag", false);
        }
    }
    // private void OnTriggerExit2D(Collider2D other) {
    //     _animator.SetTrigger("walk");
    // }
}
