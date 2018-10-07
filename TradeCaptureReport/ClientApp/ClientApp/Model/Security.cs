using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TradingClientApp.Model
{
	public class Security
	{
		public string Symbol { get; set; }
		public int SecurityId { get; set; }
		public string Exchange { get; set; }
		public string MaturityMonthYear { get; set; }
		public string MaturityDay { get; set; }
		public decimal ContractMultiplier { get; set; }
		public string Currency { get; set; }
	}

	public class MarketPrice : INotifyPropertyChanged
	{
	
		public int SecurityId { get; set; }
		public string Exchange { get; set; }
		public string MaturityMonthYear { get; set; }
		public string MaturityDay { get; set; }
		public decimal ContractMultiplier { get; set; }
		public string Currency { get; set; }

		private string _symbol;
		public string Symbol {
			get
			{
				return this._symbol;
			}
			set
			{
				if (value != this._symbol)
				{
					this._symbol = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _offer;
		public decimal Offer
		{
			get
			{
				return this._offer;
			}
			set
			{
				if (value != this._offer)
				{
					this._offer = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _bid;
		public decimal Bid
		{
			get
			{
				return this._bid;
			}
			set
			{
				if (value != this._offer)
				{
					this._bid = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _ltp;
		public decimal TradedPrice
		{
			get
			{
				return this._ltp;
			}
			set
			{
				if (value != this._ltp)
				{
					this._ltp = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _volume;
		public decimal Volume
		{
			get
			{
				return this._volume;
			}
			set
			{
				if (value != this._volume)
				{
					this._volume = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _openpx;
		public decimal OpenPx
		{
			get
			{
				return this._openpx;
			}
			set
			{
				if (value != this._openpx)
				{
					this._openpx = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _highpx;
		public decimal HighPx
		{
			get
			{
				return this._highpx;
			}
			set
			{
				if (value != this._highpx)
				{
					this._highpx = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _lowPx;
		public decimal LowPx
		{
			get
			{
				return this._lowPx;
			}
			set
			{
				if (value != this._lowPx)
				{
					this._lowPx = value;
					NotifyPropertyChanged();
				}
			}
		}

		private decimal _closePx;
		public decimal ClosePx
		{
			get
			{
				return this._closePx;
			}
			set
			{
				if (value != this._closePx)
				{
					this._closePx = value;
					NotifyPropertyChanged();
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		// This method is called by the Set accessor of each property.  
		// The CallerMemberName attribute that is applied to the optional propertyName  
		// parameter causes the property name of the caller to be substituted as an argument.  
		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
