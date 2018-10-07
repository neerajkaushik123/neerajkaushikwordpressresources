using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TradingClientApp.Model;

namespace TradingClientApp
{
	public partial class Form1 : Form
	{
		FixClient44 _ctsFixClient;
		BindingList<MarketPrice> customerList = new BindingList<MarketPrice>();
		// This BindingSource binds the list to the DataGridView control.  
		private BindingSource marketPriceBndingPrice = new BindingSource();

		public Form1()
		{
			InitializeComponent();
			// Bind the list to the BindingSource.  
			this.marketPriceBndingPrice.DataSource = customerList;
			dgMarketPrice.AutoGenerateColumns = false;
			// Attach the BindingSource to the DataGridView.  
			this.dgMarketPrice.DataSource = this.marketPriceBndingPrice;
		}

		private async void button1_Click(object sender, EventArgs e)
		{
			if (_ctsFixClient == null)
			{
				_ctsFixClient = new FixClient44();
				_ctsFixClient.OnProgress += ShowProgress;
				_ctsFixClient.OnSecurity += _ctsFixClient_OnSecurity;
				_ctsFixClient.OnMarketPrice += _ctsFixClient_OnMarketPrice;
			}

			await _ctsFixClient.Initialize(ShowProgress, CancellationToken.None);

			_ctsFixClient.Connect();

		}

		private void _ctsFixClient_OnMarketPrice(MarketPrice msg)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<Model.MarketPrice>(_ctsFixClient_OnMarketPrice), msg);
				return;
			}
			var marketprice = customerList.FirstOrDefault(a => a.Symbol != null && a.Symbol == msg.Symbol);

			if (marketprice == null)
			{
				customerList.Add(msg);
			}
			else
			{
				marketprice.Offer = msg.Offer;
				marketprice.Bid = msg.Bid;
				marketprice.ClosePx = msg.ClosePx;
				marketprice.HighPx = msg.HighPx;
				marketprice.LowPx = msg.LowPx;
				marketprice.TradedPrice = msg.TradedPrice;
			}
		}

		private void _ctsFixClient_OnSecurity(Model.Security msg)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<Model.Security>(_ctsFixClient_OnSecurity), msg);
				return;
			}
			listBox.Items.Add(msg.Symbol);
		}

		private void ShowProgress(string msg)
		{
			if (InvokeRequired)
			{
				Invoke(new Action<string>(ShowProgress), msg);
				return;
			}
			richTextBox1.Text += $"\r\n{msg}";

		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (_ctsFixClient != null)
			{
				_ctsFixClient.Disconnect();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			_ctsFixClient.SendSecurityDefinitionRequest(ShowProgress);
			//	_ctsFixClient.SendMarketDataRequest(txtSymbol.Text, txtExchange.Text, ShowProgress);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			_ctsFixClient.SendMarketDataRequest(txtSymbol.Text, txtExchange.Text, ShowProgress);
		}

		private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			
		}

		private void listBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtSymbol.Text = listBox.SelectedItem.ToString();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			_ctsFixClient.SendTradeCaptureRequest(DateTime.Now.AddDays(-1), DateTime.Now, ShowProgress);
		}
	}
}
