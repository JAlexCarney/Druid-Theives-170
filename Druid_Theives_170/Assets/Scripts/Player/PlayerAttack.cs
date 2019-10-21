using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackPrefab;
    private int delayCount = 0;
    private int delayAmount = 60;


    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && delayCount >= delayAmount)
        {
            delayCount = 0;
            Debug.Log("Click");
            Vector3 input = Input.mousePosition;
            Vector3 pos = transform.position;
            input.z = 0;
            input = Camera.main.ScreenToWorldPoint(input);
            Vector2 dir = new Vector2(input.x - pos.x, input.y - pos.y).normalized;
            GameObject attack = Instantiate(attackPrefab);
            attack.transform.position = new Vector3(pos.x + 2*dir.x, pos.y + 2*dir.y);
            attack.transform.eulerAngles = new Vector3(0, 0, Vector2.Angle(new Vector2(0,1), dir) + 180f);
            attack.transform.localScale = new Vector3(1, 1, 1);
        }
        if(delayCount < delayAmount)
        {
            delayCount++;
        }
        
    }
}
