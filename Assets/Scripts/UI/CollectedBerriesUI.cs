using TMPro;
using UnityEngine;

public class CollectedBerriesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI collectedBerriesText;
    [SerializeField] private TextMeshProUGUI allLevelBerriesText;

    [SerializeField] private ItemTypeSO itemType;
    [SerializeField] private GameObjectRuntimeSetSO gameObjectRuntimeSet;

    private int collectedBerriesNumber;
    private int allLevelBerriesNumber;

    private void Start()
    {
    }

    private void Update()
    {

        allLevelBerriesNumber = gameObjectRuntimeSet.Items.Count;
        collectedBerriesNumber = itemType.itemQuantity;

        collectedBerriesText.text = collectedBerriesNumber.ToString();
        allLevelBerriesText.text = allLevelBerriesNumber.ToString();
    }
}
