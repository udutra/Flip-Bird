using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPool : MonoBehaviour {

    private List<GameObject> listObstacles;
    private int poolSize = 5;
    //private int obstacleCount;
    private float timeElapsed;

    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float spawnTime = 2.5f;
    [SerializeField] private float xSpawnPosition = 12f;
    [SerializeField] private float minYPosition = -2f;
    [SerializeField] private float maxYPosition = 3f;

    private void Start() {
        listObstacles = new List<GameObject>(poolSize);
        AddPipesToPool(poolSize);
    }

    private void Update() {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnTime && !GameManager.Instance.isGameOver) {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle() {
        timeElapsed = 0f;

        float ySpawnPosition = Random.Range(minYPosition, maxYPosition);
        Vector2 spawnPosition = new(xSpawnPosition, ySpawnPosition);
        GameObject pipe = RequestPipe();
        pipe.transform.position = spawnPosition;
    }

    private void AddPipesToPool(int amount) {
        for (int i = 0; i < amount; i++) {
            GameObject pipe = Instantiate(obstaclePrefab, this.transform);
            pipe.SetActive(false);
            listObstacles.Add(pipe);
            poolSize++;
        }
    }

    public GameObject RequestPipe() {

        for (int i = 0; i < listObstacles.Count; i++) {
            if (!listObstacles[i].activeSelf) {
                listObstacles[i].SetActive(true);
                return listObstacles[i];
            }
        }

        AddPipesToPool(1);
        listObstacles[^1].SetActive(true);
        return listObstacles[^1];
    }
}