﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCarUIHandler : MonoBehaviour
{
    [Header("Car prefab")]
    public GameObject carPrefab;

    [Header("Spawn on")]
    public Transform spawnOnTransform;

    bool isChangingCar = false;

    CarData[] carDatas;

    int selectedCarIndex = 0;

    //Other components
    CarUIHandler carUIHandler = null;

    // Start is called before the first frame update
    void Start()
    {
        //Load the car data
        carDatas = Resources.LoadAll<CarData>("CarData/");

        StartCoroutine(SpawnCarCO(true));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnPreviousCar();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            OnNextCar();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelectCarMap1();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelectCarMap2();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelectCarMap3();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSelectCarMap4();
        }
    }

    public void OnPreviousCar()
    {
        if (isChangingCar)
            return;

        selectedCarIndex--;

        if (selectedCarIndex < 0)
            selectedCarIndex = carDatas.Length - 1;

        StartCoroutine(SpawnCarCO(true));
    }

    public void OnNextCar()
    {
        if (isChangingCar)
            return;

        selectedCarIndex++;

        if (selectedCarIndex > carDatas.Length - 1)
            selectedCarIndex = 0;

        StartCoroutine(SpawnCarCO(false));
    }

    public void OnSelectCarMap1()
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);
        PlayerPrefs.SetInt("P1_IsAI", 0);

        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P2_IsAI", 1);

        PlayerPrefs.SetInt("P3SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P3_IsAI", 1);

        PlayerPrefs.SetInt("P4SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P4_IsAI", 1);

        PlayerPrefs.Save();

        SceneManager.LoadScene("Map1_1Player");
    }
    public void OnSelectCarMap2()
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);
        PlayerPrefs.SetInt("P1_IsAI", 0);

        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P2_IsAI", 1);

        PlayerPrefs.SetInt("P3SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P3_IsAI", 1);

        PlayerPrefs.SetInt("P4SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P4_IsAI", 1);

        PlayerPrefs.Save();

        SceneManager.LoadScene("Map2_1Player");
    }
    public void OnSelectCarMap3()
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);
        PlayerPrefs.SetInt("P1_IsAI", 0);

        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P2_IsAI", 1);

        PlayerPrefs.SetInt("P3SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P3_IsAI", 1);

        PlayerPrefs.SetInt("P4SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P4_IsAI", 1);

        PlayerPrefs.Save();

        SceneManager.LoadScene("Map3_1Player");
    }
    public void OnSelectCarMap4()
    {
        PlayerPrefs.SetInt("P1SelectedCarID", carDatas[selectedCarIndex].CarUniqueID);
        PlayerPrefs.SetInt("P1_IsAI", 0);

        PlayerPrefs.SetInt("P2SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P2_IsAI", 1);

        PlayerPrefs.SetInt("P3SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P3_IsAI", 1);

        PlayerPrefs.SetInt("P4SelectedCarID", carDatas[Random.Range(0, carDatas.Length)].CarUniqueID);
        PlayerPrefs.SetInt("P4_IsAI", 1);

        PlayerPrefs.Save();

        SceneManager.LoadScene("Map4_1Player");
    }
    public void OnSelectCarMap1_2()
    {

        SceneManager.LoadScene("Map1_2Player");
    }
    public void OnSelectCarMap2_2()
    {

        SceneManager.LoadScene("Map2_2Player");
    }

    IEnumerator SpawnCarCO(bool isCarAppearingOnRightSide)
    {
        isChangingCar = true;

        if (carUIHandler != null)
            carUIHandler.StartCarExitAnimation(!isCarAppearingOnRightSide);

        GameObject instantiatedCar = Instantiate(carPrefab, spawnOnTransform);

        carUIHandler = instantiatedCar.GetComponent<CarUIHandler>();
        carUIHandler.SetupCar(carDatas[selectedCarIndex]);
        carUIHandler.StartCarEntranceAnimation(isCarAppearingOnRightSide);

        yield return new WaitForSeconds(0.4f);

        isChangingCar = false;
    }
}
