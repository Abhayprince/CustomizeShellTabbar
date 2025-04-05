using CoreAnimation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;

namespace GradientTabbar;
internal class GradientTabbarShellHandler : ShellRenderer
{
    protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
    {
        //return base.CreateTabBarAppearanceTracker();
        return new GradientShellTabBarAppearanceTracker();
    }
}

internal class GradientShellTabBarAppearanceTracker : ShellTabBarAppearanceTracker
{
    public override void UpdateLayout(UITabBarController controller)
    {
        base.UpdateLayout(controller);

        var gradientLayer = new CAGradientLayer
        {
            Frame = controller.TabBar.Frame,
            Colors = [Colors.Red.ToCGColor(), Colors.Orange.ToCGColor()],
            StartPoint = new CoreGraphics.CGPoint(0, 0),
            EndPoint = new CoreGraphics.CGPoint(1, 0)
        };
        
        controller.TabBar.Layer.InsertSublayer(gradientLayer, 0);
    }
}