using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    //Key in playerprefs for lifetime visitors
    private const string VISITORS_KEY = "lifetime_visitors";

    //Updates lifetime visitor count
    public static void UpdateVisitors(int previousRun)
    {
        PlayerPrefs.SetInt(VISITORS_KEY, ReturnVisitors() + previousRun);
    }

    //Returns the count
    public static int ReturnVisitors()
    {
        return PlayerPrefs.GetInt(VISITORS_KEY);
    }
}
