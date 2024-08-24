using Godot;
using System;


namespace Interactables
{
	public partial class Key : Node3D
	{
		[Export]
		private int myId;

		public int GetMyId()
		{
			return myId;
		}
	}
}
