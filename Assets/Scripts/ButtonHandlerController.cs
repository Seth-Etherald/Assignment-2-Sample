using UnityEngine;
using UnityEngine.UI;
using static DataManagement;

public class ButtonHandlerController : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    private readonly DataManagement _dataManage = new DataManagement();
    private string _saveFile;

    private void Awake()
    {
        _saveFile = Application.persistentDataPath + "/savedata.json";
    }

    public void SaveButtonClicked()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesArray.Length > 0)
        {
            EnemiesData[] enemies = new EnemiesData[enemiesArray.Length];
            for (int i = 0; i < enemiesArray.Length; i++)
            {
                enemies[i] = new EnemiesData()
                {
                    positionX = enemiesArray[i].transform.position.x,
                    positionY = enemiesArray[i].transform.position.y,
                    healthPoint = enemiesArray[i].GetComponent<EnemyController>().HealthPoint
                };
            }
            _dataManage.SaveData(enemies, _saveFile);
        }
    }

    public void LoadButtonClicked()
    {
        GameObject[] enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemiesArray != null)
        {
            foreach (GameObject enemy in enemiesArray)
            {
                Destroy(enemy);
            }
        }

        EnemiesData[] enemies = _dataManage.ReadData(_saveFile);
        if (enemies.Length > 0)
        {
            foreach (EnemiesData enemy in enemies)
            {
                GameObject enemyInstantiated = Instantiate(_enemyPrefab, new Vector3(enemy.positionX, enemy.positionY, 0), Quaternion.identity);
                enemyInstantiated.GetComponent<EnemyController>().SetHealth(enemy.healthPoint);
            }
        }

        PlayButtonClicked();
    }

    public void PlayButtonClicked()
    {
        GameObject spawner = GameObject.Find("Spawner");
        Button saveButton = GameObject.Find("SaveButton").GetComponent<Button>();
        spawner.GetComponent<SpawnerController>().Initialize();
        saveButton.interactable = true;
    }
}