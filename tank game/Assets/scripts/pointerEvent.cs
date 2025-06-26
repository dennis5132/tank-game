using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pointerEvent : MonoBehaviour, IPointerEnterHandler
{
    public liveUIScript UI;
    public int thisButton;
    public AudioSource Audio;
    public AudioClip AudioClip;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    public void OnPointerEnter(PointerEventData eventData) //checkt of de muis boven de knop zit
    {
        UI.currentButton = thisButton; //selecteert die knop
        UI.colorCheck();
        Audio.PlayOneShot(AudioClip);
    }
}
