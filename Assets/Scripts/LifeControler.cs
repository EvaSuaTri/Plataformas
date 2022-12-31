using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeControler : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    bool invencible;

    public enum DeathMode { Teleport, ReloadScene, Destroy}
    public DeathMode death_mode;
    public Transform respawn;

    Rigidbody2D rb;


    public static int vidas3 = 3;
    public int vidaPublic;
    public bool puedeHacerDano = true;
    public GameObject panelMuerte;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifes_current = lifes_max;
        panelMuerte.gameObject.SetActive(false);
    }

    public void Damage(int damage = 1, bool ignoreInvencible = false)
    {
        if(!invencible || ignoreInvencible)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_Corutine());
            if(lifes_current <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        Debug.Log("He muerto");
        switch (death_mode)
        {
            case DeathMode.Teleport:
                rb.velocity = new Vector2(0, 0);
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.ReloadScene:
                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
   
    IEnumerator Invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!puedeHacerDano)
            return;

        if (collision.transform.CompareTag("Enemy"))
        {

            Invoke("ActivarDano", 1);
            vidas3 -= 1;

            if (Vidas.vidas != null)
            {
                Vidas.vidas.reducirVidas();
            }

            if (vidas3 == 0)
            {
                panelMuerte.gameObject.SetActive(true);
            }
            
        }

        if (collision.transform.CompareTag("corazon"))
        {
            if (lifes_current < 3)
            {
                lifes_current = 3;
                Vidas.vidas.recuperarVidas();
            }           
            
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Respawn"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = respawn.position;
        }

    }
}
