using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minecraft_Modded_Server_Updater.UI
{
	/// <summary>
	/// Interaction logic for NavButton.xaml
	/// </summary>
	public partial class NavButton : UserControl
	{
		public NavButton()
		{
			InitializeComponent();
		}

		public event EventHandler OnNavClicked;

		public String Text
		{
			get
			{
				return NavText.Content.ToString();
			}
			set
			{
				NavText.Content = value;
			}
		}

		private void Label_MouseEnter(object sender, MouseEventArgs e)
		{
            this.Background = new SolidColorBrush(Color.FromArgb(51, 255, 255, 255));
        }

		private void Label_MouseLeave(object sender, MouseEventArgs e)
		{
            this.Background = new SolidColorBrush(Color.FromArgb(51, 0, 0, 0));
        }

		private void Label_MouseDown(object sender, MouseButtonEventArgs e)
		{
            this.Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0));
        }

		private void Label_MouseUp(object sender, MouseButtonEventArgs e)
		{
            this.Background = new SolidColorBrush(Color.FromArgb(51, 255, 255, 255));

            OnNavClicked?.Invoke(this, e);
        }
	}
}
