using UnityEngine;

[RequireComponent(typeof(WorldStateSwitcher))]
public class WorldStateSwitcherInput : MonoBehaviour
{
    private WorldStateSwitcher stateSwitcher;

    private void Awake()
    {
        stateSwitcher = GetComponent<WorldStateSwitcher>();
    }

    private void Start()
    {
        stateSwitcher.ChangeToFantasyWorld();
    }

    private void Update()
    {
        CheckSwitchButtonPressed();
    }

    private void CheckSwitchButtonPressed()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            stateSwitcher.ChangeWorldState();
        }
    }
}
