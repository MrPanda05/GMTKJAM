using Godot;
using Interactables;
using System;

namespace StuffDoer
{
	public partial class EnableDoorKeyLevel1 : Node3D
	{
		[Export]
		private Node3D keyBlock, doorBlock;


		[Export] private InteractableArea keyArea, doorArea;

        [Export] private EatAllInteractable eatAll;

        public override void _Ready()
        {
            eatAll.DoSomething += DoStuff;
        }

        public void DoStuff()
        {
            keyBlock.ProcessMode = ProcessModeEnum.Disabled;
            doorBlock.ProcessMode = ProcessModeEnum.Disabled;
            keyArea.EnableSelf();
            doorArea.EnableSelf();
        }
    }
}
