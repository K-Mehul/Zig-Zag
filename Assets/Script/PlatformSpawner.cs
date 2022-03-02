using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond;
    float size;
    Vector3 lastPos;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        
        for(int i=0;i<=20;i++) {
            SpawnPlatforms();
        }
    }

    public void StartSpawning()
    {
        InvokeRepeating("SpawnPlatforms",0.1f,0.2f);
    }

    void Update()
    {
        if(GameManager.instance.gameOver == true){
            CancelInvoke("SpawnPlatforms");
        }
        
    }

    void SpawnPlatforms()
    {
        int rand = Random.Range(0,7);
        if(rand < 3) {
            SpawnZ();
        } else if(rand > 3) {
            SpawnX();
        }
    }

    void SpawnX() 
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform,pos,Quaternion.identity);

        int randDiamond = Random.Range(0,4);
        if(randDiamond>1){
            Instantiate(diamond,new Vector3(pos.x,pos.y+1,pos.z),diamond.transform.rotation);
        } 
        
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform,pos,Quaternion.identity);

        int randDiamond = Random.Range(0,4);
        if(randDiamond>1){
            Instantiate(diamond,new Vector3(pos.x,pos.y+1,pos.z),diamond.transform.rotation);
        }
    }
}
