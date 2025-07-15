using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedShadowPanel : Panel
{
    public int CornerRadius { get; set; } = 16;
    public int ShadowSize { get; set; } = 15;
    public Color ShadowColor { get; set; } = Color.FromArgb(80, 0, 0, 0);
    public Color FillColor { get; set; } = Color.White;

    private Padding _innerPadding = new Padding(20);
    public Padding InnerPadding
    {
        get => _innerPadding;
        set
        {
            _innerPadding = value;
            UpdateEffectivePadding();
        }
    }

    public RoundedShadowPanel()
    {
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                      ControlStyles.UserPaint |
                      ControlStyles.ResizeRedraw |
                      ControlStyles.OptimizedDoubleBuffer |
                      ControlStyles.SupportsTransparentBackColor, true);

        this.BackColor = Color.Transparent;
        this.AutoSize = true;
        this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        this.Dock = DockStyle.Top;

        UpdateEffectivePadding();
    }

    private void UpdateEffectivePadding()
    {
        this.Padding = new Padding(
            ShadowSize + _innerPadding.Left,
            ShadowSize + _innerPadding.Top,
            ShadowSize + _innerPadding.Right,
            ShadowSize + _innerPadding.Bottom
        );

        Invalidate();
        PerformLayout();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        Rectangle shadowRect = new Rectangle(
            ShadowSize / 2,
            ShadowSize / 2,
            this.Width - ShadowSize,
            this.Height - ShadowSize
        );

        using (GraphicsPath path = GetRoundedRect(shadowRect, CornerRadius))
        using (PathGradientBrush brush = new PathGradientBrush(path))
        {
            brush.CenterColor = ShadowColor;
            brush.SurroundColors = new[] { Color.FromArgb(0, ShadowColor) };
            g.FillPath(brush, path);
        }

        Rectangle panelRect = new Rectangle(
            0,
            0,
            this.Width - ShadowSize,
            this.Height - ShadowSize
        );

        using (GraphicsPath panelPath = GetRoundedRect(panelRect, CornerRadius))
        using (SolidBrush fillBrush = new SolidBrush(FillColor))
        {
            g.FillPath(fillBrush, panelPath);
        }
    }

    private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int d = radius * 2;
        path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
        path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
        path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
        path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }
}
