using Godot;
using System;
using Commons.Singletons;

namespace Interactables
{
	public partial class KeyInteractable : Node3D
	{
        private InteractableArea area;
        [Export] public int myKeyId { get; private set; } = -1;
        public override void _Ready()
        {
            area = GetNode<InteractableArea>("InteractableArea");
            area.OnInteract += OnGetKey;
        }
        public void OnGetKey()
        {
            PlayerInvetorySingletoon.Instance.AddKey(myKeyId);
            GD.Print($"Got key of ID: {myKeyId}");
            DialogueManager.Instance.ShowPlayerText(area.TextOnInteract);
            area.PlaySoundPool3D();
            area.DisableSelf();
            Visible = false;
            //QueueFree();
        }

        public override void _ExitTree()
        {
            area.OnInteract -= OnGetKey;
        }
    }

}
