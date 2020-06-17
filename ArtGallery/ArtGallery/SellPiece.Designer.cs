namespace ArtGallery
{
    partial class SellPiece
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
            this.sellpieceID = new System.Windows.Forms.TextBox();
            this.pieceIDLabel = new System.Windows.Forms.Label();
            this.sellingPriceLabel = new System.Windows.Forms.Label();
            this.sellingPrice = new System.Windows.Forms.TextBox();
            this.OKbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sellpieceID
            // 
            this.sellpieceID.Location = new System.Drawing.Point(130, 30);
            this.sellpieceID.Name = "sellpieceID";
            this.sellpieceID.Size = new System.Drawing.Size(100, 20);
            this.sellpieceID.TabIndex = 0;
            // 
            // pieceIDLabel
            // 
            this.pieceIDLabel.AutoSize = true;
            this.pieceIDLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pieceIDLabel.Location = new System.Drawing.Point(27, 31);
            this.pieceIDLabel.Name = "pieceIDLabel";
            this.pieceIDLabel.Size = new System.Drawing.Size(58, 19);
            this.pieceIDLabel.TabIndex = 1;
            this.pieceIDLabel.Text = "Piece ID";
            // 
            // sellingPriceLabel
            // 
            this.sellingPriceLabel.AutoSize = true;
            this.sellingPriceLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sellingPriceLabel.Location = new System.Drawing.Point(27, 63);
            this.sellingPriceLabel.Name = "sellingPriceLabel";
            this.sellingPriceLabel.Size = new System.Drawing.Size(78, 17);
            this.sellingPriceLabel.TabIndex = 2;
            this.sellingPriceLabel.Text = "Selling Price";
            // 
            // sellingPrice
            // 
            this.sellingPrice.Location = new System.Drawing.Point(130, 63);
            this.sellingPrice.Name = "sellingPrice";
            this.sellingPrice.Size = new System.Drawing.Size(100, 20);
            this.sellingPrice.TabIndex = 3;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(94, 109);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 4;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // SellPiece
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 158);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.sellingPrice);
            this.Controls.Add(this.sellingPriceLabel);
            this.Controls.Add(this.pieceIDLabel);
            this.Controls.Add(this.sellpieceID);
            this.Name = "SellPiece";
            this.Text = "Sell Art Piece";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sellpieceID;
        private System.Windows.Forms.Label pieceIDLabel;
        private System.Windows.Forms.Label sellingPriceLabel;
        private System.Windows.Forms.TextBox sellingPrice;
        private System.Windows.Forms.Button OKbutton;
    }
}