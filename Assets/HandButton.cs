using UnityEngine;
using System.Collections.Generic; // Import for using List
using UnityEngine.XR.Interaction.Toolkit;

public class HandButton : XRBaseInteractable
{
    public List<ParticleSystem> controlledParticleSystems; // List of particle systems

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        ToggleParticleSystems();
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
}
