using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Hero : MonoBehaviour
{
    // Singleton pattern
    static public Hero S { get; private set; }

    [Header("Inscribed")]
    public float speed = 30f;
    public float rollMult = -45f;
    public float pitchMult = 30f;

    [Header("Dynamic")]
    [Range(0, 4)]
    public float shieldLevel = 1;

    void Awake()
    {
        // Awake can be called multiple times;
        // -> The hero is never put to sleep
        if (S == null)
        {
            S = this;
        }
        else
        {
            UnityEngine.Debug.LogError("Hero.Awake()");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical"); 

        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;

        transform.rotation = Quaternion.Euler(vAxis * pitchMult, hAxis * rollMult, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        
        Destroy(go);
        shieldLevel--;
        if (shieldLevel < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
