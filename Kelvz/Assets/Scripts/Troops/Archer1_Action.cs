using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer1_Action : MonoBehaviour
{
    public int health = 100;
    public int attack_strength = 10;
    private Animator _animator;
    private GameObject self;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("life", health);
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
