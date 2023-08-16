using MS.DemoAppDesktop.Forms;
using MS.DemoAppDesktop.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MS.DemoAppDesktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Thực hiện đăng nhập:
            var userName = txtAccount.Text.Trim();
            var password = txtPassword.Text.Trim();
            var httpClient = new MSHttpClient();

            var user = new UserModel()
            {
                UserName = userName,
                Password = password,
            };

            // Gọi api thực hiện đăng nhập:
            var res = await httpClient.HttpClient.PostAsJsonAsync("Accounts/login", user);
            switch (res.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:
                    var content = await res.Content.ReadAsStringAsync(); // raw content as string
                    var json = (JObject)JsonConvert.DeserializeObject(content);
                    var token = json["Token"].Value<string>();
                    MessageBox.Show($"Đăng nhập thành công! ({token})");
                    this.Hide();
                    var mainForm = new frmMain(token);
                    mainForm.Show();
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!");
                    break;
                default:
                    MessageBox.Show($"{res.StatusCode}: Có lỗi xảy ra vui lòng liên hệ MS Software để được trợ giúp!");
                    break;
            }
            

        }
    }
}