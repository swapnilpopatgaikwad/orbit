﻿using BuildingGames.GameObjects;

namespace BuildingGames.Slides;

public class TheFinalBossScene : SlideSceneBase
{
	public TheFinalBossScene(Pointer pointer, Achievement achievement) : base(pointer, achievement)
	{
	}

    public override void Render(ICanvas canvas, RectF dimensions)
    {
        Styling.RenderTitle("The final boss", canvas, dimensions);

        canvas.DrawString(
            dimensions,
            @"
- A better name? MAGE - Multi-platform App Game Engine

- Physics - Collisions / Gravity

- Diagnostics

- Testing support

- Feedback Driven Development",
            Styling.TitleColor,
            Colors.Transparent,
            1,
            Styling.CodeFont,
            (float)Styling.ScaledFontSize(0.05),
            new PointF(40, dimensions.Height * 0.2f),
            HorizontalAlignment.Left,
            VerticalAlignment.Top);

        base.Render(canvas, dimensions);
    }
}
