
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
    /// Yatan Hasta Birimi(Koğuş)
    /// </summary>
    public  partial class ResWard : ResSection
    {
        public partial class GetWardDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_ResWard_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// Sivil yatan hasta sayısı (tedavi gören)
    /// </summary>
        public int? CivillianInpatientCount
        {
            get
            {
                try
                {
#region CivillianInpatientCount_GetScript                    
                    //BindingList<ResBed> usedBedList = ResBed.GetUsedBedsByClinic(this.ObjectContext, this.ObjectID);

                BindingList<InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class> inPaTrtClnAppList = InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource(ObjectContext,ObjectID);
                int civillianInpatientCount = 0;
                foreach(InPatientTreatmentClinicApplication.GetActiveInpatientTrtClinicAppByMasterResource_Class inPaTrtClnApp in inPaTrtClnAppList)
                {
                    Guid inpGuid = new Guid(inPaTrtClnApp.ObjectID.ToString());
                    InPatientTreatmentClinicApplication inp = (InPatientTreatmentClinicApplication)ObjectContext.GetObject(inpGuid, typeof(InPatientTreatmentClinicApplication).Name);
                    if(inp.SubEpisode.PatientAdmission.RequiredQuota == true)
                        civillianInpatientCount++;
                }
                return civillianInpatientCount;
#endregion CivillianInpatientCount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "CivillianInpatientCount") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Klinikteki toplam yatak sayısı
    /// </summary>
        public int? BedCount
        {
            get
            {
                try
                {
#region BedCount_GetScript                    
                    BindingList<ResBed.GetBedCountByClinic_Class> bedCountList = ResBed.GetBedCountByClinic(ObjectID);
                if(bedCountList.Count > 0)
                    return (int?)((decimal)(bedCountList[0].Bedcount));
                return 0;
#endregion BedCount_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "BedCount") + " : " + ex.Message, ex);
                }
            }
        }

#region Methods
        [Serializable]
        [LooselyTypeAttribute]
        public class NIComCode
        {
            public string ObjectId;
            public string CodeName;
            public string Code;
            public string Definition;
        }

        public static void SendResWardToDietRationSystem(ResWard resWard)
        {
            IList<ResWard.NIComCode> itemList = new List<ResWard.NIComCode>();
            ResWard.NIComCode wardNIComCode = new ResWard.NIComCode();
            wardNIComCode.ObjectId = resWard.ObjectID.ToString();

            if (resWard.Name != null)
                wardNIComCode.CodeName = resWard.Name.ToString();
            if (resWard.Qref != null)
                wardNIComCode.Code = resWard.Qref.ToString();
            if(resWard.Name != null)
                wardNIComCode.Definition = resWard.Name.ToString();

            itemList.Add(wardNIComCode);
            //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.LowPriority, "Nebula.Integration", "NebulaIntegrationUtils", "SaveClinic", null, itemList);
        }

        public static List<ResUser> GetSimpleResUserInfoOfWard(Guid? ResWardcGuid)
        {
            List<ResUser> l = new List<ResUser>();
            if (ResWardcGuid != null)
            {
                TTObjectContext context = new TTObjectContext(true);
                BindingList<Resource> resWardList = ResWard.GetResource(context, ResWardcGuid.ToString());
                foreach (ResWard resWard in resWardList)
                {
                    foreach (UserResource userResource in resWard.ResourceUsers)
                    {
                        if (userResource.User != null)
                        {
                            l.Add(userResource.User);
                        }
                    }
                    break;
                }
            }
            return l;

        }
        public static List<ResUser> GetSimpleResUserInfoByUserType(UserTypeEnum userTypeEnum, Guid? resRectionGuid)
        {
            List<ResUser> l = new List<ResUser>();
            TTObjectContext context = new TTObjectContext(true);
            BindingList<ResUser> resUserList;
            if (resRectionGuid == null || resRectionGuid.Equals(new Guid()))
                resUserList = TTObjectClasses.ResUser.GetResUserByUserType(context, userTypeEnum);
            else
                resUserList = TTObjectClasses.ResUser.GetResUserByUserTypeAndResource(context, userTypeEnum, (Guid)resRectionGuid);
            foreach (ResUser resUser in resUserList)
            {
                l.Add(resUser);
            }
            return l;

        }
        
#endregion Methods

    }
}