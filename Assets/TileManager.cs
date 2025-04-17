using UnityEngine;

public class TilePlacer : MonoBehaviour
{
    public GameObject tilePrefab; // Assign in Inspector
    public LayerMask groundMask;
    public LayerMask tileMask;// Only ground layer should be selected
    public float gridSize = 10f;
    
    public int gridWidth = 10;    // Number of tiles in X
    public int gridHeight = 10;   // Number of tiles in Z
    public Vector3 gridOrigin = Vector3.zero;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left click
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
         

            if (Physics.Raycast(ray, out RaycastHit hit2, 1000f, groundMask) && !Physics.Raycast(ray, out RaycastHit hit, 1000f, tileMask))
            {

                Vector3 point = hit2.point;

                //Snap to grid
                Vector3 spawnPos = new Vector3(
               Mathf.Floor(point.x / gridSize) * gridSize + gridSize / 2,  point.y,
               Mathf.Floor(point.z / gridSize) * gridSize + gridSize / 2 );

                Instantiate(tilePrefab, spawnPos, Quaternion.identity);

                Debug.Log("groundmask");
            }
        
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


