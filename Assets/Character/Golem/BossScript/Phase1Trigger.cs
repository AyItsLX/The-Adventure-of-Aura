using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1Trigger : MonoBehaviour {

    public GameManager gameManager;
    public Golem golem;
    public Transform Phase1AssistPlayerSpawn;
    public Animator P1CinematicAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.AureliaIsFollowing = false;
            gameManager.AuravIsFollowing = false;
            P1CinematicAnimator.SetBool("Phase1Trans", true);
            GameObject AssistPlayer = GameObject.FindGameObjectWithTag("AssistPlayer");
            AssistPlayer.transform.position = new Vector3(Phase1AssistPlayerSpawn.position.x, Phase1AssistPlayerSpawn.position.y, Phase1AssistPlayerSpawn.position.z);
            gameManager.CheckSpawner = true;
            golem.ReadyToThrow = true;
            golem.FirstPhase = true;

            gameObject.SetActive(false);
        }
    }
}
