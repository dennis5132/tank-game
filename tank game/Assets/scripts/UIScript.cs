using UnityEngine;

public class UIScript : MonoBehaviour
{
    public TankMovement tank;
    public tankManager Manager;
    public float barLength;
    public float side;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(1, 1);//zet de healthbar op de achtergrond
    }

    // Update is called once per frame
    void Update()
    {
        barLength = ((float)Manager.startHealth - tank.health) * side;
        RectTransform rectTransform = GetComponent<RectTransform>(); // pakt de rectTransform
        rectTransform.localScale = new Vector2((float)tank.health / (float)Manager.startHealth, 1); //verdeelt de overgebleven health over de basishealth en zet dat in om een barlengte te krijgen
        rectTransform.localPosition = new Vector2(barLength / ((float)Manager.startHealth*2), 0);
        
    }
}
