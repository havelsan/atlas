//$C1EC6FF8
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTStorageManager.Security;

namespace Core.Controllers
{
    public partial class ResUserServiceController
    {
        partial void PreScript_ResUserForm(ResUserFormViewModel viewModel, ResUser resUser, TTObjectContext objectContext)
        {
            if (TTUser.CurrentUser.Status != UserStatusEnum.SuperUser)
                throw new TTException("Kullanýcý tanýmlarýný sadece Super User açabilir");

            viewModel.txtUserName = "";
            foreach (TTUser user in TTUser.GetAllUsers())
            {
                if (user.TTObjectID == resUser.ObjectID)
                {
                    viewModel.txtUserName = user.Name.ToString();
                    break;
                }
            }

            if (resUser.IsClinician.HasValue == false)
                resUser.IsClinician = false;
        }

        partial void PostScript_ResUserForm(ResUserFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            resUser.Person.Name = resUser.Person.Name.Trim();
            resUser.Person.Surname = resUser.Person.Surname.Trim();
            resUser.Name = resUser.Person.Name + " " + resUser.Person.Surname;

            if (resUser.ResourceSpecialities.Count == 1)
            {
                resUser.ResourceSpecialities[0].MainSpeciality = true;
            }
            else if (resUser.ResourceSpecialities.Count > 1)
            {
                int main = 0;
                foreach (ResourceSpecialityGrid resSepeciality in resUser.ResourceSpecialities)
                {
                    if (resSepeciality.MainSpeciality == true)
                    {
                        main++;
                    }
                }
                if (main == 0)
                {
                    throw new Exception(SystemMessage.GetMessage(653));
                }
                else if (main > 1)
                {
                    throw new Exception(SystemMessage.GetMessage(654));
                }

            }

            if (resUser.UserType != null)
            {
                if (resUser.UserType != UserTypeEnum.Doctor && resUser.UserType != UserTypeEnum.Dentist)
                {
                    if (resUser.IsClinician.HasValue == true && resUser.IsClinician.Value == true)
                        throw new Exception("Mesleði Doktor veya Diþ Hekimi olmayan kullanýcýlar için 'Klinisyen Hekim' kutucuðu iþaretli olamaz.");
                }
                else
                {
                    if (resUser.IsClinician.HasValue == false)
                        throw new Exception("Mesleði Doktor veya Diþ Hekimi olan kullanýcýlar için 'Klinisyen Hekim' kutucuðu boþ geçilemez.");
                }
            }
            //SetTakesPerformanceScore(); postInset ve postUpdate içinde yapýldý
        }

        partial void AfterContextSaveScript_ResUserForm(ResUserFormViewModel viewModel, ResUser resUser, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            //SITEID ye gore PACS a gonderim yapilmis, o kod kaldirildi. PACS entegrasyonu olup olmadigi bilgisi sistem parametresi ile tutulup gonderim yapilabilir. 
            resUser.SendUserToPACS();
        }
    }
}

namespace Core.Models
{
    public partial class ResUserFormViewModel : BaseViewModel
    {
        public string txtUserName { get; set; }//Kullanýcý Adý
    }
}
