using Core.Models;
using TTInstanceManagement;
using TTObjectClasses;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using TTDefinitionManagement;
using Microsoft.AspNetCore.Mvc;

namespace Core.Controllers.HospitalDeveloperForms
{
    [Route("api/[controller]/[action]/{id?}")]
    public class AppointmentFormApiController : Controller
    {
        [HttpGet]
        public exScheduleFormViewModel FillAppointmentDefinitions()
        {
            exScheduleFormViewModel model = new exScheduleFormViewModel();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<AppointmentDefinition> defList = AppointmentDefinition.GetAllAppointmentDefinitions(objectContext);
                model.Appoitmentlist = new List<AppoitmentDVO>();
                foreach (AppointmentDefinition appDef in defList)
                {
                    AppoitmentDVO appDVO = new AppoitmentDVO();
                    appDVO.appointmentDefinition = appDef;
                    appDVO.AppointmentCarrieries = new List<exAppointmentCarrierDVO>();
                    foreach (AppointmentCarrier carrier in appDef.AppointmentCarriers)
                    {
                        exAppointmentCarrierDVO carrierDVO = new exAppointmentCarrierDVO();
                        carrierDVO.appointmentCarrier = carrier;
                        carrierDVO.MasterResource = FillMasterResourceCombo(carrier);
                        appDVO.AppointmentCarrieries.Add(carrierDVO);
                    }

                    model.Appoitmentlist.Add(appDVO);
                }

                IBindingList MHRSActionList = objectContext.QueryObjects("MHRSACTIONTYPEDEFINITION", "ISWORKINGHOUR = 1", "ACTIONNAME");
                List<MHRSActionTypeDefinition> ml = new List<MHRSActionTypeDefinition>();
                foreach (MHRSActionTypeDefinition actionType in MHRSActionList)
                {
                    ml.Add(actionType);
                }

                model.MHRSActionlist = ml;
                model.dtDate = TTObjectDefManager.ServerTime.Date;
                model.dtStartDate = TTObjectDefManager.ServerTime.Date;
                model.dtEndDate = TTObjectDefManager.ServerTime.Date;
                DateTime newStartTime;
                DateTime.TryParse(model.dtDate.Date.ToShortDateString() + " 08:00", out newStartTime);
                model.dtStartTime = newStartTime;
                DateTime newEndTime;
                DateTime.TryParse(model.dtDate.Date.ToShortDateString() + " 09:00", out newEndTime);
                model.dtEndTime = newEndTime;
                objectContext.FullPartialllyLoadedObjects();
                return model;
            }
        }

        private List<exCarrierMasterResourceDVO> FillMasterResourceCombo(AppointmentCarrier carrier)
        {
            string masterResourceFilter = carrier.MasterResourceFilter;
            List<exCarrierMasterResourceDVO> mRList = new List<exCarrierMasterResourceDVO>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (String.IsNullOrEmpty(masterResourceFilter))
                    masterResourceFilter += " ISACTIVE = 1";
                else
                    masterResourceFilter += " AND ISACTIVE = 1";
                IBindingList masterResourceList = objectContext.QueryObjects(carrier.MasterResource, masterResourceFilter);
                foreach (ResSection section in masterResourceList)
                {
                    exCarrierMasterResourceDVO carDVO = new exCarrierMasterResourceDVO();
                    carDVO.MasterResource = section;
                    carDVO.resource = FillSubResource(section, carrier);
                    mRList.Add(carDVO);
                }

                objectContext.FullPartialllyLoadedObjects();
                return mRList;
            }
        }

        private List<Resource> FillSubResource(ResSection section, AppointmentCarrier carrier)
        {
            bool isUserTypeAllowed;
            List<Resource> sResourceList = new List<Resource>();
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                if (!String.IsNullOrEmpty(carrier.RelationParentName))
                {
                    IBindingList subResList = objectContext.QueryObjects(carrier.SubResource, carrier.RelationParentName + " = '" + section.ObjectID.ToString() + "' AND ISACTIVE = 1");
                    foreach (ResSection s in subResList)
                    {
                        sResourceList.Add(s);
                    }
                }
                else
                {
                    if (carrier.SubResource.ToUpperInvariant() == "RESUSER")
                    {
                        foreach (UserResource userResource in section.ResourceUsers)
                        {
                            if (userResource.User != null && userResource.User.IsActive == true)
                            {
                                isUserTypeAllowed = false;
                                foreach (AppointmentCarrierUserTypes appCarrierUserType in carrier.AppointmentCarrierUserTypes)
                                {
                                    if (appCarrierUserType.UserType == userResource.User.UserType)
                                    {
                                        isUserTypeAllowed = true;
                                        break;
                                    }
                                }

                                if (isUserTypeAllowed || carrier.AppointmentCarrierUserTypes.Count == 0)
                                {
                                    Resource resUser = (Resource)userResource.User;
                                    sResourceList.Add(resUser);
                                }
                            }
                        }
                    }
                }

                objectContext.FullPartialllyLoadedObjects();
                return sResourceList;
            }
        }
    }
}