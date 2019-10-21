using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.transform.gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            RectTransform trans = GameObject.FindGameObjectWithTag("BossHealth").GetComponent<RectTransform>();
            trans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, trans.rect.width - 10);
        }
    }

}
