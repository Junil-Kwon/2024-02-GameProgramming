using System;



// ====================================================================================================
// Action
// ====================================================================================================

[Serializable] public enum KeyAction {
	MoveUp,
	MoveLeft,
	MoveDown,
	MoveRight,
	Move,
	Interact,
	Cancel,
	Point,
	LeftClick,
	MiddleClick,
	RightClick,
	Scroll,
	Control,
}



// ====================================================================================================
// Animation Type
// ====================================================================================================

[Serializable] public enum AnimationType {
	Idle,
	Moving,
	Attacking,
	Dead,
}



// ====================================================================================================
// Creature Type
// ====================================================================================================

[Serializable] public enum CreatureType {
	None,
	Player,
}



// ====================================================================================================
// Particle Type
// ====================================================================================================

[Serializable] public enum ParticleType {
	None,
}
