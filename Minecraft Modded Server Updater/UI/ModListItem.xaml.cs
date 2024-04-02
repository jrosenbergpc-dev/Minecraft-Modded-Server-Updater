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
	/// Interaction logic for ModListItem.xaml
	/// </summary>
	public partial class ModListItem : UserControl
	{
		private ModType m_ModType = ModType.None;
		private String m_ModName = String.Empty;

		public ModListItem()
		{
			InitializeComponent();
		}

		public ModType Type
		{
			get
			{
				return m_ModType;
			}
			set
			{
				m_ModType = value;

				if (m_ModType == ModType.Installed)
				{
					InstalledImage.Visibility = Visibility.Visible;
					NewModImage.Visibility = Visibility.Collapsed;
				}
				else if (m_ModType == ModType.NewMod)
				{
					InstalledImage.Visibility = Visibility.Collapsed;
					NewModImage.Visibility = Visibility.Visible;
				}
			}
		}

		public string ModName
		{
			get
			{
				return m_ModName;
			}
			set
			{
				m_ModName = value;

				if (m_ModName != null)
				{
					ModNameLabel.Content = m_ModName;
				}
			}
		}
	}
}
