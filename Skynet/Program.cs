using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Skynet
{
    internal static class Program
    {
        private class Input
        {
            public bool VsCodeChkBox { get; set; }
            public bool WaterfoxChkBox { get; set; }
        }

        private static void Main()
        {
            using (var myDialog = new Form())
            {
                myDialog.Width = 400;
                myDialog.Height = 200;
                myDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                myDialog.StartPosition = FormStartPosition.CenterScreen;
                var textLabel = new Label() { Left = 50, Width = 350, Top = 20, Text = "Start the world domination?" };
                var vsCodeChkBox = new CheckBox() { Text = "run VS Code", Left = 50, Width = 350, Top = 40, };
                var chkBox = new CheckBox() { Text = "run Waterfox", Left = 50, Width = 350, Top = 65, };

                var confirmProcess = new Button()
                    { Text = "Yes", Left = 100, Width = 75, Top = 100, DialogResult = DialogResult.OK };
                var cancelProcess = new Button()
                    { Text = "No", Left = 200, Width = 100, Top = 100, DialogResult = DialogResult.Cancel };

                myDialog.Controls.Add(textLabel);
                myDialog.Controls.Add(vsCodeChkBox);
                myDialog.Controls.Add(chkBox);
                myDialog.Controls.Add(confirmProcess);
                myDialog.Controls.Add(cancelProcess);

                myDialog.AcceptButton = confirmProcess;
                myDialog.CancelButton = cancelProcess;

                if (myDialog.ShowDialog() != DialogResult.OK)
                    return;

                var request = new Input()
                {
                    VsCodeChkBox = vsCodeChkBox.Checked,
                    WaterfoxChkBox = chkBox.Checked,
                };

                WorldDomination(request);
            }
        }

        private static void WorldDomination(Input input)
        {
            TryStart(@"C:\Users\hai.nguyen\Downloads\jira-mcp-windows-x64 (1)\jira-mcp.exe");

            TryStart(@"C:\Program Files\Docker\Docker\Docker Desktop.exe");
            TryStart(@"C:\Program Files\JetBrains\JetBrains Rider 2022.3.2\bin\rider64.exe");

            if (input.VsCodeChkBox)
                TryStart(@"C:\Program Files\Microsoft VS Code\Code.exe");

            TryStart(@"C:\Program Files\Notepad++\notepad++.exe");
            TryStart(@"C:\Program Files\Slack\slack.exe");

            if (input.WaterfoxChkBox)
                TryStart(@"C:\Program Files\Waterfox\waterfox.exe");

            TryStart(@"C:\Program Files\Google\Chrome\Application\chrome.exe");
        }

        private static void TryStart(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {
                // One bad/missing path must not stop the rest of the launch sequence.
                Console.Error.WriteLine("Failed to start '{0}': {1}", path, ex.Message);
            }
        }
    }
}
