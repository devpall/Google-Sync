namespace Google_Sync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cal_box = new System.Windows.Forms.CheckBox();
            this.task_box = new System.Windows.Forms.CheckBox();
            this.contact_box = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Tasksbox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.Tasksbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.contact_box);
            this.groupBox1.Controls.Add(this.task_box);
            this.groupBox1.Controls.Add(this.cal_box);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cal_box
            // 
            resources.ApplyResources(this.cal_box, "cal_box");
            this.cal_box.Name = "cal_box";
            this.cal_box.UseVisualStyleBackColor = true;
            // 
            // task_box
            // 
            resources.ApplyResources(this.task_box, "task_box");
            this.task_box.Name = "task_box";
            this.task_box.UseVisualStyleBackColor = true;
            // 
            // contact_box
            // 
            resources.ApplyResources(this.contact_box, "contact_box");
            this.contact_box.Name = "contact_box";
            this.contact_box.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Tasksbox
            // 
            this.Tasksbox.Controls.Add(this.label1);
            resources.ApplyResources(this.Tasksbox, "Tasksbox");
            this.Tasksbox.Name = "Tasksbox";
            this.Tasksbox.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Tasksbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Tasksbox.ResumeLayout(false);
            this.Tasksbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox contact_box;
        private System.Windows.Forms.CheckBox task_box;
        private System.Windows.Forms.CheckBox cal_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox Tasksbox;
        private System.Windows.Forms.Label label1;
    }
}

