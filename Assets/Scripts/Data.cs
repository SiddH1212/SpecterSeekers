using UnityEngine;

[CreateAssetMenu(fileName = "KillCountData", menuName = "Game Data/Kill Count")]
public class Data : ScriptableObject
{
    public int killCount = 0; // Stores the number of killed ghosts

    public void ResetKillCount()
    {
        killCount = 0;
    }
}
