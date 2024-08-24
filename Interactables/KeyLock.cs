using Godot;
using System;

namespace Interactables 
{ 
	public partial class KeyLock : Node3D
	{
		[Export]
		private int needkeyID;

		[Export]
		private bool needKey;

		public Action OnOpen;
		public int GetMyId()
		{
			return needkeyID;
		}
		public bool GetIfNeedKey()
		{
			return needKey;
		}
	}
}
