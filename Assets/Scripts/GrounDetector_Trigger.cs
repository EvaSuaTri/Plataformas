using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrounDetector_Trigger : MonoBehaviour
{
    public bool grounded;

    void OnTriggerStay2D(Collider2D collision)
    {
        grounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        grounded = false;
    }
}
