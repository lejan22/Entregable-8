using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    //Canciones y sus nombres
    public string[] songName;
    public AudioClip[] canciones;

    public AudioSource audiosource;

    public int cancionActual = 0;

    public GameObject titulo;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        //Pone la cancion que toca en la cancion actual
        audiosource.clip = canciones[cancionActual];
        //Enseña la cancion en el principio
        Showname();
    }

   

    public void nextSong()
    {
        //Se añade 1 a la cancion actual, es decir, vamos a la siguiente cancion
        cancionActual++;

        //Si la cancion actual tiene el valos mas grande a la cantidad de canciones, volver a la primera cancion
        if (cancionActual >= canciones.Length)
        {
            cancionActual = 0;
        }
        startAudio();
    }

    public void previousSong()
    {
        //Se quita 1 a la cancion actual, es decir, vamos a la anterior cancion
        cancionActual--;

        //Si la cancion actual tiene el valos menor a la primera , volver a la ultima cancion
        if (cancionActual < 0)
        {
            cancionActual = canciones.Length -1;
        }
        startAudio();
    }

    public void pauseSong()
    {
        //Para el audio
        audiosource.Pause();
    }

    public void startAudio()
    {
        //pone la cancio que se reproduce en el momento
        audiosource.clip = canciones[cancionActual];
        pauseSong();
        Playsong();
        Showname();
    }

    public void Playsong()
    {
        //Si la cancion no se reproduce
        if (!audiosource.isPlaying)
        {
            //Reproduce la cancion
            audiosource.Play();
        }
    }

    public void RandomSong()
    {
        int randomIndex = Random.Range(0, canciones.Length);
        cancionActual = randomIndex;

        startAudio();
    }

    private void Showname()
    {
        titulo.GetComponent<TextMeshProUGUI>().text = songName[cancionActual];
    }
}
