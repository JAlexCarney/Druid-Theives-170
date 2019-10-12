using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoxCheck : MonoBehaviour
{
    private MetaEvents meta = null;

    public void Start()
    {
        meta = transform.parent.gameObject.GetComponent<MetaEvents>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            meta.Die();
        }
    }

    private void Reload() {
        Application.LoadLevel(Application.loadedLevel);
    }
}
