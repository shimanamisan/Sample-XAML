using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Sample_XAML
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var s = new StackPanel() { Margin = new Thickness(20) };
            //s.Children.Add(new Button() { Content = "xaml.csから作成。", Width = 90, HorizontalAlignment = HorizontalAlignment.Center });

            //grid1.Children.Add(s);

            //ShowMessage();
        }

        private void ToggleMenuVisibility(bool show)
        {

            if (show)
            {
                hamburgerButton.Visibility = Visibility.Collapsed;
                menuGrid.Visibility = Visibility.Visible;
            }
            else
            {
                hamburgerButton.Visibility = Visibility.Visible;
                menuGrid.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            // アニメーションの設定
            // DoubleAnimationは浮動小数点数値のアニメーションを生成する
            DoubleAnimation animation = new DoubleAnimation();
            // アニメーションの持続時間
            // Durationプロパティは、アニメーションの持続時間を取得または設定する
            // このプロパティは、継承元のTimelineで実装されている
            animation.Duration = TimeSpan.FromMilliseconds(250); // アニメーションの持続時間を300ミリ秒に設定

            if (menuGrid.Visibility == Visibility.Collapsed)
            {
                ToggleMenuVisibility(true);
                // FromおよびToプロパティは、アニメーションの開始値と終了値を指定する
                // メニューが表示されるときの位置を指定する
                animation.From = -250;
                animation.To = 0;
            }
            else
            {
                // メニューが非表示になるときの位置を指定する
                animation.From = 0;
                animation.To = -250;
                // アニメーションが終了したときに発生するイベント
                // メニューが非表示になるアニメーションが完了したときに、
                // menuGrid.Visibility = Visibility.Collapsed; を実行するために使用されている
                animation.Completed += (s, a) => { ToggleMenuVisibility(false); };
            }

            menuTranslateTransform.BeginAnimation(TranslateTransform.XProperty, animation);
        }

    }

}

/// <summary>
/// クラスを分離して機能拡張する
/// INFO: https://ufcpp.net/study/csharp/fun_WhyExtensions.html
/// </summary>
public partial class MainWindow
{
    public static void ShowMessage()
    {
        //MessageBox.Show("partialクラスでクラスを分割");
    }
}

