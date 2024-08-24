using Godot;
using System;

namespace Interactables
{
	public partial class Door : Node3D
	{
		private KeyLock myLock;
		// Called when the node enters the scene tree for the first time.

		private AnimationPlayer myAnimation;
		public override void _Ready()
		{
			myLock = GetNode<KeyLock>("KeyLock");
			myAnimation = GetNode<AnimationPlayer>("AnimationPlayer");
			myLock.OnOpen += Open;
		}
		public void Open()
		{
			myAnimation.Play("Open");
		}

		// Called every frame. 'delta' is the elapsed time since the previous frame.
		public override void _Process(double delta)
		{
		}
        public override void _ExitTree()
        {
            myLock.OnOpen -= Open;
        }
    }
}
