using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Transform FiringPoint;

    public float Power = 10.0f;

    private GameObject _projectileParent;

    void Awake()
    {
        GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        _projectileParent = new GameObject("ProjectileParent");

    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, Quaternion.identity, _projectileParent.transform);
                Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody>();
                projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode.VelocityChange);
            }
        }
    }
}
