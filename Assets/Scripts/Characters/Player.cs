using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed
    {
        get { return speed; }
        set
        {
            speed = value;
            if (speed < 0)
                throw new ArgumentException("Ўвидк≥сть Player не може бути менше 0");
        }
    }
    public bool IsRunning { get; set; }
    public bool IsFighting { get; set; }
    public bool IsIdle { get; set; }
    public bool IsDead { get; set; }
    public Vector3 MovementDirection { get; private set; }
    public float Hp { get; set; } = 10;
    public Animator AnimatorController;
    private int speed = 5;
    private IMovement movement;
    private IRotation rotation;
    private IDie die;
    private void Start()
    {
        movement = new PlayerMovement();
        rotation = new RotationPlayer();
        die = new DiePlayer();
    }
    private void Update()
    {
        if (IsDead) return;
        IsDead = die.Die();
        MovementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        movement.Move();
        rotation.Rotation();

    }
    public void AddHP()
    {
        Hp++;
    }
}