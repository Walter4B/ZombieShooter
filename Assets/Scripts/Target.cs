using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    public PlayerController damage;
    public int ScoreValue = 1;
    public int pom_score;
    

    public ParticleSystem ExplosionPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (GameManager.GM._currentState == GameManager.GameState.GameOver)
            return;

        if(other.tag == "Projectile")
        {
            GameManager.GM.AddScore(ScoreValue);


            if (ExplosionPrefab)
                Instantiate(ExplosionPrefab, transform.position, transform.rotation);

            Destroy(other.gameObject); //projektil
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            GameObject dmg = GameObject.FindGameObjectWithTag("Player");
            damage = dmg.GetComponent<PlayerController>();
            damage.Health -= 10;

            if (ExplosionPrefab)
                Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(2);
        }
    }
}
