using QuanLyThuVien.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class LoginForm : Form
    {
        private LoginDAL _loginDAL = new LoginDAL();
        private CancellationTokenSource _tokenSource = null;
        public LoginForm()
        {
            InitializeComponent();

            Load += LoginForm_UpdateSize;
            panelContainer.SizeChanged += LoginForm_UpdateSize;

        }

        private void LoginForm_UpdateSize(object sender, EventArgs e)
        {
            Size = panelContainer.Size;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chxShowPassword.Checked ? '\0' : '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_tokenSource == null)
            {
                btnLogin.Text = QuanLyThuVien.Resource.btnCancel;

                _tokenSource = new CancellationTokenSource();

                _loginDAL.loginAsync(txtUsername.Text, txtPassword.Text, _tokenSource.Token).ContinueWith(
                (_taskToContinue) =>
                {
                    if (_taskToContinue.IsFaulted)
                    {
                        MessageBox.Show(_taskToContinue.Exception.Message);
                    }
                    else if (_taskToContinue.IsCanceled)
                    {
                        MessageBox.Show("Task is cancelled.");
                    }
                    else
                    {
                        if (_taskToContinue.Result)
                        {
                            if (InvokeRequired)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    Hide();
                                    var _mainFrm = new MainForm();
                                    _mainFrm.ShowDialog();
                                    _mainFrm.Dispose();
                                }));
                            }
                        }
                        else
                        {
                            MessageBox.Show(QuanLyThuVien.Resource.CantLogin);
                        }
                    }
                });
            }
            else
            {
                btnLogin.Text = QuanLyThuVien.Resource.btnLogin;

                _tokenSource.Cancel();
                _tokenSource.Dispose();
                _tokenSource = null;
            }
        }
        
        private void btnEsc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(QuanLyThuVien.Resource.ClosingNotification,
                    QuanLyThuVien.Resource.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(QuanLyThuVien.Resource.ClosingNotification,
                    QuanLyThuVien.Resource.Confirm, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            updateControlStates();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            updateControlStates();
            cbxFlags.SelectedIndex = 0;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            updateControlStates();
        }

        private void updateControlStates()
        {
            txtPassword.Enabled = !string.IsNullOrEmpty(txtUsername.Text.Trim());
            chxShowPassword.Enabled = !string.IsNullOrEmpty(txtPassword.Text) &&
                !string.IsNullOrEmpty(txtUsername.Text.Trim());
            btnLogin.Enabled = !string.IsNullOrEmpty(txtUsername.Text.Trim()) &&
                !string.IsNullOrEmpty(txtPassword.Text);
        }

        private void switchLanguage(string pzLangId)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(pzLangId);
            applyUIStrings();
        }

        private void applyUIStrings()
        {
            chxShowPassword.Text = QuanLyThuVien.Resource.chxShowPassword;
            btnLogin.Text = QuanLyThuVien.Resource.btnLogin;
            btnExit.Text = QuanLyThuVien.Resource.btnEsc;
            lblUsername.Text = QuanLyThuVien.Resource.lblUserName;
            lblPassword.Text = QuanLyThuVien.Resource.lblPassword;
        }

        private void cbxFlags_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

                if (e.State.HasFlag(DrawItemState.Focus) && !e.State.HasFlag(DrawItemState.ComboBoxEdit))
                {
                    e.DrawBackground();
                    e.DrawFocusRectangle();
                }
                else
                {
                    using (var _br = new SolidBrush(Color.WhiteSmoke))
                        e.Graphics.FillRectangle(_br, e.Bounds);
                }

                e.Graphics.DrawImage(imageList1.Images[e.Index],
                    new Rectangle(e.Bounds.Location,
                    new Size(e.Bounds.Height - 2, e.Bounds.Height - 2)));
            }

        }

        private void cbxFlags_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxFlags.SelectedIndex)
            {
                case 0:
                    switchLanguage("en");
                    break;

                case 1:
                    switchLanguage("vi");
                    break;
            }
        }

    }
}
