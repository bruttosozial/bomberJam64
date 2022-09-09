using Godot;
using System;

public class player : KinematicBody
{
	private readonly int speed = 30;

	private Vector3 movement;

	private PackedScene bomb;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		movement = new Vector3();
		
		bomb = ResourceLoader.Load<PackedScene>("res://Scenes/Bomb.tscn");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	  HandleInput();
  }


  public override void _PhysicsProcess(float delta)
  {
	  MoveAndSlide(movement);
  }

  private void HandleInput()
  {
	  movement = new Vector3();
	  
	  if (Input.IsActionPressed("move_up"))
	  {
		  movement.z -= 1 * speed;
	  }
	  else if (Input.IsActionPressed("move_down"))
	  {
		  movement.z += 1 * speed;
	  }
	  else if (Input.IsActionPressed("move_left"))
	  {
		  movement.x -= 1 * speed;
	  }
	  else if (Input.IsActionPressed("move_right"))
	  {
		  movement.x += 1 * speed;
	  }

	  if (Input.IsActionJustPressed("action"))
	  {
		  GD.Print("Action!");

		  var bombInstance = bomb.Instance();

		  bombInstance.GetNode<Spatial>(".").Translation = this.Translation;
		  
		  GetTree().CurrentScene.AddChild(bombInstance);
	  }
  }
}
