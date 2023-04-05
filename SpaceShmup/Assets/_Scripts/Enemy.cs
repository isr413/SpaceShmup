using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [Header("Inscribed")]
    public float speed = 10f;
    public float pitchMult = 5f;

    private BoundsCheck bndCheck;

    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }

    public Vector3 pos
    {
        get
        {
            return this.transform.position;
        }
        set
        {
            this.transform.position = value;
        }
    }

    public Quaternion rot
    {
        get
        {
            return this.transform.rotation;
        }
        set
        {
            this.transform.rotation = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (pos.y + bndCheck.radius < -bndCheck.camHeight)
        {
            Vector3 tempPos = pos;
            tempPos.y = bndCheck.camHeight + 2.5f * bndCheck.radius;
            pos = tempPos;
        }
    }

    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
        //rot = Quaternion.Euler(-speed * pitchMult, 0, 0);
    }
}