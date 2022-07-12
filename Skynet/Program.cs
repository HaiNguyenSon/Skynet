using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Skynet
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Form myDialog = new Form()
            {
                Width = 400,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Width = 350, Top = 20, Text = "Start the world domination?" };
            CheckBox vsCodeChkBox = new CheckBox() { Text = "include VS Code", Left = 50, Width = 350, Top = 40, };
            CheckBox spotifyChkBox = new CheckBox() { Text = "include Spotify", Left = 50, Width = 350, Top = 65, };

            Button confirmProcess = new Button()
                { Text = "Yes", Left = 100, Width = 75, Top = 100, DialogResult = DialogResult.OK };
            Button cancelProcess = new Button()
                { Text = "No", Left = 200, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };
            cancelProcess.Click += (sender, e) => { myDialog.Close(); };

            myDialog.Controls.Add(textLabel);
            myDialog.Controls.Add(vsCodeChkBox);
            myDialog.Controls.Add(spotifyChkBox);

            myDialog.Controls.Add(confirmProcess);
            myDialog.Controls.Add(cancelProcess);

            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                WorldDomination(vsCodeChkBox.Checked, spotifyChkBox.Checked);
            }
            else
                Application.Exit();
        }

        private static void WorldDomination(bool includeVsCode, bool includeSpotify)
        {
            try
            {
                // Process.Start("C:\\Program Files\\Docker\\Docker\\Docker Desktop.exe");
                Process.Start("C:\\Program Files\\JetBrains\\JetBrains Rider 2020.1.4\\bin\\rider64.exe");

                if (includeVsCode)
                    Process.Start("C:\\Program Files\\Microsoft VS Code\\Code.exe");

                Process.Start("C:\\Program Files (x86)\\Notepad++\\notepad++.exe");
                Process.Start("C:\\Users\\hai.nguyen\\AppData\\Local\\slack\\slack.exe");
                
                if (includeSpotify)
                    Process.Start("C:\\Users\\hai.nguyen\\AppData\\Roaming\\Spotify\\Spotify.exe");

                // Process.Start("C:\\Users\\hai.nguyen\\AppData\\Local\\gitkraken\\app-6.3.1\\gitkraken.exe");
                Process.Start("C:\\Users\\hai.nguyen\\AppData\\Local\\SourceTree\\SourceTree.exe");
                // Process.Start("C:\\Users\\hai.nguyen\\AppData\\Local\\GitHubDesktop\\GitHubDesktop.exe");

                // Process.Start("C:\\Users\\hai.nguyen\\AppData\\Local\\Programs\\Opera\\launcher.exe");
                Process.Start("C:\\Program Files\\Mozilla Firefox\\firefox.exe");
                Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe");

//                Process[] oneNote = Process.GetProcessesByName("ONENOTEM");
//                oneNote[0]?.Kill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}