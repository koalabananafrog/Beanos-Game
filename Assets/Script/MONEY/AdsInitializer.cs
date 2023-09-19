using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameID;

    void Awake(){

    }
    void InitalizeAds(){
        _gameID = _androidGameId;
        _gameID = _iOSGameId;
    }
}
