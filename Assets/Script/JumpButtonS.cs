using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
 
public class JumpButtonS : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
public bool buttonPressed;
 
public void OnPointerDown(PointerEventData eventData){
     buttonPressed = true;
      Debug.Log("HEJSAN");
}
 
public void OnPointerUp(PointerEventData eventData){
    buttonPressed = false;
}
private void Update(){
    if(buttonPressed){
        Debug.Log("HEJSAN");
    }
}
}