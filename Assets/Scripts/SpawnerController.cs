using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private Timer _spawnTimer;

    public void Initialize()
    {
        _spawnTimer = gameObject.AddComponent<Timer>();
        _spawnTimer.Duration = 2;
        _spawnTimer.Run();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_spawnTimer != null && _spawnTimer.Finished)
        {
            float spawnPositionX = Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight);
            float spawnPositionY = Random.Range(ScreenUtils.ScreenTop, ScreenUtils.ScreenBottom);

            Instantiate(_enemyPrefab, new Vector2(spawnPositionX, spawnPositionY), Quaternion.identity);
            _spawnTimer.Run();
        }
    }
}