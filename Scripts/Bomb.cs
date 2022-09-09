using Godot;
using System;

public class Bomb : Spatial
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Stuff();
	}

	private async void Stuff()
	{
		await ToSignal(GetTree().CreateTimer(5.0f, false), "timeout");
		
		GD.Print("Boom!");
		
		QueueFree();
	}
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
