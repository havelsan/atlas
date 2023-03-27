
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
    public  abstract  partial class TerminologyManagerDef : TTDefinitionSet
    {
        public partial class GetAllDefsByLastUpdate_ReportQuery_Class : TTReportNqlObject 
        {
        }

        
                    
        protected override void PreDelete()
        {
#region PreDelete
            base.PreDelete();
            
            //if(this is FixedAssetMaterialDefinition == false && this is MaterialPrice == false)
            //        throw new TTUtils.TTException(SystemMessage.GetMessage(578));

#endregion PreDelete
        }

#region Methods
        // TerminologyManagerDef olan tanımların TerminologyManagerDef olan gridlerini tek tek alır paketini hazırlar.

        List<TTObject> package;
        public virtual List<TTObject> GetMyDefinitionPackage()
        {
            if (this is TerminologyManagerDef)
            {

                package = new List<TTObject>();
                if (!package.Contains(this))
                {
                    package.Add(this);
                    AddParentObjects((TTObject)this);
                }

                if (GetMyChildTerminologyManagerDefs())
                {
                    foreach (TTObjectRelationDef relDef in ObjectDef.AllChildRelationDefs)
                    {
                        if (!string.IsNullOrEmpty(relDef.ChildrenName))
                        {
                            object childCollection = GetType().GetProperty(relDef.ChildrenName).GetValue(this, null);
                            ITTChildObjectCollection cc = childCollection as ITTChildObjectCollection;
                            foreach (TTObject childobject in cc)
                            {
                                if (childobject != null)
                                {
                                    if (childobject is TerminologyManagerDef)
                                    {
                                        if (((TerminologyManagerDef)childobject).SendMeWithMyParentTerminologyManagerDefs())
                                        {
                                            if (!package.Contains(childobject))
                                            {
                                                package.Add(childobject);
                                                AddParentObjects(childobject);
                                                List<TTObject> childPackage = ((TerminologyManagerDef)childobject).GetMyDefinitionPackage();
                                                foreach (TTObject childOfchild in childPackage)
                                                {
                                                    if (childOfchild != null && (!package.Contains(childOfchild)) && childOfchild is TerminologyManagerDef)
                                                    {
                                                        package.Add(childOfchild);
                                                        AddParentObjects(childOfchild);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return package;
            }
            return null;
        }

        private void AddParentObjects(TTObject obj)
        {
            foreach (TTObjectRelationDef prelDef in obj.ObjectDef.AllParentRelationDefs)
            {
                if (string.IsNullOrEmpty(prelDef.CodeName))
                    continue;
                System.Reflection.PropertyInfo propInfo = obj.GetType().GetProperty(prelDef.CodeName);
                object parentObj = propInfo.GetValue(obj, null);
                if (parentObj is TerminologyManagerDef && package.Contains((TTObject)parentObj) == false)
                    package.Add((TTObject)parentObj);
            }
        }

        public virtual bool IsActiveLocal()
        {
            return true;
        }
        public virtual List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = new List<string>();
            if (IsActiveLocal())
                localPropertyNamesList.Add("IsActive");
            return localPropertyNamesList;
        }

        protected TerminologyManagerDef PrepareTerminologyManagerDefForRemoteMethod()
        {
            // Çağırılan yerde savePoit konulup daha sonra o pointe dönülmeli
            List<string> localPropertyNamesList = GetMyLocalPropertyNamesList();
            if (localPropertyNamesList != null)
            {
                foreach (string localPropertyName in localPropertyNamesList)
                {
                    System.Reflection.PropertyInfo propInfo = GetType().GetProperty(localPropertyName);
                    if (propInfo != null)
                        propInfo.SetValue(this, null, null);
                }
            }
            return this;
        }

        public static bool IsAuthorized()
        {
            Sites site = TTObjectClasses.SystemParameter.GetSite();

            if (site.IsTerminologyManagerSite.HasValue && site.IsTerminologyManagerSite.Value)
                return true;
            else
                return false;
        }



        public static Dictionary<Guid, Sites> GetMyTargetSites(TerminologyManagerDef terminologyManagerDef)
        {
            Dictionary<Guid, Sites> siteList = new Dictionary<Guid, Sites>();
            TTObjectContext context = new TTObjectContext(true);

            if (terminologyManagerDef is StockCard)
            {
                if (((StockCard)terminologyManagerDef).CreatedSite == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(579));

                Sites site = (Sites)context.GetObject(((StockCard)terminologyManagerDef).CreatedSite.ObjectID, typeof(Sites).Name);
                if (site.ObjectID.Equals(Sites.SiteMerkezSagKom))
                    return Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST;
                else
                    siteList.Add(site.ObjectID, site);
            }
            else if (terminologyManagerDef is Sites)
            {
                Sites site = (Sites)terminologyManagerDef;
                if (site.ObjectID.Equals(Sites.SiteLocalHost) == false)
                    return Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST;
                else
                    return new Dictionary<Guid, Sites>();
            }
            else
            {
                Guid localSiteGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                IList tempList = TermManagerSiteDefObject.GetSiteDefObjectByObjDefID(context, terminologyManagerDef.ObjectDef.ID);
                if (tempList.Count == 0)
                    return Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST;
                else if (siteList.Count > 1)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(581));
                else
                {
                    TermManagerSiteDefObject termManagerSiteDefObject = (TermManagerSiteDefObject)tempList[0];
                    if (termManagerSiteDefObject.TerminologyManagerSite.EditorSite.ObjectID != Sites.SiteMerkezSagKom)
                    {
                        Sites site = (Sites)context.GetObject(Sites.SiteMerkezSagKom, typeof(Sites).Name);
                        siteList.Add(site.ObjectID, site);
                    }
                    else
                        return Sites.AllActiveSitesWithoutCurrentSiteAndLOCALHOST;
                }
            }

            return siteList;
        }

        public static void RunSendWithTerminologyManagerDef(TerminologyManagerDef terminologyManagerDef)
        {
            RunSendWithTerminologyManagerDefV3(terminologyManagerDef, null, true);
        }

        public static void RunSendWithTerminologyManagerDefV2(TerminologyManagerDef terminologyManagerDef, List<Sites> targetSites)
        {
            RunSendWithTerminologyManagerDefV3(terminologyManagerDef, null, true);
        }

        public static void RunSendWithTerminologyManagerDefV3(TerminologyManagerDef terminologyManagerDef, List<Sites> targetSites, bool checkAuthority)
        {
            if (checkAuthority)
                if (IsAuthorized() == false)
                    return;

            List<TerminologyManagerDef> terManList = new List<TerminologyManagerDef>();
            terManList.Add(terminologyManagerDef);
            if (targetSites == null)
                SendPackages(terManList);
            else
                SendPackagesV2(terManList, targetSites);
        }

        public static void RunSendTerminologyManagerDef(DateTime startDate)
        {
            RunSendTerminologyManagerDefV2(startDate, null);
        }

        public static void RunSendTerminologyManagerDefV2(DateTime startDate, List<Sites> targetSites)
        {
            if (IsAuthorized())
            {
                TTObjectContext context = new TTObjectContext(false);
                IBindingList objects = TerminologyManagerDef.GetAllDefsByLastUpdate(context, startDate);
                List<TerminologyManagerDef> terManList = new List<TerminologyManagerDef>();

                foreach (TerminologyManagerDef terminologyManagerDef in objects)
                    terManList.Add(terminologyManagerDef);

                if (targetSites == null)
                    SendPackages(terManList);
                else
                    SendPackagesV2(terManList, targetSites);
            }
        }


        public static void SendPackages(List<TerminologyManagerDef> terMans)
        {
            SendPackagesV2(terMans, null);
        }

        public static void SendPackagesV2(List<TerminologyManagerDef> terMans, List<Sites> targetSites)
        {
            List<TTObjectDef> objDefList = new List<TTObjectDef>();


            foreach (TerminologyManagerDef terminologyManagerDef in terMans)
            {
                if (objDefList.Contains(terminologyManagerDef.ObjectDef) == false)
                {
                    objDefList.Add(terminologyManagerDef.ObjectDef);
                }

                List<TTObject> package = terminologyManagerDef.GetMyDefinitionPackage();
                if (package != null)
                {
                    foreach (TTObject packageObject in package)
                    {
                        if (packageObject is TerminologyManagerDef)
                            ((TerminologyManagerDef)packageObject).PrepareTerminologyManagerDefForRemoteMethod();
                    }

                    List<Guid> siteIDs = new List<Guid>();
                    if (targetSites == null)
                    {
                        foreach (KeyValuePair<Guid, Sites> targetSite in GetMyTargetSites(terminologyManagerDef))
                            siteIDs.Add(targetSite.Key);
                    }
                    else
                    {
                        foreach (Sites targetSite in targetSites)
                            siteIDs.Add(targetSite.ObjectID);
                    }
                    if (siteIDs.Count == 0)
                        throw new TTUtils.TTException(SystemMessage.GetMessage(566));


                    //if (package.Count > 0)
                    //{
                    //    TerminologyManagerDef.RemoteMethods.SendTerminologyManagerDef(siteIDs, package);
                    //}
                }
            }
        }

        public virtual bool GetMyChildTerminologyManagerDefs() //Childlarının  alınmasını istemediğimiz tanım ekranları için false döndürülmeli
        {
            return true;
        }

        public virtual bool SendMeWithMyParentTerminologyManagerDefs() //Parentlarıyla gitmesini istemediğimiz tanım ekranları için false döndürülmeli
        {
            return true;
        }

        public virtual SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return null;
        }
        
        public virtual BaseSKRSDefinition GetSKRSDefinition()
        {
            return null;
        }
        
#endregion Methods

    }
}