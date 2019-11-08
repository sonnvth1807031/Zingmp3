using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Constant;
using App1.Entity;
using App1.Service;
using App1.view;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MySong : Page
    {
        static ObservableCollection<Song> ListSong;
        static bool refresh = true;
        private ISongService _songService;
        private bool running = false;
        private int currentIndex = 0;
        public MySong()
        {
            this.InitializeComponent();
            this.Loaded += CheckMemberCredential;
            this._songService = new SongService();
            LoadSongs();
        }
        private void LoadSongs()
        {
         
                var list = this._songService.GetMineSongs(Api.CurrentMemberCredential);
                ListSong = new ObservableCollection<Song>(list);
                refresh = false;
                ListViewSong.ItemsSource = ListSong;
        }

        private void CheckMemberCredential(object sender, RoutedEventArgs e)
        {
            if (Api.CurrentMemberCredential == null)
            {
                this.Frame.Navigate(typeof(login));
            }
        }

        private void UIElement_OnDoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            currentIndex = ListViewSong.SelectedIndex;
            var playIcon = sender as SymbolIcon;
            if (playIcon != null)
            {
                var currentSong = playIcon.Tag as Song;
                MyMediaElement.Source = new Uri(currentSong.link);
                NowPlayingText.Text = "Now playing: " + currentSong.name + " - " + currentSong.singer;
            }
            MyMediaElement.Play();
            PlayAndPauseButton.Icon = new SymbolIcon(Symbol.Pause);
            running = true;
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Play(object sender, RoutedEventArgs e)
        {
            if (running)
            {
                MyMediaElement.Pause();
                PlayAndPauseButton.Icon = new SymbolIcon(Symbol.Play);
                running = false;
            }
            else
            {
                MyMediaElement.Play();
                PlayAndPauseButton.Icon = new SymbolIcon(Symbol.Pause);
                running = true;
            }
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            currentIndex += 1;
            if (currentIndex >= ListSong.Count)
            {
                currentIndex = 0;
            }
            var song = ListSong[currentIndex];
            ListViewSong.SelectedIndex = currentIndex;
            MyMediaElement.Source = new Uri(song.link);
            NowPlayingText.Text = "Now playing: " + song.name + " - " + song.singer;
            MyMediaElement.Play();
        }

        private void Previous(object sender, RoutedEventArgs e)
        {
            currentIndex -= 1;
            if (currentIndex < 0)
            {
                currentIndex = ListSong.Count - 1;
            }
            var song = ListSong[currentIndex];
            ListViewSong.SelectedIndex = currentIndex;
            MyMediaElement.Source = new Uri(song.link);
            NowPlayingText.Text = "Now playing: " + song.name + " - " + song.singer;
        }
    }
}
