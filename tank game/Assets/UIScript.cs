using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TankMovement tank;
    public float barLength;
    public float side;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        barLength = ((float)tank.startHealth - tank.health) * side;
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector2((float)tank.health / (float)tank.startHealth, 1);
        rectTransform.localPosition = new Vector2(barLength / ((float)tank.startHealth*2), 0);
        //Debug.Log(tank.health /3);
        
    }
}
