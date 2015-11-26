namespace PairTradingView.Controls
{
    partial class NumericBox
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.decrementButton = new System.Windows.Forms.Button();
            this.incrementButton = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // decrementButton
            // 
            this.decrementButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.decrementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decrementButton.ForeColor = System.Drawing.Color.Red;
            this.decrementButton.Location = new System.Drawing.Point(88, 0);
            this.decrementButton.Name = "decrementButton";
            this.decrementButton.Size = new System.Drawing.Size(29, 20);
            this.decrementButton.TabIndex = 5;
            this.decrementButton.Text = "-";
            this.decrementButton.UseVisualStyleBackColor = true;
            this.decrementButton.Click += new System.EventHandler(this.decrementButton_Click);
            // 
            // incrementButton
            // 
            this.incrementButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.incrementButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.incrementButton.ForeColor = System.Drawing.Color.Lime;
            this.incrementButton.Location = new System.Drawing.Point(119, 0);
            this.incrementButton.Name = "incrementButton";
            this.incrementButton.Size = new System.Drawing.Size(29, 20);
            this.incrementButton.TabIndex = 4;
            this.incrementButton.Text = "+";
            this.incrementButton.UseVisualStyleBackColor = true;
            this.incrementButton.Click += new System.EventHandler(this.incrementButton_Click);
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.ForeColor = System.Drawing.Color.White;
            this.textBox.Location = new System.Drawing.Point(0, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(82, 13);
            this.textBox.TabIndex = 3;
            // 
            // NumericBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.decrementButton);
            this.Controls.Add(this.incrementButton);
            this.Controls.Add(this.textBox);
            this.Name = "NumericBox";
            this.Size = new System.Drawing.Size(151, 22);
            this.MinimumSize = new System.Drawing.Size(151, 22);
            this.Load += new System.EventHandler(this.NumericBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button decrementButton;
        private System.Windows.Forms.Button incrementButton;
        private System.Windows.Forms.TextBox textBox;
    }
}
