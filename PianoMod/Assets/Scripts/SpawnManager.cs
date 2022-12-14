using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{

    
    private float[] horizontalPositions = { -3.2f, -1.2f, 0.785f };
    public GameObject tilePrefab;
    private float tilePosZ = 8.5f;
    private float tilePozY = 6.75f;

    public float tileGenSpeed = 1f;

    private int score = 0;

    public TMP_Text txtCanvas;
    public AudioSource startAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenerateTile", 1.0f, tileGenSpeed);
        PlayStartSound();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateTile()
    {
        Instantiate(tilePrefab, new Vector3(horizontalPositions[UnityEngine.Random.Range(0, 3)], tilePozY, tilePosZ), tilePrefab.transform.rotation);
    }
 
    public void ScoreUpdate()
    {
        score++;
        txtCanvas.text = score.ToString();
    }

    private void PlayStartSound()
    {
        startAudioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        startAudioSource.Play();
    }

}

