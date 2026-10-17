using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;


    void Start()
    {
        CurrentCheckpoint = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer(){

        FindObjectOfType<playerControl>().transform.position = CurrentCheckpoint.transform.position;

    }
}