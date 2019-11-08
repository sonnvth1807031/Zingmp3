using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App1.Entity;
using App1.Service;
using App1.Constant;
using System.Collections.Generic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1.view
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class register : Page
    {
        private string _gender = "Gender";
        private IMemberService _memberService;
        private IFileService _flieService;
        public register()
        {
            this._memberService = new MemberService();
            this._flieService = new FileService();
            this.InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var birthdaySelectedDate = this.Birthday.SelectedDate;
            if (birthdaySelectedDate == null)
            {
                birthdaySelectedDate = DateTime.Now;
            }
            var birthday = birthdaySelectedDate.Value.ToString("yyyy-MM-dd");

            var member = new Member
            {
                firstName = this.FirstName.Text,
                lastName = this.LastName.Text,
                avatar = this.Avatar.Text,
                phone = this.Phone.Text,
                address = this.Address.Text,
                introduction = this.Introduction.Text,
                email = this.Email.Text,
                gender = _gender.Equals("Male") ? 1 : (_gender.Equals("Female") ? 0 : 2),
                birthday = birthday,
                password = this.Password.Password
            };
            var son = _memberService.Register(member);
            if ( son != null)
            {
                var loginMember = new LoginMember
                {
                    email = this.Email.Text,
                    password = this.Password.Password
                };
                var memberCredential = _memberService.Login(loginMember);
                this._flieService.SeveToFile(memberCredential);
                this.Frame.Navigate(typeof(View.UserInformation));
            }
            
            
            /*Dictionary<String, String> err = member.Validate();
            if (err.Count == 0)
            {
               
            }
            else
            {*/
            /*if (err.ContainsKey("firstName"))
            {
                FirstNameMessage.Text = err["firstName"];
                FirstNameMessage.Visibility = Visibility.Visible;
            }
            else
            {
                FirstNameMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("lastName"))
            {
                LastNameMessage.Text = err["lastName"];
                LastNameMessage.Visibility = Visibility.Visible;
            }
            else
            {
                LastNameMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("avatar"))
            {
                AvatarMessage.Text = err["avatar"];
                AvatarMessage.Visibility = Visibility.Visible;
            }
            else
            {
                AvatarMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("phone"))
            {
                PhoneMessage.Text = err["phone"];
                PhoneMessage.Visibility = Visibility.Visible;
            }
            else
            {
                PhoneMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("address"))
            {
                AddressMessage.Text = err["address"];
                AddressMessage.Visibility = Visibility.Visible;
            }
            else
            {
                AddressMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("introduction"))
            {
                IntroductionMessage.Text = err["introduction"];
                IntroductionMessage.Visibility = Visibility.Visible;
            }
            else
            {
                IntroductionMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("email"))
            {
                EmailMessage.Text = err["email"];
                EmailMessage.Visibility = Visibility.Visible;
            }
            else
            {
                EmailMessage.Visibility = Visibility.Collapsed;
            }
            if (err.ContainsKey("password"))
            {
                PasswordMessage.Text = err["password"];
                PasswordMessage.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordMessage.Visibility = Visibility.Collapsed;
            }*/
            /* }*/
        }

        private void RadionButton_OnChecked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton checkedRadio)
            {
                this._gender = checkedRadio.Tag.ToString();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var memberCredential = await this._flieService.ReadFile();
            if (memberCredential != null)
            {
                this.Frame.Navigate(typeof(View.UserInformation));
            }
            else if (memberCredential == null)
            {
                this.Frame.Navigate(typeof(login));
            }
        }
    }
}


