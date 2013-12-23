namespace KitchenTimer
{
    partial class KitchenTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenTimer));
            this.timmerTabs = new System.Windows.Forms.TabControl();
            this.alarmChooser = new System.Windows.Forms.Button();
            this.newTimer = new System.Windows.Forms.Button();
            this.timmerSelectDown = new System.Windows.Forms.Button();
            this.timmerSelectUp = new System.Windows.Forms.Button();
            this.openAlarmFile = new System.Windows.Forms.OpenFileDialog();
            this.alarmFilename = new System.Windows.Forms.Label();
            this.preventSleep = new System.Windows.Forms.CheckBox();
            this.deleteTimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timmerTabs
            // 
            this.timmerTabs.Location = new System.Drawing.Point(2, 50);
            this.timmerTabs.Name = "timmerTabs";
            this.timmerTabs.SelectedIndex = 0;
            this.timmerTabs.Size = new System.Drawing.Size(374, 111);
            this.timmerTabs.TabIndex = 0;
            // 
            // alarmChooser
            // 
            this.alarmChooser.Location = new System.Drawing.Point(276, 8);
            this.alarmChooser.Name = "alarmChooser";
            this.alarmChooser.Size = new System.Drawing.Size(100, 23);
            this.alarmChooser.TabIndex = 3;
            this.alarmChooser.Text = "Change Alarm";
            this.alarmChooser.UseVisualStyleBackColor = true;
            this.alarmChooser.Click += new System.EventHandler(this.alarmChooser_Click);
            // 
            // newTimer
            // 
            this.newTimer.Location = new System.Drawing.Point(2, 12);
            this.newTimer.Name = "newTimer";
            this.newTimer.Size = new System.Drawing.Size(50, 23);
            this.newTimer.TabIndex = 1;
            this.newTimer.Text = "New";
            this.newTimer.UseVisualStyleBackColor = true;
            this.newTimer.Click += new System.EventHandler(this.newTimer_Click);
            // 
            // timmerSelectDown
            // 
            this.timmerSelectDown.Location = new System.Drawing.Point(115, 13);
            this.timmerSelectDown.Name = "timmerSelectDown";
            this.timmerSelectDown.Size = new System.Drawing.Size(23, 23);
            this.timmerSelectDown.TabIndex = 3;
            this.timmerSelectDown.Text = "<";
            this.timmerSelectDown.UseVisualStyleBackColor = true;
            this.timmerSelectDown.Click += new System.EventHandler(this.timmerSelectDown_Click);
            // 
            // timmerSelectUp
            // 
            this.timmerSelectUp.Location = new System.Drawing.Point(145, 13);
            this.timmerSelectUp.Name = "timmerSelectUp";
            this.timmerSelectUp.Size = new System.Drawing.Size(23, 23);
            this.timmerSelectUp.TabIndex = 4;
            this.timmerSelectUp.Text = ">";
            this.timmerSelectUp.UseVisualStyleBackColor = true;
            this.timmerSelectUp.Click += new System.EventHandler(this.timmerSelectUp_Click);
            // 
            // openAlarmFile
            // 
            this.openAlarmFile.FileName = "Alarm.wma";
            this.openAlarmFile.Filter = "Wave Sound (*.wav)|*.wav";
            // 
            // alarmFilename
            // 
            this.alarmFilename.AutoSize = true;
            this.alarmFilename.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::KitchenTimer.Properties.Settings.Default, "alarmFilePathSetting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.alarmFilename.Location = new System.Drawing.Point(174, 32);
            this.alarmFilename.MaximumSize = new System.Drawing.Size(200, 13);
            this.alarmFilename.Name = "alarmFilename";
            this.alarmFilename.Size = new System.Drawing.Size(63, 13);
            this.alarmFilename.TabIndex = 5;
            this.alarmFilename.Text = global::KitchenTimer.Properties.Settings.Default.alarmFilePathSetting;
            // 
            // preventSleep
            // 
            this.preventSleep.AutoSize = true;
            this.preventSleep.Checked = global::KitchenTimer.Properties.Settings.Default.preventSleepSetting;
            this.preventSleep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.preventSleep.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::KitchenTimer.Properties.Settings.Default, "preventSleepSetting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.preventSleep.Location = new System.Drawing.Point(177, 12);
            this.preventSleep.Name = "preventSleep";
            this.preventSleep.Size = new System.Drawing.Size(93, 17);
            this.preventSleep.TabIndex = 2;
            this.preventSleep.Text = "Prevent Sleep";
            this.preventSleep.UseVisualStyleBackColor = true;
            this.preventSleep.CheckedChanged += new System.EventHandler(this.preventSleep_CheckedChanged);
            // 
            // deleteTimer
            // 
            this.deleteTimer.Location = new System.Drawing.Point(59, 13);
            this.deleteTimer.Name = "deleteTimer";
            this.deleteTimer.Size = new System.Drawing.Size(50, 23);
            this.deleteTimer.TabIndex = 6;
            this.deleteTimer.Text = "Del";
            this.deleteTimer.UseVisualStyleBackColor = true;
            this.deleteTimer.Click += new System.EventHandler(this.deleteTimer_Click);
            // 
            // KitchenTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 162);
            this.Controls.Add(this.deleteTimer);
            this.Controls.Add(this.alarmFilename);
            this.Controls.Add(this.timmerSelectUp);
            this.Controls.Add(this.alarmChooser);
            this.Controls.Add(this.timmerSelectDown);
            this.Controls.Add(this.preventSleep);
            this.Controls.Add(this.newTimer);
            this.Controls.Add(this.timmerTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KitchenTimer";
            this.Text = "KitchenTimer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl timmerTabs;
        private System.Windows.Forms.Button newTimer;
        private System.Windows.Forms.Button timmerSelectDown;
        private System.Windows.Forms.Button timmerSelectUp;
        private System.Windows.Forms.CheckBox preventSleep;
        private System.Windows.Forms.Button alarmChooser;
        private System.Windows.Forms.OpenFileDialog openAlarmFile;
        private System.Windows.Forms.Label alarmFilename;
        private System.Windows.Forms.Button deleteTimer;
    }
}

