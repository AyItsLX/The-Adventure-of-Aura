using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour {

    [SerializeField]
    private AudioClip[] clips;
    [SerializeField]
    private AudioClip[] rockClips;
    [SerializeField]
    private AudioClip[] rockLandClips;
    [SerializeField]
    private AudioClip[] LandClips;

    private AudioSource audioSource;

    private TerrainDetector terrainDetector;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private void Land()
    {
        AudioClip clip = GetRandomClip1();
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip1()
    {
        //return LandClips[Random.Range(0, LandClips.Length)];
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);
        switch (terrainTextureIndex)
        {
            case 0:
                return LandClips[Random.Range(0, LandClips.Length)];
            case 2:
                return rockLandClips[Random.Range(0, rockLandClips.Length)];
            default:
                return rockLandClips[Random.Range(0, rockLandClips.Length)];
        }
    }

    private AudioClip GetRandomClip()
    {
        //return clips[Random.Range(0, clips.Length)];
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);
        switch (terrainTextureIndex)
        {
            case 0:
                AudioClip Check = clips[Random.Range(0, clips.Length)];
                if (Check == clips[Random.Range(0, clips.Length)])
                {
                    Check = clips[Random.Range(0, clips.Length)];
                    return Check;
                }
                return Check;
                //return clips[Random.Range(0, clips.Length)];
            case 2:
                AudioClip Checke = rockClips[Random.Range(0, rockClips.Length)];
                if (Checke == rockClips[Random.Range(0, rockClips.Length)])
                {
                    Checke = rockClips[Random.Range(0, rockClips.Length)];
                    return Checke;
                }
                return Checke;
                //return rockClips[Random.Range(0, rockClips.Length)];
            default:
                AudioClip Checker = rockClips[Random.Range(0, rockClips.Length)];
                if (Checker == rockClips[Random.Range(0, rockClips.Length)])
                {
                    Checker = rockClips[Random.Range(0, rockClips.Length)];
                    return Checker;
                }
                return Checker;
                //return rockClips[Random.Range(0, rockClips.Length)];
        }
    }
}
