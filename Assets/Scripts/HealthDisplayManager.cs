using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayManager : MonoBehaviour
{

    public Image EmptyHeartImage;
    public Transform EmptyHeartParent;
    public Transform FullHeartParent;
    public Image FullHeartImage;
    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void Start()
    {
        CreateEmptyDisplayHearts();
        FillHearts();
    }

    void Update()
    {
    }

    void OnEnable()
    {
        Player.currentHealthChange += FillHearts;
    }

    void OnDisable()
    {
        Player.currentHealthChange -= FillHearts;
    }

    void CreateEmptyDisplayHearts()
    {
        foreach (Transform child in EmptyHeartParent)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < player.MaximumHealth; i++)
        {
            GameObject heart = Instantiate(EmptyHeartImage.gameObject, Vector3.zero, Quaternion.identity);
            heart.transform.SetParent(EmptyHeartParent, false);
        }
    }

    void FillHearts()
    {
        foreach (Transform child in FullHeartParent)
        {
            GameObject.Destroy(child.gameObject);
        }

        for (int i = 0; i < player.CurrentHealth; i++)
        {
            GameObject heart = Instantiate(FullHeartImage.gameObject, Vector3.zero, Quaternion.identity);
            heart.transform.SetParent(FullHeartParent, false);
        }
    }


}
