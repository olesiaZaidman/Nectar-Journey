using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] musicTracks;
    private AudioSource audioSource;
    private int currentTrackIndex;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentTrackIndex = 0;

        // Start playing the first track
        PlayNextTrack();
    }

    private void Update()
    {
        // Check if the current track has finished playing
        if (!audioSource.isPlaying)
        {
            // Move to the next track
            PlayNextTrack();
        }
    }

    private void PlayNextTrack()
    {
        // Set the next track on the audio source
        audioSource.clip = musicTracks[currentTrackIndex];

        // Play the track
        audioSource.Play();

        // Increment the track index
        currentTrackIndex = (currentTrackIndex + 1) % musicTracks.Length;
    }
}
