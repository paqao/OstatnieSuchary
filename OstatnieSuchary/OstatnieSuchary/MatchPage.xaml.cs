using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OstatnieSuchary.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OstatnieSuchary
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MatchPage : Page
	{
		private MatchViewModel _viewModel;
		public MatchPage()
		{
			this.InitializeComponent();
			_viewModel = GameManager.Instance.Match;
			DataContext = _viewModel;
		}

		private void ButtonBase2_OnClick(object sender, RoutedEventArgs e)
		{
			_viewModel.AwayResult++;
		}

		private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			_viewModel.HomeResult++;
		}
	}
}
