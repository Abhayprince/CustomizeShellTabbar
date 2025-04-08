using Android.Graphics.Drawables;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using static Android.Views.ViewGroup;

namespace RoundedFloatingTabbar;
internal class RoundedFloatingTabbarHandler : ShellRenderer
{
    protected override IShellBottomNavViewAppearanceTracker CreateBottomNavViewAppearanceTracker(ShellItem shellItem)
    {
        //return base.CreateBottomNavViewAppearanceTracker(shellItem);
        return new RoundedFloatingBottomNavViewAppearanceTracker(this, shellItem);
    }
}
internal class RoundedFloatingBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
{
    public RoundedFloatingBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem)
        : base(shellContext, shellItem)
    {
    }

    public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
    {
        base.SetAppearance(bottomView, appearance);

        var tabbarDrawable = new GradientDrawable();

        // X and Y radius starting from Top Left, Top Right, Bottom Right, Bottom Left
        //tabbarDrawable.SetCornerRadii([50, 50, 50, 50, 0, 0, 0, 0]);

        // If we want to have the samve value radius  for all corners
        tabbarDrawable.SetCornerRadius(50);

        //tabbarDrawable.SetColor(Colors.Yellow.ToPlatform());
        tabbarDrawable.SetColor(appearance.EffectiveTabBarBackgroundColor.ToPlatform());

        bottomView.SetBackground(tabbarDrawable);


        ViewGroup.LayoutParams layoutParameters = bottomView.LayoutParameters;
        if(layoutParameters is MarginLayoutParams marginLayoutParams)
        {
            marginLayoutParams.SetMargins(50, 0, 50, 50);
            bottomView.LayoutParameters = marginLayoutParams;
        }


    }
}