using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int CurrentHealth;
    public int MaxHealth;
    public bool dead;
    public Texture2D fadeoutTexture; //is white screen
    public float fadeSpeed = 0.0f;

    public GameObject playerCamera;
    private bool faded;
    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    private SFXManager sfx;

    void Start () {
        sfx = FindObjectOfType<SFXManager>();
        CurrentHealth = MaxHealth;
        faded = false;
	}

    void Update () {

        if (CurrentHealth <= 0 && faded == false)
        {
            dead = true;
            sfx.playerDeadGrunt.Play();
            sfx.playerDeadMusic.Play();
            StartCoroutine(DeathFade());
            
            //Destroy(gameObject);
            PlayerMove.Exists = false;
            PlayerCamera.Exists = false;
            UIController.UIExists = false;
            DestroyManager.Exists = false;
            //Destroy(FindObjectOfType<UIController>());
            Destroy(FindObjectOfType<PlayerCamera>());
            //FindObjectOfType<PlayerCamera>().gameObject.SetActive(false);
            SceneManager.LoadScene("Game Over");
            //Destroy(playerCamera);
            faded = true;

        }
	}


    public void HurtPlayer(int damage)
    {
        CurrentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
        
    }


    //EVERYTHING BELOW IS SO THE GAME FADES TO WHITE WHEN PLAYER DIES
    void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeoutTexture);
  
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLoadCallback;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLoadCallback;
    }

    void OnLoadCallback(Scene scene, LoadSceneMode mode)
    {
        BeginFade(-1);
    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }

    IEnumerator DeathFade()
    {
        float fade = BeginFade(1);
        yield return new WaitForSeconds(fade);

    }
}
