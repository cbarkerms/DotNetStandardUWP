namespace Northwind.NET.WinForms
{
    partial class NewOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewOrderForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.status = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.quantityPerUnit = new System.Windows.Forms.Label();
            this.pricePerUnit = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.units = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCustomers = new System.Windows.Forms.ComboBox();
            this.submit = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.units)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.08745F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.91255F));
            this.tableLayoutPanel.Controls.Add(this.status, 1, 8);
            this.tableLayoutPanel.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel.Controls.Add(this.total, 1, 5);
            this.tableLayoutPanel.Controls.Add(this.comboBoxProducts, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.quantityPerUnit, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.pricePerUnit, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.units, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.comboBoxCustomers, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.submit, 1, 6);
            this.tableLayoutPanel.Location = new System.Drawing.Point(105, 73);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 9;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28531F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28816F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(789, 534);
            this.tableLayoutPanel.TabIndex = 14;
            // 
            // status
            // 
            this.status.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.status.AutoSize = true;
            this.tableLayoutPanel.SetColumnSpan(this.status, 2);
            this.status.Location = new System.Drawing.Point(394, 511);
            this.status.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 20);
            this.status.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 63);
            this.label2.TabIndex = 3;
            this.label2.Text = "Product:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 315);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(221, 63);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // total
            // 
            this.total.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(500, 336);
            this.total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(18, 20);
            this.total.TabIndex = 11;
            this.total.Text = "0";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxProducts.DisplayMember = "ProductName";
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(285, 80);
            this.comboBoxProducts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(448, 28);
            this.comboBoxProducts.TabIndex = 1;
            this.comboBoxProducts.ValueMember = "ProductID";
            this.comboBoxProducts.SelectedIndexChanged += new System.EventHandler(this.comboBoxProducts_SelectedIndexChanged);
            // 
            // quantityPerUnit
            // 
            this.quantityPerUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quantityPerUnit.AutoSize = true;
            this.quantityPerUnit.Location = new System.Drawing.Point(509, 147);
            this.quantityPerUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.quantityPerUnit.Name = "quantityPerUnit";
            this.quantityPerUnit.Size = new System.Drawing.Size(0, 20);
            this.quantityPerUnit.TabIndex = 5;
            // 
            // pricePerUnit
            // 
            this.pricePerUnit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pricePerUnit.AutoSize = true;
            this.pricePerUnit.Location = new System.Drawing.Point(509, 273);
            this.pricePerUnit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pricePerUnit.Name = "pricePerUnit";
            this.pricePerUnit.Size = new System.Drawing.Size(0, 20);
            this.pricePerUnit.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 126);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 63);
            this.label3.TabIndex = 4;
            this.label3.Text = "Quantity/Unit:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 63);
            this.label5.TabIndex = 8;
            this.label5.Text = "Price/Unit:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // units
            // 
            this.units.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.units.Location = new System.Drawing.Point(419, 207);
            this.units.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.units.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.units.Name = "units";
            this.units.Size = new System.Drawing.Size(180, 26);
            this.units.TabIndex = 7;
            this.units.ValueChanged += new System.EventHandler(this.units_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 63);
            this.label4.TabIndex = 6;
            this.label4.Text = "Units:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 63);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxCustomers
            // 
            this.comboBoxCustomers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxCustomers.DisplayMember = "CompanyName";
            this.comboBoxCustomers.FormattingEnabled = true;
            this.comboBoxCustomers.Location = new System.Drawing.Point(285, 17);
            this.comboBoxCustomers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxCustomers.Name = "comboBoxCustomers";
            this.comboBoxCustomers.Size = new System.Drawing.Size(448, 28);
            this.comboBoxCustomers.TabIndex = 1;
            this.comboBoxCustomers.ValueMember = "CustomerID";
            this.comboBoxCustomers.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomers_SelectedIndexChanged);
            // 
            // submit
            // 
            this.submit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel.SetColumnSpan(this.submit, 2);
            this.submit.Location = new System.Drawing.Point(263, 447);
            this.submit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(262, 40);
            this.submit.TabIndex = 12;
            this.submit.Text = "Submit Order";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // NewOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 678);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "NewOrderForm";
            this.Text = "Northwind - New Order";
            this.Load += new System.EventHandler(this.NewOrderForm_Load);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.units)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label quantityPerUnit;
        private System.Windows.Forms.Label pricePerUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown units;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCustomers;
        private System.Windows.Forms.Button submit;
    }
}