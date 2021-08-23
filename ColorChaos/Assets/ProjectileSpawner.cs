using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileSpawner : MonoBehaviour
{
    public Transform Spawner1;
    public Transform Spawner2;
    public Transform Spawner3;
    public Transform Projectile1;
    public Transform Projectile2;
    public Transform Projectile3;
    public Transform[] Projectiles;
    public int ProjectileNum;
    public int SpawnerNum;
    public float WaitTimer;
    public float Limit;
    public int Score;
    public int HiScore;
    public Text ScoreText;
    public Text HiScoreText;

    /*
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(WaitTimer);
        Instantiate(MuzzleFlash, MuzzleFlashPoint.position, MuzzleFlashPoint.rotation);
        Transform BulletPrefab = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Instantiate(AudioClip, ShootPoint.position, ShootPoint.rotation);

        Rigidbody2D BulletRB = BulletPrefab.GetComponent<Rigidbody2D>();
        BulletRB.AddForce(ShootPoint.up * BulletForce, ForceMode2D.Impulse);
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        HiScore = PlayerPrefs.GetInt("HiScore");
    }

    // Update is called once per frame
    void Update()
    {
        

        WaitTimer++;

        SpawnerNum = Random.Range(1, 91);

        if (SpawnerNum <= 30 && WaitTimer >= Limit)
        {
            Instantiate(Projectile1, Spawner1.position, Spawner1.rotation);
            WaitTimer = 0;
        }
        else if (SpawnerNum >= 31 && SpawnerNum <= 60 && WaitTimer >= Limit)
        {
            Instantiate(Projectile2, Spawner2.position, Spawner2.rotation);
            WaitTimer = 0;
        }
        else if (SpawnerNum >= 61 && WaitTimer >= Limit)
        {
            Instantiate(Projectile3, Spawner3.position, Spawner3.rotation);
            WaitTimer = 0;
        }

        if (Score > HiScore)
        {
            HiScore = Score;
            PlayerPrefs.SetInt("HiScore", Score);
        }

        ScoreText.text = "Score: " + Score.ToString();
        HiScoreText.text = "High Score: " + HiScore.ToString();
    }
}
