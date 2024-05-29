using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip sonDeFond; // Référence vers votre musique de fond
    private AudioSource audioSource;

    void Start()
    {
        // Créez un composant AudioSource et configurez-le pour jouer la musique de fond
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sonDeFond;
        audioSource.loop = true; // Pour que la musique se répète en boucle
        audioSource.Play(); // Jouez la musique au démarrage du jeu
    }
}