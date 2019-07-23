﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using SSFS;
using VRTK;

public class Achievement_merge : MonoBehaviour
{

    AudioSource audio;
    private SimpleSSFSToggle SSFSToggle;

    int frameSpan = -1; 
    // Start is called before the first frame update
    public VRTK_BodyPhysics bodyPhysics;
    public VRTK_PlayerClimb playerClimb;
    protected virtual void Awake()
        {
            bodyPhysics = (bodyPhysics != null ? bodyPhysics : FindObjectOfType<VRTK_BodyPhysics>());
            playerClimb = (playerClimb != null ? playerClimb : FindObjectOfType<VRTK_PlayerClimb>());
        }
    void Start()
    {
        SSFSToggle = gameObject.GetComponent<SimpleSSFSToggle>();
        SSFSToggle.phaseOn = false;
        audio = GetComponent<AudioSource>();//之前一直出问题居然……是因为没加音源而请求………………
        
    }

    // Update is called once per frame
    void Update()
    {
        if(frameSpan>0)
        {
            frameSpan--;
        }else if(frameSpan ==0){
            frameSpan--;
            //置标志脚本的Boolean为true
            SSFSToggle.phaseOn = true;
            //播放标志出现音乐
        }
    }

    void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.CompareTag("Player"))
        {
            //判断一下玩家是否在地上（onground）只有在地上才……
            Debug.Log("Achievement_merge:OnTriggerEnter");
            Debug.Log("bodyPhysics.OnGround():"+bodyPhysics.OnGround());
            if(!playerClimb.IsClimbing()){
                //播放情节背景音乐
                audio.Play();
                frameSpan = 90;//约1.5秒后出现标志
            }
            
        }

    }
}