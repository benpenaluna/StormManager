﻿using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace StormManager.UWP.Behaviors
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Behaviors/TimeoutAction.cs
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-XamlBehaviors
    [ContentProperty(Name = nameof(Actions))]
    public sealed class TimeoutAction : DependencyObject, IAction
    {
        public ActionCollection Actions
        {
            get
            {
                ActionCollection actions = (ActionCollection)base.GetValue(ActionsProperty);
                if (actions == null)
                {
                    actions = new ActionCollection();
                    SetValue(ActionsProperty, actions);
                }
                return actions;
            }
        }
        public static readonly DependencyProperty ActionsProperty =
            DependencyProperty.Register(nameof(Actions), typeof(ActionCollection),
                typeof(TimeoutAction), new PropertyMetadata(null));

        public int Milliseconds
        {
            get { return (int)GetValue(MillisecondsProperty); }
            set { SetValue(MillisecondsProperty, value); }
        }

        public static readonly DependencyProperty MillisecondsProperty =
            DependencyProperty.Register(nameof(Milliseconds), typeof(int),
                typeof(TimeoutAction), new PropertyMetadata(5000));

        public object Execute(object sender, object parameter)
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(Milliseconds) };
            timer.Tick += Timer_Tick;
            timer.Start();

            return null;
        }

        private void Timer_Tick(object sender, object e)
        {
            var timer = sender as DispatcherTimer;
            timer.Tick -= Timer_Tick;
            timer.Stop();

            Interaction.ExecuteActions(sender, Actions, null);
        }
    }
}
