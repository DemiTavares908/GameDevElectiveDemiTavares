using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public GameObject PlayerPrefab = null;
    public Transform[] SpawnPoints = null;

    private List<PlayerController> Cubes = new List<PlayerController>();

    // Start is called before the first frame update
    void Start()
    {
        BaseAI[] aiArray = new BaseAI[]{
            new DemiAI(),
            new OtherAI(),
            new OtherAI(),
            new OtherAI(),
        };

        for (int i = 0; i < 4; i++)
        {
            GameObject Player = Instantiate(PlayerPrefab, SpawnPoints[i].position, SpawnPoints[i].rotation);
            PlayerController playerController = Player.GetComponent<PlayerController>();
            playerController.SetAI(aiArray[i]);
            Cubes.Add(playerController);
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            foreach (var Player in Cubes) {
                Player.StartFight();
            }
        }
    }
}
