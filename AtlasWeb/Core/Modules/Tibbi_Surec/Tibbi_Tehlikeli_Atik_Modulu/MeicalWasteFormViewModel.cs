//$22EC782B
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

namespace Core.Controllers
{
    public partial class MedicalWasteServiceController
    {
        [HttpPost]
        public List<MedicalWaste.GetAllMedicalWaste_Class> GetAllMedicalWaste()
        {
            List<MedicalWaste.GetAllMedicalWaste_Class> list = MedicalWaste.GetAllMedicalWaste().ToList();
            return list;
        }

        [HttpPost]
        public List<MedicalWaste.GetMedicalWasteWithParam_Class> GetSelectedMedicalWaste(InputParam param)
        {
            List<MedicalWaste.GetMedicalWasteWithParam_Class> list = MedicalWaste.GetMedicalWasteWithParam(param.StartDate, param.EndDate, param.ResourceId, param.MedicalWasteTypeID).ToList();
            return list;
        }

        [HttpPost]
        public List<ResSection.GetAllSections_Class> GetResSections()
        {
            List<ResSection.GetAllSections_Class> list = ResSection.GetAllSections().ToList();
            return list;
        }
        [HttpPost]
        public MedicalWasteContainerDefinition GetContainers()
        {
             using (TTObjectContext objectContext = new TTObjectContext(true))
            {
                var containerList = objectContext.QueryObjects<MedicalWasteContainerDefinition>(" ISACTIVE = 1 ");

                if (containerList.Count == 1)
                {
                    return containerList[0];
                }
                return null;
            }

        }
        public class GetEpisodeDocuments_Input
        {
            public List<Guid> selectedMedicalWasteList
            {
                get; set;
            }

            public DateTime deliveryDate
            {
                get; set;
            }
        }

        [HttpPost]
        public void SetDeliveryDate(GetEpisodeDocuments_Input input)
        {
            foreach (var medicalWaste in input.selectedMedicalWasteList)
            {
                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    MedicalWaste mw = objectContext.GetObject<MedicalWaste>(medicalWaste);
                    if (mw.TransactionDate > input.deliveryDate)
                        throw new TTException("Firmaya teslim iþlem tarihinden önce yapýlamaz!");
                    else
                    {
                        mw.DeliveryDate = input.deliveryDate;
                        objectContext.Save();
                    }

                }
            }
        }

        [HttpGet]
        public void DeleteSelectedMedicalWaste(Guid id)
        {
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                MedicalWaste mw = objectContext.GetObject<MedicalWaste>(id);
                mw.CurrentStateDefID = MedicalWaste.States.Cancelled;
                objectContext.Save();
            }
        }
        [HttpPost]
        public bool CheckContainerCapacity(MedicalWasteContainerParameterClass input)
        {
            bool result = true;
            using (TTObjectContext objectContext = new TTObjectContext(false))
            {
                // List<MedicalWaste.GetAllMedicalWaste_Class> containers = MedicalWaste.GetAllMedicalWaste().Where(x => x.TransactionDate.Value == null && x.medi == mw.ObjectID).ToList();
                MedicalWasteContainerDefinition mw = objectContext.GetObject<MedicalWasteContainerDefinition>(input.ContainerID);
                List<MedicalWaste> wastes = objectContext.QueryObjects<MedicalWaste>("MedicalWasteContainer='" + input.ContainerID + "'").ToList();
                double cikisToplam = wastes.Where(x => x.DeliveryDate != null && x.Amount.HasValue).Sum(x => x.Amount.Value);
                double girisToplam = wastes.Where(x => x.DeliveryDate == null && x.Amount.HasValue).Sum(x => x.Amount.Value) + input.Amount;

                if (mw.Capacity * 1000 - girisToplam + cikisToplam < 0)
                {
                    result = false;
                }
            }

            return result;
        }

        partial void PreScript_MeicalWasteForm(MeicalWasteFormViewModel viewModel, MedicalWaste medicalWaste, TTObjectContext objectContext)
        {
            if (medicalWaste.MedicalWasteContainer != null)
                viewModel.Container = medicalWaste.MedicalWasteContainer;
            else
            {
                List<MedicalWasteContainerDefinition> container = objectContext.QueryObjects<MedicalWasteContainerDefinition>(" ISACTIVE = 1 ").ToList();
                if (container.Count == 1)
                {
                    viewModel.Container = container[0];
                }
            }
        }

        partial void PostScript_MeicalWasteForm(MeicalWasteFormViewModel viewModel, MedicalWaste medicalWaste, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {



            if (viewModel.Container != null)
            {
                medicalWaste.MedicalWasteContainer = viewModel.Container;

            }
            else
            {
                throw new Exception("Lütfen Atýk Deposu seçimi yapýnýz!");
            }
        }
    }
}

namespace Core.Models
{
    public partial class MeicalWasteFormViewModel : BaseViewModel
    {
        public MedicalWasteContainerDefinition Container;
    }

    public class InputParam
    {
        public Guid ResourceId
        {
            get;
            set;
        }
        public Guid MedicalWasteTypeID
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
    }
    public class MedicalWasteContainerParameterClass
    {
        public Guid ContainerID { get; set; }
        public Double Amount { get; set; }
    }
}
