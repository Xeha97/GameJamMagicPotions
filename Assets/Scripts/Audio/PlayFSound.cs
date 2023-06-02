using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;


public class PlayFSound : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference sound;
    
    public void PlaySound()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(sound, gameObject);
    }
}
