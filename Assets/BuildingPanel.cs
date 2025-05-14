using Unity.VisualScripting;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public MonoBehaviour tilePlacer; // Drag your script component here in the Inspector


    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }

    public void ToggleTargetScript()
    {
        if (tilePlacer != null)
        {
            tilePlacer.enabled = !tilePlacer.enabled;
        }
    }
}
