
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

    public partial class CentralActionPermissionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
            {
                if (DontCheckSite.HasValue && DontCheckSite.Value)
                    return true;

                Sites currentSite = TTObjectClasses.SystemParameter.GetSite();

                BaseCentralAction centralAction = securableObjectInstance as BaseCentralAction;

                List<Guid> newActionRoles = new List<Guid>();
                newActionRoles.Add(new Guid("5a742403-5109-4f43-b524-3a2b7dc2e1d5"));
                newActionRoles.Add(new Guid("0dbcd1a4-3df3-47a3-85c8-4e917e1bdb7a"));
                newActionRoles.Add(new Guid("df867a42-9711-4096-8035-865826f631dd"));
                newActionRoles.Add(new Guid("ecb49c2a-fb6a-4f1d-821c-8601f656d9e6"));
                newActionRoles.Add(new Guid("22ba662e-634c-496d-8111-9e45805ad91b"));
              

                List<Guid> oldActionRoles = new List<Guid>();
                oldActionRoles.Add(new Guid("763e6227-8706-4636-a5fa-0c29c9e398b5"));
                oldActionRoles.Add(new Guid("cb79bd4a-7722-4ae9-aa20-63cc0f082627"));
                oldActionRoles.Add(new Guid("ec08c2b2-8f15-488c-97df-bee7d15dc415"));
                oldActionRoles.Add(new Guid("07eddf45-82e2-4c87-a845-abdbd7821a3e"));
                oldActionRoles.Add(new Guid("4fdd6384-da82-4f29-9570-d7295585afd6"));

                if (centralAction == null)
                    return false;

                if (centralAction is FixedAssetDetailAction)
                {
                    bool isNewDetail = false;
                    bool isOldDetail = false;
                    bool isNewRight = false;
                    bool isOldRight = false;

                    FixedAssetDetailAction fda = centralAction as FixedAssetDetailAction;
                    if (fda.FixedAssetDetailActionDetails[0].IsNewFixedAsset.HasValue && (bool)fda.FixedAssetDetailActionDetails[0].IsNewFixedAsset)
                        isNewDetail = true;
                    else
                        isOldDetail = true;

                    if (isNewDetail)
                    {
                        foreach (TTUserRole r in user.Roles)
                        {
                            if (newActionRoles.Contains(r.RoleID))
                                isNewRight = true;
                        }
                    }

                    if (isOldDetail)
                    {
                        foreach (TTUserRole r in user.Roles)
                        {
                            if (oldActionRoles.Contains(r.RoleID))
                                isOldRight = true;
                        }
                    }

                    if (CheckFromSite.HasValue && CheckFromSite.Value)
                    {
                        if (centralAction.FromSite == null)
                            return false;

                        if (centralAction.FromSite.ObjectID.Equals(currentSite.ObjectID))
                        {
                            if (isOldRight || isNewRight)
                                return true;
                        }
                    }

                    if (CheckToSite.HasValue && CheckToSite.Value)
                    {
                        if (centralAction.ToSite == null)
                            return false;

                        if (centralAction.ToSite.ObjectID.Equals(currentSite.ObjectID))
                        {
                            if (isOldRight || isNewRight)
                                return true;
                        }
                    }
                }
                else
                {
                    if (CheckFromSite.HasValue && CheckFromSite.Value)
                    {
                        if (centralAction.FromSite == null)
                            return false;

                        if (centralAction.FromSite.ObjectID.Equals(currentSite.ObjectID))
                            return true;
                    }

                    if (CheckToSite.HasValue && CheckToSite.Value)
                    {
                        if (centralAction.ToSite == null)
                            return false;

                        if (centralAction.ToSite.ObjectID.Equals(currentSite.ObjectID))
                            return true;
                    }
                }
                return false;
            }
            
#endregion Body
    }
}