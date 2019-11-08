using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Gaming.XboxLive.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App1.Entity;
using App1.Service;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormAddSong : Page
    {
        private ISongService songService;

        public FormAddSong()
        {
            this.InitializeComponent();
            songService = new SongService();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var song = new Song()
            {
                name = Name.Text,
                description = Description.Text,
                author = Author.Text,
                singer = Single.Text,
                thumbnail = Thumbnail.Text,
                link = Link.Text
            };
            Dictionary<String, String> err = song.Validate();
            if (err.Count == 0)
            {
                songService.CreateSong(song, UserInformation._token);
                this.Frame.Navigate(typeof(MySong));
            }
            else
            {
                if (err.ContainsKey("name"))
                {
                    NameMessage.Text = err["name"];
                    NameMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    NameMessage.Visibility = Visibility.Collapsed;
                }
                if (err.ContainsKey("description"))
                {
                    DescriptionMessage.Text = err["description"];
                    DescriptionMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    DescriptionMessage.Visibility = Visibility.Collapsed;
                }
                if (err.ContainsKey("thumbnail"))
                {
                    ThumbnailMessage.Text = err["thumbnail"];
                    ThumbnailMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    ThumbnailMessage.Visibility = Visibility.Collapsed;
                }
                if (err.ContainsKey("single"))
                {
                    SingleMessage.Text = err["single"];
                    SingleMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    Single.Visibility = Visibility.Collapsed;
                }
                if (err.ContainsKey("author"))
                {
                    AuthorMessage.Text = err["author"];
                    AuthorMessage.Visibility = Visibility.Visible;
                }
                else
                {
                    AuthorMessage.Visibility = Visibility.Collapsed;
                }
                if (err.ContainsKey("link"))
                {
                    LinkMeesaga.Text = err["link"];
                    LinkMeesaga.Visibility = Visibility.Visible;
                }
                else
                {
                    LinkMeesaga.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
