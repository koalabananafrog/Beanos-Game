using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrivacyPolicy : MonoBehaviour
{
    public void OpenPrivacyP(){
        Application.OpenURL("https://unity.com/legal/privacy-policy");
    }
}
