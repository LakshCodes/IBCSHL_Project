using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace game_splash_screen
{
    public partial class Form3 : Form
    {
        public const string FEATURE_NAME = "Test screen for C# game";
        internal bool Dismissed;
        internal Rect SplashImageRect;

        public List<Scenario> scenarios = new List<Scenario>
        {
            new Scenario() { Title = "Loading game assets", ClassType = typeof(game_splash_screen.Scenario1) },
            new Scenario() { Title = "Loading game", ClassType= typeof(game_splash_screen.Scenario2) },
        };

        public void SetExtendedSplashInfo(Rect splashRect, bool dismissStat)
        {
            SplashImageRect = splashRect;
            Dismissed = dismissStat;
        }
    }
}

public class Scenario
{
    public string Title { get; set; }

    public Type ClassType { get; set; }

    public override string ToString()
    {
        return Title;
    }
}

public class MainPageSizeChangedEventArgs : EventArgs
{
    private double width;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }
}


