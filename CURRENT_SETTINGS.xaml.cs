
using DataStoreDllDemo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MenuStack
{
    /// <summary>
    /// Interaction logic for CURRENT_SETTINGS.xaml
    /// </summary>
    public partial class CURRENT_SETTINGS : Window, INotifyPropertyChanged
    {
        private String fileName;
        private String selectedGender;
        public CURRENT_SETTINGS()
        {
            InitializeComponent();
            stateList.ItemsSource = StateData.getStates();
            DataContext = new CONT_USER();
            DataTable dt =DataStoreDllDemo.OracleConnector.FillDataGrid();
            MessageBox.Show(dt.Rows.Count.ToString());
        }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
        private void ValidationError(object sender, ValidationErrorEventArgs e)
        {
            // Check that the error is being added (not cleared).
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

       
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //if (!Validation.GetHasError(txtfirstName))
            //{
            //    if (!Validation.GetHasError(txtEmail))
            //    {
            //        MessageBox.Show(txtfirstName.Text + "" + txtLastName.Text + "" + txtEmail.Text + dtDOB.SelectedDate.ToString() + "" + stateList.SelectedValue.ToString() + "" + txtPasswd.Password + "" + txtAddress.Text + "" + this.fileName+this.selectedGender);
            //        DataStoreDllDemo.CONT_USER userObj = new DataStoreDllDemo.CONT_USER();
            //        userObj.FirstName = txtfirstName.Text;
            //        userObj.LastName = txtLastName.Text;
            //        userObj.Gender = this.selectedGender;
            //        userObj.DOB = dtDOB.SelectedDate.ToString();
            //        userObj.State = stateList.SelectedValue.ToString();
            //        userObj.Email = txtEmail.Text;
            //        userObj.Password = txtPasswd.Password;
            //        userObj.Address = txtAddress.Text;
            //        userObj.ProfilePhoto = this.fileName;
            //        MessageBox.Show(DataStoreDllDemo.OracleConnector.addUser(userObj).ToString());

            //    }
                  
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select a picture";
            ofd.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if(ofd.ShowDialog()==true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(ofd.FileName));
                this.fileName = ofd.FileName;
            }

        }

        private void radio_Checked(object sender, RoutedEventArgs e)
        {
            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            this.selectedGender = radioButton.Content.ToString();
            MessageBox.Show(radioButton.Content.ToString());
        }
    }
}
