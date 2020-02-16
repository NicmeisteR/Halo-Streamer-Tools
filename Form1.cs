using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Halo_Streamer_Tools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            startStop.BackColor = Color.LawnGreen;
            // startStop.Enabled = false;
        }

        private bool start = true;
        private string _outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
        private int _seconds = 5;
        private CancellationTokenSource cancelSource;


        private string ApiKey = "YOUR-API-KEY-HERE";
        private int MaxXp = 50000000;
        private string gamertag;
        private int StartKills = 0;
        private int StartWins = 0;
        private int StartHeadshots = 0;
        private int StartXp = 0;
        private string Type = "arena";
        

        private void startStop_Click(object sender, EventArgs e)
        {
            gamertag = txt_gamertag.Text;

            if (start == true)
            {
                Start();
                cancelSource = new CancellationTokenSource();
                var timespan = TimeSpan.FromSeconds(60);
                var task = WatcherTask(timespan, cancelSource.Token);
                task.Start();
                //var input = Console.ReadLine();
                startStop.Text = "Stop";
                startStop.BackColor = Color.Red;
                start = false;
            }
            else
            {
                cancelSource.Cancel();
                startStop.Text = "Start";
                startStop.BackColor = Color.Green;
                start = true;
            }
        }

        string Get(string url)
        {

            var client = new RestClient($"https://www.haloapi.com/{url}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("ocp-apim-subscription-key", ApiKey);
            IRestResponse response = client.Execute(request);
            return response.Content;

        }

        public void Start()
        {
            var ResponseObjects = JsonConvert.DeserializeObject<dynamic>(Get($"stats/h5/servicerecords/{Type}?players={gamertag}"));
            if(Type == "arena")
            {
              StartWins = ResponseObjects.Results[0].Result.ArenaStats.TotalGamesWon;
              StartKills = ResponseObjects.Results[0].Result.ArenaStats.TotalKills;
              StartHeadshots = ResponseObjects.Results[0].Result.ArenaStats.TotalHeadshots;
              StartXp = ResponseObjects.Results[0].Result.Xp;
            }
            else
            {
              StartWins = ResponseObjects.Results[0].Result.CustomStats.TotalGamesWon;
              StartKills = ResponseObjects.Results[0].Result.CustomStats.TotalKills;
              StartHeadshots = ResponseObjects.Results[0].Result.CustomStats.TotalHeadshots;
              StartXp = ResponseObjects.Results[0].Result.Xp;
            }

        }

        void ShowStats()
        {
            var ResponseObject = JsonConvert.DeserializeObject<dynamic>(Get($"stats/h5/servicerecords/{Type}?players={gamertag}"));

            var Kills = "";
            var Wins = "";
            var Headshots = "";
            var Xp = "";

            if (Type == "arena")
            {
                Kills = $"Kills: {ResponseObject.Results[0].Result.ArenaStats.TotalKills - StartKills}";
                Wins = $"Wins: {ResponseObject.Results[0].Result.ArenaStats.TotalGamesWon - StartWins}";
                Headshots = $"Headshots: {ResponseObject.Results[0].Result.ArenaStats.TotalHeadshots - StartHeadshots}";
                Xp = $"XP: {ResponseObject.Results[0].Result.Xp - StartXp}";
            }
            else
            {
                Kills = $"Kills: {ResponseObject.Results[0].Result.CustomStats.TotalKills - StartKills}";
                Wins = $"Wins: {ResponseObject.Results[0].Result.CustomStats.TotalGamesWon - StartWins}";
                Headshots = $"Headshots: {ResponseObject.Results[0].Result.CustomStats.TotalHeadshots - StartHeadshots}";
                Xp = $"XP: {ResponseObject.Results[0].Result.Xp - StartXp}";
            }



            if (lbl_winstotal.InvokeRequired)
            {
                lbl_winstotal.Invoke(new MethodInvoker(delegate { lbl_winstotal.Text = Wins; }));
            }
            else
            {
                lbl_winstotal.Text = Wins;
            }

            if (lbl_kills.InvokeRequired)
            {
                lbl_kills.Invoke(new MethodInvoker(delegate { lbl_kills.Text = Kills; }));
            }
            else
            {
                lbl_kills.Text = Kills;
            }

            if (lbl_headshots.InvokeRequired)
            {
                lbl_headshots.Invoke(new MethodInvoker(delegate { lbl_headshots.Text = Headshots; }));
            }
            else
            {
                lbl_headshots.Text = Headshots;
            }

            if (lbl_xp.InvokeRequired)
            {
                lbl_xp.Invoke(new MethodInvoker(delegate { lbl_xp.Text = Xp; }));
            }
            else
            {
                lbl_xp.Text = Xp;
            }

            if (label3.InvokeRequired)
            {
                label3.Invoke(new MethodInvoker(delegate { label3.Text = "Last Update: " + DateTime.Now.ToString("h:mm:ss tt"); }));
            }
            else
            {
                label3.Text = DateTime.Now.ToString("h:mm:ss tt");
            }

            //Console.WriteLine($"{kills}\n{wins}\n{headshots}");
            //Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt") + " " + Kills);
            File.WriteAllText(_outputPath + "/kills.txt", Kills);
            File.WriteAllText(_outputPath + "/wins.txt", Wins);
            File.WriteAllText(_outputPath + "/headshots.txt", Headshots);
            File.WriteAllText(_outputPath + "/xp.txt", Xp);
        }

        Task WatcherTask(TimeSpan seconds, CancellationToken cancellationToken)
        {
            return new Task(async () =>
            {
                while (true)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        return;
                    }
                    ShowStats();
                    await Task.Delay(seconds);
                }
            }, cancellationToken);
        }

    private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
    {
      startStop.Enabled = true;
      ComboBox cmb = (ComboBox)sender;
      //int SelectedIndex = cmb.SelectedIndex;
      string selectedValue = (string)cmb.SelectedItem;

      Type = selectedValue.ToLower();
      //selectedGame = (string)cmb.SelectedItem;
    }
  }
}
