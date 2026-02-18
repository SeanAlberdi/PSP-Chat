namespace ClienteChat
{
    partial class ChatForm
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
            lstMensajes = new ListBox();
            txtMensaje = new TextBox();
            btnEnviar = new Button();
            SuspendLayout();
            // 
            // lstMensajes
            // 
            lstMensajes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstMensajes.FormattingEnabled = true;
            lstMensajes.HorizontalScrollbar = true;
            lstMensajes.ItemHeight = 21;
            lstMensajes.Location = new Point(12, 66);
            lstMensajes.Name = "lstMensajes";
            lstMensajes.Size = new Size(762, 256);
            lstMensajes.TabIndex = 0;
            lstMensajes.SelectedIndexChanged += lstMensajes_SelectedIndexChanged;
            // 
            // txtMensaje
            // 
            txtMensaje.Cursor = Cursors.IBeam;
            txtMensaje.Location = new Point(12, 331);
            txtMensaje.Multiline = true;
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(626, 23);
            txtMensaje.TabIndex = 1;
            // 
            // btnEnviar
            // 
            btnEnviar.Cursor = Cursors.Hand;
            btnEnviar.Location = new Point(644, 331);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(130, 23);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Bidali";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 84, 100);
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensaje);
            Controls.Add(lstMensajes);
            Name = "ChatForm";
            Text = "Txat";
            Load += ChatForm_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMensajes;
        private TextBox txtMensaje;
        private Button btnEnviar;
    }
}