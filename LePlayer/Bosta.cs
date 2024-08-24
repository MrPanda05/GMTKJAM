using Godot;
using System;

public partial class Bosta : CharacterBody3D
{
	public const float Speed = 5.0f;
	public const float JumpVelocity = 4.5f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/3d/default_gravity").AsSingle();

    [Export] private Node3D head;
    [Export] private Camera3D camera;

    public override void _UnhandledInput(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouse)
        {
            Vector3 camRot = new Vector3();
            head.RotateY(-mouse.Relative.X * 0.01f);
            camera.RotateX(-mouse.Relative.Y * 0.01f);
            camRot.X = Mathf.Clamp(camera.Rotation.X, Mathf.DegToRad(-40), Mathf.DegToRad(60));
            camera.Rotation = camRot;
        }
    }
    public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector("Left", "Right", "Foward", "Back");
		Vector3 direction = (head.Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
