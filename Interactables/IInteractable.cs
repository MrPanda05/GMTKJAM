using Godot;
using System;

namespace Interactables
{
    public interface IInteractable
    {
        public bool unique { get; set; }//true mean it will only run once
        Action OnInteract { get; set; }
        public string TextOnInteract { get; set; }
    }
}
