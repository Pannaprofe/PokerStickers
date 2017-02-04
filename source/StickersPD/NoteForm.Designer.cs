namespace StickersPD
{
    partial class NoteForm
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
            this.NotesRtb = new System.Windows.Forms.RichTextBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NotesRtb
            // 
            this.NotesRtb.Location = new System.Drawing.Point(-1, -1);
            this.NotesRtb.Name = "NotesRtb";
            this.NotesRtb.Size = new System.Drawing.Size(245, 168);
            this.NotesRtb.TabIndex = 0;
            this.NotesRtb.Text = "";
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(163, 166);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 23);
            this.OkBtn.TabIndex = 1;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // NoteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 191);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.NotesRtb);
            this.Name = "NoteForm";
            this.Text = "NoteForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox NotesRtb;
        private System.Windows.Forms.Button OkBtn;
    }
}