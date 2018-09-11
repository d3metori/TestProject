using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSpawner : MonoBehaviour {

    public List<CharTemplate> charTemplates = new List<CharTemplate>();
    public GameObject charToSpawn;
    public GameObject parentObject;

    CharTemplate curTemplate;

    public void SpawnObject(Vector3 pos)
    {
        GetRandomData();
        GameObject spawnedChar = Instantiate(charToSpawn, pos, charToSpawn.transform.rotation);
        spawnedChar.transform.parent = parentObject.transform;
    }

    void GetRandomData()
    {
        Character curChar = charToSpawn.GetComponent<Character>();

        int rand = Random.Range(0, charTemplates.Count);
        curTemplate = charTemplates[rand];

        float curScale = Random.Range(curTemplate.minSize, curTemplate.maxSize);
        float curForce = Random.Range(curTemplate.minSpeed, curTemplate.maxSpeed);

        charToSpawn.transform.localScale = new Vector3(curScale, curScale, 0);
        curChar.forceSpeed = curForce;


    }
}
