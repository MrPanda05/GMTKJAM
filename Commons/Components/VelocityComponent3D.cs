using Godot;
using System;

namespace Commons.Components
{

    public partial class VelocityComponent3D : Node
    {
        [ExportGroup("Propreties")]
        [Export] public float speed { get; private set; } = 800f;
        [Export] public float maxSpeed { get; private set; } = 1600f;
        [Export] public float aceleration { get; private set; } = 1f;
        [Export] public float friction { get; private set; } = 0.25f;
        [Export] public float jumpForce { get; private set; } = 2000f;
        [Export] public float gravityForce { get; private set; } = 980f;
        [Export] public float terminalVelocity { get; private set; } = 1600;
        [Export] public bool hasGravity { get; private set; } = true;
        [Export] public float sprintSpeed { get; private set; } = 8f;
        [Export] public float baseSpeed { get; private set; } = 5f;



        [ExportSubgroup("Individual")]
        [Export] private CharacterBody3D myIndividual;

        private Vector3 vel;

        public void SetSprintSpeed(float newSprintSpeed)
        {
            sprintSpeed = newSprintSpeed;
        }
        public void SetBaseSpeed(float newSpeed)
        {
            baseSpeed = newSpeed;
        }
        public bool ActivateMovement()
        {
            return myIndividual.MoveAndSlide();
        }
        public Vector3 GetVelocity()
        {
            return vel;
        }

        public void SetSpeed(float newSpeed)
        {
            speed = Mathf.Abs(newSpeed);
        }

        public void AddSpeed(float newSpeed)
        {
            speed += newSpeed;
            Mathf.Round(speed);
        }

        public void SetMaxSpeed(float newMaxSpeed)
        {
            if (maxSpeed <= 0)
            {
                GD.PushWarning("Value less than zero or iqual zero, May cause unintended behaviour");
            }
            maxSpeed = newMaxSpeed;
            GD.Print($"Set speed to {newMaxSpeed}");
        }
        public void SetAcelleration(float newAce)
        {
            aceleration = newAce;
            GD.Print($"Set aceleration to {newAce}");
        }

        public void SetFriction(float newFriction)
        {
            friction = newFriction;
            GD.Print($"Set friction to {newFriction}");
        }

        public void SetJumpForce(float newJumpForce)
        {
            jumpForce = newJumpForce;
            GD.Print($"Set jump force to {newJumpForce}");
        }

        public void SetGravity(float newGravity)
        {
            if (newGravity <= 0)
            {
                GD.PushWarning("Gravity setting to negative or iqual zero may cause uninteded behaviour");
            }
            gravityForce = newGravity;
            GD.Print($"Set gravity to {newGravity}");
        }

        public void SetTerminalVelocity(float newTerminalVelocity)
        {
            terminalVelocity = Mathf.Abs(newTerminalVelocity);
            GD.Print($"Set terminal velocity to {newTerminalVelocity}");
        }

        public void SwitchGravity()
        {
            hasGravity = !hasGravity;
            GD.Print($"Gravity is now {hasGravity}");
        }

        public void SetGravity(bool hasGravityValue)
        {
            hasGravity = hasGravityValue;
        }
        public float AddGravity(float delta)
        {
            if (!hasGravity) return 0;
            if (myIndividual == null) return 0;
            if (myIndividual.IsOnFloor()) return 0;
            vel = myIndividual.Velocity;
            vel.Y -= gravityForce * delta;
            vel.Y = Mathf.Clamp(vel.Y, -terminalVelocity, terminalVelocity);
            return vel.Y;
        }
    }
}
