using UnityEngine;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{
    public List<ParticleSystem> controlledParticleSystems; 
    public AudioSource audioSource; 

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ToggleParticleSystems();
        PlayAudioClip();
    }

    private void ToggleParticleSystems()
    {
        foreach (var ps in controlledParticleSystems)
        {
            if (ps != null)
            {
                if (ps.isPlaying)
                    ps.Stop();
                else
                    ps.Play();
            }
        }
    }

    private void PlayAudioClip()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
