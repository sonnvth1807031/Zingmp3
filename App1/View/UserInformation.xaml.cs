using System;
using System.Collections.Generic;
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
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserInformation : Page
    {
        private IMemberService _memberService;
        private IFileService _fileService;
        public static string _token;

        public object LoginMember { get; private set; }

        public UserInformation()
        {
            this.Loaded += LoadUserInformation;
            this.InitializeComponent();
            this._memberService = new MemberService();
            this._fileService = new FileService();
        }

        private async void LoadUserInformation(object sender, RoutedEventArgs e)
        {
            MemberCredential memberCredential = Api.CurrentMemberCredential;
            _token = memberCredential.token;
            if (Api.CurrentMemberCredential == null)
            {
                memberCredential = await this._fileService.ReadFile();
            }
            if (memberCredential == null)
            {
                this.Frame.Navigate(typeof(login));
            }

            if (memberCredential != null)
            {
               
                var member = this._memberService.GetInformation(_token);
                Email.Text = member.email;
                Name.Text = member.firstName + " " + member.lastName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormAddSong));
        }
        private void MySong(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MySong));
        }
        public async void Logout(object sender, RoutedEventArgs e)
        {
            StorageFile logout = await ApplicationData.Current.LocalFolder.GetFileAsync("token.txt");
            if (logout != null)
            {
                await logout.DeleteAsync();
            }
        }
    }
}
