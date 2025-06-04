using Unity.VisualScripting;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public MonoBehaviour tilePlacer; // Drag your script component here in the Inspector
    [SerializeField] private MonoBehaviour roadPlacer;

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

    public void ToggleRoadPlacerScript()
    {
        if (roadPlacer != null)
        {
            roadPlacer.enabled = !roadPlacer.enabled;
        }
    }

    public void OpenTileManager()
    {

        if (!tilePlacer.isActiveAndEnabled) 
        {

            tilePlacer.enabled = true;
               

        }
    }

    public void CloseRoadPlacer()
    {

        if (roadPlacer.isActiveAndEnabled)
        {

            roadPlacer.enabled = false;


        }
    }
}
