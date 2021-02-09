using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text textScore;

    public Slider sliderForce;
    SnowmanMovement snowmanMovement;


    void Start()
    {
        snowmanMovement = FindObjectOfType<SnowmanMovement>(); 
    }

    void Update()
    {
        sliderForce.value = snowmanMovement.GetForceInPercentage();
    }
}
