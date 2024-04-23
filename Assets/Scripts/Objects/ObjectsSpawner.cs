using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _objects;
    [SerializeField] GameObject _bomb;
    [SerializeField] RectTransform _prefabSpawner;

    public float left;
    public float right;

    void Start()
    {

        StartCoroutine(SpawnRandom());
    }

    public IEnumerator SpawnRandom()
    {
        yield return new WaitForSeconds(3);
        while (FindObjectOfType<GameManager>().isGameOver == false)
        {
            InstantiateRandomObjects();
            yield return new WaitForSeconds(RandomInstantiatingTime());
        }
    }
    private void InstantiateRandomObjects()
    {
        float bombSpawnPercentage = 0.15f;
        float objectsSpawnPercentage = 0.6f;

        float randomValue = Random.value;

        if (randomValue < bombSpawnPercentage)
        {
            GameObject bombClones = Instantiate(_bomb, _prefabSpawner);
            bombClones.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-30f, 30f));
            bombClones.GetComponent<Rigidbody2D>().AddForce(RandomDirection() * RandomPush(), ForceMode2D.Impulse);
        }

        if (randomValue < objectsSpawnPercentage)
        {
            int randomObjIndex = Random.Range(0, _objects.Length);
            GameObject objectsClones = Instantiate(_objects[randomObjIndex], _prefabSpawner);
            objectsClones.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-30f, 30f));
            objectsClones.GetComponent<Rigidbody2D>().AddForce(RandomDirection() * RandomPush(), ForceMode2D.Impulse);
        }
        

        
    }
    private Vector2 RandomDirection()
    {
        Vector2 randomDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return randomDirection;
    }
    private float RandomPush()
    {
        float force = Random.Range(11f, 14f);
        return force;
    }
    private float RandomInstantiatingTime()
    {
        float waittingTime = Random.Range(0.5f, 4f);
        return waittingTime;
    }
}
