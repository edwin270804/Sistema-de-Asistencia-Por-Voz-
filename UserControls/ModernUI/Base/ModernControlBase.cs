using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ModernUI.Helpers;

namespace ModernUI.Base;

public abstract class ModernControlBase : UserControl
{
    private int _borderRadius = 8;
    private Color _borderColor = ModernColors.BorderColor;
    private int _borderThickness = 1;
    private bool _enableShadow = false;
    private Color _shadowColor = Color.Black;
    private int _shadowDepth = 4;

    public ModernControlBase()
    {
        SetStyle(ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.SupportsTransparentBackColor |
                 ControlStyles.UserPaint, true);
        BackColor = Color.Transparent;
    }

    [Category("Modern UI")]
    [Description("Gets or sets the border radius of the control.")]
    [DefaultValue(8)]
    public int BorderRadius
    {
        get => _borderRadius;
        set { _borderRadius = value; Invalidate(); }
    }

    [Category("Modern UI")]
    [Description("Gets or sets the border color of the control.")]
    public Color BorderColor
    {
        get => _borderColor;
        set { _borderColor = value; Invalidate(); }
    }

    [Category("Modern UI")]
    [Description("Gets or sets the border thickness of the control.")]
    [DefaultValue(1)]
    public int BorderThickness
    {
        get => _borderThickness;
        set { _borderThickness = value; Invalidate(); }
    }

    [Category("Modern UI")]
    [Description("Gets or sets a value indicating whether to enable shadow.")]
    [DefaultValue(false)]
    public bool EnableShadow
    {
        get => _enableShadow;
        set { _enableShadow = value; Invalidate(); }
    }

    [Category("Modern UI")]
    [Description("Gets or sets the shadow color.")]
    public Color ShadowColor
    {
        get => _shadowColor;
        set { _shadowColor = value; Invalidate(); }
    }

    [Category("Modern UI")]
    [Description("Gets or sets the shadow depth.")]
    [DefaultValue(4)]
    public int ShadowDepth
    {
        get => _shadowDepth;
        set { _shadowDepth = value; Invalidate(); }
    }
}
