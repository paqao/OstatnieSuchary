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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OstatnieSuchary
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TeamChooseView2 : Page
    {
        public TeamChooseView2()
        {
            this.InitializeComponent();
	        this.DataContext = GameManager.Instance.TeamSelector;
        }

	    private Animal _draggedAnimal;

		private void choosenAnimalsGridView_OnDrop(object sender, DragEventArgs e)
		{
			// dodac animala do kolekcji
		}


	    private void ListViewBase_OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
	    {

	    }

		private void UIElement_OnDragStarting(object sender, DragStartingEventArgs args)
		{
			var animal = (sender as Image).DataContext as Animal;
			this._draggedAnimal = animal;
		}
	}
}
