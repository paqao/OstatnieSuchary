﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using OstatnieSuchary.Model;
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

			Loaded += MatchPage_Loaded;
			Task.Run(() => Load());
		}

		private async void MatchPage_Loaded(object sender, RoutedEventArgs e)
		{
			_viewModel.Busy = true;
		}

		private async void Load()
		{
			await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
			{
				foreach (var field in _viewModel.FieldItemViewModels)
				{
					Button button = new Button();
					button.VerticalAlignment = VerticalAlignment.Stretch;
					button.HorizontalAlignment = HorizontalAlignment.Stretch;

					button.Content = field.ToString();

					button.BorderThickness = new Thickness(1, 1, 1, 1);
					button.BorderBrush = new SolidColorBrush(Colors.AliceBlue);
					button.Background = new SolidColorBrush(Colors.LawnGreen);

					Board.Children.Add(button);
					Grid.SetColumn(button, field.PositionX + 2);
					Grid.SetRow(button, field.PositionY + 1);

				}
				
			});
			await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
			{
				_viewModel.Busy = false;
			});
		}


		/*private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
		{
			_viewModel.ActiveAnimal = new TemplateAnimal("ble", AnimalType.Hippo);
			_viewModel.ActiveAnimal.KickCommand = new RelayCommand(async x =>
			{
				MessageDialog dialog = new MessageDialog("Pass2");
				await dialog.ShowAsync();
			});
		}*/
	}
}