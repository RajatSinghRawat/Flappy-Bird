using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize=6;
    [SerializeField] private GameObject columnPrefab;
    public float spawnRate = 2f;
    private float columnMin = -20f;
    private float columnMax = 40f;
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(0f,0f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 200f;
    private int currentColumn = 0;
    private bool status;
    // Start is called before the first frame update
    void Start()
    {        
        columns = new GameObject[columnPoolSize];
        columns[0] = Instantiate(columnPrefab, new Vector2(-250f, 0f), Quaternion.identity);
        for (int i = 1; i < columnPoolSize; i++)
        {
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[i] = Instantiate(columnPrefab,new Vector2(objectPoolPosition.x,spawnYPosition),Quaternion.identity);
            objectPoolPosition.x += 50f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if(GameManager.chkGameStatus()==false&&timeSinceLastSpawned>=spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin,columnMax);
            spawnXPosition = Random.Range(190f,230f);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition,spawnYPosition);
            currentColumn++;
            if(currentColumn>=columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
