using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArteroidsGenerator : MonoBehaviour
{
    [SerializeField] GameObject prefabAsteriod;
    [SerializeField] int numberOfAsteriods;
    [SerializeField] float spaceRadious;
    void Start()
    {
        for (int i = 0; i < numberOfAsteriods; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(-spaceRadious,spaceRadious),
                Random.Range(-spaceRadious, spaceRadious),
                Random.Range(-spaceRadious, spaceRadious)
                );
            Instantiate(prefabAsteriod, position, Quaternion.identity);
        }
    }
}
