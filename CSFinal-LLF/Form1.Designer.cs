namespace CSFinal_LLF
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            NavBox = new GroupBox();
            RightBtn = new Button();
            LeftBtn = new Button();
            DownBtn = new Button();
            UpBtn = new Button();
            RoomList = new ImageList(components);
            LogoImage = new PictureBox();
            MiniMapBox = new TextBox();
            label1 = new Label();
            DirectionFaceTxt = new TextBox();
            label2 = new Label();
            StartBtn = new Button();
            NavBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoImage).BeginInit();
            SuspendLayout();
            // 
            // NavBox
            // 
            NavBox.Anchor = AnchorStyles.Bottom;
            NavBox.BackColor = SystemColors.ControlLight;
            NavBox.Controls.Add(RightBtn);
            NavBox.Controls.Add(LeftBtn);
            NavBox.Controls.Add(DownBtn);
            NavBox.Controls.Add(UpBtn);
            NavBox.FlatStyle = FlatStyle.Flat;
            NavBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            NavBox.Location = new Point(413, 497);
            NavBox.Margin = new Padding(4, 5, 4, 5);
            NavBox.Name = "NavBox";
            NavBox.Padding = new Padding(4, 5, 4, 5);
            NavBox.Size = new Size(311, 233);
            NavBox.TabIndex = 1;
            NavBox.TabStop = false;
            NavBox.Text = "Navigation";
            // 
            // RightBtn
            // 
            RightBtn.BackColor = SystemColors.ControlLightLight;
            RightBtn.Enabled = false;
            RightBtn.FlatAppearance.BorderColor = Color.Black;
            RightBtn.FlatAppearance.BorderSize = 40;
            RightBtn.FlatStyle = FlatStyle.Popup;
            RightBtn.ForeColor = Color.Chocolate;
            RightBtn.Location = new Point(193, 100);
            RightBtn.Margin = new Padding(4, 5, 4, 5);
            RightBtn.Name = "RightBtn";
            RightBtn.Size = new Size(107, 53);
            RightBtn.TabIndex = 3;
            RightBtn.Text = "Right";
            RightBtn.UseVisualStyleBackColor = false;
            RightBtn.Click += RightBtn_Click;
            // 
            // LeftBtn
            // 
            LeftBtn.BackColor = SystemColors.ControlLightLight;
            LeftBtn.Enabled = false;
            LeftBtn.FlatAppearance.BorderColor = Color.Black;
            LeftBtn.FlatAppearance.BorderSize = 40;
            LeftBtn.FlatStyle = FlatStyle.Popup;
            LeftBtn.ForeColor = Color.Chocolate;
            LeftBtn.Location = new Point(9, 100);
            LeftBtn.Margin = new Padding(4, 5, 4, 5);
            LeftBtn.Name = "LeftBtn";
            LeftBtn.Size = new Size(107, 53);
            LeftBtn.TabIndex = 2;
            LeftBtn.Text = "Left";
            LeftBtn.UseVisualStyleBackColor = false;
            LeftBtn.Click += LeftBtn_Click;
            // 
            // DownBtn
            // 
            DownBtn.BackColor = SystemColors.ControlLightLight;
            DownBtn.Enabled = false;
            DownBtn.FlatAppearance.BorderColor = Color.Black;
            DownBtn.FlatAppearance.BorderSize = 40;
            DownBtn.FlatStyle = FlatStyle.Popup;
            DownBtn.ForeColor = Color.Chocolate;
            DownBtn.Location = new Point(101, 163);
            DownBtn.Margin = new Padding(4, 5, 4, 5);
            DownBtn.Name = "DownBtn";
            DownBtn.Size = new Size(107, 53);
            DownBtn.TabIndex = 1;
            DownBtn.Text = "Back";
            DownBtn.UseVisualStyleBackColor = false;
            DownBtn.Click += BackBtn_Click;
            // 
            // UpBtn
            // 
            UpBtn.BackColor = SystemColors.ControlLightLight;
            UpBtn.Enabled = false;
            UpBtn.FlatAppearance.BorderColor = Color.Black;
            UpBtn.FlatAppearance.BorderSize = 40;
            UpBtn.FlatStyle = FlatStyle.Popup;
            UpBtn.ForeColor = Color.Chocolate;
            UpBtn.Location = new Point(101, 37);
            UpBtn.Margin = new Padding(4, 5, 4, 5);
            UpBtn.Name = "UpBtn";
            UpBtn.Size = new Size(107, 53);
            UpBtn.TabIndex = 0;
            UpBtn.Text = "Foward";
            UpBtn.UseVisualStyleBackColor = false;
            UpBtn.Click += UpBtn_Click;
            // 
            // RoomList
            // 
            RoomList.ColorDepth = ColorDepth.Depth8Bit;
            RoomList.ImageStream = (ImageListStreamer)resources.GetObject("RoomList.ImageStream");
            RoomList.TransparentColor = Color.Transparent;
            RoomList.Images.SetKeyName(0, "3 Fork.png");
            RoomList.Images.SetKeyName(1, "2 fork.png");
            RoomList.Images.SetKeyName(2, "Corner.png");
            RoomList.Images.SetKeyName(3, "Hall.png");
            // 
            // LogoImage
            // 
            LogoImage.Anchor = AnchorStyles.Top;
            LogoImage.BackColor = SystemColors.ActiveCaptionText;
            LogoImage.BorderStyle = BorderStyle.Fixed3D;
            LogoImage.Image = Properties.Resources.Logo;
            LogoImage.Location = new Point(290, 170);
            LogoImage.Margin = new Padding(4, 5, 4, 5);
            LogoImage.Name = "LogoImage";
            LogoImage.Size = new Size(594, 195);
            LogoImage.SizeMode = PictureBoxSizeMode.StretchImage;
            LogoImage.TabIndex = 2;
            LogoImage.TabStop = false;
            // 
            // MiniMapBox
            // 
            MiniMapBox.AllowDrop = true;
            MiniMapBox.Anchor = AnchorStyles.Bottom;
            MiniMapBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            MiniMapBox.Location = new Point(743, 581);
            MiniMapBox.Margin = new Padding(4, 5, 4, 5);
            MiniMapBox.Multiline = true;
            MiniMapBox.Name = "MiniMapBox";
            MiniMapBox.ReadOnly = true;
            MiniMapBox.Size = new Size(381, 142);
            MiniMapBox.TabIndex = 3;
            MiniMapBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom;
            label1.AutoSize = true;
            label1.Location = new Point(1035, 548);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(89, 25);
            label1.TabIndex = 4;
            label1.Text = "Mini-Map";
            // 
            // DirectionFaceTxt
            // 
            DirectionFaceTxt.Anchor = AnchorStyles.Bottom;
            DirectionFaceTxt.Location = new Point(743, 548);
            DirectionFaceTxt.Margin = new Padding(4, 5, 4, 5);
            DirectionFaceTxt.Name = "DirectionFaceTxt";
            DirectionFaceTxt.ReadOnly = true;
            DirectionFaceTxt.Size = new Size(141, 31);
            DirectionFaceTxt.TabIndex = 5;
            DirectionFaceTxt.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Location = new Point(780, 518);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 25);
            label2.TabIndex = 6;
            label2.Text = "Facing";
            // 
            // StartBtn
            // 
            StartBtn.Anchor = AnchorStyles.Top;
            StartBtn.AutoSize = true;
            StartBtn.BackColor = SystemColors.MenuHighlight;
            StartBtn.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            StartBtn.ForeColor = SystemColors.ButtonFace;
            StartBtn.Location = new Point(487, 384);
            StartBtn.Name = "StartBtn";
            StartBtn.Size = new Size(215, 77);
            StartBtn.TabIndex = 7;
            StartBtn.Text = "Start!";
            StartBtn.UseVisualStyleBackColor = false;
            StartBtn.Click += StartBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(StartBtn);
            Controls.Add(label2);
            Controls.Add(DirectionFaceTxt);
            Controls.Add(label1);
            Controls.Add(MiniMapBox);
            Controls.Add(LogoImage);
            Controls.Add(NavBox);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "DungeonForm";
            NavBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button RightBtn;
        private Button LeftBtn;
        private Button DownBtn;
        private Button UpBtn;
        public ImageList RoomList;
        private PictureBox LogoImage;
        private Label label1;
        private TextBox MiniMapBox;
        private GroupBox NavBox;
        private TextBox DirectionFaceTxt;
        private Label label2;
        private Button button1;
        private Button StartBtn;
    }
}