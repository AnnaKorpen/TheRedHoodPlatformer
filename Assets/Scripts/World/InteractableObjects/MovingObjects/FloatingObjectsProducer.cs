using System.Collections;
using UnityEngine;

public class FloatingObjectsProducer : MonoBehaviour
{
    [SerializeField] private BoxCollider2D waterCollider;

    private ObjectPool floatingObjectsPool;
    private float delayTime = 8f;
    private Vector2 startingPoint;
    private Vector2 endPoint;

    private void Awake()
    {
        floatingObjectsPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        SetStartAndEndPosition();
        StartCoroutine(ProduceFloatingObject());
    }

    private void SetStartAndEndPosition()
    {
        startingPoint = new Vector2(transform.position.x - (waterCollider.size.x / 2), transform.position.y);
        endPoint = new Vector2(transform.position.x + (waterCollider.size.x / 2), transform.position.y);
    }

    private IEnumerator ProduceFloatingObject()
    {
        yield return null;

        while (true)
        {
            ActivateFloatingObject();

            yield return new WaitForSeconds(delayTime);
        }
    }

    private void ActivateFloatingObject()
    {
        GameObject floatingObject = floatingObjectsPool.GetPooledObject();

        if (floatingObject != null)
        {
            floatingObject.transform.position = startingPoint;
            floatingObject.SetActive(true);
            floatingObject.GetComponent<FloatingObject>().SetEndPoint(endPoint);
        }
    }




}
