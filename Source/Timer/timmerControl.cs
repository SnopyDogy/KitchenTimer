using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KitchenTimer
{
    public partial class timmerControl : UserControl
    {
        /// <summary>
        /// This bool will keep tell if the timmer is running
        /// </summary>
        bool isTimerRunning = false;

        /// <summary>
        /// This TimeSpan keeps trak of how much time is left until the alarm goes off
        /// </summary>
        TimeSpan timeLeft;

        /// <summary>
        /// This is used to store the date/time that the alarm should go off
        /// </summary>
        DateTime AlarmTriggerDateTime;

        /// <summary>
        /// This SoundPlayer plays the alarm sound
        /// </summary>
        System.Media.SoundPlayer alarmSoundPlayer;

        /// <summary>
        /// Used to reference timer tab index
        /// </summary>
        int timerTabIndex;

        /// <summary>
        /// Allows access to this controls parent form
        /// </summary>
        KitchenTimer parentForm;


        System.Windows.Forms.ToolTip ToolTip;

        public timmerControl(KitchenTimer a_ParentForm, int timerIndex)
        {
            InitializeComponent();
            timmerStop.Enabled = false;

            timerTabIndex = timerIndex;
            parentForm = a_ParentForm;

            alarmSoundPlayer = new System.Media.SoundPlayer(parentForm.AlarmFilename);

            alarmTriggerDateTimeSelector.Value = DateTime.Now;
            alarmTriggerDateTimeSelector.Format = DateTimePickerFormat.Custom;
            alarmTriggerDateTimeSelector.CustomFormat = " hh:mm tt, dd/MM/yy"; // see http://msdn.microsoft.com/en-us/library/system.windows.forms.datetimepicker.customformat.aspx for custom string info.

            ToolTip = new ToolTip();
        }

        private void timmerControl_Load(object sender, System.EventArgs e)
        {
            ToolTip.SetToolTip(alarmTriggerDateTimeSelector, "Set the Date/Time for when you want the alarm to go off");  // sets up tooltip for notes trigger date/time picker
            ToolTip.SetToolTip(timmerHours, "Enter number of hours to time");           // sets up tool tip for timmerHours
            ToolTip.SetToolTip(timmerMinutes, "Enter number of minutes to time");       // sets up tool tip for timmerMinutes
            ToolTip.SetToolTip(timmerSeconds, "Enter number of seconds to time");       // sets up tool tip for timmerSeconds
            ToolTip.SetToolTip(timmerStart, "Press to start the timer");                // sets up tool tip for start button
            ToolTip.SetToolTip(timmerStop, "Press to stop the timmer");                 //sets up tool tip for stop button
            ToolTip.SetToolTip(timmerClear, "Press to clear/reset timmer");             //sets up tool tip for clear button
            ToolTip.SetToolTip(muteAlarm, "Prevents the alarm from playing when this timer goes off");      //sets up tool tip for mute tick box
            ToolTip.SetToolTip(this.popupAlarm, "The alarm window will popup when this timer goes off");    //sets up tool tip for popup tick box
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (AlarmTriggerDateTime.CompareTo(DateTime.Now) > 0 && isTimerRunning)  //will equate to true if the timmer is currently running and not 0.
            {
                // calulate new values for alarm timers
                timeLeft = AlarmTriggerDateTime.Subtract(DateTime.Now);

                timmerSeconds.Value = timeLeft.Seconds;
                timmerMinutes.Value = timeLeft.Minutes;
                timmerHours.Value = timeLeft.Hours;
            }
            else //sound alarm as all times are 0!!!
            {

                if (muteAlarm.Checked != true)
                {
                    //then play alarm
                    try
                    {
                        alarmSoundPlayer.PlayLooping();
                    }
                    catch (System.IO.FileNotFoundException exception)
                    {
                        // Stop the alarm:
                        if (MessageBox.Show("Alarm File could not be played, Have you set the Alarm?\n\nError Message: " + exception.ToString(), "Alarm Error!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                        {
                            alarmSoundPlayer.Stop();
                            timmerStart.Enabled = true;
                            timmerStop.Enabled = false;
                            isTimerRunning = false;
                        }
                    }
                }

                if (popupAlarm.Checked)
                {
                    //then popup the window
                    parentForm.Activate();
                }

                parentForm.activeTimerTab = timerTabIndex;
                timmerStart.Enabled = true;
                timer.Stop();
            }
        }

        private void timmerStart_Click(object sender, EventArgs e)
        {
            //initialse the timer values to what was entered by the user...
            timeLeft = new TimeSpan((int)timmerHours.Value, (int)timmerMinutes.Value, (int)timmerSeconds.Value);

            //Calculate the date/time when the alarm should trigger...
            AlarmTriggerDateTime = DateTime.Now;
            AlarmTriggerDateTime = AlarmTriggerDateTime.Add(timeLeft);

            isTimerRunning = true;

            //start the timer
            timer.Start();

            timmerStart.Enabled = false;
            timmerStop.Enabled = true;
        }

        private void timmerStop_Click(object sender, EventArgs e)
        {
            // check if there is time left and stop the timer
            //otherwise stop the alarm from sounding.
            if (timeLeft.TotalSeconds > 0) // if there is any time left this will be true
            {
                timer.Stop();
                alarmSoundPlayer.Stop();
                timmerStart.Enabled = true;
                isTimerRunning = false;
            }
            else
            {
                alarmSoundPlayer.Stop();
                timmerStart.Enabled = true;
                timmerStop.Enabled = false;
                isTimerRunning = false;
            }
        }

        private void timmerClear_Click(object sender, EventArgs e)
        {
            timer.Stop();
            alarmSoundPlayer.Stop();
            isTimerRunning = false;
            timmerSeconds.Value = 0;
            timmerMinutes.Value = 0;
            timmerHours.Value = 0;
            timmerStart.Enabled = true;
            timmerStop.Enabled = false;
        }

        private void muteAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (muteAlarm.Checked)
            {
                //check the pupup box to ensure that there is still some visable notice of the alarm going off.
                popupAlarm.Checked = true;
            }
        } 

        /// <summary>
        /// used by a parent form to stop the timer prior to deleting it.
        /// </summary>
        public void timmerClearForDel()
        {
            timer.Stop();
            alarmSoundPlayer.Stop();
            isTimerRunning = false;
        }

        private void alarmTriggerDateTimeSelector_ValueChanged(object sender, EventArgs e)
        {
            AlarmTriggerDateTime = alarmTriggerDateTimeSelector.Value;
            // calulate new values for alarm timers
            timeLeft = AlarmTriggerDateTime.Subtract(DateTime.Now);

            NumicUpDownClampAndSetValue(timeLeft.Seconds, timmerSeconds);
            NumicUpDownClampAndSetValue(timeLeft.Minutes, timmerMinutes);
            NumicUpDownClampAndSetValue(timeLeft.Hours + (timeLeft.Days * 24), timmerHours); // need to add the number of days * 24 to get the correct number of hours.
        }

        /// <summary>
        /// used to get and set the status of the timer, i.e. is it running or not running.
        /// </summary>
        public bool IsTimerRunning
        {
            get { return isTimerRunning; }
            set { isTimerRunning = value; }
        }


        void NumicUpDownClampAndSetValue(int value, NumericUpDown numericUpDown)
        {
            if (value < numericUpDown.Minimum)
            {
                numericUpDown.Value = numericUpDown.Minimum; 
            }
            else if (value > numericUpDown.Maximum)
            {
                numericUpDown.Value = numericUpDown.Maximum;
            }
            else
            {
                numericUpDown.Value = value;
            }
        }

        public void UpdateAlarmSound(string a_AlarmFile)
        {
            alarmSoundPlayer = new System.Media.SoundPlayer(a_AlarmFile);
        }

    }
}
