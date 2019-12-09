using RegLoginApp.Tables;
using System;
using System.IO;
using RegLoginApp.Tables;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegLoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "userDatabases.db");
            var db = new SQLiteConnection(dbpath);
            db.CreateTable<RegUserTable>();

            var item = new RegUserTable()
            {
                UserName = EntryUserName.Text,
                Password = EntryUserPassword.Text,
                Email = EntryUserEmail.Text,
                PhoneNumber = EntryUserPhoneNumer.Text
            };

            db.Insert(item);
            Device.BeginInvokeOnMainThread(async() =>
            {
                var result = await this.DisplayAlert("Congratulation", "User Registeration Sucessfull", "Yes", "Cancel");
            });
        }
    }
}