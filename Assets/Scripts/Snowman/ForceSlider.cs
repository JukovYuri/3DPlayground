using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSlider : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    SnowmanMovement snowmanMovement;

    // Start is called before the first frame update
    void Start()
    {
        snowmanMovement = FindObjectOfType<SnowmanMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
