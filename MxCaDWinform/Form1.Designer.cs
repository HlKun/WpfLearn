
namespace MxCADWinform
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
            this.axMxDrawX1 = new AxMxDrawXLib.AxMxDrawX();
            ((System.ComponentModel.ISupportInitialize)(this.axMxDrawX1)).BeginInit();
            this.SuspendLayout();
            // 
            // axMxDrawX1
            // 
            this.axMxDrawX1.Enabled = true;
            this.axMxDrawX1.Location = new System.Drawing.Point(404, 215);
            this.axMxDrawX1.Name = "axMxDrawX1";
            this.axMxDrawX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMxDrawX1.OcxState")));
            this.axMxDrawX1.Size = new System.Drawing.Size(100, 50);
            this.axMxDrawX1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axMxDrawX1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axMxDrawX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxMxDrawXLib.AxMxDrawX axMxDrawX1;
    }
}

