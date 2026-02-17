using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace ClienteChat
{
    public partial class ChatForm : Form
    {
        TcpClient clientSocket = new TcpClient();
        StreamWriter writer;
        StreamReader reader;
        string nombreUsuario;

        public ChatForm(string nombre)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            this.Load += ChatForm_Load;
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {
            this.Text = "Chat - Bezeroa: " + nombreUsuario;
            try
            {
                // Intentamos conectar
                clientSocket.Connect("127.0.0.1", 8888);
                NetworkStream stream = clientSocket.GetStream();

                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);
                writer.AutoFlush = true;

                // Enviar aviso de conexión
                writer.WriteLine(nombreUsuario + " sartu da.");

                // Iniciar el hilo de escucha
                Thread ctThread = new Thread(EscucharServidor);
                ctThread.Start();
            }
            catch (Exception ex)
            {
                // AQUÍ ESTÁ LA CLAVE: Nos dirá exactamente qué pasa
                MessageBox.Show("ERROR CRÍTICO AL CONECTAR: \n" + ex.Message);

                // Si falla, cerramos el chat automáticamente para evitar errores
                this.Close();
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            // 1. Si no escribieron nada, no hacemos nada
            if (string.IsNullOrEmpty(txtMensaje.Text)) return;

            // 2. CORRECCIÓN: Si writer es null, significa que no hay conexión.
            if (writer == null)
            {
                MessageBox.Show("No estás conectado al servidor.");
                return;
            }

            try
            {
                // Enviar mensaje
                writer.WriteLine(nombreUsuario + ": " + txtMensaje.Text);

                txtMensaje.Text = "";
                txtMensaje.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar: " + ex.Message);
            }
        }

        private void EscucharServidor()
        {
            while (clientSocket.Connected)
            {
                try
                {
                    string mensaje = reader.ReadLine();
                    if (mensaje != null)
                    {
                        // Invoke para tocar la UI desde otro hilo
                        this.Invoke(new MethodInvoker(delegate
                        {
                            lstMensajes.Items.Add(mensaje);
                        }));
                    }
                }
                catch
                {
                    break;
                }
            }
        }
    }
}