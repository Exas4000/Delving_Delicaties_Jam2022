using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField] GameObject loot;

    void Start()
    {
        if (PlayerPrefs.GetFloat("DroppedLoot") > 0)
        {
            //move parent to location of loot
            Vector3 deadLootSpawn = new Vector3(PlayerPrefs.GetFloat("DeathX"), PlayerPrefs.GetFloat("DeathY"),0);
            transform.position = deadLootSpawn;

            //produce the loot and assign score value
            var deadLoot = Instantiate(loot, transform);
            deadLoot.GetComponent<Collectable_Score>().setValue(PlayerPrefs.GetFloat("DroppedLoot"));
            deadLoot.transform.position = transform.position;
        }
    }

    
}
