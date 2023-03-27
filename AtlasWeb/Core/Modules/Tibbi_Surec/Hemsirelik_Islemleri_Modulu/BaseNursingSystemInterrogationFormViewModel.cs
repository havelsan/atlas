//$820E11C3
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using System.Collections.Generic;

namespace Core.Controllers
{
    public partial class BaseNursingSystemInterrogationServiceController
    {
        partial void PreScript_BaseNursingSystemInterrogationForm(BaseNursingSystemInterrogationFormViewModel viewModel, BaseNursingSystemInterrogation baseNursingSystemInterrogation, TTObjectContext objectContext)
        {
            //System.ComponentModel.BindingList<SystemInterrogationDefinition.GetSystemInterrogationDefinitionList_Class> AllSystemInterrogationDefList = SystemInterrogationDefinition.GetSystemInterrogationDefinitionList(" ORDER BY ACTIVITYGROUP,NAME");
            if (baseNursingSystemInterrogation.ApplicationUser == null)
                baseNursingSystemInterrogation.ApplicationUser = Common.CurrentResource;
            System.ComponentModel.BindingList<SystemInterrogationDefinition> AllSystemInterrogationDefList = SystemInterrogationDefinition.GetAllSysInterrogDefList(objectContext);
            SystemInterrogationDefinitionList_Class xxx = new SystemInterrogationDefinitionList_Class();
            string groupName = String.Empty;
            viewModel.SystemInterrogationDefinitionViewList = new List<SystemInterrogationDefinitionList_Class>();
            int index = 0;
            foreach (SystemInterrogationDefinition item in AllSystemInterrogationDefList)
            {
                string _temp = Common.GetDisplayTextOfDataTypeEnum(item.ActivityGroup.Value);
                if (groupName != _temp)
                {
                    if (index != 0) //ilk girişinde atmasın tüm liste gelmemiş oluyor
                    {
                        viewModel.SystemInterrogationDefinitionViewList.Add(xxx);
                        xxx = new SystemInterrogationDefinitionList_Class();
                    }

                    xxx.GroupName = _temp;
                    groupName = _temp;
                    xxx.SystemInterrogationDefinitionList = new List<SystemInterrogationDefinition>();
                    index++;
                }

                xxx.SystemInterrogationDefinitionList.Add(item);
            }

            viewModel.SystemInterrogationDefinitionViewList.Add(xxx); //son kayıt
            index = 0;

            if (!((ITTObject)baseNursingSystemInterrogation).IsNew && !viewModel.ReadOnly)
            {
                using (var nasc = new Core.Controllers.NursingApplicationServiceController())
                {
                    viewModel.ReadOnly = nasc.ArrangeNursingApplicationReadOnly((BaseNursingDataEntry)baseNursingSystemInterrogation);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class BaseNursingSystemInterrogationFormViewModel
    {
        public List<SystemInterrogationDefinitionList_Class> SystemInterrogationDefinitionViewList
        {
            get;
            set;
        }
    }

    public class SystemInterrogationDefinitionList_Class
    {
        public string GroupName
        {
            get;
            set;
        }

        public List<TTObjectClasses.SystemInterrogationDefinition> SystemInterrogationDefinitionList
        {
            get;
            set;
        }

        public SystemInterrogationDefinitionList_Class()
        {
            SystemInterrogationDefinitionList = new List<SystemInterrogationDefinition>();
        }
    }
}