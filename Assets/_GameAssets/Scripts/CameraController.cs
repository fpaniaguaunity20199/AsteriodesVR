using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float distanceToDestruction;
    [SerializeField] float focusSpeed;
    [SerializeField] Image imageSensor;
    [SerializeField] GameObject prefabExplosion;
    private bool asteroidSelected = false;
    private float selectedAmount = 0;

    void Update()
    {
        if (GameManager.playing==false)
        {
            return;
        }
        transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
        ScanAsteriods();
    }
    private void ScanAsteriods()
    {
        RaycastHit rch;
        Ray rayito = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(rayito, out rch, distanceToDestruction))
        {
            asteroidSelected = true;
            selectedAmount += focusSpeed * Time.deltaTime;
            if (selectedAmount >= 1)
            {
                Instantiate(prefabExplosion, rch.transform.position, Quaternion.identity);
                Destroy(rch.transform.gameObject);
            }
        } else
        {
            asteroidSelected = false;
            selectedAmount = 0;
        }
        imageSensor.fillAmount = selectedAmount;
    }
}
