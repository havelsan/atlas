//$A64F5AEF
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using System.Collections.Generic;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text;
using Newtonsoft.Json;
using TTUtils;
using TTStorageManager.Security;
using System.Web.Script.Serialization;
using RenkliEncryption;
using Core.Security;
using System.Diagnostics;

namespace Core.Controllers
{
    [HvlResult]
    [Route("api/[controller]/[action]/{id?}")]
    public partial class HospitalTimeScheduleServiceController : Controller
    {
        public class HospitalTimeScheduleFormViewModel
        {
            public HospitalTimeSchedule HospitalTimeSchedule;
            public List<HospitalTimeScheduleDetail> HospitalTimeScheduleDetails = new List<HospitalTimeScheduleDetail>();
        }

        public class GetHospitalTimeSchedule_Input
        {
            public Guid hospitalTimeScheduleID;
        }

        public class GetHospitalTimeSchedule_OutPut
        {
            public HospitalTimeScheduleFormViewModel hospitalTimeScheduleFormViewModel = new HospitalTimeScheduleFormViewModel();
        }

        [HttpGet]
        public List<HospitalTimeSchedule> InitHospitalTimeScheduleForm()
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                return objectContext.QueryObjects<HospitalTimeSchedule>("").OrderByDescending(x => x.Frequency).ToList();
            }
        }

        [HttpPost]
        public GetHospitalTimeSchedule_OutPut GetSelectedHospitalTimeSchedule(GetHospitalTimeSchedule_Input input)
        {
            using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                GetHospitalTimeSchedule_OutPut outPut = new GetHospitalTimeSchedule_OutPut();
                HospitalTimeScheduleFormViewModel hospitalTimeScheduleFormViewModel = new HospitalTimeScheduleFormViewModel();
                HospitalTimeSchedule timeSchedule = objectContext.GetObject<HospitalTimeSchedule>(input.hospitalTimeScheduleID);
                hospitalTimeScheduleFormViewModel.HospitalTimeSchedule = timeSchedule;
                hospitalTimeScheduleFormViewModel.HospitalTimeScheduleDetails = timeSchedule.HospitalTimeScheduleDetails.OrderBy(x => x.TimeNumber).ToList();
                outPut.hospitalTimeScheduleFormViewModel = hospitalTimeScheduleFormViewModel;
                objectContext.FullPartialllyLoadedObjects();
                return outPut;
            }
        }

        [HttpPost]
        public bool HospitalTimeSchedule(HospitalTimeScheduleFormViewModel viewModel)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                objectContext.AddToRawObjectList(viewModel.HospitalTimeSchedule);
                objectContext.AddToRawObjectList(viewModel.HospitalTimeScheduleDetails);
                objectContext.ProcessRawObjects(false);


                var hospitalTimeSchedule = (HospitalTimeSchedule)objectContext.GetLoadedObject(viewModel.HospitalTimeSchedule.ObjectID);

                List<HospitalTimeScheduleDetail> deleteDetails = new List<HospitalTimeScheduleDetail>();
                foreach (HospitalTimeScheduleDetail detail in hospitalTimeSchedule.HospitalTimeScheduleDetails)
                {
                    int isFind = viewModel.HospitalTimeScheduleDetails.Where(x => x.ObjectID == detail.ObjectID).Count();
                    if (isFind == 0)
                        deleteDetails.Add(detail);

                }

                foreach (HospitalTimeScheduleDetail detail in deleteDetails)
                {
                    ((ITTObject)detail).Delete();
                }

                if (viewModel.HospitalTimeScheduleDetails != null && viewModel.HospitalTimeScheduleDetails.Count > 0)
                {
                    foreach (var item in viewModel.HospitalTimeScheduleDetails)
                    {
                        var hospitalTimeScheduleDetailImported = (HospitalTimeScheduleDetail)objectContext.GetLoadedObject(item.ObjectID);
                        if (((ITTObject)hospitalTimeScheduleDetailImported).IsDeleted)
                            continue;
                        hospitalTimeScheduleDetailImported.HospitalTimeSchedule = hospitalTimeSchedule;
                    }
                }
                objectContext.Save();
                return true;
            }
        }

    }
}