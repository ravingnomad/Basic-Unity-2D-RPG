using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadManager : MonoBehaviour {

	public static List<GameObject> dontDestroyOnLoadObjectList = new List<GameObject>();


	public static void SetDontDestroy(GameObject gameObj)
    {
        DontDestroyOnLoad(gameObj);
        dontDestroyOnLoadObjectList.Add(gameObj);
    }


	public static void DestroyAll()
    {
		foreach(GameObject obj in dontDestroyOnLoadObjectList)
        {
            if (obj != null)
            {
                TurnOffExists(obj.tag);
                Destroy(obj);
            }  
        }
        dontDestroyOnLoadObjectList.Clear();
    }

    
    private static void TurnOffExists(string objectTagName)
    {
        switch(objectTagName)
        {
            case "Player":
                PlayerMove.Exists = false;
                break;
            case "Player Camera":
                PlayerCamera.Exists = false;
                break;
            case "Dialogue Manager":
                DialogueManager.Exists = false;
                break;
            case "Destroy Manager":
                DestroyManager.Exists = false;
                break;
            case "Music Manager":
                MusicManager.Exists = false;
                break;
            case "SFX Manager":
                SFXManager.Exists = false;
                break;
            case "UI Manager":
                UIController.Exists = false;
                break;
            default:
                break;
        }
    }
}
