using CoreAnimation;
using CoreGraphics;
using GameController;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;

namespace RoundedFloatingTabbar;

internal class RoundedFloatingTabbarHandler : ShellRenderer
{
    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        //return base.CreateTabBarAppearanceTracker();
        return new RoundedFloatingShellTabBarAppearanceTracker();
    }
}

internal class RoundedFloatingShellTabBarAppearanceTracker : ShellTabBarAppearanceTracker
{
    public override void UpdateLayout(UITabBarController controller)
    {
        base.UpdateLayout(controller);

        AddMarginsToTheTabbar(controller);


        var shapeLayer = new CAShapeLayer();
        shapeLayer.Frame = controller.TabBar.Bounds;

        // Rounded Top Left and Top Right corners of the Bottom Tabbar
        shapeLayer.Path = UIBezierPath.FromRoundedRect(
                                controller.TabBar.Bounds, 
                                UIRectCorner.TopLeft | UIRectCorner.TopRight, 
                                new CoreGraphics.CGSize(50, 50)).CGPath;

        // Same Radius for all corners 
        shapeLayer.Path = UIBezierPath.FromRoundedRect(
                                controller.TabBar.Bounds,
                                UIRectCorner.AllCorners,
                                new CoreGraphics.CGSize(50, 50)).CGPath;

        controller.TabBar.Layer.Mask = shapeLayer;        
    }

    private void AddMarginsToTheTabbar(UITabBarController controller)
    {
        /*
            ------------
             ----------
        */
        var existingFrame = controller.TabBar.Frame;
        double margin = 50;
        var newX = existingFrame.X + margin;
        var newWidth = existingFrame.Width - margin - margin;
        var newY = existingFrame.Y - 40;
        var newHeight = existingFrame.Height;

        var newRectFrame = new CGRect(newX, newY, newWidth, newHeight);
        controller.TabBar.Frame = newRectFrame;
    }
}