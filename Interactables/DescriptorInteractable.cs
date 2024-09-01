using Commons.Singletons;
using Godot;
using System;

namespace Interactables
{

	public partial class DescriptorInteractable : Node3D
	{
        private InteractableArea area;

        [Export] private string myText;
        public override void _Ready()
        {
            area = GetNode<InteractableArea>("InteractableArea");
            area.OnInteract += ShowText;
        }

        public void ShowText()
        {
            DialogueManager.Instance.ShowPlayerText(myText);
        }

        public override void _ExitTree()
        {
            area.OnInteract -= ShowText;

        }
    }
}
