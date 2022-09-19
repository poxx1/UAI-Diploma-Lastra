using Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utiles;
using System.Windows.Forms;

namespace Business
{
      
    public class UserService 
    {
        UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public List<User_MachineModel> getReparadores()
        {
            MachineRepository machineRepository = new MachineRepository();
            return machineRepository.listMachinesToRepair();
        }
        public List<User> GetAll()
        {
            return userRepository.GetAll();
        }

        public List<user_typeModel> GetAllTypes()
        {
            return userRepository.GetAllTypes();
        }

        public void Save(User user)
        {
            userRepository.Create(user);
        }

        public User Get(String name)
        {
            return userRepository.Get(name);
        }

        public void SavePermissions(User u)
        {
            userRepository.SavePermissions(u);
        }

        public void ResetPassword(User user)
        {
            string oldPassword = user.Password;
            try
            {
                Crypt crypt = new Crypt();
                string nonHashedPassword = KeyGen.RandomString(7);
                user.Password = crypt.Encrypt(nonHashedPassword);
                userRepository.UpdatePassword(user);

                StringBuilder sb = new StringBuilder();
                sb.Append("Su administrador modifico su contraseña. ");
                sb.Append(user.Name);
                sb.AppendLine("Su nueva password es: ");
                sb.AppendLine(nonHashedPassword);

                NotificationService.SendMail(sb.ToString(), user.Email);

                userRepository.unblockUser(user);
                userRepository.resetTries(user);

            }
            catch (Exception)
            {
                try
                {
                    user.Password = oldPassword;
                    userRepository.SavePermissions(user);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public bool CheckIfExist(User user)
        {
            UserRepository machineRepository = new UserRepository();
            return machineRepository.CheckIfExist(user);
        }

        public bool CheckIfExistUserName(User user)
        {
            UserRepository machineRepository = new UserRepository();
            return machineRepository.CheckIfExistUserName(user);
        }
    }
}
