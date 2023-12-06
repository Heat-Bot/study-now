using System;
using System.Windows.Forms;
using System.Timers;

namespace StudyNow
{
    public partial class MainForm : Form
    {
        private System.Timers.Timer timer;
        private bool active = false;
        private bool paused = false;
        private bool subjectSelected = false;
        private int activeMinutes = 0;

        public MainForm()
        {
            InitializeComponent();

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval = 1000;  
            timer.Enabled = true;
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (active && !paused)
            {
                activeMinutes++;

                if (activeMinutes >= 50)
                {
                    timer.Stop();
                    paused = true;
                    active = false;
                    SelectSubjectDialog();
                }
            }
        }

        private void SelectSubjectDialog()
        {
            if (subjectSelected)
            {
                ResumeStudying();
            }
        }

        private void ResumeStudying()
        {
            subjectSelected = false;
            activeMinutes = 0;
            timer.Start();
            paused = false;
            active = true;
        }

        private void FinishedStudyingButton_Click(object sender, EventArgs e)
        {
            ResumeStudying();
        }
    }
}