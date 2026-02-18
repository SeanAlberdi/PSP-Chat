using System;
using System.Security.Cryptography;
using System.Text;
using System.Net.Http; // Necesario para llamar a la API
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ClienteChat
{
    public partial class Form1 : Form
    {
        // Cuando tengas la API lista, cambia esto a 'true'
        private bool usarApi = false;
        private const string URL_API_LOGIN = "https://tu-api.com/api/login";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, introduce usuario y contraseña.");
                return;
            }

            // 1. HASHEAR LA CONTRASEÑA
            string passwordHasheada = ComputeSha256Hash(password);

            bool loginExitoso = false;

            // 2. DECIDIR CÓMO LOGUEARSE
            if (usarApi)
            {
                // MODO API
                btnLogin.Enabled = false;
                loginExitoso = await LoginConApi(usuario, passwordHasheada);
                btnLogin.Enabled = true;
            }
            else
            {
                // MODO HARDCODED

                string hashEsperado = ComputeSha256Hash("1234");

                if (usuario != "" && passwordHasheada == hashEsperado)
                {
                    loginExitoso = true;
                }
            }

            // 3. RESULTADO
            if (loginExitoso)
            {
                this.Hide();
                ChatForm chat = new ChatForm(usuario);
                chat.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private async Task<bool> LoginConApi(string user, string passHash)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var jsonData = $"{{\"usuario\": \"{user}\", \"hash\": \"{passHash}\"}}";

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    await Task.Delay(100);
                    MessageBox.Show("El modo API está activado pero no hay URL configurada.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión con la API: " + ex.Message);
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}