using Commons.Components;
using Commons.Singletons;
using Godot;
using System;
using static Godot.TextServer;

namespace LePlayer
{
    public partial class Player : CharacterBody3D
    {
        [Export]
        private VelocityComponent3D velocityComp;

        [Export]
        private float Sens = 0.02f;

        [Export] private Node3D head;
        [Export] private Camera3D camera;

        private bool jumping;

        private Vector3 vel;

        private Vector2 Inputdir;
        private Vector3 dir;

        public bool disableMovement;
        private void GetInput()
        {
            jumping = Input.IsActionJustPressed("Jump");
            Inputdir = Input.GetVector("Left", "Right", "Foward", "Back");
            dir = (head.GlobalTransform.Basis * new Vector3(Inputdir.X, 0, Inputdir.Y)).Normalized();
        }
        public override void _Ready()
        {
            DialogueManager.Instance.ShowPlayerText("Gosh... its so foggy today, I can't see shit...");
            Input.MouseMode = Input.MouseModeEnum.Captured;
        }

        public override void _UnhandledInput(InputEvent @event)
        {
            if (disableMovement) return;
            if (@event is InputEventMouseMotion mouse)
            {
                Vector3 camRot = new Vector3();
                head.RotateY(-mouse.Relative.X * Sens);
                camera.RotateX(-mouse.Relative.Y * Sens);
                camRot.X = Mathf.Clamp(camera.Rotation.X, Mathf.DegToRad(-90), Mathf.DegToRad(80));
                camera.Rotation = camRot;
            }
        }
        public void Jump()
        {
            vel.Y = velocityComp.jumpForce;

        }
        public void Movement(float delta)
        {
            if (Input.IsActionPressed("Run"))
            {
                velocityComp.SetSpeed(velocityComp.sprintSpeed);
            }
            else
            {
                velocityComp.SetSpeed(velocityComp.baseSpeed);
            }
            if (IsOnFloor())
            {

                if (dir != Vector3.Zero)
                {
                    vel.X = dir.X * velocityComp.speed;
                    vel.Z = dir.Z * velocityComp.speed;
                }
                else
                {
                    vel.X = Mathf.Lerp(Velocity.X, dir.X *velocityComp.speed, delta * 7f);
                    vel.Z = Mathf.Lerp(Velocity.Z, dir.Z * velocityComp.speed, delta * 7f);
                }
            }
            else
            {
                vel.X = Mathf.Lerp(Velocity.X, dir.X * velocityComp.speed, delta * 3f);
                vel.Z = Mathf.Lerp(Velocity.Z, dir.Z * velocityComp.speed, delta * 3f);
            }
        }
        public override void _PhysicsProcess(double delta)
        {
            if (disableMovement) return;
            vel = Velocity;
            vel.Y = velocityComp.AddGravity((float)delta);
            GetInput();
            if (jumping && IsOnFloor())
            {
                Jump();
            }
            Movement((float)delta);
            Velocity = vel;
            velocityComp.ActivateMovement();
        }
    }
}
