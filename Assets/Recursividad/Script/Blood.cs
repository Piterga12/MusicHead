using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public Color bloodColor;
    public GameObject BloodPrefab;
    Material bloodMaterial;
    
    public float bloodDurationTime = 3.0f;
    public float bloodRate = 5;
    public float bloodScaleX = 10;
    public float bloodScaleY = 4;
    public float repeatNumber = 0;

    float bloodTimer;

    

    void bloodGenerator(Vector3 posicion, float escalaX, float escalaY)
    {
        if (escalaY < 0.2f)
        {
            GameObject go = (GameObject)GameObject.Instantiate(BloodPrefab, posicion, Quaternion.identity);
            go.transform.localScale = new Vector3(escalaX, escalaY, 1);
        }
        else
        {
            GameObject go = (GameObject)GameObject.Instantiate(BloodPrefab, posicion, Quaternion.identity);
            go.transform.localScale = new Vector3(escalaX, escalaY, 1);

            float x = UnityEngine.Random.Range(-escalaX / 2, escalaX / 2);
            float y = UnityEngine.Random.Range(-escalaY / 2, escalaY / 2);
            Vector3 p1 = posicion + new Vector3(x, y, 0);

            bloodGenerator(p1, escalaX / 2, escalaY / 2);

            x = UnityEngine.Random.Range(-escalaX / 2, escalaX / 2) * bloodRate;
            y = UnityEngine.Random.Range(-escalaY / 2, escalaY / 2) * bloodRate;
            Vector3 p2 = posicion + new Vector3(x, y, 0);

            bloodGenerator(p2, escalaX / 2, escalaY / 2);

            x = UnityEngine.Random.Range(-escalaX / 2, escalaX / 2) * bloodRate;
            y = UnityEngine.Random.Range(-escalaY / 2, escalaY / 2) * bloodRate;
            Vector3 p3 = posicion + new Vector3(x, y, 0);

            bloodGenerator(p3, escalaX / 2, escalaY / 2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer r = BloodPrefab.GetComponent<MeshRenderer>();
        bloodMaterial = r.sharedMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        if (repeatNumber < 50)
        {
            bloodGenerator(transform.position, bloodScaleX, bloodScaleY);
            repeatNumber++;
        }
        if (bloodTimer + Time.deltaTime < bloodDurationTime)
        {
            bloodTimer += Time.deltaTime;
        }

        bloodMaterial.color = new Color(bloodColor.r, bloodColor.g, bloodColor.b, bloodTimer / bloodDurationTime);
    }
}
