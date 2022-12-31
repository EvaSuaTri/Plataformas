using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public Transform controladorGolpe;
    public float radioGolpe = 1;
    public float dañoGolpe = 0;
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Uptdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Golpe();
        }
    }

    public void Golpe()
    {

        anim.SetTrigger("golpe");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);


        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<Enemigo>().Morir(dañoGolpe);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
