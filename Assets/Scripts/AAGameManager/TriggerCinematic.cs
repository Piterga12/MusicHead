using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCinematic : MonoBehaviour
{
    public int index;
    public Transform LevelManager;

    bool fired;

    LevelManager lvlManagerC;

    // Start is called before the first frame update
    void Start()
    {
        lvlManagerC = LevelManager.GetComponent<LevelManager>();

        fired = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!fired)
        {

            lvlManagerC.OnTriggerCinematic(index);

            fired = true;
        }
        
    }
}
