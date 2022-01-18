
namespace uanta_Envelop
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_maCount = new System.Windows.Forms.TextBox();
            this.tb_envelopValue = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_getError = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "이평선 일봉갯수";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "저항지지선 비율";
            // 
            // tb_maCount
            // 
            this.tb_maCount.Location = new System.Drawing.Point(136, 9);
            this.tb_maCount.Name = "tb_maCount";
            this.tb_maCount.Size = new System.Drawing.Size(54, 25);
            this.tb_maCount.TabIndex = 2;
            // 
            // tb_envelopValue
            // 
            this.tb_envelopValue.Location = new System.Drawing.Point(136, 40);
            this.tb_envelopValue.Name = "tb_envelopValue";
            this.tb_envelopValue.Size = new System.Drawing.Size(54, 25);
            this.tb_envelopValue.TabIndex = 3;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(12, 248);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 4;
            this.btn_start.Text = "산출";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_getError
            // 
            this.btn_getError.Location = new System.Drawing.Point(122, 248);
            this.btn_getError.Name = "btn_getError";
            this.btn_getError.Size = new System.Drawing.Size(75, 23);
            this.btn_getError.TabIndex = 5;
            this.btn_getError.Text = "에러검출";
            this.btn_getError.UseVisualStyleBackColor = true;
            this.btn_getError.Click += new System.EventHandler(this.btn_getError_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "저항지지선 비율";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 283);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_getError);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.tb_envelopValue);
            this.Controls.Add(this.tb_maCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(227, 330);
            this.MinimumSize = new System.Drawing.Size(227, 330);
            this.Name = "Form1";
            this.Text = "산출";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_maCount;
        private System.Windows.Forms.TextBox tb_envelopValue;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_getError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}

