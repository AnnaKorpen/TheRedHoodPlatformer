using UnityEngine;

public class FloatingObject : MonoBehaviour
{
    private bool startFloating = false;
    private Vector2 endPoint;

    private void Update()
    {
        if (startFloating)
        {
            if (transform.position.x >= endPoint.x)
            {
                startFloating = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void SetEndPoint(Vector2 position)
    {
        startFloating = true;

        endPoint = position;

    }
}
