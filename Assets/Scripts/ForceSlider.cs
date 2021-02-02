using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceSlider : MonoBehaviour
{
    [SerializeField] private GameObject slider;
    PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
