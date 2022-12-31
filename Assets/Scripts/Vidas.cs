using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public GameObject[] Vidass;
    public Queue<GameObject> VidasCola = new Queue<GameObject>();
    public static Vidas vidas;

    // Start is called before the first frame update
    void Start()
    {
        vidas = this;
        foreach (GameObject g in Vidass)
        {
            VidasCola.Enqueue(g);
            g.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reducirVidas()
    {
        GameObject g = VidasCola.Dequeue();
        g.gameObject.SetActive(false);
        VidasCola.Enqueue(g);
    }

    public void recuperarVidas()
    {
        foreach (GameObject g in Vidass)
        {
            VidasCola.Enqueue(g);
            g.gameObject.SetActive(true);
        }

    }
}
