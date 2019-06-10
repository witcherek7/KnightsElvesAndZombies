using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeAWish : MonoBehaviour
{
    // private string[] listOfWishes = new string[4]{"giveLife", "giveStrength", "giveMoney", "giveLifeAdvantage"};
    // private string[] listOfDisaster = new string[4]{"getLife", "getStrength", "getMoney", "getLifeAdvantage"};
    private GameObject[] creatures;
    private GameObject[] troops;

    private GameObject[] enemies;

    private enum listOfWishes
    {
        giveLife, giveStrength, giveMoney, giveLifeAdvantage, killHalfEnemies
    };

    private enum listOfDisaster {
        getLife, getStrength, getMoney, getLifeAdvantage, nothing, killThirdMine
    }

    [SerializeField] private int villagerLifeAppendAmount = 20;
    [SerializeField] private int troopLifeAppendAmount = 30;
    [SerializeField] private int moneyBonusAmount = 100;
    [SerializeField] private int lifeAdvantage = 15;
    [SerializeField] private int strengthBonus = 5;
    void Start()
    {
        // givaAChance();
    }
    private void getAllCreatures(){
        creatures = GameObject.FindGameObjectsWithTag("Creatures");
        troops = GameObject.FindGameObjectsWithTag("Troop");
    }
    private void getAllEnemies(){
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    

    static T getWish<T>(){
        System.Array A = System.Enum.GetValues(typeof (T));
        T V = (T)A.GetValue(UnityEngine.Random.RandomRange(0, A.Length));
        return V;
    }


    private void giveLife(){
        getAllCreatures();
        foreach (GameObject creature in creatures){
            creature.GetComponent<WalkOnTrigger>().health += villagerLifeAppendAmount;
        }
        foreach (GameObject troop in troops){
            troop.GetComponent<Hero_Action>().health += troopLifeAppendAmount;
        }

    }
    private void killThirdMine(){
        getAllCreatures();
        if (creatures.Length>5){
            for (int i=0; i<creatures.Length; i+=3){
                Destroy(creatures[i]);
            }
        }
        if (troops.Length>4){
            for (int i=0; i<troops.Length; i+=3){
                Destroy(troops[i]);
            }
        }
        else if(troops.Length<=4 && creatures.Length>5){
            givaAChance();
        }
    }
    private void killHalfEnemies(){
        getAllEnemies();
        if(enemies.Length>4){
            for (int i=0; i<enemies.Length; i+=2){
                Destroy(enemies[i]);
            }
        }
    }
    private void giveMoney(){
        GameObject play = GameObject.Find("Player");
        play.GetComponent<Player>().gold += moneyBonusAmount;

    }
    private void giveStrength(){
        getAllCreatures();

        foreach (GameObject troop in troops){
            troop.GetComponent<Hero_Action>().attack_strength += strengthBonus;
        }
    }
    private void giveLifeAdvantage(){
        getAllEnemies();
        foreach (GameObject enemy in enemies){
            enemy.GetComponent<skeleton_action>().health -= lifeAdvantage;
        }


    }
    private void getLife(){
        getAllCreatures();
        foreach (GameObject creature in creatures){
            creature.GetComponent<WalkOnTrigger>().health -= villagerLifeAppendAmount;
        }
        foreach (GameObject troop in troops){
            troop.GetComponent<Hero_Action>().health -= troopLifeAppendAmount;
        }

    }
    private void getMoney(){
        GameObject play = GameObject.Find("Player");
        if(play.GetComponent<Player>().gold > moneyBonusAmount){
            play.GetComponent<Player>().gold -= moneyBonusAmount;
        }
        else {
            play.GetComponent<Player>().gold = 0;
        }

    }
    private void getStrength(){
        getAllCreatures();

        foreach (GameObject troop in troops){
            troop.GetComponent<Hero_Action>().attack_strength -= strengthBonus;
        }


    }
    private void getLifeAdvantage(){
        getAllEnemies();
        foreach (GameObject enemy in enemies){
            enemy.GetComponent<skeleton_action>().health += lifeAdvantage;
        }
    }

    private void givaAChance(){
        // int x = Random.Range(0, 3);
        // string good = listOfWishes[x];
        var wishh = getWish<listOfWishes>();
        var diss = getWish<listOfDisaster>();
        Debug.Log(wishh);
        Debug.Log(diss);

        switch (wishh){

            case listOfWishes.giveLife: giveLife(); break;
            case listOfWishes.giveLifeAdvantage: giveLifeAdvantage(); break;
            case listOfWishes.giveStrength: giveStrength(); break;
            case listOfWishes.killHalfEnemies: killThirdMine(); break;

            case listOfWishes.giveMoney: giveMoney(); break;
        }
        switch (diss){

            case listOfDisaster.getLife: getLife(); break;
            case listOfDisaster.getLifeAdvantage: getLifeAdvantage(); break;
            case listOfDisaster.getStrength: getStrength(); break;
            case listOfDisaster.killThirdMine: killThirdMine(); break;

            case listOfDisaster.getMoney: getMoney(); break;
        }

        // x = Random.RandomRange(0,3);
        // string bad = listOfDisaster[x];
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Troop")){
            givaAChance();
            Destroy(GameObject.Find("goldenBall"));
        }
    }
}
