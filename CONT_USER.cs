using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStoreDllDemo
{
    public class CONT_USER:INotifyPropertyChanged
    {
        private String firstName;
        private String lastName;
        private String dob;
        private String email;
        private String state;
        private String address;
        private String profilePhoto;
        private String password;
        private String gender;
        SaveCommand _saveCommand = new SaveCommand();
        public String FirstName {

            get
            {
                return this.firstName;

            }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }


            }
        }
        public String LastName {

            get
            {
                return this.lastName;
            }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    OnPropertyChanged("LastName");
                }

            }
        }
        public String DOB {

            get
            {
                return this.dob;
            }
            set
            {
                if (dob != value)
                {
                   dob = value;
                    OnPropertyChanged("DOB");
                }

            }
        }
        public String Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChanged("Gender");
                }

            }
        }
        public String State
        {
            get
            {
                return this.state;
            }
            set
            {
                if (state != value)
                {
                    state = value;
                    OnPropertyChanged("State");
                }

            }
        }
        public String Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (email != value)
                {
                   email = value;
                    OnPropertyChanged("Email");
                }

            }
        }
        public String Address
        {
            get
            {
                return this.address;
            }
            set
            {
                if (address != value)
                {
                    address = value;
                    OnPropertyChanged("Address");
                }

            }
        }
        public String Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (password!= value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }

            }
        }
        public String ProfilePhoto
        {
            get
            {
                return this.profilePhoto;
            }
            set
            {
                if (profilePhoto != value)
                {
                    gender = value;
                    OnPropertyChanged("ProfilePhoto");
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public SaveCommand SaveCommand
        {
            get { return _saveCommand; }
        }
    }
}
