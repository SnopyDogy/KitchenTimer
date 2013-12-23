using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//the following Using staments were added to help prevent sleep mode.
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KitchenTimer
{
    public partial class KitchenTimer : Form
    {

        /// <summary>
        /// Stroes the total number of timers currently in use
        /// </summary>
        int numberOfTimmers;

        /// <summary>
        /// List of timmerControls, allows each tab to have a different timer.
        /// </summary>
        List<timmerControl> timmerControls;

        /// <summary>
        /// This SoundPlayer plays/test the alarm sound
        /// </summary>
        System.Media.SoundPlayer alarmSoundTester;


        System.Windows.Forms.ToolTip toolTip;


        const string DefaultAlarmPath = "%windir%/Alarm01.wav";


        public KitchenTimer()
        {
            InitializeComponent();

            // initialize number of timmers to 0
            numberOfTimmers = 0;
            timmerControls = new List<timmerControl>();
            //maxTimerTabs = 0;
            //timmerControls = new timmerControl[maxTimerTabs];

            toolTip = new ToolTip();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            toolTip.SetToolTip(this.newTimer, "Creates a new Timer tab");                                                   // sets up tooltip for new button
            toolTip.SetToolTip(this.preventSleep, "Prevents the PC from going to Sleep");                                   //sets up tool tip for sleep setting tick box
            toolTip.SetToolTip(this.alarmChooser, "Browes for a different alarm sound, must be a wave (*.wav) file");       //sets up tool tip for change alarm button
            toolTip.SetToolTip(this.alarmFilename, String.Format("The current alarm is {0}", alarmFilename.Text));          //sets up tool tip for alarm text box
            toolTip.SetToolTip(this.timmerSelectDown, "Selects the next idle Timer to the left");                           //sets up tool tip for left (down) idle selector
            toolTip.SetToolTip(this.timmerSelectUp, "Selects the next idle Timer to the right");                            //sets up tool tip for right (up) idle selector
            toolTip.SetToolTip(this.deleteTimer, "Deletes the currently selected tab");                                     //sets up tool tip for right (up) idle selector

            //disable selector buttons until new tab created to prevent crahses
            timmerSelectDown.Enabled = false;
            timmerSelectUp.Enabled = false;

            //load settings
            Properties.Settings.Default.Reload();

            //apply sleep mode setting
            if (Properties.Settings.Default.preventSleepSetting)
            {
                // Prevent Idle-to-Sleep (monitor not affected) (see note above)
                NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_AWAYMODE_REQUIRED);
            } 
        }

        /// <summary>
        /// The following class is used to help prevent the PC from entering sleep mode.
        /// </summary>
        internal static class NativeMethods
        {
            // Import SetThreadExecutionState Win32 API and necessary flags
            [DllImport("kernel32.dll")]
            public static extern uint SetThreadExecutionState(uint esFlags);
            public const uint ES_CONTINUOUS = 0x80000000;
            public const uint ES_SYSTEM_REQUIRED = 0x00000001;
            public const uint ES_AWAYMODE_REQUIRED = 0x00000040;
        }

        /// <summary>
        /// Sets the excution state to allow/prevent the PC from going to Sleep according to the Sleep setting tick box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void preventSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (preventSleep.Checked)
            {
                // Prevent Idle-to-Sleep (monitor not affected) (see note above)
                NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_AWAYMODE_REQUIRED);
            }
            else
            {
                // return to previous/default excution state (allow sleep mode).
                NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS);
            }
        }

        private void newTimer_Click(object sender, EventArgs e)
        {
            // allow aditional tabs if required.
            //if (numberOfTimmers == maxTimerTabs)
           // {
            //    maxTimerTabs++;
            //    timmerControls = new timmerControl[maxTimerTabs];
           // }
            
            //get name for the tab.
            InputBox inputBox = new InputBox("Name Timer?", "Name of new Timer?", String.Format("Timmer#{0}", numberOfTimmers));
            inputBox.Show();

            if (!inputBox.InputCancled)
            {
                //add new timmer tab with user inputed name
                timmerTabs.TabPages.Add(String.Format("timmerTab{0}", numberOfTimmers), inputBox.returnText, numberOfTimmers);

                // create new timmer UI elements
                //timmerControls[numberOfTimmers] = new timmerControl(this, numberOfTimmers);
                timmerControls.Add(new timmerControl(this, numberOfTimmers));
                // add timer to tab
                timmerTabs.TabPages[String.Format("timmerTab{0}", numberOfTimmers)].Controls.Add(timmerControls[numberOfTimmers]);

                //set currently selected timmer tab to new tab
                timmerTabs.SelectedIndex = numberOfTimmers;

                //increase number of timmers by one
                numberOfTimmers++;
            }

            if (numberOfTimmers > 0)
            {
                //enable selector buttons until new tab created to prevent crahses
                timmerSelectDown.Enabled = true;
                timmerSelectUp.Enabled = true;
            }
            else
            {
                //disable selector buttons to prevent crashes
                timmerSelectDown.Enabled = false;
                timmerSelectUp.Enabled = false;
            }
        }

        private void timmerSelectDown_Click(object sender, EventArgs e)
        {
            // loop through the tabs to the left (down) looking for one where the timmer isn't running
            for (int i = timmerTabs.SelectedIndex; i >= 0; i--)
            {
                if (timmerControls[i].IsTimerRunning == false)
                {
                    timmerTabs.SelectedIndex = i;
                    break;
                }
            }
        }

        private void timmerSelectUp_Click(object sender, EventArgs e)
        {
            // loop through the tabs to the right (up) looking for one where the timmer isn't running
            for (int i = timmerTabs.SelectedIndex; i < numberOfTimmers; i++)
            {
                if (i >= 0)
                {
                    if (timmerControls[i].IsTimerRunning == false)
                    {
                        timmerTabs.SelectedIndex = i;
                        break;
                    }
                }
            }
        }


        private void deleteTimer_Click(object sender, EventArgs e)
        {
            //clear then delete the unused timer form.
            timmerControls[timmerTabs.SelectedIndex].timmerClearForDel();
            timmerControls.RemoveAt(timmerTabs.SelectedIndex);

            //delete tab.
            timmerTabs.TabPages.RemoveAt(timmerTabs.SelectedIndex);

            // decrease the number of tabs acordingly.
            numberOfTimmers--;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save application settings
            Properties.Settings.Default.Save();
        }

        private void alarmChooser_Click(object sender, EventArgs e)
        {
            if (openAlarmFile.ShowDialog() == DialogResult.Cancel)
                return;

            // play new sound file to make sure that it works
            try
            {
                alarmSoundTester = new System.Media.SoundPlayer(openAlarmFile.FileName);
                alarmSoundTester.Play();
            }
            catch (System.InvalidOperationException exception)
            {
                MessageBox.Show("Alarm File could not be played!\n\nError Message: " + exception.ToString(), "Alarm Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); // == DialogResult.OK
                return;
            }

            //ask user if the file worked, if yes change settings, if no inform user to pick a wav file.
            if (MessageBox.Show("Can you hear the alarm?", "Alarm Test!", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    alarmFilename.Text = openAlarmFile.FileName;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error opening file", "File Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                alarmSoundTester.Stop();

                //update alarm path tool tip
                toolTip.SetToolTip(this.alarmFilename, String.Format("The current alarm is {0}", alarmFilename.Text));

                // Update the existing tabs:
                foreach (timmerControl timer in timmerControls)
                {
                    timer.UpdateAlarmSound(alarmFilename.Text);
                }

            }
            else
            {
                MessageBox.Show("Please select a different Wave file (*.wav), this one doesn't work.", "Test Failure!", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// gets the current path to the alarm file.
        /// </summary>
        public string AlarmFilename
        {
            get { return alarmFilename.Text; }
        }

        /// <summary>
        /// gets the index for the currently selected timer tab control
        /// </summary>
        public int activeTimerTab
        {
            set { timmerTabs.SelectedIndex = value; }
        }
    }
}