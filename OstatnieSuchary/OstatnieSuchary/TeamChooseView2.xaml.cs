using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Protection.PlayReady;
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
    public sealed partial class TeamChooseView2 : Page
    {
        bool playerOneReady=false, playerTwoReady=false;

        public TeamChooseView2()
        {
            this.InitializeComponent();
	        this.DataContext = GameManager.Instance.TeamSelector;
        }

	    private Animal _draggedAnimal;

        private void choosenAnimalsGridView_OnDrop(object sender, DragEventArgs e)
        {
            // dodac animala do kolekcji
            var choosenAnimals = GameManager.Instance.ChooseTeamViewModel.ChoosenAnimals;
            if (choosenAnimals.Count < GameManager.Instance.animalsInTeam)
            {
                Animal animal = new Hippo("hipek");
                switch (_draggedAnimal.Type)
                {
                    case AnimalType.Lemur:
                        animal = new Lemur("lemurek");
                        break;
                    case AnimalType.Lion:
                        animal = new Lion("lewy");
                        break;
                    case AnimalType.Monkey:
                        animal = new Monkey("maupa");
                        break;
                    case AnimalType.Pinguins:
                        animal = new Pinguins("pppinguiny");
                        break;
                }
                choosenAnimals.Add(animal);
                if(choosenAnimals.Count== GameManager.Instance.animalsInTeam)
                {
                    playerOneReady = true;
                    if (playerTwoReady == true) { continueButton.IsEnabled = true; } 
                }
            }
        }

        private void choosenAnimalsGridView_OnDrop2(object sender, DragEventArgs e)
        {
            // dodac animala do kolekcji
            var choosenAnimals2 = GameManager.Instance.ChooseTeamViewModel.ChoosenAnimals2;
            if (choosenAnimals2.Count < GameManager.Instance.animalsInTeam)
            {
                Animal animal = new Hippo("hipek");
                switch (_draggedAnimal.Type)
                {
                    case AnimalType.Lemur:
                        animal = new Lemur("lemurek");
                        break;
                    case AnimalType.Lion:
                        animal = new Lion("lewy");
                        break;
                    case AnimalType.Monkey:
                        animal = new Monkey("maupa");
                        break;
                    case AnimalType.Pinguins:
                        animal = new Pinguins("pppinguiny");
                        break;
                }
                choosenAnimals2.Add(animal);
                if (choosenAnimals2.Count == GameManager.Instance.animalsInTeam)
                {
                    playerTwoReady = true;
                    if (playerOneReady == true) { continueButton.IsEnabled = true; }
                }
            }
        }


        private void ListViewBase_OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
	    {

            
	    }

		private void UIElement_OnDragStarting(object sender, DragStartingEventArgs args)
		{
			var animal = (sender as Image).DataContext as Animal;
			this._draggedAnimal = animal;
		}

        private void UIElement_OnDragStartingDelete(object sender, DragStartingEventArgs args)
        {
            playerOneReady = false;
            continueButton.IsEnabled = false;
            var animal = (sender as Image).DataContext as Animal;
            GameManager.Instance.ChooseTeamViewModel.ChoosenAnimals.Remove(animal);
        }

        private void UIElement_OnDragStartingDelete2(object sender, DragStartingEventArgs args)
        {
            playerTwoReady = false;
            continueButton.IsEnabled = false;
            var animal = (sender as Image).DataContext as Animal;
            GameManager.Instance.ChooseTeamViewModel.ChoosenAnimals2.Remove(animal);
        }

        private void choosenAnimalsGridView_Copy2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void choosenAnimalsGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
