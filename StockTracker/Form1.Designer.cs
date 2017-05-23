using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace StockTracker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this._listViewStocks = new ListView();
            this.Ticker = ((ColumnHeader)(new ColumnHeader()));
            this.Quote = ((ColumnHeader)(new ColumnHeader()));
            this.Shares = ((ColumnHeader)(new ColumnHeader()));
            this.Value = ((ColumnHeader)(new ColumnHeader()));
            this.label1 = new Label();
            this.label2 = new Label();
            this.buttonRefresh = new Button();
            this._textBoxTicker = new TextBox();
            this._buttonAddTicker = new Button();
            this._textBoxShares = new TextBox();
            this.label3 = new Label();
            this._buttonDelete = new Button();
            this._textBoxPurchaseDate = new TextBox();
            this.label4 = new Label();
            this._textBoxPurchasePrice = new TextBox();
            this.label5 = new Label();
            this._buttonClear = new Button();
            this.Gain = ((ColumnHeader)(new ColumnHeader()));
            this.SuspendLayout();
            // 
            // _listViewStocks
            // 
            this._listViewStocks.Columns.AddRange(new ColumnHeader[] {
            this.Ticker,
            this.Quote,
            this.Shares,
            this.Value,
            this.Gain});
            this._listViewStocks.Location = new Point(12, 203);
            this._listViewStocks.Name = "_listViewStocks";
            this._listViewStocks.Size = new Size(761, 288);
            this._listViewStocks.TabIndex = 0;
            this._listViewStocks.UseCompatibleStateImageBehavior = false;
            this._listViewStocks.View = View.Details;
            // 
            // Ticker
            // 
            this.Ticker.Text = "Ticker";
            this.Ticker.Width = 120;
            // 
            // Quote
            // 
            this.Quote.Text = "Quote";
            // 
            // Shares
            // 
            this.Shares.Text = "Shares";
            // 
            // Value
            // 
            this.Value.Text = "Current Value";
            this.Value.TextAlign = HorizontalAlignment.Right;
            this.Value.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 173);
            this.label1.Name = "label1";
            this.label1.Size = new Size(50, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Stocks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new Size(89, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter Ticker:";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new Point(798, 203);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new Size(75, 23);
            this.buttonRefresh.TabIndex = 4;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new EventHandler(this.RefreshValues);
            // 
            // _textBoxTicker
            // 
            this._textBoxTicker.Location = new Point(129, 22);
            this._textBoxTicker.Name = "_textBoxTicker";
            this._textBoxTicker.Size = new Size(100, 22);
            this._textBoxTicker.TabIndex = 0;
            // 
            // _buttonAddTicker
            // 
            this._buttonAddTicker.Location = new Point(264, 130);
            this._buttonAddTicker.Name = "_buttonAddTicker";
            this._buttonAddTicker.Size = new Size(75, 23);
            this._buttonAddTicker.TabIndex = 4;
            this._buttonAddTicker.Text = "Add";
            this._buttonAddTicker.UseVisualStyleBackColor = true;
            this._buttonAddTicker.Click += new EventHandler(this.AddTicker);
            // 
            // _textBoxShares
            // 
            this._textBoxShares.Location = new Point(129, 56);
            this._textBoxShares.Name = "_textBoxShares";
            this._textBoxShares.Size = new Size(100, 22);
            this._textBoxShares.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new Point(15, 56);
            this.label3.Name = "label3";
            this.label3.Size = new Size(95, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Enter Shares:";
            // 
            // _buttonDelete
            // 
            this._buttonDelete.Location = new Point(798, 262);
            this._buttonDelete.Name = "_buttonDelete";
            this._buttonDelete.Size = new Size(75, 23);
            this._buttonDelete.TabIndex = 5;
            this._buttonDelete.Text = "Delete";
            this._buttonDelete.UseVisualStyleBackColor = true;
            this._buttonDelete.Click += new EventHandler(this.DeleteStock);
            // 
            // _textBoxPurchaseDate
            // 
            this._textBoxPurchaseDate.Location = new Point(129, 93);
            this._textBoxPurchaseDate.Name = "_textBoxPurchaseDate";
            this._textBoxPurchaseDate.Size = new Size(100, 22);
            this._textBoxPurchaseDate.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new Point(15, 93);
            this.label4.Name = "label4";
            this.label4.Size = new Size(106, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Purchase Date:";
            // 
            // _textBoxPurchasePrice
            // 
            this._textBoxPurchasePrice.Location = new Point(129, 130);
            this._textBoxPurchasePrice.Name = "_textBoxPurchasePrice";
            this._textBoxPurchasePrice.Size = new Size(100, 22);
            this._textBoxPurchasePrice.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new Point(15, 130);
            this.label5.Name = "label5";
            this.label5.Size = new Size(108, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Purchase Price:";
            // 
            // _buttonClear
            // 
            this._buttonClear.Location = new Point(1040, 489);
            this._buttonClear.Name = "_buttonClear";
            this._buttonClear.Size = new Size(23, 23);
            this._buttonClear.TabIndex = 11;
            this._buttonClear.Text = "X";
            this._buttonClear.UseVisualStyleBackColor = true;
            this._buttonClear.Click += new EventHandler(this.ClearAllData);
            // 
            // Gain
            // 
            this.Gain.Text = "Gain";
            this.Gain.TextAlign = HorizontalAlignment.Right;
            this.Gain.Width = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1075, 524);
            this.Controls.Add(this._buttonClear);
            this.Controls.Add(this._textBoxPurchasePrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._textBoxPurchaseDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._buttonDelete);
            this.Controls.Add(this._textBoxShares);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._buttonAddTicker);
            this.Controls.Add(this._textBoxTicker);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._listViewStocks);
            this.Name = "Form1";
            this.Text = "Stock Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView _listViewStocks;
        private Label label1;
        private Label label2;
        private Button buttonRefresh;
        private TextBox _textBoxTicker;
        private ColumnHeader Ticker;
        private ColumnHeader Quote;
        private Button _buttonAddTicker;
        private ColumnHeader Shares;
        private ColumnHeader Value;
        private TextBox _textBoxShares;
        private Label label3;
        private Button _buttonDelete;
        private TextBox _textBoxPurchaseDate;
        private Label label4;
        private TextBox _textBoxPurchasePrice;
        private Label label5;
        private Button _buttonClear;
        private ColumnHeader Gain;
    }
}

