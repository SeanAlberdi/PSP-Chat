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
            lstMensajes.FormattingEnabled = true;
            lstMensajes.ItemHeight = 15;
            lstMensajes.Location = new Point(12, 16);
            lstMensajes.Name = "lstMensajes";
            lstMensajes.Size = new Size(762, 349);
            lstMensajes.TabIndex = 0;
            // 
            // txtMensaje
            // 
            txtMensaje.Location = new Point(12, 372);
            txtMensaje.Name = "txtMensaje";
            txtMensaje.Size = new Size(762, 23);
            txtMensaje.TabIndex = 1;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(12, 404);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(762, 23);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Bidali";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += this.btnEnviar_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensaje);
            Controls.Add(lstMensajes);
            Name = "ChatForm";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMensajes;
        private TextBox txtMensaje;
        private Button btnEnviar;
    }
}