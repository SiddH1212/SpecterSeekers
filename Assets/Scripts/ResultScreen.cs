using System.Collections;
using System.Collections.Generic;
using Meta.XR.MRUtilityKit;
using TMPro;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI result;
    public Data killCountData;
    // Start is called before the first frame update
    void Start()
    {
        string gameResult = PlayerPrefs.GetString("Result");
        result.text = gameResult;
        text.text = "You defeated " + killCountData.killCount + " Ghosts!";
    }
}
