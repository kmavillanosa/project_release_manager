using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ProjectReleaseManager.UI.CustomControls
{
    public static class EffectExtension
    {
        public static bool GetAnimate(DependencyObject obj)
        {
            return (bool)obj.GetValue(AnimateProperty);
        }
        public static void SetAnimate(DependencyObject obj, bool value)
        {
            obj.SetValue(AnimateProperty, value);
        }

        // Using a DependencyProperty as the backing store for Animate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimateProperty =
            DependencyProperty.RegisterAttached("Animate", typeof(bool), typeof(EffectExtension), new PropertyMetadata(false, AnimatePropertyHandler));

        public static Status GetBGColor(DependencyObject obj)
        {
            return (Status)obj.GetValue(BGColorProperty);
        }

        public static void SetBGColor(DependencyObject obj, Status value)
        {
            obj.SetValue(BGColorProperty, value);
        }

        // Using a DependencyProperty as the backing store for Animate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BGColorProperty =
            DependencyProperty.RegisterAttached("BGColor", typeof(Status), typeof(EffectExtension), new PropertyMetadata(Status.Primary, BGColorPropertyHandler));

        public static bool GetFadeUpDown(DependencyObject obj)
        {
            return (bool)obj.GetValue(FadeUpDownProperty);
        }
        public static void SetFadeUpDown(DependencyObject obj, bool value)
        {
            obj.SetValue(FadeUpDownProperty, value);
        }

        // Using a DependencyProperty as the backing store for Animate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FadeUpDownProperty =
            DependencyProperty.RegisterAttached("FadeUpDown", typeof(bool), typeof(EffectExtension), new PropertyMetadata(false, FadeUpDownPropertyHandler));


        public static bool GetSlide(DependencyObject obj)
        {
            return (bool)obj.GetValue(SlideProperty);
        }
        public static void SetSlide(DependencyObject obj, bool value)
        {
            obj.SetValue(SlideProperty, value);
        }

        // Using a DependencyProperty as the backing store for Animate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SlideProperty =
            DependencyProperty.RegisterAttached("Slide", typeof(bool), typeof(EffectExtension), new PropertyMetadata(true, SlidePropertyHandler));

        private static void SlidePropertyHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;

            if ((bool)e.NewValue)
            {
                SlideAnimation(element, -(element.ActualWidth), 0, TimeSpan.FromMilliseconds(350));
            }
            else
            {
                SlideAnimation(element, 0, -(element.ActualWidth), TimeSpan.FromMilliseconds(300));
            }
        }

        private static async void FadeUpDownPropertyHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement element = d as FrameworkElement;
            element.RenderTransform = new TranslateTransform();

            if ((bool)e.NewValue)
            {
                element.Visibility = Visibility.Visible;
                FadeUpDownAnimation(element, 40, 0, 0, 1, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(200));
            }
            else
            {
                FadeUpDownAnimation(element, 0, 30, 1, 0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(150));
                await Task.Delay(200);
                element.Visibility = Visibility.Collapsed;
            }
        }

        public static void SlideAnimation(FrameworkElement element, double from, double to, TimeSpan duration)
        {
            ThicknessAnimation animation = new ThicknessAnimation();
            animation.From = new Thickness(from, 0, 0, 0);
            animation.To = new Thickness(to, 0, 0, 0);
            animation.Duration = duration;
            animation.EasingFunction = new QuarticEase();

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);
            sb.Begin();
        }

        public static void FadeUpDownAnimation(FrameworkElement element, double fromTranslate, double toTranslate, double fromOpacity, double toOpacity, TimeSpan durationTranslate, TimeSpan durationOpacity)
        {
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = fromTranslate;
            animation.To = toTranslate;
            animation.Duration = durationTranslate;
            animation.EasingFunction = new CubicEase();

            Storyboard.SetTarget(animation, element);
            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));

            DoubleAnimation animation2 = new DoubleAnimation();
            animation2.From = fromOpacity;
            animation2.To = toOpacity;
            animation2.Duration = durationOpacity;

            Storyboard.SetTarget(animation2, element);
            Storyboard.SetTargetProperty(animation2, new PropertyPath("Opacity"));

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);
            sb.Children.Add(animation2);
            sb.Begin();
        }

        private static async void AnimatePropertyHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement obj = d as FrameworkElement;
            obj.RenderTransform = new ScaleTransform(0, 0);
            obj.RenderTransformOrigin = new Point(0.5, 0.5);

            if (obj.Visibility != Visibility.Visible)
                obj.Visibility = Visibility.Visible;

            if ((bool)e.NewValue)
                await ScaleAnimation(obj, TimeSpan.FromMilliseconds(0), .8, 1, 250);
            else
            {
                //await ScaleAnimation(obj, TimeSpan.FromMilliseconds(0), 1, .5, 150);
                obj.RenderTransform = new ScaleTransform(0, 0);
            }
        }

        private static void BGColorPropertyHandler(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Border obj = d as Border;
            Color backgroundColor = Colors.Transparent;

            switch ((Status)e.NewValue)
            {
                case Status.Primary:
                    backgroundColor = Color.FromRgb(25, 118, 210);
                    break;
                case Status.Secondary:
                    backgroundColor = Color.FromRgb(117, 117, 117);
                    break;
                case Status.Error:
                    backgroundColor = Color.FromRgb(244, 67, 54);
                    break;
                case Status.Success:
                    backgroundColor = Color.FromRgb(67, 160, 71);
                    break;
                default:
                    break;
            }

            ColorAnimation colorChangeAnimation = new ColorAnimation();
            colorChangeAnimation.From = BrushToColor(obj.Background);
            colorChangeAnimation.To = backgroundColor;
            colorChangeAnimation.Duration = TimeSpan.FromMilliseconds(250);

            PropertyPath colorTargetPath = new PropertyPath("(Panel.Background).(SolidColorBrush.Color)");
            Storyboard CellBackgroundChangeStory = new Storyboard();
            Storyboard.SetTarget(colorChangeAnimation, obj);
            Storyboard.SetTargetProperty(colorChangeAnimation, colorTargetPath);

            CellBackgroundChangeStory.Children.Add(colorChangeAnimation);
            CellBackgroundChangeStory.Begin();
        }

        public static async Task ScaleAnimation(FrameworkElement obj, TimeSpan beginTime, double from = 0, double to = 1, double duration = 180)
        {
            await Task.Delay(10);
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = TimeSpan.FromMilliseconds(duration);
            animation.EasingFunction = new CubicEase();

            Storyboard.SetTarget(animation, obj);
            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.ScaleY"));

            DoubleAnimation animation2 = new DoubleAnimation();
            animation2.From = from;
            animation2.To = to;
            animation2.Duration = TimeSpan.FromMilliseconds(duration);
            animation2.EasingFunction = new CubicEase();

            Storyboard.SetTarget(animation2, obj);
            Storyboard.SetTargetProperty(animation2, new PropertyPath("RenderTransform.ScaleX"));

            Storyboard sb = new Storyboard();
            sb.Children.Add(animation);
            sb.Children.Add(animation2);
            sb.Begin();
        }

        private static Color BrushToColor(Brush brush)
        {
            byte a = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).A;
            byte g = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).G;
            byte r = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).R;
            byte b = ((Color)brush.GetValue(SolidColorBrush.ColorProperty)).B;

            return Color.FromArgb(a, r, g, b);
        }
    }
}
