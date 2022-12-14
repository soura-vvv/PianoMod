using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SceneManagement;

public class TileController : MonoBehaviour
{
    public float tileSpeed = 8.0f;
    public AudioSource endAudioSource;
    public AudioClip endAudioClip;
    public AudioSource audioSource;
    public AudioClip[] audioSources;
    public SpawnManager spawnManager;
    
    void Start()
    {
        audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        endAudioSource= GameObject.Find("EndAudioSource").GetComponent<AudioSource>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * tileSpeed);

        if (transform.position.z < -8.38)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        endAudioSource.clip = endAudioClip;
        endAudioSource.Play();
        SceneManager.LoadScene("End");
    }
    void OnMouseDown()
    {
        PlayNote();
        spawnManager.ScoreUpdate();
        Destroy(gameObject);
    }

    private void PlayNote()
    {
        audioSource.clip = audioSources[UnityEngine.Random.Range(0, audioSources.Length)];
        audioSource.Play();
    }

}