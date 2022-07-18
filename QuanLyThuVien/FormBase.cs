using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
            MainForm.onLanguageChanged += MainForm_onLanguageChanged;

        }

        private void MainForm_onLanguageChanged(object sender, EventArgs e)
        {
            applyUIStrings();
        }

        protected virtual void applyUIStrings() { }

        protected virtual void bindingData() { }

        private void FormBase_Load(object sender, EventArgs e)
        {
            loadData().ContinueWith((t) => 
            {
                if (InvokeRequired)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        bindingData();
                        applyUIStrings();
                    }));
                }
                else
                {
                    bindingData();
                    applyUIStrings();
                }
            });
        }

        protected virtual async Task loadData() { }
    }
}
