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
	class FieldStateToBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var field = value as FieldItemViewModel;

			var color = Colors.LawnGreen;

			if (field != null && field.AnimalAtField != null)
			{
				if (field.AnimalAtField.IsActive)
				{
					color = Colors.Red;
				}
			}
			if (field.InSprintRange)
			{
				color = Colors.Yellow;
			}
			return new SolidColorBrush(color);
			//if(field.AnimalAtField == null)
			//	return new Solid
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
