using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class FlashlightPov : MonoBehaviour
{
    public Transform player;
    public PostProcessVolume Volume;

    private readonly ColorParameter cpBlack = new ColorParameter { value = Color.black };
    private readonly ColorParameter cpRed = new ColorParameter { value = Color.red };
    Vignette vignetteLayer = null;

    private readonly float minIntensity = 0.4f;
    private readonly float maxIntensity = 1.0f;
    private readonly float flashlightRange = 6.0f;

    void Start()
    {
        Volume.profile.TryGetSettings(out vignetteLayer);
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position + Vector3.up;
        float distance = direction.magnitude;

        if (distance < flashlightRange)
        { // if a gargoyle and the player are within range

            Ray ray = new Ray(transform.position, direction);
            // use dot products to see if the player and gargoyles are looking at each other
            float lookingAt = Vector3.Dot(direction, transform.forward);
            float beingLookedAt = Vector3.Dot(-direction, player.transform.forward);

            vignetteLayer.enabled.value = true;

            if (lookingAt > 0 && beingLookedAt > 0 && Physics.Raycast(ray, out RaycastHit raycastHit)
                && raycastHit.collider.transform == player)
            { // and looking at each other with eye contact
              // set vignette color to red (like their flashlights!)
                vignetteLayer.color.value = cpRed;
                // normalize distance to (0,1)
                float distNormalized = distance / flashlightRange;
                // Lerp makes the red vignette more intense when closer to gargoyles
                float flashlightIntensity = (1 - distNormalized) * maxIntensity + distNormalized * minIntensity;
                vignetteLayer.intensity.value = flashlightIntensity;
            }
            else
            { // if not looking at each other, reset vignette to original settings
                vignetteLayer.color.value = cpBlack;
                vignetteLayer.intensity.value = 0.4f;
            }
        }
    }
}
