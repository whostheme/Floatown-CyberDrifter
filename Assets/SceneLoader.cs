﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string loadlevel;

    private void OnTriggerEnter(Collider other)
    {

        SceneManager.LoadScene(loadlevel);

    }
}