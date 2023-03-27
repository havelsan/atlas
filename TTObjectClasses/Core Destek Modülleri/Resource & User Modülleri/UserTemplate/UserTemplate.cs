using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;



namespace TTObjectClasses
{
    /// <summary>
    /// Kullanıcı Şablonları
    /// </summary>
    public partial class UserTemplate : TTObject
    {
#region Methods
        public static Dictionary<string, List<DrugOrderIntroductionDet>> GetDrugOrderIntroductionTemplate(Guid ResUserObjectId)
        {
            TTObjectContext context = new TTObjectContext(true);
            Dictionary<string, List<DrugOrderIntroductionDet>> drugOrderIntroductions = new Dictionary<string, List<DrugOrderIntroductionDet>>();
            IBindingList templates = UserTemplate.GetUserTemplate(ResUserObjectId, new Guid("a175dfa4-8038-4605-8183-9b2d41fecf51"), "DrugOrderIntroduction");
            foreach (UserTemplate.GetUserTemplate_Class template in templates)
            {
                List<DrugOrderIntroductionDet> details = new List<TTObjectClasses.DrugOrderIntroductionDet>();
                DrugOrderIntroduction drugOrderInt = (DrugOrderIntroduction)context.GetObject((Guid)template.TAObjectID, (Guid)template.TAObjectDefID);
                foreach (DrugOrderIntroductionDet det in drugOrderInt.DrugOrderIntroductionDetails)
                    details.Add(det);
                drugOrderIntroductions.Add(template.Description, details);
            }

            return drugOrderIntroductions;
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Ilac_Direktif_Giris_Yeni, TTRoleNames.Ilac_Direktif_Giris_Tamam)]
        public static bool IsTemplateNameAvailable(Guid ResUserObjectId, string TemplateName)
        {
            TTObjectContext context = new TTObjectContext(true);
            bool isAvailable = true;
            IBindingList templates = UserTemplate.GetUserTemplate(ResUserObjectId, new Guid("a175dfa4-8038-4605-8183-9b2d41fecf51"), "DrugOrderIntroduction");
            foreach (UserTemplate.GetUserTemplate_Class template in templates)
            {
                if (template.Description.ToString().Equals(TemplateName))
                {
                    isAvailable = false;
                    break;
                }
            }

            return isAvailable;
        }
#endregion Methods
    }
}