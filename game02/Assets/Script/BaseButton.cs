using UnityEngine;
using System.Collections;
using System;

public class BaseButton : MonoBehaviour
{

    public Action onClick;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    { 
        Debug.Log("clicked");
        if (onClick != null) onClick();
    }
}