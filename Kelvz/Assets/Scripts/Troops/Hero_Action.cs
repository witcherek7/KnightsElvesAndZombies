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
    public GameObject flaga;
    private Vector3 flag_position;
    private Vector3 localScale;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
        localScale = this.transform.localScale;

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
        gameObject.GetComponent<AudioSource>().Play(0);
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
        if (other.gameObject.CompareTag("flag_trigger"))
        {
            _animator.SetTrigger("hero_idle");
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
           _animator.SetTrigger("hero_attack");
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        other_obj = other.gameObject;

        if (other.gameObject.CompareTag("Enemy")){
            _animator.SetTrigger("hero_attack");
        }
        else if (other.gameObject.CompareTag("Flag"))
        {
            _animator.SetTrigger("hero_idle");
        }
        // else if (!other.gameObject.CompareTag("flag_trigger")) {
        //     _animator.SetTrigger("hero_run");
        // }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("flag_trigger")){
            _animator.SetTrigger("hero_run");
        }
    }
}