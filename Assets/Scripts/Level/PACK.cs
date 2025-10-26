using UnityEngine;

public class TileAligner : MonoBehaviour
{
    public float gridSize = 1f;

    [ContextMenu("Align Tiles")]
    void AlignTiles()
    {
        foreach (Transform child in transform)
        {
            Vector3 pos = child.position;
            pos.x = Mathf.Round(pos.x / gridSize) * gridSize;
            pos.y = Mathf.Round(pos.y / gridSize) * gridSize;
            pos.z = 0;
            child.position = pos;
        }
        Debug.Log("Tiles READY");
    }
}
