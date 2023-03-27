
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


namespace TTStorageManager.Security
{

    public partial class StockActionPermissionDefinition : TTSecurityAuthority
    {
        #region Body
        bool CheckCardDrawer(StockAction sta, ResUser resUser)
        {
            if (sta.AccountingTerm != null)
            {
                if (sta.SelectedCardDrawers.Count > 0)
                {
                    if (resUser.SecMasterUserResources.Count == 0)
                        return false;
                    bool isAccess = false;
                    foreach (Resource resource in resUser.SecMasterUserResources)
                    {
                        if (resource is ResCardDrawer)
                        {
                            if (sta.SelectedCardDrawers.ContainsKey(resource.ObjectID))
                            {
                                isAccess = true;
                                break;
                            }
                        }
                    }
                    return isAccess;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        bool CheckStorePrivate(ResUser user, Store store)
        {
            if (user.InPatientUserResources != null)
            {
                foreach (Resource inResource in user.InPatientUserResources)
                {
                    if (inResource.Store != null)
                    {
                        if (store.ObjectID.Equals(inResource.Store.ObjectID))
                            return true;
                    }
                }
            }

            if (user.OutPatientUserResources != null)
            {
                foreach (Resource outResource in user.OutPatientUserResources)
                {
                    if (outResource.Store != null)
                    {
                        if (store.ObjectID.Equals(outResource.Store.ObjectID))
                            return true;
                    }
                }
            }

            if (user.SecMasterUserResources != null)
            {
                foreach (Resource secResource in user.SecMasterUserResources)
                {
                    if (secResource.Store != null)
                    {
                        if (store.ObjectID.Equals(secResource.Store.ObjectID))
                            return true;
                    }
                }
            }

            return false;
        }

        protected override bool HasRight(TTUser user, object securableObjectInstance)
        {
            if (DontCheckStore.HasValue && DontCheckStore.Value)
                return true;

            StockAction sta = securableObjectInstance as StockAction;
            if (CheckStore.HasValue && CheckStore.Value)
            {

                if (sta == null)
                    return false;
                if (sta.Store == null)
                    return false;

                ResUser resUser = user.UserObject as ResUser;
                if (resUser == null)
                    return false;

                if (CheckStorePrivate(resUser, sta.Store))
                {
                    if (sta.Store is MainStoreDefinition)
                    {
                        return CheckCardDrawer(sta, resUser);
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            if (CheckDestinationStore.HasValue && CheckDestinationStore.Value)
            {
                if (sta == null)
                    return false;
                if (sta.DestinationStore == null)
                    return false;

                ResUser resUser = user.UserObject as ResUser;
                if (resUser == null)
                    return false;

                if (CheckStorePrivate(resUser, sta.DestinationStore))
                {
                    if (sta.DestinationStore is MainStoreDefinition)
                    {
                        return CheckCardDrawer(sta, resUser);
                    }
                    else
                    {
                        return true;
                    }
                }
            }

            if (CheckHospital.HasValue && CheckHospital.Value)
            {
                if (sta is PurchaseExamination)
                {
                    PurchaseExamination pe = (PurchaseExamination)sta;

                    Guid guid = new Guid("f0478622-55cd-42c9-a46c-ecbeb93a164d");
                    if (Common.CurrentUser.HasRole(guid))
                        return true;

                    if (pe.CurrentStateDefID != PurchaseExamination.States.FunctionalExamination)
                        return false;

                    ArrayList sections = new ArrayList();
                    foreach (ResSection res in Common.CurrentResource.SelectedResources)
                    {
                        sections.Add(res.ObjectID);
                    }

                    foreach (PurchaseExaminationDetail ped in pe.PurchaseExaminationDetails)
                        foreach (ExaminationDetail ed in ped.ExaminationDetails)
                            if (ed.ResSection != null)
                                if (sections.Contains(ed.ResSection.ObjectID))
                                    return true;
                }
                else
                    return true;
            }

            return false;
        }

        #endregion Body
    }
}