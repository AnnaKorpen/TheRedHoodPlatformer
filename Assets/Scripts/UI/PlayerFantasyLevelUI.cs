using TMPro;
using UnityEngine;

public class PlayerFantasyLevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fantasyValueText;
    [SerializeField] private FloatValueSO fantasyCurrentLevel;

    private void Start()
    {
        UpdateFantasyLevel();
    }
    public void UpdateFantasyLevel()
    {
        fantasyValueText.text = fantasyCurrentLevel.runtimeValue.ToString();
    }
}
