using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using Newtonsoft.Json;
using TriathlonWPF;

namespace TriathlonWPF
{
    public partial class MainWindow : Window
    {
        private List<string> inputs = new List<string>();
        List<TeamDaten> teamDaten = new List<TeamDaten>();

        private string teamName;
        private float laufzeit;
        private float schwimmzeit;
        private float radzeit;
        private string inputJson;
        private TeamDaten yallah = new TeamDaten();
      
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            var input = new
            {
                _teamName = "",
                _schwimmZeit = 0.0f,
                _radZeit = 0.0f,
                _laufZeit = 0.0f,
                _gesamtZeit = 0.0f
            };
            try
            {
                teamName = TeamNameTextBox.Text;
                laufzeit = float.Parse(LaufzeitTextBox.Text);
                schwimmzeit = float.Parse(SchwimmzeitTextBox.Text);
                radzeit = float.Parse(RadzeitTextBox.Text);

                input = new
                {
                    _teamName = teamName,
                    _schwimmZeit = schwimmzeit,
                    _radZeit = radzeit,
                    _laufZeit = laufzeit,
                    _gesamtZeit = laufzeit + schwimmzeit + radzeit
                };

                 inputJson = JsonConvert.SerializeObject(input);

                TeamNameTextBox.Text = null;
                LaufzeitTextBox.Text = null;
                SchwimmzeitTextBox.Text = null;
                RadzeitTextBox.Text = null;

                inputs.Add(inputJson);

                //InputList.Items.Add(inputJson);
             

            }
            catch(Exception ex)
            {
               MessageBox.Show("Ungültiges Format für Zeiten. Bitte [Minuten, Sekunden]", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
                LaufzeitTextBox.Text = null;
                SchwimmzeitTextBox.Text = null;
                RadzeitTextBox.Text = null;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6969");
               
             
                Console.WriteLine(inputJson);
            
                var result = await client.PostAsJsonAsync("http://localhost:6969/addTeam", input);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
                InputList.Items.Add(resultContent);
            }

            /*string json = client.GetStringAsync("http://localhost:6969/daten").Result;
            InputList.Items.Add(inputJson);
            InputList.Items.Add(json);
            client.PostAsJsonAsync("http://localhost:6969/addTeam", inputJson);*/


        }

        private async void LoadList_Click(object sender, RoutedEventArgs e)
        {
            FullList.Items.Clear();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:6969/daten");

            Console.WriteLine(response.EnsureSuccessStatusCode());

            string responseBody = await response.Content.ReadAsStringAsync();
            teamDaten = JsonConvert.DeserializeObject<List<TeamDaten>>(responseBody);

            List<TeamDaten> sortedList = yallah.SortByTitleUsingLinq(teamDaten);

            foreach (TeamDaten item in sortedList)
            {
                Console.WriteLine(item.TeamName);
                FullList.Items.Add("Teamname: " + item.TeamName + "\t\t\t\t\t\t\t\t" + "Gesamtzeit: " + item.GesamtZeit);
            }

     
            TeamComboBox.ItemsSource = sortedList;
            TeamComboBox.DisplayMemberPath = "TeamName";
            TeamComboBox.SelectedValuePath = "_id";

            DeleteTeamComboBox.ItemsSource = sortedList;
            DeleteTeamComboBox.DisplayMemberPath = "TeamName";
            DeleteTeamComboBox.SelectedValuePath = "_id";
        }

        private void UpdateTeamData(TeamDaten teamData)
        {
            UpdateTeamNameTextBox.Text = teamData.TeamName;
            UpdateLaufzeitTextBox.Text = teamData._laufZeit.ToString();
            UpdateSchwimmzeitTextBox.Text = teamData._schwimmZeit.ToString();
            UpdateRadzeitTextBox.Text = teamData._radZeit.ToString();
        }
        private void TeamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeamComboBox.SelectedItem != null)
            {
                TeamDaten selectedTeam = (TeamDaten)TeamComboBox.SelectedItem;
                UpdateTeamData(selectedTeam);
            }
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TeamComboBox.SelectedItem != null)
            {
                try
                {
                    TeamDaten selectedTeam = (TeamDaten)TeamComboBox.SelectedItem;
                    string id = selectedTeam._id; 
                    selectedTeam.TeamName = UpdateTeamNameTextBox.Text;
                    selectedTeam._laufZeit = float.Parse(UpdateLaufzeitTextBox.Text);
                    selectedTeam._schwimmZeit = float.Parse(UpdateSchwimmzeitTextBox.Text);
                    selectedTeam._radZeit = float.Parse(UpdateRadzeitTextBox.Text);
                    selectedTeam._gesamtZeit = selectedTeam._laufZeit + selectedTeam._schwimmZeit + selectedTeam._radZeit;

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:6969");

                        var input = new
                        {
                            _teamName = selectedTeam.TeamName,
                            _schwimmZeit = selectedTeam._schwimmZeit,
                            _radZeit = selectedTeam._radZeit,
                            _laufZeit = selectedTeam._laufZeit,
                            _gesamtZeit = selectedTeam._gesamtZeit
                        };

                        string inputJson = JsonConvert.SerializeObject(input);

                        var result = await client.PutAsJsonAsync($"http://localhost:6969/updateTeam/{id}", input); 
                        string resultContent = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(resultContent);
                        InputList.Items.Add(resultContent);
                        UpdateSuccessMessageTextBlock.Visibility = Visibility.Visible;
                        UpdateTeamNameTextBox.Text = null;
                        UpdateLaufzeitTextBox.Text = null;
                        UpdateSchwimmzeitTextBox.Text = null;
                        UpdateRadzeitTextBox.Text = null;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ungültiges Format für Zeiten. Bitte [Minuten, Sekunden]", "Update error", MessageBoxButton.OK, MessageBoxImage.Error);
                    UpdateLaufzeitTextBox.Text = null;
                    UpdateSchwimmzeitTextBox.Text = null;
                    UpdateRadzeitTextBox.Text = null;
                }
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteTeamComboBox.SelectedItem != null)
            {
                try
                {
                    TeamDaten selectedTeam = (TeamDaten)DeleteTeamComboBox.SelectedItem;
                    string id = selectedTeam._id; 

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:6969");

                        var result = await client.DeleteAsync($"http://localhost:6969/deleteTeam/{id}"); 
                        string resultContent = await result.Content.ReadAsStringAsync();
                        Console.WriteLine(resultContent);
                        DeleteSuccessMessageTextBlock.Visibility = Visibility.Visible;
                        DeleteTeamComboBox.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while deleting the team.", "Delete error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


    }



}
    

