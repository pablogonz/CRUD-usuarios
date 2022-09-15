
namespace EjemploDB
{
    partial class SelectCrud
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
            this.btclient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btcontact = new System.Windows.Forms.Button();
            this.btpeople = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btclient
            // 
            this.btclient.Location = new System.Drawing.Point(172, 115);
            this.btclient.Margin = new System.Windows.Forms.Padding(4);
            this.btclient.Name = "btclient";
            this.btclient.Size = new System.Drawing.Size(100, 28);
            this.btclient.TabIndex = 3;
            this.btclient.Text = "Client";
            this.btclient.UseVisualStyleBackColor = true;
            this.btclient.Click += new System.EventHandler(this.btclient_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "SELECT CRUD";
            // 
            // btcontact
            // 
            this.btcontact.Location = new System.Drawing.Point(301, 115);
            this.btcontact.Margin = new System.Windows.Forms.Padding(4);
            this.btcontact.Name = "btcontact";
            this.btcontact.Size = new System.Drawing.Size(100, 28);
            this.btcontact.TabIndex = 5;
            this.btcontact.Text = "Contact";
            this.btcontact.UseVisualStyleBackColor = true;
            this.btcontact.Click += new System.EventHandler(this.btcontact_Click);
            // 
            // btpeople
            // 
            this.btpeople.Location = new System.Drawing.Point(32, 115);
            this.btpeople.Margin = new System.Windows.Forms.Padding(4);
            this.btpeople.Name = "btpeople";
            this.btpeople.Size = new System.Drawing.Size(100, 28);
            this.btpeople.TabIndex = 7;
            this.btpeople.Text = "People";
            this.btpeople.UseVisualStyleBackColor = true;
            this.btpeople.Click += new System.EventHandler(this.btpeople_Click);
            // 
            // SelectCrud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(501, 382);
            this.Controls.Add(this.btpeople);
            this.Controls.Add(this.btcontact);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btclient);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectCrud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectCrud";
            this.Load += new System.EventHandler(this.SelectCrud_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btclient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btcontact;
        private System.Windows.Forms.Button btpeople;
    }
}