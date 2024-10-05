using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] private List<GameObject> Characters = new List<GameObject>();
    [SerializeField] GameObject player;
    // Start is called before the first frame update
   
    public void ChooseDeadpool()
    {
        Instantiate(Characters[0], player.transform);
    }

    public void ChooseCube()
    {
        Instantiate(Characters[1], player.transform);
    }
}
