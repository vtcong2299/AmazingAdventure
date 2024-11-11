using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{    
    Start,
    Playing,
    Pause
}
public class GameManager : MonoBehaviour
{
    public GameState curState;
    public static GameManager instance;
    public int index = 1000;
    public GameObject map1Prefab;
    public GameObject map2Prefab;
    public GameObject currentMap;    
    public GameObject player;
    public AudioSource audioSource;
    public AudioClip clipBG;
    [SerializeField]
    private GameObject mainPlayer;
    public int curChapter = 0;
    public int maxChapter = 2;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clipBG;
        map1Prefab = Resources.Load<GameObject>("Map1"); 
        map2Prefab = Resources.Load<GameObject>("Map2");
    }
    private void Start()
    {
        SetBG();
        UnActiveAllLevel();
        audioSource.Play();
        StartCoroutine(Music());
    }  
    IEnumerator Music()
    {
        while (true)
        {
            yield return new WaitForSeconds(48f);
            audioSource.Play();
        }
    }
    private void Update()
    {
        SetParentOfPlayer();
        switch (curState)
        {
            case GameState.Playing:
                {
                    if (!SpawnPlan.instance.hasChild)
                    {
                        return;
                    }
                    SpawnBullet.instance.UpdateBullet();
                    break;
                }
            case GameState.Pause:
                {
                    break;
                }
        }        
    }
    public void ManagerHeartUI(float hp)
    {
        UIManager.instance.HeartUI(hp);
    }
    public void ManagerStarsUI(int stars)
    {
        UIManager.instance.StarsUI(stars);
    }
    public void ManagerOnChangeCoins(int coins)
    {
        UIManager.instance.OnChangeCoins(coins);
    }
    public void ManagerEndChapter(int coins, int stars)
    {
        UIManager.instance.CheckEndChapter(coins);
        UIManager.instance.StarsUIEnd(stars);
    }
    public void DestroyObj()
    {
        SpawnMushroom.instance.DestroyObj();
        SpawnCoins.instance.DestroyObj();
        SpawnStars.instance.DestroyObj();
        SpawnHeart.instance.DestroyObj();
        SpawnFalingFlatform.instance.DestroyObj();
        SpawnBlueBird.instance.DestroyObj();
        SpawnBoxRock.instance.DestroyObj();
        SpawnBat.instance.DestroyObj();
        SpawnPlan.instance.DestroyObj();
        SpawnBullet.instance.DestroyObj();
    }
    public void SpawnObj()
    {
        SpawnMushroom.instance.AddPosObj();
        SpawnMushroom.instance.Spawn();
        SpawnCoins.instance.AddPosObj();
        SpawnCoins.instance.Spawn();
        SpawnStars.instance.AddPosObj();
        SpawnStars.instance.Spawn();
        SpawnHeart.instance.AddPosObj();
        SpawnHeart.instance.Spawn();
        SpawnFalingFlatform.instance.AddPosObj();
        SpawnFalingFlatform.instance.Spawn();
        SpawnBlueBird.instance.AddPosObj();
        SpawnBlueBird.instance.Spawn();
        SpawnBoxRock.instance.AddPosObj();
        SpawnBoxRock.instance.Spawn();
        SpawnBat.instance.AddPosObj(); 
        SpawnBat.instance.Spawn();
        SpawnPlan.instance.AddPosObj();
        SpawnPlan.instance.Spawn();
        SpawnBullet.instance.AddPosObj();
    }
    public void ResetObj()
    {
        SpawnCoins.instance.ResetObj();
        SpawnStars.instance.ResetObj();
        SpawnHeart.instance.ResetObj();
        SpawnMushroom.instance.ResetObj();
        SpawnFalingFlatform.instance.ResetObj();
        SpawnBlueBird.instance.ResetObj();  
        SpawnBoxRock.instance.ResetObj();
        SpawnBat.instance.ResetObj();
        SpawnPlan.instance.ResetObj();
        SpawnBullet.instance.ResetObj();
    }   
    public void UnActiveAllLevel()
    {
        player.SetActive(false);
        SetActiveChapter();
    }
    public void SetBG()
    {
        BGManager.instance.RandomBG();
    }
    public void SetActiveChapter()
    {       
        switch (index)
        {
            case 0:
                {
                    if (map1Prefab == null)
                    {
                        Debug.LogError("Map1 Prefab is null. Please check if the resource exists.");
                        return;
                    }
                    if (currentMap != null)
                    {
                        Destroy(currentMap);
                        Resources.UnloadUnusedAssets();
                    }
                    currentMap = Instantiate(map1Prefab, transform.position, transform.rotation);
                    break;
                }
            case 1:
                {
                    if (map2Prefab == null)
                    {
                        Debug.LogError("Map1 Prefab is null. Please check if the resource exists.");
                        return;
                    }
                    if (currentMap != null)
                    {
                        Destroy(currentMap);
                        Resources.UnloadUnusedAssets();
                    }
                    currentMap = Instantiate(map2Prefab, transform.position, transform.rotation);
                    break;
                }
            case 1000:
                {
                    if (currentMap != null)
                    {
                        Destroy(currentMap);
                        Resources.UnloadUnusedAssets();
                    }
                    break;
                }
        }
    }
    public void SetParentOfPlayer()
    {
        if (!player.gameObject.activeSelf)
        {
            mainPlayer.transform.SetParent(player.transform);
        }
    }
}
