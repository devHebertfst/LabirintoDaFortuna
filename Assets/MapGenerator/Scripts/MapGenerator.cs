using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public Texture2D texture;
    public ObjectInfo[] objectInfo;
    public ObjectInfo floor;
    public GameObject floorParent;
    public GameObject coinPrefab;
    public GameObject coinParent;
    public Vector3 offset = Vector3.zero;

    private Vector2 pos;
    private readonly float prefabSize = 5f;

    void Start()
    {
        ReadTexture();
    }

    public void ReadTexture()
    {
        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                pos = new Vector2(x, y);
                GetColor(x, y);
            }
        }
    }

    private void GetColor(int x, int y)
    {
        Color c = texture.GetPixel(x, y);
        if (c.a < 1)
        {
            GameObject floorInstance = Instantiate(floor.prefab, new Vector3(pos.x * prefabSize, 0, pos.y * prefabSize), Quaternion.identity, floorParent.transform);
            Instantiate(coinPrefab, new Vector3(floorInstance.transform.position.x, floorInstance.transform.position.y + 0.5f, floorInstance.transform.position.z), Quaternion.identity, coinParent.transform);
            return;
        }
        CreateObject(c);
    }

    private void CreateObject(Color c)
    {
        foreach (ObjectInfo info in objectInfo)
        {
            if (info.color == c)
            {
                Instantiate(info.prefab, new Vector3(pos.x * prefabSize, 0, pos.y * prefabSize) + offset, Quaternion.identity, transform);
            }
        }
    }
}
