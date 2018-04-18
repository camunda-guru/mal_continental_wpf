using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataStoreDllDemo
{
    public class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            var cont_user = parameter as CONT_USER;
            return cont_user != null
                && !string.IsNullOrWhiteSpace(cont_user.FirstName)
                && !string.IsNullOrWhiteSpace(cont_user.LastName)
                && !string.IsNullOrWhiteSpace(cont_user.Address)
                && !string.IsNullOrWhiteSpace(cont_user.DOB)
                && !string.IsNullOrWhiteSpace(cont_user.Email)
                && !string.IsNullOrWhiteSpace(cont_user.Gender)
                && !string.IsNullOrWhiteSpace(cont_user.Password)
                && !string.IsNullOrWhiteSpace(cont_user.ProfilePhoto)
                && !string.IsNullOrWhiteSpace(cont_user.State);
        }

        public void Execute(object parameter)
        {
            var cont_user = parameter as CONT_USER;
            OracleConnector.addUser(cont_user);
        }
    }
}
