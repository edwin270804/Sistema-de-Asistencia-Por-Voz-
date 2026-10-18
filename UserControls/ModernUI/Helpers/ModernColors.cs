using System.Drawing;

namespace ModernUI.Helpers;

public static class ModernColors
{
    public static Color Primary { get; } = Color.FromArgb(13, 110, 253);
    public static Color Secondary { get; } = Color.FromArgb(108, 117, 125);
    public static Color Success { get; } = Color.FromArgb(25, 135, 84);
    public static Color Warning { get; } = Color.FromArgb(255, 193, 7);
    public static Color Danger { get; } = Color.FromArgb(220, 53, 69);
    public static Color Info { get; } = Color.FromArgb(13, 202, 240);

    public static Color Light { get; } = Color.FromArgb(248, 249, 250);
    public static Color Dark { get; } = Color.FromArgb(33, 37, 41);

    public static Color TextLight { get; } = Color.FromArgb(248, 249, 250);
    public static Color TextDark { get; } = Color.FromArgb(33, 37, 41);

    public static Color BorderColor { get; } = Color.FromArgb(222, 226, 230);
}
