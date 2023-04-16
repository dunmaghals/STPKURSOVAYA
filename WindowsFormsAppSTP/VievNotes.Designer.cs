namespace WindowsFormsAppSTP
{
    partial class VievNotes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VievNotes));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bunifuTextBox2 = new Bunifu.UI.WinForms.BunifuTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(316, 74);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(427, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.Enter += new System.EventHandler(this.ComboBox_Load);
            this.comboBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ComboBox_Leave);
            // 
            // bunifuTextBox2
            // 
            this.bunifuTextBox2.AcceptsReturn = false;
            this.bunifuTextBox2.AcceptsTab = false;
            this.bunifuTextBox2.AnimationSpeed = 200;
            this.bunifuTextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuTextBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTextBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox2.BackgroundImage")));
            this.bunifuTextBox2.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.bunifuTextBox2.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuTextBox2.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuTextBox2.BorderColorIdle = System.Drawing.Color.Silver;
            this.bunifuTextBox2.BorderRadius = 1;
            this.bunifuTextBox2.BorderThickness = 1;
            this.bunifuTextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox2.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.bunifuTextBox2.DefaultText = "";
            this.bunifuTextBox2.FillColor = System.Drawing.Color.White;
            this.bunifuTextBox2.HideSelection = true;
            this.bunifuTextBox2.IconLeft = null;
            this.bunifuTextBox2.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox2.IconPadding = 10;
            this.bunifuTextBox2.IconRight = null;
            this.bunifuTextBox2.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox2.Lines = new string[0];
            this.bunifuTextBox2.Location = new System.Drawing.Point(120, 15);
            this.bunifuTextBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuTextBox2.MaxLength = 32767;
            this.bunifuTextBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.bunifuTextBox2.Modified = false;
            this.bunifuTextBox2.Multiline = false;
            this.bunifuTextBox2.Name = "bunifuTextBox2";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox2.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.bunifuTextBox2.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox2.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox2.OnIdleState = stateProperties4;
            this.bunifuTextBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bunifuTextBox2.PasswordChar = '\0';
            this.bunifuTextBox2.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuTextBox2.PlaceholderText = "Enter text";
            this.bunifuTextBox2.ReadOnly = false;
            this.bunifuTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuTextBox2.SelectedText = "";
            this.bunifuTextBox2.SelectionLength = 0;
            this.bunifuTextBox2.SelectionStart = 0;
            this.bunifuTextBox2.ShortcutsEnabled = true;
            this.bunifuTextBox2.Size = new System.Drawing.Size(849, 31);
            this.bunifuTextBox2.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.bunifuTextBox2.TabIndex = 4;
            this.bunifuTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuTextBox2.TextMarginBottom = 0;
            this.bunifuTextBox2.TextMarginLeft = 3;
            this.bunifuTextBox2.TextMarginTop = 0;
            this.bunifuTextBox2.TextPlaceholder = "Enter text";
            this.bunifuTextBox2.UseSystemPasswordChar = false;
            this.bunifuTextBox2.WordWrap = true;
            this.bunifuTextBox2.TextChange += new System.EventHandler(this.bunifuTextBox2_TextChanged);
            this.bunifuTextBox2.TextChanged += new System.EventHandler(this.bunifuTextBox2_TextChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(232, 238);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(633, 191);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bunifuTextBox2);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ComboBox comboBox1;
        private Bunifu.UI.WinForms.BunifuTextBox bunifuTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}