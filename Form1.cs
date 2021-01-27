using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private string ApiKey = "f4bfe0061ba84032b87aeb1c00600dc3";
        private int MaxXp = 50000000;
        private string gamertag;

        private int WinStreak = 0;
        private int TotalWins = 0;
        private int TotalLosses = 0;

        private int StartWins = 0;
        private int StartLosses = 0;
        private int StartKills = 0;
        private int StartHeadshots = 0;
        private int StartXp = 0;
        private string Type = "arena";

        List<string> StartStats;


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
            //   Stats.Arena(ResponseObjects);
                StartWins = ResponseObjects.Results[0].Result.ArenaStats.TotalGamesWon;
                StartLosses = ResponseObjects.Results[0].Result.ArenaStats.TotalGamesLost;
                StartKills = ResponseObjects.Results[0].Result.ArenaStats.TotalKills;
                StartHeadshots = ResponseObjects.Results[0].Result.ArenaStats.TotalHeadshots;
                StartXp = ResponseObjects.Results[0].Result.Xp;
            }
            else
            {
            //   Stats.Custom(ResponseObjects);
                StartWins = ResponseObjects.Results[0].Result.CustomStats.TotalGamesWon;
                StartLosses = ResponseObjects.Results[0].Result.CustomStats.TotalGamesLost;
                StartKills = ResponseObjects.Results[0].Result.CustomStats.TotalKills;
                StartHeadshots = ResponseObjects.Results[0].Result.CustomStats.TotalHeadshots;
                StartXp = ResponseObjects.Results[0].Result.Xp;
            }

        }

        void ShowStats()
        {
            var ResponseObject = JsonConvert.DeserializeObject<dynamic>(Get($"stats/h5/servicerecords/{Type}?players={gamertag}"));

            var Streak = "";
            var tempWins = TotalWins;
            var tempLosses = TotalLosses;
            Debug.WriteLine(tempLosses);

            var Wins = "";
            var Losses = "";


            var Kills = "";
            var Headshots = "";
            var Xp = "";

            if (Type == "arena")
            {
                TotalWins = ResponseObject.Results[0].Result.ArenaStats.TotalGamesWon - StartWins;
                TotalLosses = ResponseObject.Results[0].Result.ArenaStats.TotalGamesLost - StartLosses;
                 Debug.WriteLine(TotalWins);
                if (TotalLosses != tempLosses)
                {
                  WinStreak = 0;
                }
                else
                {
                  if (TotalWins != tempWins)
                  {
                    WinStreak = WinStreak + 1;
                  }
                }

                Streak = $"Streak: {WinStreak}";
                Kills = $"Kills: {ResponseObject.Results[0].Result.ArenaStats.TotalKills - StartKills}";
                Wins = $"Wins: {ResponseObject.Results[0].Result.ArenaStats.TotalGamesWon - StartWins}";
                Losses = $"Losses: {ResponseObject.Results[0].Result.ArenaStats.TotalGamesLost - StartLosses}";
                Headshots = $"Headshots: {ResponseObject.Results[0].Result.ArenaStats.TotalHeadshots - StartHeadshots}";
                Xp = $"XP: {ResponseObject.Results[0].Result.Xp - StartXp}";
            }
            else
            {
                Debug.WriteLine(TotalLosses);
                TotalWins = ResponseObject.Results[0].Result.CustomStats.TotalGamesWon - StartWins;
                TotalLosses = ResponseObject.Results[0].Result.CustomStats.TotalGamesLost - StartLosses;
                Debug.WriteLine(TotalLosses);
                if (TotalLosses != tempLosses)
                {
                  WinStreak = 0;
                }
                else
                {
                  if(TotalWins != tempWins)
                  {
                    WinStreak = WinStreak + 1;
                  }
                }

                Streak = $"Streak: {WinStreak}";
                Kills = $"Kills: {ResponseObject.Results[0].Result.CustomStats.TotalKills - StartKills}";
                Wins = $"Wins: {ResponseObject.Results[0].Result.CustomStats.TotalGamesWon - StartWins}";
                Losses = $"Losses: {ResponseObject.Results[0].Result.CustomStats.TotalGamesLost - StartLosses}";
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
            File.WriteAllText(_outputPath + "/streak.txt", Streak);
            File.WriteAllText(_outputPath + "/wins.txt", Wins);
            File.WriteAllText(_outputPath + "/losses.txt", Losses);
            File.WriteAllText(_outputPath + "/kills.txt", Kills);
            File.WriteAllText(_outputPath + "/headshots.txt", Headshots);
            File.WriteAllText(_outputPath + "/xp.txt", Xp);

            File.WriteAllText(_outputPath + "/all.txt", $"{Streak}       {Wins}       {Losses}       {Kills}       {Headshots}       {Xp}");
            UpdateTitle(txt_title.Text, $"{MaxXp - ResponseObject.Results[0].Result.Xp.ToObject<int>()}");
    }

        void UpdateTitle(string title, string xp){
            var client = new RestClient("https://api.twitch.tv/helix/channels?broadcaster_id=62429584");
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("authorization", "Bearer mmpzhnc85zcdxjy013n1ccb3b7rkng");
            request.AddHeader("client-id", "a96m941naggznrqpxc5tlpii8hk53m");
            request.AddHeader("content-type", "application/json");
            request.AddCookie("unique_id", "607cd02c136fa229");
            request.AddCookie("unique_id_durable", "607cd02c136fa229");
            request.AddCookie("twitch.lohp.countryCode", "ZA");
            request.AddParameter("application/json", @"{""game_id"":""369567"", ""title"":" + $@"""{title} {WinStreak} Win Streak, {xp} Xp till 152""," +  @"""broadcaster_language"":""en""}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
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

    private void btn_view_Click(object sender, EventArgs e)
    {
      System.Diagnostics.Process.Start(@"notepad.exe", $"{ _outputPath}/kills.txt");
    }
  }
}
