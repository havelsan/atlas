
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
    /// Dış Eczane 
    /// </summary>
    public  partial class ExternalPharmacy : TTDefinitionSet
    {
        public partial class GetExternalPharmacy_Class : TTReportNqlObject 
        {
        }

#region Methods
        public static List<ExternalPharmacy> GetAvaliblePharmacy(DateTime currentTime)
        {
            List<ExternalPharmacy> pharmacys = new List<ExternalPharmacy>();
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ExternalPharmacy> avalibleExternalPharmacy = ExternalPharmacy.GetExternalPharmacys(context);
            foreach (ExternalPharmacy externalPharmacy in avalibleExternalPharmacy)
            {
                bool avalible = true;
                foreach (ExternalPharmacyStatus externalPharmacyStatus in externalPharmacy.ExternalPharmacyStatuses)
                {
                    if (externalPharmacyStatus.Status == ExternalPharmacyStatusEnum.Punished || externalPharmacyStatus.Status == ExternalPharmacyStatusEnum.Offduty)
                    {
                        if( ((DateTime)externalPharmacyStatus.StartDate).Date <= currentTime.Date  && currentTime.Date  <= ((DateTime)externalPharmacyStatus.EndDate).Date)
                        {
                            avalible = false;
                        }
                    }
                }
                if (avalible)
                {
                    pharmacys.Add(externalPharmacy);
                }
            }
            return pharmacys;
        }

        public static List<ExternalPharmacy> GetNightPharmacy(DateTime currentTime)
        {
            List<ExternalPharmacy> pharmacys = new List<ExternalPharmacy>();
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ExternalPharmacy> nightExternalPharmacy = ExternalPharmacy.GetExternalPharmacys(context);
            foreach (ExternalPharmacy externalPharmacy in nightExternalPharmacy)
            {
                bool night = false;
                foreach (ExternalPharmacyStatus externalPharmacyStatus in externalPharmacy.ExternalPharmacyStatuses)
                {
                    if (externalPharmacyStatus.Status == ExternalPharmacyStatusEnum.NightPharmacy)
                    {
                        if (((DateTime)externalPharmacyStatus.StartDate).Date == currentTime.Date)
                        {
                            night = true;
                        }
                    }
                }
                if (night)
                {
                    pharmacys.Add(externalPharmacy);
                }
            }
            return pharmacys;
        }
        
#endregion Methods

    }
}