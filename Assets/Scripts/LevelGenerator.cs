using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] string[] mapRows;
    [SerializeField] GameObject[] tilePrefabs;
    [SerializeField] float tileSize = 1f;

    void Start()
    {
        BuildLevel();
    }

    void BuildLevel()
    {
        int h = mapRows.Length;
        int w = mapRows[0].Length;

        for (int r = 0; r < h; r++)
        {
            for (int c = 0; c < w; c++)
            {
                char ch = mapRows[r][c];
                int id = (ch >= '0' && ch <= '9') ? ch - '0' : 0;
                if (id < 0 || id >= tilePrefabs.Length) continue;
                Vector3 pos = new Vector3(c * tileSize, -r * tileSize, 0);
                Instantiate(tilePrefabs[id], pos, Quaternion.identity, transform);
            }
        }
    }
}
