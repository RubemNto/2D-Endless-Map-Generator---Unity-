using UnityEngine;

public class wallsGeneration : MonoBehaviour
{
    public Transform spawner;
    public GameObject[] prefabs;
    public GameObject[] instancesOfTheWall = new GameObject[5];
    int prefabIndex;
    private float[] heights = { -4, -2, 0, 2, 4 };
    private float[] sides = { -2.25f, 2.25f };
    public bool generateWall = true;



    // Update is called once per frame
    void Update()
    {
        //max instances : 5
        //height positions: -4, -2, 0, 2, 4
        //sides positions: -2.25, 0, 2.25
        if (generateWall)
        {
            GenerateWall();
            generateWall = false;
        }
    }

    void GenerateWall()
    {
        for (int i = 0; i < heights.Length; i++)
        {
            prefabIndex = Random.Range(0, prefabs.Length);
            if (prefabIndex == 5 || prefabIndex == 6 || prefabIndex == 7)
            {
                spawner.localPosition = new Vector2(0, heights[i]);
                GameObject instance = Instantiate(prefabs[prefabIndex], spawner.position, spawner.rotation);
                instance.transform.SetParent(transform);
                instancesOfTheWall[i] = instance;
            }
            else
            {
                int sideSelected = Random.Range(0, 2);
                spawner.localPosition = new Vector2(sides[sideSelected], heights[i]);
                if (sideSelected == 0)
                {//left side of the screen
                    GameObject instance = Instantiate(prefabs[Random.Range(0,2)], spawner.position, spawner.rotation);
                    instance.transform.SetParent(transform);
                    instancesOfTheWall[i] = instance;
                }
                else if(sideSelected == 1)
                {//right side of the screen
                    GameObject instance = Instantiate(prefabs[Random.Range(2, 5)], spawner.position, spawner.rotation);
                    instance.transform.SetParent(transform);
                    instancesOfTheWall[i] = instance;
                }
            }
        }
    }
}
