using System.Drawing;
using System.Windows.Forms;


namespace QbTrackerUtil
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            toolStrip2 = new ToolStrip();
            toolStripLabel2 = new ToolStripLabel();
            tbUsername = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            tbPassword = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            btnLogin = new ToolStripButton();
            tbLog = new RichTextBox();
            toolStrip1 = new ToolStrip();
            cbType = new ToolStripComboBox();
            toolStripLabel1 = new ToolStripLabel();
            tbUrl = new ToolStripTextBox();
            toolStrip3 = new ToolStrip();
            toolStripLabel5 = new ToolStripLabel();
            tbReplaceDomain = new ToolStripTextBox();
            toolStripLabel4 = new ToolStripLabel();
            tbTargetUrl = new ToolStripTextBox();
            btnReplace = new ToolStripButton();
            toolStripContainer1 = new ToolStripContainer();
            toolStrip2.SuspendLayout();
            toolStrip1.SuspendLayout();
            toolStrip3.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(514, 406);
            // 
            // toolStrip2
            // 
            toolStrip2.Dock = DockStyle.None;
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripLabel2, tbUsername, toolStripSeparator1, toolStripLabel3, tbPassword, toolStripSeparator2, btnLogin });
            toolStrip2.Location = new Point(3, 25);
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Size = new Size(340, 25);
            toolStrip2.TabIndex = 1;
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(44, 22);
            toolStripLabel2.Text = "用户名";
            // 
            // tbUsername
            // 
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(100, 25);
            tbUsername.Text = "admin";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(32, 22);
            toolStripLabel3.Text = "密码";
            // 
            // tbPassword
            // 
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // btnLogin
            // 
            btnLogin.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnLogin.Image = (Image)resources.GetObject("btnLogin.Image");
            btnLogin.ImageTransparentColor = Color.Magenta;
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(36, 22);
            btnLogin.Text = "登录";
            btnLogin.Click += btnLogin_Click;
            // 
            // tbLog
            // 
            tbLog.Dock = DockStyle.Fill;
            tbLog.Location = new Point(0, 0);
            tbLog.Margin = new Padding(4);
            tbLog.Name = "tbLog";
            tbLog.ReadOnly = true;
            tbLog.Size = new Size(782, 500);
            tbLog.TabIndex = 0;
            tbLog.Text = "";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.Items.AddRange(new ToolStripItem[] { cbType, toolStripLabel1, tbUrl });
            toolStrip1.Location = new Point(3, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(507, 25);
            toolStrip1.TabIndex = 0;
            // 
            // cbType
            // 
            cbType.Items.AddRange(new object[] { "qBitorrent", "transmission" });
            cbType.Name = "cbType";
            cbType.Size = new Size(121, 25);
            cbType.Text = "qBitorrent";
            cbType.TextChanged += cbType_SelectedIndexChanged;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(70, 22);
            toolStripLabel1.Text = "web ui地址";
            // 
            // tbUrl
            // 
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(300, 25);
            tbUrl.Text = "http://localhost:8080";
            // 
            // toolStrip3
            // 
            toolStrip3.Dock = DockStyle.None;
            toolStrip3.Items.AddRange(new ToolStripItem[] { toolStripLabel5, tbReplaceDomain, toolStripLabel4, tbTargetUrl, btnReplace });
            toolStrip3.Location = new Point(3, 50);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.Size = new Size(695, 25);
            toolStrip3.TabIndex = 2;
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(112, 22);
            toolStripLabel5.Text = "要替换的地址(包含)";
            // 
            // tbReplaceDomain
            // 
            tbReplaceDomain.Name = "tbReplaceDomain";
            tbReplaceDomain.Size = new Size(120, 25);
            tbReplaceDomain.Text = "hdtime.org";
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(80, 22);
            toolStripLabel4.Text = "替换为的地址";
            // 
            // tbTargetUrl
            // 
            tbTargetUrl.Name = "tbTargetUrl";
            tbTargetUrl.Size = new Size(300, 25);
            tbTargetUrl.Text = "https://tracker.hdtime.org/announce.php?passkey=yourpasskey";
            // 
            // btnReplace
            // 
            btnReplace.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnReplace.Enabled = false;
            btnReplace.Image = (Image)resources.GetObject("btnReplace.Image");
            btnReplace.ImageTransparentColor = Color.Magenta;
            btnReplace.Name = "btnReplace";
            btnReplace.Size = new Size(36, 22);
            btnReplace.Text = "替换";
            btnReplace.Click += btnReplace_Click;
            // 
            // toolStripContainer1
            // 
            toolStripContainer1.BottomToolStripPanelVisible = false;
            // 
            // toolStripContainer1.ContentPanel
            // 
            toolStripContainer1.ContentPanel.Controls.Add(tbLog);
            toolStripContainer1.ContentPanel.Margin = new Padding(4);
            toolStripContainer1.ContentPanel.Size = new Size(782, 500);
            toolStripContainer1.Dock = DockStyle.Fill;
            toolStripContainer1.LeftToolStripPanelVisible = false;
            toolStripContainer1.Location = new Point(0, 0);
            toolStripContainer1.Margin = new Padding(4);
            toolStripContainer1.Name = "toolStripContainer1";
            toolStripContainer1.RightToolStripPanelVisible = false;
            toolStripContainer1.Size = new Size(782, 575);
            toolStripContainer1.TabIndex = 0;
            toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip2);
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip3);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 575);
            Controls.Add(toolStripContainer1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "authkey替换passkey工具";
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private ToolStrip toolStrip2;
        private ToolStripLabel toolStripLabel2;
        private ToolStripTextBox tbUsername;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel3;
        private ToolStripTextBox tbPassword;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnLogin;
        private RichTextBox tbLog;
        private ToolStrip toolStrip1;
        private ToolStripComboBox cbType;
        private ToolStripLabel toolStripLabel1;
        private ToolStripTextBox tbUrl;
        private ToolStrip toolStrip3;
        private ToolStripLabel toolStripLabel5;
        private ToolStripTextBox tbReplaceDomain;
        private ToolStripLabel toolStripLabel4;
        private ToolStripTextBox tbTargetUrl;
        private ToolStripButton btnReplace;
        private ToolStripContainer toolStripContainer1;
    }
}

