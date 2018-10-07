namespace TradingClientApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.listBox = new System.Windows.Forms.ListBox();
			this.button4 = new System.Windows.Forms.Button();
			this.txtSymbol = new System.Windows.Forms.TextBox();
			this.txtExchange = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dgMarketPrice = new System.Windows.Forms.DataGridView();
			this.securityIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.exchangeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.symbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.offerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.bidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tradedPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.openPxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.highPxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lowPxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.closePxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.marketPriceBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.button5 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgMarketPrice)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.marketPriceBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(61, 43);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "&Start";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(154, 45);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(256, 384);
			this.richTextBox1.TabIndex = 1;
			this.richTextBox1.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(61, 93);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "S&top";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(65, 135);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(71, 67);
			this.button3.TabIndex = 3;
			this.button3.Text = "Send Request Definition";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// listBox
			// 
			this.listBox.FormattingEnabled = true;
			this.listBox.Location = new System.Drawing.Point(425, 45);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(249, 381);
			this.listBox.TabIndex = 4;
			this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
			this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(685, 43);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 5;
			this.button4.Text = "Subscribe";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// txtSymbol
			// 
			this.txtSymbol.Location = new System.Drawing.Point(767, 43);
			this.txtSymbol.Name = "txtSymbol";
			this.txtSymbol.Size = new System.Drawing.Size(139, 20);
			this.txtSymbol.TabIndex = 6;
			// 
			// txtExchange
			// 
			this.txtExchange.Location = new System.Drawing.Point(912, 43);
			this.txtExchange.Name = "txtExchange";
			this.txtExchange.Size = new System.Drawing.Size(139, 20);
			this.txtExchange.TabIndex = 7;
			this.txtExchange.Text = "ICDX";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(818, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Symbol";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(962, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Exchange";
			// 
			// dgMarketPrice
			// 
			this.dgMarketPrice.AllowUserToAddRows = false;
			this.dgMarketPrice.AllowUserToDeleteRows = false;
			this.dgMarketPrice.AutoGenerateColumns = false;
			this.dgMarketPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgMarketPrice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.securityIdDataGridViewTextBoxColumn,
            this.exchangeDataGridViewTextBoxColumn,
            this.symbolDataGridViewTextBoxColumn,
            this.offerDataGridViewTextBoxColumn,
            this.bidDataGridViewTextBoxColumn,
            this.tradedPriceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.openPxDataGridViewTextBoxColumn,
            this.highPxDataGridViewTextBoxColumn,
            this.lowPxDataGridViewTextBoxColumn,
            this.closePxDataGridViewTextBoxColumn});
			this.dgMarketPrice.DataSource = this.marketPriceBindingSource;
			this.dgMarketPrice.Location = new System.Drawing.Point(696, 108);
			this.dgMarketPrice.Name = "dgMarketPrice";
			this.dgMarketPrice.ReadOnly = true;
			this.dgMarketPrice.Size = new System.Drawing.Size(484, 318);
			this.dgMarketPrice.TabIndex = 10;
			// 
			// securityIdDataGridViewTextBoxColumn
			// 
			this.securityIdDataGridViewTextBoxColumn.DataPropertyName = "SecurityId";
			this.securityIdDataGridViewTextBoxColumn.HeaderText = "SecurityId";
			this.securityIdDataGridViewTextBoxColumn.Name = "securityIdDataGridViewTextBoxColumn";
			this.securityIdDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// exchangeDataGridViewTextBoxColumn
			// 
			this.exchangeDataGridViewTextBoxColumn.DataPropertyName = "Exchange";
			this.exchangeDataGridViewTextBoxColumn.HeaderText = "Exchange";
			this.exchangeDataGridViewTextBoxColumn.Name = "exchangeDataGridViewTextBoxColumn";
			this.exchangeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// symbolDataGridViewTextBoxColumn
			// 
			this.symbolDataGridViewTextBoxColumn.DataPropertyName = "Symbol";
			this.symbolDataGridViewTextBoxColumn.HeaderText = "Symbol";
			this.symbolDataGridViewTextBoxColumn.Name = "symbolDataGridViewTextBoxColumn";
			this.symbolDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// offerDataGridViewTextBoxColumn
			// 
			this.offerDataGridViewTextBoxColumn.DataPropertyName = "Offer";
			this.offerDataGridViewTextBoxColumn.HeaderText = "Offer";
			this.offerDataGridViewTextBoxColumn.Name = "offerDataGridViewTextBoxColumn";
			this.offerDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// bidDataGridViewTextBoxColumn
			// 
			this.bidDataGridViewTextBoxColumn.DataPropertyName = "Bid";
			this.bidDataGridViewTextBoxColumn.HeaderText = "Bid";
			this.bidDataGridViewTextBoxColumn.Name = "bidDataGridViewTextBoxColumn";
			this.bidDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// tradedPriceDataGridViewTextBoxColumn
			// 
			this.tradedPriceDataGridViewTextBoxColumn.DataPropertyName = "TradedPrice";
			this.tradedPriceDataGridViewTextBoxColumn.HeaderText = "TradedPrice";
			this.tradedPriceDataGridViewTextBoxColumn.Name = "tradedPriceDataGridViewTextBoxColumn";
			this.tradedPriceDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// volumeDataGridViewTextBoxColumn
			// 
			this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
			this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
			this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
			this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// openPxDataGridViewTextBoxColumn
			// 
			this.openPxDataGridViewTextBoxColumn.DataPropertyName = "OpenPx";
			this.openPxDataGridViewTextBoxColumn.HeaderText = "OpenPx";
			this.openPxDataGridViewTextBoxColumn.Name = "openPxDataGridViewTextBoxColumn";
			this.openPxDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// highPxDataGridViewTextBoxColumn
			// 
			this.highPxDataGridViewTextBoxColumn.DataPropertyName = "HighPx";
			this.highPxDataGridViewTextBoxColumn.HeaderText = "HighPx";
			this.highPxDataGridViewTextBoxColumn.Name = "highPxDataGridViewTextBoxColumn";
			this.highPxDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// lowPxDataGridViewTextBoxColumn
			// 
			this.lowPxDataGridViewTextBoxColumn.DataPropertyName = "LowPx";
			this.lowPxDataGridViewTextBoxColumn.HeaderText = "LowPx";
			this.lowPxDataGridViewTextBoxColumn.Name = "lowPxDataGridViewTextBoxColumn";
			this.lowPxDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// closePxDataGridViewTextBoxColumn
			// 
			this.closePxDataGridViewTextBoxColumn.DataPropertyName = "ClosePx";
			this.closePxDataGridViewTextBoxColumn.HeaderText = "ClosePx";
			this.closePxDataGridViewTextBoxColumn.Name = "closePxDataGridViewTextBoxColumn";
			this.closePxDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// marketPriceBindingSource
			// 
			this.marketPriceBindingSource.DataSource = typeof(TradingClientApp.Model.MarketPrice);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(61, 217);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(71, 67);
			this.button5.TabIndex = 11;
			this.button5.Text = "Send TradeCapture Request";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1192, 518);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.dgMarketPrice);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtExchange);
			this.Controls.Add(this.txtSymbol);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.listBox);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dgMarketPrice)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.marketPriceBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox txtSymbol;
		private System.Windows.Forms.TextBox txtExchange;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgMarketPrice;
		private System.Windows.Forms.DataGridViewTextBoxColumn securityIdDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn exchangeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn symbolDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn offerDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn bidDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn tradedPriceDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn openPxDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn highPxDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lowPxDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn closePxDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource marketPriceBindingSource;
		private System.Windows.Forms.Button button5;
	}
}

