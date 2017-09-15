namespace vFireCal
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCopyCatDesc2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCopyOneLiner2 = new System.Windows.Forms.Button();
            this.lbOneLiner = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCopyOneLiner1 = new System.Windows.Forms.Button();
            this.btnCopyCatDesc1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchStr = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lbCatDesc = new System.Windows.Forms.ListBox();
            this.lbV_FireType = new System.Windows.Forms.ListBox();
            this.lbWhatsIncluded = new System.Windows.Forms.ListBox();
            this.lblMsg1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(1, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "vFire Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(532, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "What\'s Included:";
            // 
            // btnCopyCatDesc2
            // 
            this.btnCopyCatDesc2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyCatDesc2.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyCatDesc2.Image")));
            this.btnCopyCatDesc2.Location = new System.Drawing.Point(230, 218);
            this.btnCopyCatDesc2.Name = "btnCopyCatDesc2";
            this.btnCopyCatDesc2.Size = new System.Drawing.Size(297, 39);
            this.btnCopyCatDesc2.TabIndex = 23;
            this.btnCopyCatDesc2.Text = "Copy Selected Category Description";
            this.btnCopyCatDesc2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyCatDesc2.UseVisualStyleBackColor = true;
            this.btnCopyCatDesc2.Click += new System.EventHandler(this.btnCopyCatDesc2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(227, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Category Description";
            // 
            // btnCopyOneLiner2
            // 
            this.btnCopyOneLiner2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyOneLiner2.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyOneLiner2.Image")));
            this.btnCopyOneLiner2.Location = new System.Drawing.Point(832, 220);
            this.btnCopyOneLiner2.Name = "btnCopyOneLiner2";
            this.btnCopyOneLiner2.Size = new System.Drawing.Size(244, 39);
            this.btnCopyOneLiner2.TabIndex = 26;
            this.btnCopyOneLiner2.Text = "Copy Selected One Liner";
            this.btnCopyOneLiner2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyOneLiner2.UseVisualStyleBackColor = true;
            this.btnCopyOneLiner2.Click += new System.EventHandler(this.btnCopyOneLiner2_Click);
            // 
            // lbOneLiner
            // 
            this.lbOneLiner.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbOneLiner.FormattingEnabled = true;
            this.lbOneLiner.ItemHeight = 15;
            this.lbOneLiner.Location = new System.Drawing.Point(795, 28);
            this.lbOneLiner.Name = "lbOneLiner";
            this.lbOneLiner.Size = new System.Drawing.Size(300, 184);
            this.lbOneLiner.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(789, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "One Liner";
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1106, 302);
            this.tabControl1.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblMsg1);
            this.tabPage2.Controls.Add(this.btnCopyOneLiner1);
            this.tabPage2.Controls.Add(this.btnCopyCatDesc1);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.txtSearchStr);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1098, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Search";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCopyOneLiner1
            // 
            this.btnCopyOneLiner1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyOneLiner1.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyOneLiner1.Image")));
            this.btnCopyOneLiner1.Location = new System.Drawing.Point(851, 8);
            this.btnCopyOneLiner1.Name = "btnCopyOneLiner1";
            this.btnCopyOneLiner1.Size = new System.Drawing.Size(244, 39);
            this.btnCopyOneLiner1.TabIndex = 46;
            this.btnCopyOneLiner1.Text = "Copy Selected One Liner";
            this.btnCopyOneLiner1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyOneLiner1.UseVisualStyleBackColor = true;
            this.btnCopyOneLiner1.Click += new System.EventHandler(this.btnCopyOneLiner1_Click);
            // 
            // btnCopyCatDesc1
            // 
            this.btnCopyCatDesc1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopyCatDesc1.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyCatDesc1.Image")));
            this.btnCopyCatDesc1.Location = new System.Drawing.Point(589, 8);
            this.btnCopyCatDesc1.Name = "btnCopyCatDesc1";
            this.btnCopyCatDesc1.Size = new System.Drawing.Size(256, 39);
            this.btnCopyCatDesc1.TabIndex = 45;
            this.btnCopyCatDesc1.Text = "Copy Selected Category Description";
            this.btnCopyCatDesc1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopyCatDesc1.UseVisualStyleBackColor = true;
            this.btnCopyCatDesc1.Click += new System.EventHandler(this.btnCopyCatDesc1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 53);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1090, 213);
            this.dataGridView1.TabIndex = 44;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(198, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 39);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchStr
            // 
            this.txtSearchStr.Location = new System.Drawing.Point(5, 16);
            this.txtSearchStr.Name = "txtSearchStr";
            this.txtSearchStr.Size = new System.Drawing.Size(187, 22);
            this.txtSearchStr.TabIndex = 0;
            this.txtSearchStr.Text = "access";
            this.txtSearchStr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchStr_KeyPress);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblMsg2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.lbCatDesc);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnCopyOneLiner2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.lbOneLiner);
            this.tabPage1.Controls.Add(this.lbV_FireType);
            this.tabPage1.Controls.Add(this.lbWhatsIncluded);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnCopyCatDesc2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1098, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "vFire Categories";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbCatDesc
            // 
            this.lbCatDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCatDesc.FormattingEnabled = true;
            this.lbCatDesc.ItemHeight = 15;
            this.lbCatDesc.Location = new System.Drawing.Point(230, 28);
            this.lbCatDesc.Name = "lbCatDesc";
            this.lbCatDesc.Size = new System.Drawing.Size(297, 184);
            this.lbCatDesc.TabIndex = 2;
            this.lbCatDesc.SelectedIndexChanged += new System.EventHandler(this.lbCatDesc_SelectedIndexChanged);
            // 
            // lbV_FireType
            // 
            this.lbV_FireType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbV_FireType.FormattingEnabled = true;
            this.lbV_FireType.ItemHeight = 15;
            this.lbV_FireType.Location = new System.Drawing.Point(4, 28);
            this.lbV_FireType.Name = "lbV_FireType";
            this.lbV_FireType.Size = new System.Drawing.Size(219, 184);
            this.lbV_FireType.TabIndex = 1;
            this.lbV_FireType.SelectedIndexChanged += new System.EventHandler(this.lbV_FireType_SelectedIndexChanged);
            // 
            // lbWhatsIncluded
            // 
            this.lbWhatsIncluded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.150944F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbWhatsIncluded.FormattingEnabled = true;
            this.lbWhatsIncluded.ItemHeight = 15;
            this.lbWhatsIncluded.Location = new System.Drawing.Point(533, 28);
            this.lbWhatsIncluded.Name = "lbWhatsIncluded";
            this.lbWhatsIncluded.Size = new System.Drawing.Size(256, 184);
            this.lbWhatsIncluded.TabIndex = 3;
            this.lbWhatsIncluded.SelectedIndexChanged += new System.EventHandler(this.lbWhatsIncluded_SelectedIndexChanged);
            // 
            // lblMsg1
            // 
            this.lblMsg1.ForeColor = System.Drawing.Color.Blue;
            this.lblMsg1.Location = new System.Drawing.Point(291, 5);
            this.lblMsg1.Name = "lblMsg1";
            this.lblMsg1.Size = new System.Drawing.Size(292, 38);
            this.lblMsg1.TabIndex = 47;
            this.lblMsg1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblMsg2
            // 
            this.lblMsg2.ForeColor = System.Drawing.Color.Blue;
            this.lblMsg2.Location = new System.Drawing.Point(8, 220);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(216, 38);
            this.lblMsg2.TabIndex = 48;
            this.lblMsg2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 314);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "vFire Categories";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCopyCatDesc2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCopyOneLiner2;
        private System.Windows.Forms.ListBox lbOneLiner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox lbCatDesc;
        private System.Windows.Forms.ListBox lbV_FireType;
        private System.Windows.Forms.ListBox lbWhatsIncluded;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchStr;
        private System.Windows.Forms.Button btnCopyOneLiner1;
        private System.Windows.Forms.Button btnCopyCatDesc1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblMsg1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblMsg2;
    }
}

