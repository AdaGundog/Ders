using Unity.VisualScripting;
using UnityEngine;

public class BuildingPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
    }
}