using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawn : MonoBehaviour
{

    [SerializeField] private Vector2 randomRange_X;
    [SerializeField] private float spawnZ;
    [SerializeField] private float spawnY;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private float spawnTime;
    [SerializeField] private float destroyTime;

    private void Start()
    {
        StartCoroutine(spawnObj());
    }

    private IEnumerator spawnObj()
    {
        while (true)
        {
            var spawn = Instantiate(spawnObject,
                new Vector3(Random.Range(randomRange_X.x, randomRange_X.y), spawnY, spawnZ), Quaternion.identity);
            Rigidbody spawnRigid = spawn.GetComponent<Rigidbody>();
            spawnRigid.AddForce(Vector3.up,ForceMode.Impulse);
            Destroy(spawn,destroyTime);
            yield return new WaitForSeconds(spawnTime);
        }
    }
}
