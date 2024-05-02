using UnityEngine;

public class UIActivator : MonoBehaviour
{
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private bool activeOnStart;

    private void Start()
    {
        if (UIPanel == null) return;

        if (activeOnStart)
        {
            UIPanel.SetActive(true);
        }
        else
        {
            UIPanel.SetActive(false);
        }
    }

    public void ActivateUI()
    {
        UIPanel.SetActive(true);
    }

    public void DisactivateUI()
    {
        UIPanel.SetActive(false);
    }
}
