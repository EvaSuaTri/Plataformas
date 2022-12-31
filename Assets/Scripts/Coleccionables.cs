using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coleccionables : MonoBehaviour
{

    public int score;
    public Text TXTscore;
    public GameObject panelFIN;

    public Animator door;
    

    // Start is called before the first frame update
    void Start()
    {
        panelFIN.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TXTscore.text = score + " / 10";

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coleccionable")
        {
            score++;
            Destroy(collision.gameObject);
            
        }


        if ((collision.gameObject.tag == "door") && (score == 10) )
        {

            door.SetTrigger("abrir");
            StartCoroutine(FinalRoutine());

        }
    }

    public IEnumerator FinalRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        panelFIN.gameObject.SetActive(true);
        
    }


}
