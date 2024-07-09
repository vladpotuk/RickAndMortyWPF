using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using RickAndMortyWPF.Models;
using RickAndMortyWPF.Controllers;
using System.Windows.Media.Imaging;
using System.Text;
using System.Linq;

namespace RickAndMortyWPF.Views
{
    public partial class MainWindow : Window
    {
        private RickAndMortyApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();
            _apiService = new RickAndMortyApiService();
            LoadCharacters();
        }

        private async void LoadCharacters()
        {
            var characters = await _apiService.GetCharactersAsync();
            CharacterListBox.ItemsSource = characters;
            CharacterListBox.SelectionChanged += CharacterListBox_SelectionChanged;
        }

        private async void CharacterListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterListBox.SelectedItem is Character selectedCharacter)
            {
                CharacterImage.Source = new BitmapImage(new System.Uri(selectedCharacter.Image));

                var originLocation = await _apiService.GetLocationAsync(selectedCharacter.Origin.Url);
                var episodes = await _apiService.GetEpisodesAsync(selectedCharacter.Episode);

                var episodeDetails = new StringBuilder();
                foreach (var episode in episodes)
                {
                    episodeDetails.AppendLine($"{episode.Name} ({episode.EpisodeCode}) - {episode.AirDate}");
                }

                CharacterDetails.Text = $"ID: {selectedCharacter.Id}\n" +
                                        $"Name: {selectedCharacter.Name}\n" +
                                        $"Status: {selectedCharacter.Status}\n" +
                                        $"Gender: {selectedCharacter.Gender}\n" +
                                        $"Origin: {originLocation.Name}\n" +
                                        $"Episodes:\n{episodeDetails}";
            }
        }
    }
}
