using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FadingLightEffect : MonoBehaviour
{
    [SerializeField] private Light2D fadingLight;
    [SerializeField] private LayerMask triggerLayerMask;
    [SerializeField] private float zeroLightCircleRadius;

    private CircleCollider2D circleCollider;
    private float currentLightIntensity;

    private void Awake()
    {
        currentLightIntensity = fadingLight.intensity;

        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & triggerLayerMask.value) != 0)
        {
            float distanceToLight = (collision.transform.position - fadingLight.transform.position).magnitude;
            float distanceProportion = distanceToLight / circleCollider.radius;

            if (distanceProportion < 1 && distanceProportion > zeroLightCircleRadius)
            {
                fadingLight.intensity = currentLightIntensity * Mathf.Pow(distanceProportion, 3);
            }

            if (distanceProportion < zeroLightCircleRadius)
            {
                fadingLight.intensity = 0;
            }
        }
    }
}
