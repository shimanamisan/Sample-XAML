using System.Windows;
using System.Windows.Controls;

namespace Button_Sample
{
    public sealed class MainWindowViewModel : BindableBase
    {

        public DelegateCommand<Button> IsOpenContexMenuExecute { get; }

        public DelegateCommand MenuItemExecute { get; }

        public DelegateCommand MenuItemExecute2 { get; }

        public MainWindowViewModel()
        {
            IsOpenContexMenuExecute = new DelegateCommand<Button>(IsOpenContexMenu);

            MenuItemExecute = new DelegateCommand(MenuItemFirst);

            MenuItemExecute2 = new DelegateCommand(MenuItemSecond);
        }

        private void MenuItemSecond()
        {
            MessageBox.Show("メニュー２");

            /*
                if (Status.MainMachine != null)
                {
                Status.MainMachine.IsChecked = true;
                }

                if (Status.SubMachine != null)
                {
                Status.SubMachine.IsChecked = false;
                }
            */
        }

        private void MenuItemFirst()
        {
            MessageBox.Show("メニュー１");

            /*
                if (Status.MainMachine != null)
                {
                Status.MainMachine.IsChecked = true;
                }

                if (Status.SubMachine != null)
                {
                Status.SubMachine.IsChecked = false;
                }
            */
        }

        /// <summary>
        /// メインのボタンを押したときにContextMenuを開く方法
        /// </summary>
        /// <param name="obj"></param>
        private void IsOpenContexMenu(Button button)
        {
            if (button?.ContextMenu != null)
            {
                button.ContextMenu.PlacementTarget = button;
                button.ContextMenu.IsOpen = true;
            }
        }
    }
}
