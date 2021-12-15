using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class StackerDropper : MonoBehaviour
{
    [Header("Game Setup")]
    private int _currentLevel;

    public int dropsAllowed;
    public float startingSpeed;
    public float percentIncreasePerLevel;
    [Header("Config")] public MoveBetweenPoints dropperMovement;
    public GameObject blockPrefab;
    
    //
    private int dropsAttemped;
    void Start()
    {
        _currentLevel = 0;
        dropsAttemped = 0;
        SetLevelSpeed();
    }

    public void Drop()
    {
        //we create the stacker block, it moves itself downwards.
        //I have shrunk the collider on the prefab by like 1% to prevent it from hitting a block it should look like its next to.
        Instantiate(blockPrefab, transform.position, quaternion.identity);
        
        //set level (speed)
        _currentLevel++;
        SetLevelSpeed();
        
        //check attempts
        dropsAttemped++;
        if (dropsAttemped > dropsAllowed)
        {
            Debug.Log("Game Over");
        }

    }

    private void SetLevelSpeed()
    {
        float speed = startingSpeed;
        //replace this with the compound interest forumula so we dont have to do a loop lol
        for (int i = 0; i < _currentLevel; i++)
        {
            speed += speed * percentIncreasePerLevel;
        }

        dropperMovement.SetSpeed(speed);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Drop();
        }
    }
}
