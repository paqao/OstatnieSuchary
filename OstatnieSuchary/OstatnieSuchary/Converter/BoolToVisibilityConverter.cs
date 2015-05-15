using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace OstatnieSuchary.Converter
{
	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			Visibility visibility = Visibility.Collapsed;

			bool result = (bool) value;

			if (parameter != null && parameter.ToString() == "Negation")
			{
				result = !result;
			}

			visibility = result ? Visibility.Visible : Visibility.Collapsed;

			return visibility;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return true;
		}
	}
}
