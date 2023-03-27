//$7DB3085E
using System;
using System.Linq;
using System.Collections.Generic;
using Core.Models;
using Infrastructure.Models;
using Infrastructure.Filters;
using TTObjectClasses;
using TTInstanceManagement;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core.Controllers
{
    [Route("api/[controller]/[action]/{id?}")]
    [HvlResult]
    public partial class DentalLaboratoryProcedureServiceController : Controller
    {
        [HttpPost]
        [Core.Security.AtlasRequiredRoles(TTRoleNames.Dis_Lab_okuma, TTRoleNames.Dis_Lab_yeni)]
        public List<FillTechnicians_Output> FillTechnicians()
        {
            using (var objectContext = new TTObjectContext(false))
            {
                List<FillTechnicians_Output> ret = new List<FillTechnicians_Output>();

                //Aşağıdaki kod, DentalLaboratoryForm.html deki Teknisyenlerin listelendiği grid kapatıldığı için kapatıldı. 
                //technician.TechnicianType değeri null olan kullanıcılar için hataya düşüyor. 
                //output.technicianType = (DentalTechnicianTypeEnum)user.TechnicianType;
                //output.technicianTypeName = Common.GetDescriptionOfDataTypeEnum((DentalTechnicianTypeEnum)user.TechnicianType);
                //bu kısım düzeltimeli

                /*
                BindingList<Technician> userList = Technician.GetAllTechnicians(objectContext);
                BindingList<ResUser> tempUserList = ResUser.GetResUserByUserType(objectContext, UserTypeEnum.DentalTechnician);
                bool isUpdate = false;
                if (userList == null || userList.Count == 0)
                {
                    foreach (ResUser user in tempUserList)
                    {
                        Technician technician = new Technician(objectContext);
                        technician.ResUser = user;
                        userList.Add(technician);
                        isUpdate = true;
                    }
                }
                else
                {
                    foreach (ResUser user in tempUserList)
                    {
                        bool found = false;
                        foreach (Technician tech in userList)
                        {
                            if (tech.ResUser.Equals(user))
                            {
                                found = true;
                                break;
                            }
                        }

                        if (!found)
                        {
                            Technician technician = new Technician(objectContext);
                            technician.ResUser = user;
                            userList.Add(technician);
                            isUpdate = true;
                        }
                    }
                }

                List<Technician> prevList = new List<Technician>();
                foreach (Technician user in userList)
                {
                    if (user.ResUser.UserType == UserTypeEnum.DentalTechnician && !prevList.Contains(user))
                    {
                        FillTechnicians_Output output = new FillTechnicians_Output();
                        output.name = user.ResUser.ToString();
                        BindingList<DentalProsthesisRequestSuggestedProsthesis> prosthesisList = DentalProsthesisRequestSuggestedProsthesis.GetAllProsthesisByTechnician(objectContext, user.ObjectID);
                        output.technicianType = (DentalTechnicianTypeEnum)user.TechnicianType;
                        output.technicianTypeName = Common.GetDescriptionOfDataTypeEnum((DentalTechnicianTypeEnum)user.TechnicianType);
                        output.totalWorks = prosthesisList.Count;
                        int unfinishedWorks = 0;
                        foreach (DentalProsthesisRequestSuggestedProsthesis item in prosthesisList)
                        {
                            DentalLaboratoryProcedure labTemp = ((DentalExaminationSuggestedProsthesis)item).DentalLaboratoryProcedure;
                            if (labTemp != null && labTemp.CurrentStateDefID != DentalLaboratoryProcedure.States.Completed)
                                unfinishedWorks++;
                        }

                        output.unfinishedWorks = unfinishedWorks;
                        output.TecnicanObjectID = user.ObjectID;
                        ret.Add(output);
                        prevList.Add(user);
                    }
                }

                if (isUpdate)
                    objectContext.Save();
                objectContext.FullPartialllyLoadedObjects();
                */
                return ret;
            }
        }

        public class FillTechnicians_Output
        {
            public string name
            {
                get;
                set;
            }

            public DentalTechnicianTypeEnum technicianType
            {
                get;
                set;
            }

            public string technicianTypeName
            {
                get;
                set;
            }

            public int totalWorks
            {
                get;
                set;
            }

            public int unfinishedWorks
            {
                get;
                set;
            }

            public Guid TecnicanObjectID
            {
                get;
                set;
            }
        }
    }
}