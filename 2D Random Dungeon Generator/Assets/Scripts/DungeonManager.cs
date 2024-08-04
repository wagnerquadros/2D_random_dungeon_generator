using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonManager : MonoBehaviour
{

    public GameObject floorPrefab, wallPrefab, tilePrefab;
    public int totalFloorCount;

    [HideInInspector] public float minX, maxX, minY, maxY;

    List<Vector3> floorList = new List<Vector3>();

    private void Start()
    {
        RandomWalker();
    }

    private void Update()
    {
        if (Application.isEditor && Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void RandomWalker()
    {
        Vector3 currentPos = Vector3.zero;
        
        floorList.Add(currentPos);
        while (floorList.Count < totalFloorCount)
        {
            switch (Random.Range(1, 5))
            {
                case 1:
                    currentPos += Vector3.up;
                    break;
                case 2:
                    currentPos += Vector3.right;
                    break;
                case 3:
                    currentPos += Vector3.down;
                    break;
                case 4:
                    currentPos += Vector3.left;
                    break;
            }

            bool inFloorList = false;
            for (int i = 0; i < floorList.Count; i++)
            {
                if (Vector3.Equals(currentPos, floorList[i]))
                {
                    inFloorList = true;
                    break;
                }
            }
            if (!inFloorList)
            {
                floorList.Add(currentPos);
            }
        }
        for (int i = 0;i < floorList.Count; i++)
        {
            GameObject goTile = Instantiate(tilePrefab, floorList[i],Quaternion.identity) as GameObject;
            goTile.transform.parent = transform;
            goTile.name = tilePrefab.name;
        }
    }
}
