using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Vector2 Enemypos;
    public GameObject PlayerM;
    bool perseguirP;
    public int vel;
    public float vida;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (perseguirP)
        {
            transform.position = Vector2.MoveTowards(transform.position, Enemypos, vel * Time.deltaTime);

        }

        if (Vector2.Distance (transform.position, Enemypos) > 12F)
        {
            perseguirP = false;
        }
    }

    public void Morir(float daño)
    {
        vida -= daño;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag.Equals("Player"))
        {
            Enemypos = PlayerM.transform.position;
            perseguirP = true;
        }
        
    }
}
