using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary
{
	public class GameManager
	{
		private GameManager()
		{
			
		}

		private static GameManager _instance;
		public static GameManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new GameManager();
				return _instance;
			}
		}
	}
}
