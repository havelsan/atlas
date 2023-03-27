//$35135379
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TTStorageManager.Security;

namespace Core.Controllers
{
    public partial class DoctorQuotaDefinitionServiceController
    {
        partial void PreScript_DoctorQuotaDefForm(DoctorQuotaDefFormViewModel viewModel, DoctorQuotaDefinition doctorQuotaDefinition, TTObjectContext objectContext)
        {
            viewModel.isPersonnelDoctor = Common.CurrentResource.TakesPerformanceScore == true ? true : false;
            if (viewModel.isPersonnelDoctor && !TTUser.CurrentUser.IsSuperUser)
            {
                viewModel._DoctorQuotaDefinition.ProcedureDoctor = Common.CurrentDoctor;

                string polIDs = "";
                foreach (var UserResource in viewModel._DoctorQuotaDefinition.ProcedureDoctor.UserResources)
                {
                    if (UserResource.Resource is ResPoliclinic)
                    {
                        if (polIDs != "")
                            polIDs += "','";
                        polIDs += UserResource.Resource.ObjectID;
                    }
                }
                viewModel.PoliclinicObjectIDs = polIDs;
            }

            if (doctorQuotaDefinition.CurrentStateDefID == null)
                viewModel._DoctorQuotaDefinition.CurrentStateDefID = DoctorQuotaDefinition.States.New;

            if (viewModel._DoctorQuotaDefinition.Active == null)
                viewModel._DoctorQuotaDefinition.Active = true;

            if (viewModel._DoctorQuotaDefinition.AutomaticReception == null)
                viewModel._DoctorQuotaDefinition.AutomaticReception = false;

            ContextToViewModel(viewModel, objectContext);

        }
        partial void PostScript_DoctorQuotaDefForm(DoctorQuotaDefFormViewModel viewModel, DoctorQuotaDefinition doctorQuotaDefinition, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            ControlRequiredProperties(doctorQuotaDefinition, objectContext);

            if (doctorQuotaDefinition.CurrentStateDefID == null)
                doctorQuotaDefinition.CurrentStateDefID = DoctorQuotaDefinition.States.New;
 
        }

        public void ControlRequiredProperties(DoctorQuotaDefinition doctorQuotaDefinition, TTObjectContext objectContext)
        {
            if (doctorQuotaDefinition.Active == null)
            {
                throw new Exception(SystemMessage.GetMessageV2(335, TTUtils.CultureService.GetText("M00000", "Girilen 'Aktif/Pasiflik' bilgisini kontrol ediniz.")));
            }
            if (doctorQuotaDefinition.ProcedureDoctor == null)
            {
                throw new Exception(SystemMessage.GetMessageV2(335, TTUtils.CultureService.GetText("M00000", "Girilen 'Doktor' bilgisini kontrol ediniz.")));
            }
            if (doctorQuotaDefinition.Policlinic == null)
            {
                throw new Exception(SystemMessage.GetMessageV2(335, TTUtils.CultureService.GetText("M00000", "Girilen 'Poliklinik' bilgisini kontrol ediniz.")));
            }

            if (((ITTObject)doctorQuotaDefinition).IsNew == true)
            {
                BindingList<DoctorQuotaDefinition> list = DoctorQuotaDefinition.GetDoctorQuotaByPoliclinic(objectContext, doctorQuotaDefinition.Policlinic.ObjectID, doctorQuotaDefinition.ProcedureDoctor.ObjectID);
                if (list != null && list.Count > 0)
                {
                    throw new Exception(SystemMessage.GetMessageV2(0, TTUtils.CultureService.GetText("M00000", "Ayný doktora ayný poliklinik için birden fazla kota tanýmý yapýlamaz.")));
                }
            }

        }
        [HttpPost]
        public object GetGridDataSource()
        {
            object retList;

            if (Common.CurrentResource.TakesPerformanceScore == true && !TTUser.CurrentUser.IsSuperUser)
                retList = GetDoctorOwnQuota();
            else
                retList = GetAllDoctorQuotas();

            return retList;
        }


        public BindingList<DoctorQuotaDefinition.GetAllDoctorQuota_Class> GetAllDoctorQuotas()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<DoctorQuotaDefinition.GetAllDoctorQuota_Class> list = DoctorQuotaDefinition.GetAllDoctorQuota();
                return list;
            }
        }

        public BindingList<DoctorQuotaDefinition.GetDoctorOwnQuota_Class> GetDoctorOwnQuota()
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                BindingList<DoctorQuotaDefinition.GetDoctorOwnQuota_Class> list = DoctorQuotaDefinition.GetDoctorOwnQuota(Common.CurrentDoctor.ObjectID);
                return list;
            }
        }

        [HttpGet]
        public void DeleteSelectedDoctorQuota(Guid id)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                DoctorQuotaDefinition dqd = objectContext.GetObject<DoctorQuotaDefinition>(id);
                dqd.CurrentStateDefID = DoctorQuotaDefinition.States.Cancel;
                dqd.Active = false;
                objectContext.Save();
            }
        }
    }
}

namespace Core.Models
{
    public partial class DoctorQuotaDefFormViewModel : BaseViewModel
    {
        public bool isPersonnelDoctor { get; set; }
        public string PoliclinicObjectIDs { get; set; }

    }

}
