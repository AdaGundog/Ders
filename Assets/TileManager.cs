using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TilePlacer : MonoBehaviour
{
    public GameObject redTilePrefab;
    public GameObject blueTilePrefab;
    public GameObject blackTilePrefab;

    public LayerMask groundMask;
    public LayerMask tileMask;
    public float gridSize = 10f;
   
    public int gridWidth = 10;
    public int gridHeight = 10;
    public Vector3 gridOrigin = Vector3.zero;

    private Camera mainCamera;
    private GameObject ghostTile;
    private GameObject currentTilePrefab;

    void Start()
    {
        mainCamera = Camera.main;

        // Default selected tile
        currentTilePrefab = redTilePrefab;

        // Create ghost tile
        ghostTile = Instantiate(currentTilePrefab);
        MakeTransparent(ghostTile);
        ghostTile.layer = LayerMask.NameToLayer("");
    }

    void Update()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            ghostTile.SetActive(false);
            return;
        }
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 1000f, groundMask ))
        {
            Vector3 point = hit.point;

            // Snap to grid
            Vector3 spawnPos = new Vector3(
                Mathf.Floor(point.x / gridSize) * gridSize + gridSize / 2,
                point.y,
                Mathf.Floor(point.z / gridSize) * gridSize + gridSize / 2
            );

            // Position ghost tile
            ghostTile.transform.position = spawnPos;

            // Check if tile already exists
            bool tileExists = Physics.Raycast(ray, out RaycastHit tileHit, 1000f, tileMask);
            ghostTile.SetActive(!tileExists);

            // Place real tile on click
            if (Input.GetMouseButtonDown(0) && !tileExists)
            {

                Instantiate(currentTilePrefab, spawnPos, Quaternion.identity);
                Debug.Log("Placed tile");
            }
        }
        else
        {
            ghostTile.SetActive(false);
        }
    }

    public void SetRedTile()
    {
        SwitchTile(redTilePrefab);
    }

    public void SetBlueTile()
    {
        SwitchTile(blueTilePrefab);
    }

    public void SetBlackTile()
    {
        SwitchTile(blackTilePrefab);
    }

    void SwitchTile(GameObject tilePrefab)
    {
        currentTilePrefab = tilePrefab;

        // Destroy old ghost and create new one
        if (ghostTile != null)
            Destroy(ghostTile);
       
        ghostTile = Instantiate(currentTilePrefab);
        MakeTransparent(ghostTile);
        ghostTile.layer = LayerMask.NameToLayer("");
    }

    void MakeTransparent(GameObject obj)
    {
        foreach (Renderer r in obj.GetComponentsInChildren<Renderer>())
        {
            Color color = r.material.color;
            color.a = 0.5f;
            r.material.color = color;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for (int x = 0; x <= gridWidth; x++)
        {
            for (int z = 0; z <= gridHeight; z++)
            {
                Vector3 center = gridOrigin + new Vector3(x * gridSize + gridSize / 2f, 0f, z * gridSize + gridSize / 2f);
                Vector3 size = new Vector3(gridSize, 0.01f, gridSize);
                Gizmos.DrawWireCube(center, size);
            }
        }
    }
}
