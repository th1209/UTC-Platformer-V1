﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SavePoint : MonoBehaviour
{
    private StageControl _stageControl;

    void Start()
    {
        var go = GameObject.FindGameObjectWithTag("StageControl");
        Assert.IsNotNull(go);
        _stageControl = go.GetComponent<StageControl>();
    }

    void OnTriggerEnter(Collider character)
    {
        if (character.tag != "Player")
            return;

        _stageControl.SendMessage("UpdateCharacterInstantiatePoint", transform.position);
    }
}
