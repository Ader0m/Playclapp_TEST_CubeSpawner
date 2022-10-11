using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObjPrefab;
    [SerializeField] private Transform _spawnObjLayer;
    /// <summary>
    /// Set as milliseconds
    /// </summary>
    [SerializeField] private int  _spawnInterval;
    [SerializeField] private float _spawnObjSpeed;
    [SerializeField] private float _spawnObjDistance;
    private DateTime dateTime;

    #region Get/Set

    public void SetSpeed(float speed)
    {
        _spawnObjSpeed = speed;
    }

    public void SetDistance(float distance)
    {
        _spawnObjDistance = distance;
    }

    /// <summary>
    /// Set as milliseconds
    /// </summary>
    public void SetInterval(int interval)
    {
        _spawnInterval = interval;
    }

    #endregion

    void Start()
    {
        dateTime = DateTime.Now;
    }

    void Update()
    {
        if ((DateTime.Now - dateTime).TotalMilliseconds > _spawnInterval)
        {
            dateTime = DateTime.Now;
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        GameObject obj = Instantiate(_spawnObjPrefab, _spawnObjLayer);
        ISpawnedObj spawnedObj = obj.GetComponent<ISpawnedObj>();
        spawnedObj.SetDistance(_spawnObjDistance);
        spawnedObj.SetSpeed(_spawnObjSpeed);
    }   
}
