using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode] HAS BEEN ABANDONED
public class BackgroundGenerationScript : MonoBehaviour
{
    public GameObject backgroundPrefab;

    GameObject previousUpGenerated;
    GameObject previousDownGenerated;
    GameObject previousLeftGenerated;
    GameObject previousRightGenerated;
    GameObject originGenerated;

    [SerializeField] private bool hasGenerated;

    [SerializeField] private float heightDifference;
    [SerializeField] private float widthDifference;

    [SerializeField] private int layerOfBackground;

    [SerializeField] private int amountOfBackgrounds;

    private void Update()
    {
        if (!hasGenerated)
        {
            ActivateGeneration();
        }
    }

    void ActivateGeneration()
    {
        Debug.Log("Started Generating");

        originGenerated = Instantiate(backgroundPrefab, new Vector3(0, 0, layerOfBackground), Quaternion.identity);
        originGenerated.transform.parent = gameObject.transform;

        previousDownGenerated = originGenerated;
        previousUpGenerated = originGenerated;
        previousLeftGenerated = originGenerated;
        previousRightGenerated = originGenerated;

        for (int i = 0; i < amountOfBackgrounds; i++)
        {
            GenerateVertical();
        }

        hasGenerated = true;
    }

    void GenerateHorizontal(GameObject spawnLocation)
    {
        previousUpGenerated = Instantiate(backgroundPrefab, spawnLocation.transform.position + new Vector3(0, heightDifference, layerOfBackground), Quaternion.identity);
        previousUpGenerated.transform.parent = gameObject.transform;

        previousDownGenerated = Instantiate(backgroundPrefab, spawnLocation.transform.position + new Vector3(0, -heightDifference, layerOfBackground), Quaternion.identity);
        previousDownGenerated.transform.parent = gameObject.transform;
    }

    void GenerateVertical()
    {
        previousLeftGenerated = Instantiate(backgroundPrefab, previousLeftGenerated.transform.position + new Vector3(widthDifference, 0, layerOfBackground), Quaternion.identity);
        previousLeftGenerated.transform.parent = gameObject.transform;

        GenerateHorizontal(previousLeftGenerated);

        previousRightGenerated = Instantiate(backgroundPrefab, previousRightGenerated.transform.position + new Vector3(-widthDifference, 0, layerOfBackground), Quaternion.identity);
        previousRightGenerated.transform.parent = gameObject.transform;

        GenerateHorizontal(previousRightGenerated);
    }
}
