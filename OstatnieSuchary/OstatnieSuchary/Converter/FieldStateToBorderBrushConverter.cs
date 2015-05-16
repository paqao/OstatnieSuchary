using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using OstatnieSuchary.ViewModel;

namespace OstatnieSuchary.Converter
{
	public class FieldStateToBorderBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var field = value as FieldItemViewModel;

			var color = Colors.White;

			if (field.ContainsBall)
			{
				color = Colors.OrangeRed;
			}

			if (field != null && field.AnimalAtField != null)
			{
				if (field.AnimalAtField.HasBall)
				{
					color = Colors.Blue;
				}
			}

			return new SolidColorBrush(color);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
