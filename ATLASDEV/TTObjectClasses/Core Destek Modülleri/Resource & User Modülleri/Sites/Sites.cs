
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
    public  partial class Sites : TerminologyManagerDef, ISites
    {
        public partial class GetSiteDefinition_Class : TTReportNqlObject 
        {
        }

        #region Methods

        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion

        #region ISites Members
        public int? GetASyncTCPPort()
        {
            return ASyncTCPPort;
        }

        public string GetIP()
        {
            return IP;
        }

        public int? GetSyncTCPPort()
        {
            return SyncTCPPort;
        }

        public string GetDatabaseName()
        {
            return DatabaseName;
        }

        public string GetDescription()
        {
            return Description;
        }

        public bool? GetIsPatientExist()
        {
            return IsPatientExist;
        }

        public bool? GetIsTerminologyManagerSite()
        {
            return IsTerminologyManagerSite;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetName(string value)
        {
            Name = value;
        }

        public string GetShortName()
        {
            return ShortName;
        }

        public SiteTypeEnum? GetSiteType()
        {
            return SiteType;
        }
        #endregion

        public static Dictionary<Guid, Sites> AllSites;
        public static Dictionary<Guid, Sites> AllActiveSites;
        public static Dictionary<Guid, Sites> AllActiveSitesWithoutCurrentSiteAndLOCALHOST;

        public static Guid SiteLocalHost = new Guid("0D3B4711-E09B-4F3C-B471-50350C4EE2FE");

        // XXXXXX Sözleşmesi
        public static Guid SiteOrduIlac = new Guid("AFD4D7BC-CAEA-412F-9D55-402042C289FE");
        public static Guid SiteXXXXXX06XXXXXX = new Guid("813DAB74-D4C2-4D81-B5AB-A52BB4FE6093");
        public static Guid SiteSihhiIkmal = new Guid("6BC8B318-698E-4CD7-8179-BB48548800E6");
        public static Guid SiteMerkezSagKom = new Guid("C23C102E-250F-4F3B-B1C6-DC607FECC9E9");
        public static Guid SiteXXXXXX04 = new Guid("a74942dd-1e33-439b-ab11-5da5c6903570");
        public static Guid SiteMerkezSPTS = new Guid("C23C102E-250F-4F3B-B1C6-DC607FECC9E9");




        static Sites()
        {
            TTObjectContext context = new TTObjectContext(true);
            AllSites = new Dictionary<Guid, Sites>();
            foreach (Sites sites in context.QueryObjects<Sites>())
                AllSites.Add(sites.ObjectID, sites);

            AllActiveSites = new Dictionary<Guid, Sites>();
            AllActiveSitesWithoutCurrentSiteAndLOCALHOST = new Dictionary<Guid, Sites>();
            IList actSites = context.QueryObjects("SITES", "ISACTIVE = 1");
            foreach (Sites sites in actSites)
            {
                AllActiveSites.Add(sites.ObjectID, sites);
                if (sites.ObjectID.Equals(Sites.SiteLocalHost) == false && sites.ObjectID.Equals(SystemParameter.GetSite().ObjectID) == false)
                    AllActiveSitesWithoutCurrentSiteAndLOCALHOST.Add(sites.ObjectID, sites);
            }
        }

        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.SitesDefinitionInfo;
        }

        public List<Accountancy> GetMyAccountancies
        {
            get
            {
                List<Accountancy> retValue = null;

                try
                {
                    retValue = new List<Accountancy>();
                    IBindingList milUnits = ObjectContext.QueryObjects(typeof(MilitaryUnit).Name, "SITE = " + ConnectionManager.GuidToString(ObjectID));
                    if (milUnits.Count == 1)
                    {
                        MilitaryUnit militaryUnit = (MilitaryUnit)milUnits[0];
                        IBindingList accs = ObjectContext.QueryObjects(typeof(Accountancy).Name, "ACCOUNTANCYMILITARYUNIT = " + ConnectionManager.GuidToString(militaryUnit.ObjectID));
                        foreach (Accountancy acc in accs)
                            retValue.Add(acc);
                    }
                }
                catch { }

                return retValue;
            }
        }

        public ResOtherHospital MyResOtherHospital()
        {
            if (ResOtherHospital.Count > 0)
                return ResOtherHospital[0];
            return null;
        }

        public override bool IsActiveLocal()
        {
            return false;
        }
        
#endregion Methods

    }
}