using MVPTema3.Exceptions;
using MVPTema3.Models.DataAccessLayer;
using MVPTema3.Models.EntityLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTema3.Models.BussinessLogicLayer
{
    class UserBLL
    {
        public ObservableCollection<User> UsersList { get; set; }
        public string ErrorMessage { get; set; }

        UserDAL persoanaDAL = new UserDAL();

        public ObservableCollection<User> GetAllUsers()
        {
            return persoanaDAL.GetAllUsers();
        }

        //public ObservableCollection<User> GetAllUsersWithoutPhone()
        //{
        //    return persoanaDAL.GetAllUsersWithNoPhone();
        //}

        //public void AddUser(User persoana)
        //{
        //    if (String.IsNullOrEmpty(persoana.Name))
        //    {
        //        //ErrorMessage = "Numele persoanei trebuie sa fie precizat";
        //        throw new AgendaException("Numele persoanei trebuie sa fie precizat");
        //    }
        //    persoanaDAL.AddUser(persoana);
        //    UsersList.Add(persoana);
        //}

        //public void ModifyUser(User persoana)
        //{
        //    if (persoana == null)
        //    {
        //        throw new AgendaException("Trebuie selectata o persoana");
        //    }
        //    if (String.IsNullOrEmpty(persoana.Name))
        //    {
        //        throw new AgendaException("Trebuie precizat numele persoanei");
        //    }
        //    persoanaDAL.ModifyUser(persoana);
        //}

        //public void DeleteUser(User persoana)
        //{
        //    if (persoana == null)
        //    {
        //        throw new AgendaException("Trebuie precizata o persoana!");
        //    }
        //    else
        //    {
        //       //...
        //    }
        //    persoanaDAL.DeleteUser(persoana);
        //    UsersList.Remove(persoana);
        //}
    }
}
