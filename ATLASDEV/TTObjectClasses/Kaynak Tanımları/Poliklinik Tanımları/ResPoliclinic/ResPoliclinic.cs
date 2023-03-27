
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
    /// Poliklinik
    /// </summary>
    public  partial class ResPoliclinic : ResSection
    {
        public partial class OLAP_GetResPoliclinicCount_Class : TTReportNqlObject 
        {
        }

        public partial class GetPoliclinicDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class GetMHRSPoliclinicDefinition_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            base.PreUpdate();
            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            UpdateDepartmentKiosk();
            base.PostUpdate();

            #endregion PostUpdate
        }

        protected override void PreInsert()
        {
            #region PreInsert
            UpdateDepartmentKiosk();
            base.PreInsert();

            #endregion PreInsert
        }


        #region Methods
        [LooselyTypeAttribute]
        [Serializable]
        public class NIComCode
        {
            public string ObjectId;
            public string CodeName;
            public string Code;
            public string Definition;
        }

        public static void SendResPoliclinicToMainGateOperation(ResPoliclinic resPoliclinic)
        {
            IList<ResPoliclinic.NIComCode> itemList = new List<ResPoliclinic.NIComCode>();
            ResPoliclinic.NIComCode policlinicNIComCode = new ResPoliclinic.NIComCode();
            policlinicNIComCode.ObjectId = resPoliclinic.ObjectID.ToString();
            policlinicNIComCode.CodeName = resPoliclinic.Name.ToString();
            policlinicNIComCode.Code = "";
            policlinicNIComCode.Definition = resPoliclinic.Name.ToString();
            itemList.Add(policlinicNIComCode);
            //TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.LowPriority, "Nebula.Integration", "NebulaIntegrationUtils", "SavePoliclinic", null, itemList);
        }

        //AÇILACAK bb
        //        private bool IspublicPropertiesUpdated()
        //        {
        //            if (((ITTObject)this).IsNew)
        //                return true;
        //            ResPoliclinic originalPoliclinic = ((ITTObject)this).Original as ResPoliclinic;
        //            if (originalPoliclinic != null)
        //            {
        //                if(originalPoliclinic.Name != this.Name)
        //                    return true;
        //            }
        //            return false;
        //        }
        public void CreateOrUpdateBoundReferableResource()
                {
                    Guid mySiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                    IList<ReferableResource> referableResourceList = ReferableResource.GetByResourceObjectID(ObjectContext, ObjectID.ToString());
                    List<ReferableResource> rList = new List<ReferableResource>();
                    ReferableResource referableResource = null;
                    bool checkRefChange = false;
                    if (referableResourceList.Count <= 0)
                        referableResource = (ReferableResource)(ObjectContext.CreateObject("ReferableResource"));
                    else{
                        referableResource = referableResourceList[0];
                        checkRefChange = true;
                    }
                    
                    if(checkRefChange && referableResource.ResourceName != Name && referableResource.IsActive != IsActive){
                        referableResource.ResourceName = Name;
                        //referableResource.ResourceName_Shadow = this.Name_Shadow;
                        referableResource.ResourceObjectID = ObjectID.ToString();
                        referableResource.LastUpdateSiteGuid = mySiteGuid;
                        referableResource.IsActive = IsActive;
                        Guid? lastUpdateGuid = referableResource.LastUpdateSiteGuid;
                        Sites mySite = SystemParameter.GetSite();
                        ResOtherHospital myResOtherHospital = null;
                        ReferableHospital myReferableHospital = null;
                        if (mySite != null)
                        {
                            myResOtherHospital = mySite.MyResOtherHospital();
                            if (myResOtherHospital != null)
                            {
                                myReferableHospital = myResOtherHospital.MyReferableHospital();
                                if (myReferableHospital != null)
                                    referableResource.ReferableHospital = myReferableHospital;
                                else //yeni referable hospital create et. heryere gönder.
                                    throw new TTCallAdminException(SystemMessage.GetMessage(563));
                                    //return;
                            }
                            else
                                throw new TTCallAdminException(SystemMessage.GetMessage(564));
                                //return;
                        }
                        else
                            throw new TTCallAdminException(SystemMessage.GetMessage(565));
                            //return;
    
                        //her sahaya bu objeyi gönderelim
                        List<Guid> siteIDs = new List<Guid>();
                        foreach (KeyValuePair<Guid, Sites> targetSite in Sites.AllActiveSites)
                            if (targetSite.Key!=Sites.SiteLocalHost) siteIDs.Add(targetSite.Key);
                        if (siteIDs.Count == 0)
                            throw new TTCallAdminException(SystemMessage.GetMessage(566));
                        
                        //ReferableResource.RemoteMethods.UpdateOrCreateReferableResource(siteIDs, referableResource);
                        //referableResource.LastUpdateSiteGuid = Guid.Empty;//Yeni bir Updatede eski updatein etkisinde kalmasın diye her seferinde null yapılıp bırakılıyor.
                    }
                }

        public static BindingList<ResPoliclinic> GetHCPoliclinicList()
        {
            BindingList<ResPoliclinic> HCpoliclinicList = new BindingList<ResPoliclinic>();
            TTObjectContext objectContext = new TTObjectContext(true);
            HCpoliclinicList = ResPoliclinic.GetHCPoliclinic(objectContext);
            return HCpoliclinicList;
        }

        public void UpdateDepartmentKiosk()
        {
            if (this.ShownInKiosk.HasValue && this.ShownInKiosk.Value)
                this.Department.ShownInKiosk = true;
        }
        
#endregion Methods

    }
}