namespace KitchenTimer
{
    partial class timmerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timmerStart = new System.Windows.Forms.Button();
            this.timmerStop = new System.Windows.Forms.Button();
            this.timmerClear = new System.Windows.Forms.Button();
            this.timmerHours = new System.Windows.Forms.NumericUpDown();
            this.timmerMinutes = new System.Windows.Forms.NumericUpDown();
            this.timmerSeconds = new System.Windows.Forms.NumericUpDown();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.alarmTriggerDateTimeSelector = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.muteAlarm = new System.Windows.Forms.CheckBox();
            this.popupAlarm = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.timmerHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timmerMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timmerSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // timmerStart
            // 
            this.timmerStart.Location = new System.Drawing.Point(4, 55);
            this.timmerStart.Name = "timmerStart";
            this.timmerStart.Size = new System.Drawing.Size(50, 23);
            this.timmerStart.TabIndex = 0;
            this.timmerStart.Text = "Start";
            this.timmerStart.UseVisualStyleBackColor = true;
            this.timmerStart.Click += new System.EventHandler(this.timmerStart_Click);
            // 
            // timmerStop
            // 
            this.timmerStop.Location = new System.Drawing.Point(60, 55);
            this.timmerStop.Name = "timmerStop";
            this.timmerStop.Size = new System.Drawing.Size(50, 23);
            this.timmerStop.TabIndex = 1;
            this.timmerStop.Text = "Stop";
            this.timmerStop.UseVisualStyleBackColor = true;
            this.timmerStop.Click += new System.EventHandler(this.timmerStop_Click);
            // 
            // timmerClear
            // 
            this.timmerClear.Location = new System.Drawing.Point(118, 55);
            this.timmerClear.Name = "timmerClear";
            this.timmerClear.Size = new System.Drawing.Size(50, 23);
            this.timmerClear.TabIndex = 2;
            this.timmerClear.Text = "Clear";
            this.timmerClear.UseVisualStyleBackColor = true;
            this.timmerClear.Click += new System.EventHandler(this.timmerClear_Click);
            // 
            // timmerHours
            // 
            this.timmerHours.Location = new System.Drawing.Point(4, 29);
            this.timmerHours.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.timmerHours.Name = "timmerHours";
            this.timmerHours.Size = new System.Drawing.Size(50, 20);
            this.timmerHours.TabIndex = 3;
            // 
            // timmerMinutes
            // 
            this.timmerMinutes.Location = new System.Drawing.Point(60, 29);
            this.timmerMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.timmerMinutes.Name = "timmerMinutes";
            this.timmerMinutes.Size = new System.Drawing.Size(50, 20);
            this.timmerMinutes.TabIndex = 4;
            // 
            // timmerSeconds
            // 
            this.timmerSeconds.Location = new System.Drawing.Point(116, 29);
            this.timmerSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.timmerSeconds.Name = "timmerSeconds";
            this.timmerSeconds.Size = new System.Drawing.Size(50, 20);
            this.timmerSeconds.TabIndex = 5;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Time Left:";
            // 
            // alarmTriggerDateTimeSelector
            // 
            this.alarmTriggerDateTimeSelector.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.alarmTriggerDateTimeSelector.Location = new System.Drawing.Point(192, 25);
            this.alarmTriggerDateTimeSelector.Name = "alarmTriggerDateTimeSelector";
            this.alarmTriggerDateTimeSelector.Size = new System.Drawing.Size(175, 20);
            this.alarmTriggerDateTimeSelector.TabIndex = 7;
            this.alarmTriggerDateTimeSelector.Value = new System.DateTime(2013, 2, 1, 0, 0, 0, 0);
            this.alarmTriggerDateTimeSelector.ValueChanged += new System.EventHandler(this.alarmTriggerDateTimeSelector_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(189, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Alarm Trigger Time:";
            // 
            // muteAlarm
            // 
            this.muteAlarm.AutoSize = true;
            this.muteAlarm.Location = new System.Drawing.Point(192, 55);
            this.muteAlarm.Name = "muteAlarm";
            this.muteAlarm.Size = new System.Drawing.Size(50, 17);
            this.muteAlarm.TabIndex = 9;
            this.muteAlarm.Text = "Mute";
            this.muteAlarm.UseVisualStyleBackColor = true;
            this.muteAlarm.CheckedChanged += new System.EventHandler(this.muteAlarm_CheckedChanged);
            // 
            // popupAlarm
            // 
            this.popupAlarm.AutoSize = true;
            this.popupAlarm.Location = new System.Drawing.Point(248, 55);
            this.popupAlarm.Name = "popupAlarm";
            this.popupAlarm.Size = new System.Drawing.Size(57, 17);
            this.popupAlarm.TabIndex = 10;
            this.popupAlarm.Text = "Popup";
            this.popupAlarm.UseVisualStyleBackColor = true;
            // 
            // timmerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupAlarm);
            this.Controls.Add(this.muteAlarm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.alarmTriggerDateTimeSelector);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timmerSeconds);
            this.Controls.Add(this.timmerMinutes);
            this.Controls.Add(this.timmerHours);
            this.Controls.Add(this.timmerClear);
            this.Controls.Add(this.timmerStop);
            this.Controls.Add(this.timmerStart);
            this.Name = "timmerControl";
            this.Size = new System.Drawing.Size(370, 80);
            this.Load += new System.EventHandler(this.timmerControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.timmerHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timmerMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timmerSeconds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button timmerStart;
        private System.Windows.Forms.Button timmerStop;
        private System.Windows.Forms.Button timmerClear;
        private System.Windows.Forms.NumericUpDown timmerHours;
        private System.Windows.Forms.NumericUpDown timmerMinutes;
        private System.Windows.Forms.NumericUpDown timmerSeconds;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker alarmTriggerDateTimeSelector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox muteAlarm;
        private System.Windows.Forms.CheckBox popupAlarm;
    }
}
