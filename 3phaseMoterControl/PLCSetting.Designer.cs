
namespace _3phaseMoterControl
{
  partial class PLCSetting
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
      this.tb_input = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btn_test = new System.Windows.Forms.Button();
      this.btn_connect = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tb_input
      // 
      this.tb_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.tb_input.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.tb_input.Location = new System.Drawing.Point(91, 35);
      this.tb_input.Name = "tb_input";
      this.tb_input.Size = new System.Drawing.Size(69, 23);
      this.tb_input.TabIndex = 0;
      this.tb_input.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("맑은 고딕", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
      this.label1.Location = new System.Drawing.Point(37, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(178, 23);
      this.label1.TabIndex = 1;
      this.label1.Text = "PLC Station Number";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btn_test
      // 
      this.btn_test.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_test.Location = new System.Drawing.Point(41, 64);
      this.btn_test.Name = "btn_test";
      this.btn_test.Size = new System.Drawing.Size(85, 33);
      this.btn_test.TabIndex = 2;
      this.btn_test.Text = "테스트";
      this.btn_test.UseVisualStyleBackColor = true;
      this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
      // 
      // btn_connect
      // 
      this.btn_connect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btn_connect.Location = new System.Drawing.Point(130, 64);
      this.btn_connect.Name = "btn_connect";
      this.btn_connect.Size = new System.Drawing.Size(85, 33);
      this.btn_connect.TabIndex = 3;
      this.btn_connect.Text = "연결";
      this.btn_connect.UseVisualStyleBackColor = true;
      this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
      // 
      // PLCSetting
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(251, 102);
      this.Controls.Add(this.btn_connect);
      this.Controls.Add(this.btn_test);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.tb_input);
      this.Name = "PLCSetting";
      this.Text = "PLCSetting";
      this.Load += new System.EventHandler(this.PLCSetting_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox tb_input;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btn_test;
    private System.Windows.Forms.Button btn_connect;
  }
}