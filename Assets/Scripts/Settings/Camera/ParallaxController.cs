using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeffs;

    private int layersCount;

    private void Awake()
    {
        layersCount = layers.Length;
    }

    private void Update()
    {
        for (int i = 0; i < layersCount; i++)
        {
            layers[i].position = transform.position * coeffs[i];
        }
    }
}
