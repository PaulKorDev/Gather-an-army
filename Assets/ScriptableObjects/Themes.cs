using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Theme", menuName = "ScriptableObjects/Theme", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    [Header("Application colors")]
    public Color TextColor;
    public Color BackgroundColor;
    public Sprite ButtonBackground;

    [Header("Unit stats colors")]
    public Color PowerColor;
    public Color SpecialCostColor;
    public Color CostColor;

    [Header("Icons")]
    public Sprite GitHubIcon;
    public Sprite LinkedInIcon;
    public Sprite TelegramIcon;

}
