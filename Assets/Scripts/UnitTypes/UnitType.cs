using UnityEngine;

public abstract class UnitType
{
    public readonly Sprite SpriteUnit1;
    public readonly Sprite SpriteUnit2;
    public readonly Sprite SpriteUnit3;

    protected UnitType(string Unit1SpritePath, string Unit2SpritePath, string Unit3SpritePath)
    {
        SpriteUnit1 = Resources.Load<Sprite>(Unit1SpritePath);
        SpriteUnit2 = Resources.Load<Sprite>(Unit2SpritePath);
        SpriteUnit3 = Resources.Load<Sprite>(Unit3SpritePath);
    }
}

