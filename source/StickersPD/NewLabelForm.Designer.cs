﻿namespace StickersPD
{
    partial class NewLabelForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.NameTbx = new System.Windows.Forms.TextBox();
            this.PaletteBtn = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ColorTbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // NameTbx
            // 
            this.NameTbx.Location = new System.Drawing.Point(76, 63);
            this.NameTbx.Name = "NameTbx";
            this.NameTbx.Size = new System.Drawing.Size(100, 20);
            this.NameTbx.TabIndex = 1;
            // 
            // PaletteBtn
            // 
            this.PaletteBtn.Location = new System.Drawing.Point(199, 19);
            this.PaletteBtn.Name = "PaletteBtn";
            this.PaletteBtn.Size = new System.Drawing.Size(75, 23);
            this.PaletteBtn.TabIndex = 3;
            this.PaletteBtn.Text = "Palette";
            this.PaletteBtn.UseVisualStyleBackColor = true;
            this.PaletteBtn.Click += new System.EventHandler(this.PaletteBtn_Click);
            // 
            // ColorTbx
            // 
            this.ColorTbx.Location = new System.Drawing.Point(76, 22);
            this.ColorTbx.Name = "ColorTbx";
            this.ColorTbx.ReadOnly = true;
            this.ColorTbx.Size = new System.Drawing.Size(100, 20);
            this.ColorTbx.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Color";
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(199, 89);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // NewLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 124);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.ColorTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PaletteBtn);
            this.Controls.Add(this.NameTbx);
            this.Controls.Add(this.label1);
            this.Name = "NewLabelForm";
            this.Text = "NewLabelForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTbx;
        private System.Windows.Forms.Button PaletteBtn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox ColorTbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OkBtn;
    }
}