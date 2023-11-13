using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class MainForm : Form
{
    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool LockWorkStation();

    private Timer studyTimer = new Timer();

    public MainForm()
    {
        InitializeComponent();

        studyTimer.Interval = 600000;
        studyTimer.Tick += StudyTimer_Tick;

        studyTimer.Start();
    }

    private void StudyTimer_Tick(object sender, EventArgs e)
    {
        LockComputer();
        PromptSubjectSelection();
    }

    private void LockComputer()
    {
        LockWorkStation();
    }

    private void PromptSubjectSelection()
    {

    }

    private void FinishedStudyingButton_Click(object sender, EventArgs e)
    {
        studyTimer.Stop();
        GenerateQuestions();
    }

    private void GenerateQuestions()
    {
    }

}
