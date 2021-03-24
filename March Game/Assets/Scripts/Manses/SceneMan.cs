using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



// Scan through hextiles (represented by integer xyz coordinates)
// Instantiate objects when they are found
public class SceneMan : Singleton<SceneMan>
{
    [SerializeField] protected Tilemap tm;
    [SerializeField] protected GameObject peghole;
    [SerializeField] protected GameObject pegholeFolder;

    void Start()
    {
        GridLayout gridLayout = tm.gameObject.GetComponent<GridLayout>();
        foreach (Vector3Int position in tm.cellBounds.allPositionsWithin)
        {
            if (tm.HasTile(position))
            {
                TileBase tile = tm.GetTile(position);
                if (tile.name == "Peghole Sprite")
                {
                    tm.SetTile(position, null);
                    Vector3 worldPos = gridLayout.CellToLocal(position);
                    worldPos.z = 1;
                    Instantiate(peghole, worldPos, Quaternion.identity, pegholeFolder.transform);
                }
                // Instantiate other objects here if needed
                // if (tile.name == "")...
            }
        }
    }
}
