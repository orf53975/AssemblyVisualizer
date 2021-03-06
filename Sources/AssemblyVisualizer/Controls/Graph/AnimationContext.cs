﻿// Adopted, originally created as part of GraphSharp project
// This code is distributed under Microsoft Public License 
// (for details please see \docs\Ms-PL)

namespace AssemblyVisualizer.Controls.Graph
{
	public class AnimationContext : IAnimationContext
	{
		public AnimationContext(GraphCanvas canvas)
		{
			GraphCanvas = canvas;
		}

		public GraphCanvas GraphCanvas { get; private set; }
	}
}