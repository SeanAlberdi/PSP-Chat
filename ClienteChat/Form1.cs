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
        // ---------------------------------------------------------
        // CONFIGURACIÓN
        // ---------------------------------------------------------
        // Cuando tengas la API lista, cambia esto a 'true'
        private bool usarApi = false;
        private const string URL_API_LOGIN = "https://tu-api.com/api/login";
        // ---------------------------------------------------------

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
            // Convertimos "1234" en algo seguro como "a665a45920422f9d417..."
            string passwordHasheada = ComputeSha256Hash(password);

            bool loginExitoso = false;

            // 2. DECIDIR CÓMO LOGUEARSE
            if (usarApi)
            {
                // MODO API (FUTURO)
                // Deshabilitamos el botón para que no le den dos veces
                btnLogin.Enabled = false;
                loginExitoso = await LoginConApi(usuario, passwordHasheada);
                btnLogin.Enabled = true;
            }
            else
            {
                // MODO HARDCODED (ACTUAL)
                // Aquí simulamos que la base de datos espera el hash de "1234"
                // El hash de "1234" es: 03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4

                // Nota: Para probar, comparamos el hash generado con el que esperamos
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

        // ---------------------------------------------------------
        // FUNCIONES DE UTILIDAD (NO TOCAR)
        // ---------------------------------------------------------

        // Función para convertir texto plano a SHA256
        static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Función preparada para llamar a tu futura API
        private async Task<bool> LoginConApi(string user, string passHash)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Creamos el objeto JSON que espera tu API
                    // Estructura típica: { "usuario": "pepe", "hash": "a665..." }
                    var jsonData = $"{{\"usuario\": \"{user}\", \"hash\": \"{passHash}\"}}";

                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Hacemos la llamada POST (esperamos respuesta)
                    // HttpResponseMessage response = await client.PostAsync(URL_API_LOGIN, content);

                    // Si la API devuelve código 200 OK, es que el login es bueno
                    // return response.IsSuccessStatusCode;

                    // --- MIENTRAS NO TENGAS API, ESTO DEVUELVE FALSE ---
                    await Task.Delay(100); // Simula espera de red
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
    }
}