using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App1.Entity;
using App1.Service;

namespace App1.view
{
    public sealed partial class login : Page
    { 
        static MemberCredential memberCredential;
        private IMemberService _memberService;
        private IFileService _fileService;
        public login()
        {
             this._memberService = new MemberService();
             this._fileService = new FileService();
             this.InitializeComponent();
        }

        private void ButtonLogin_OnClick(object sender, RoutedEventArgs e)
        {
            var loginMember = new LoginMember
                {
                    email = this.Email.Text,
                    password = this.Password.Password
                };
            memberCredential = _memberService.Login(loginMember);
            this._fileService.SeveToFile(memberCredential);
            this.Frame.Navigate(typeof(View.UserInformation));
        }

        private void ButtonReset_OnClick(object sender, RoutedEventArgs e)
        {
           ResetLoginForm();
        }

        private void ResetLoginForm()
        {
            this.Email.Text = string.Empty;
            this.Password.Password = string.Empty;
        }
    }
}
