
namespace _3phaseMoterControl
{
  partial class PortSetting
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
      this.cb_comPort = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.cb_baud = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.cb_dataBit = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.cb_parity = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.cb_stopBit = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.cb_handshaking = new System.Windows.Forms.ComboBox();
      this.btn_test = new System.Windows.Forms.Button();
      this.btn_connect = new System.Windows.Forms.Button();
      this.btn_default = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // cb_comPort
      // 
      this.cb_comPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_comPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cb_comPort.FormattingEnabled = true;
      this.cb_comPort.Location = new System.Drawing.Point(130, 13);
      this.cb_comPort.Margin = new System.Windows.Forms.Padding(4);
      this.cb_comPort.Name = "cb_comPort";
      this.cb_comPort.Size = new System.Drawing.Size(144, 28);
      this.cb_comPort.TabIndex = 0;
      this.cb_comPort.SelectedIndexChanged += new System.EventHandler(this.cb_comPort_SelectedIndexChanged);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(78, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(45, 20);
      this.label1.TabIndex = 1;
      this.label1.Text = "COM";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(73, 52);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(50, 20);
      this.label2.TabIndex = 3;
      this.label2.Text = "BAUD";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cb_baud
      // 
      this.cb_baud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_baud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cb_baud.FormattingEnabled = true;
      this.cb_baud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
      this.cb_baud.Location = new System.Drawing.Point(129, 49);
      this.cb_baud.Margin = new System.Windows.Forms.Padding(4);
      this.cb_baud.Name = "cb_baud";
      this.cb_baud.Size = new System.Drawing.Size(144, 28);
      this.cb_baud.TabIndex = 2;
      this.cb_baud.SelectedIndexChanged += new System.EventHandler(this.cb_baud_SelectedIndexChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(49, 88);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(74, 20);
      this.label3.TabIndex = 5;
      this.label3.Text = "DATA BIT";
      this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cb_dataBit
      // 
      this.cb_dataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_dataBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cb_dataBit.FormattingEnabled = true;
      this.cb_dataBit.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
      this.cb_dataBit.Location = new System.Drawing.Point(129, 85);
      this.cb_dataBit.Margin = new System.Windows.Forms.Padding(4);
      this.cb_dataBit.Name = "cb_dataBit";
      this.cb_dataBit.Size = new System.Drawing.Size(144, 28);
      this.cb_dataBit.TabIndex = 4;
      this.cb_dataBit.SelectedIndexChanged += new System.EventHandler(this.cb_dataBit_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(66, 160);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(57, 20);
      this.label4.TabIndex = 7;
      this.label4.Text = "PARITY";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cb_parity
      // 
      this.cb_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_parity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cb_parity.FormattingEnabled = true;
      this.cb_parity.Items.AddRange(new object[] {
            "None",
            "Even",
            "Mark",
            "Odd",
            "Space"});
      this.cb_parity.Location = new System.Drawing.Point(130, 157);
      this.cb_parity.Margin = new System.Windows.Forms.Padding(4);
      this.cb_parity.Name = "cb_parity";
      this.cb_parity.Size = new System.Drawing.Size(144, 28);
      this.cb_parity.TabIndex = 6;
      this.cb_parity.SelectedIndexChanged += new System.EventHandler(this.cb_parity_SelectedIndexChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(51, 124);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(72, 20);
      this.label5.TabIndex = 9;
      this.label5.Text = "STOP BIT";
      this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cb_stopBit
      // 
      this.cb_stopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_stopBit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cb_stopBit.FormattingEnabled = true;
      this.cb_stopBit.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
      this.cb_stopBit.Location = new System.Drawing.Point(129, 121);
      this.cb_stopBit.Margin = new System.Windows.Forms.Padding(4);
      this.cb_stopBit.Name = "cb_stopBit";
      this.cb_stopBit.Size = new System.Drawing.Size(144, 28);
      this.cb_stopBit.TabIndex = 8;
      this.cb_stopBit.SelectedIndexChanged += new System.EventHandler(this.cb_stopBit_SelectedIndexChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(7, 196);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(116, 20);
      this.label6.TabIndex = 11;
      this.label6.Text = "HANDSHAKING";
      this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // cb_handshaking
      // 
      this.cb_handshaking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cb_handshaking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cb_handshaking.FormattingEnabled = true;
      this.cb_handshaking.Items.AddRange(new object[] {
            "None",
            "RTS/CTS",
            "XON/XOFF",
            "RTS/CTS + XON/XOF"});
      this.cb_handshaking.Location = new System.Drawing.Point(129, 193);
      this.cb_handshaking.Margin = new System.Windows.Forms.Padding(4);
      this.cb_handshaking.Name = "cb_handshaking";
      this.cb_handshaking.Size = new System.Drawing.Size(144, 28);
      this.cb_handshaking.TabIndex = 10;
      this.cb_handshaking.SelectedIndexChanged += new System.EventHandler(this.cb_handshaking_SelectedIndexChanged);
      // 
      // btn_test
      // 
      this.btn_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_test.Location = new System.Drawing.Point(122, 246);
      this.btn_test.Name = "btn_test";
      this.btn_test.Size = new System.Drawing.Size(73, 41);
      this.btn_test.TabIndex = 12;
      this.btn_test.Text = "테스트";
      this.btn_test.UseVisualStyleBackColor = true;
      this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
      // 
      // btn_connect
      // 
      this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_connect.Location = new System.Drawing.Point(201, 246);
      this.btn_connect.Name = "btn_connect";
      this.btn_connect.Size = new System.Drawing.Size(73, 41);
      this.btn_connect.TabIndex = 13;
      this.btn_connect.Text = "접속";
      this.btn_connect.UseVisualStyleBackColor = true;
      this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
      // 
      // btn_default
      // 
      this.btn_default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_default.Location = new System.Drawing.Point(11, 246);
      this.btn_default.Name = "btn_default";
      this.btn_default.Size = new System.Drawing.Size(105, 41);
      this.btn_default.TabIndex = 14;
      this.btn_default.Text = "기본값 설정";
      this.btn_default.UseVisualStyleBackColor = true;
      this.btn_default.Click += new System.EventHandler(this.btn_default_Click);
      // 
      // Setting
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(286, 299);
      this.Controls.Add(this.btn_default);
      this.Controls.Add(this.btn_connect);
      this.Controls.Add(this.btn_test);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.cb_handshaking);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.cb_stopBit);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.cb_parity);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cb_dataBit);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cb_baud);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.cb_comPort);
      this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Setting";
      this.Text = "Setting";
      this.Load += new System.EventHandler(this.Setting_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cb_comPort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cb_baud;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox cb_dataBit;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cb_parity;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox cb_stopBit;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.ComboBox cb_handshaking;
    private System.Windows.Forms.Button btn_test;
    private System.Windows.Forms.Button btn_connect;
    private System.Windows.Forms.Button btn_default;
  }
}