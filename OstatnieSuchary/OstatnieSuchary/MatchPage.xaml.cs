using System;
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

using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using OstatnieSuchary.Converter;
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
		private Random _random;
		public MatchPage()
		{
			this.InitializeComponent();
			_viewModel = GameManager.Instance.Match;
			_viewModel.HomeTeamVM = new TeamViewModel();
			_viewModel.HomeTeamVM.TeamName = "Zespol domowy";
			_viewModel.HomeTeamVM.TeamList = GameManager.Instance.ChooseTeamViewModel.ChoosenAnimals.ToList();
			_viewModel.AwayTeamVM = new TeamViewModel();
			_viewModel.AwayTeamVM.TeamName = "Zespol drugi";
			_viewModel.AwayTeamVM.TeamList = GameManager.Instance.ChooseTeamViewModel.ChoosenAnimals2.ToList();

			DataContext = _viewModel;
			brushConverter = new FieldStateToBrushConverter();
			borderBrushConverter = new FieldStateToBorderBrushConverter();
			_random = new Random();
			Loaded += MatchPage_Loaded;
			Task.Run(() => Load());

		}

		private FieldStateToBrushConverter brushConverter;
		private FieldStateToBorderBrushConverter borderBrushConverter;

		private void MatchPage_Loaded(object sender, RoutedEventArgs e)
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
					
					Binding binding = new Binding();
					binding.Mode = BindingMode.TwoWay;
					binding.Path = new PropertyPath("Image");
					binding.Source = field;

					Image myImage = new Image();
					myImage.Width = 20;
					myImage.Height = 20;
					myImage.HorizontalAlignment = HorizontalAlignment.Center;
					myImage.VerticalAlignment = VerticalAlignment.Center;
					myImage.SetBinding(Image.SourceProperty, binding);

					button.Content = myImage;

					button.BorderThickness = new Thickness(1, 1, 1, 1);
					button.BorderBrush = new SolidColorBrush(Colors.AliceBlue);

					Binding binding2 = new Binding();
					binding2.Mode = BindingMode.TwoWay;
					binding2.Source = field;
					binding2.Path = new PropertyPath("Instance");
					binding2.Converter = brushConverter;

					button.SetBinding(BackgroundProperty,binding2);

					binding2 = new Binding();
					binding2.Mode = BindingMode.TwoWay;
					binding2.Source = field;
					binding2.Path = new PropertyPath("Instance");
					binding2.Converter = borderBrushConverter;

					button.SetBinding(BorderBrushProperty, binding2);

					button.Command = field.FieldCommand;

					Board.Children.Add(button);
					Grid.SetColumn(button, field.PositionX + 2);
					Grid.SetRow(button, field.PositionY + 1);

				}

				foreach (var player in _viewModel.HomeTeamVM.TeamList)
				{
					player.PositionY = _random.Next(0, 20);
					player.PositionX = _random.Next(0, 15);

					_viewModel.FieldItemViewModels[(int)(player.PositionY*30 + player.PositionX)].AnimalAtField = player;
				}

				foreach (var player in _viewModel.AwayTeamVM.TeamList)
				{
					player.PositionY = _random.Next(0, 20);
					player.PositionX = _random.Next(16, 30);

					_viewModel.FieldItemViewModels[(int)(player.PositionY * 30 + player.PositionX)].AnimalAtField = player;
				}
				_viewModel.Initialize();
			});
			await Dispatcher.RunAsync(CoreDispatcherPriority.Low, () =>
			{
				_viewModel.Busy = false;
			});
		}
	}
}
