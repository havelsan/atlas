
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
    /// Tıbbi Cihaz - Parametre Eşleştirme
    /// </summary>
    public  partial class FixedAssetParameterMatch : BaseAction, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            
            
            
            


            foreach (MatchFixedAsset matchFixedAsset in MatchFixedAssets)
            {
                Dictionary<Guid, UserLevelMaintParameter> userParameter = new Dictionary<Guid, UserLevelMaintParameter>();
                Dictionary<Guid, UnitLevelMaintParameter> unitParameter = new Dictionary<Guid, UnitLevelMaintParameter>();
                foreach (UserLevelMaintParameter userLevel in matchFixedAsset.FixedAssetDefinition.UserLevelMaintParameters)
                {
                    userParameter.Add(userLevel.UserParameter.ObjectID, userLevel);
                }
                foreach (UnitLevelMaintParameter unitLevel in matchFixedAsset.FixedAssetDefinition.UnitLevelMaintParameters)
                {
                    unitParameter.Add(unitLevel.UnitParameter.ObjectID, unitLevel);
                }

                foreach (MatchUserParameter user in MatchUserParameters)
                {
                    if (userParameter.ContainsKey(user.UserParameter.ObjectID) == false)
                    {
                        UserLevelMaintParameter userLevel = new UserLevelMaintParameter(ObjectContext);
                        userLevel.UserParameter = user.UserParameter;
                        matchFixedAsset.FixedAssetDefinition.UserLevelMaintParameters.Add(userLevel);
                    }
                }
                foreach (MatchUnitParameter unit in MatchUnitParameters)
                {
                    if (unitParameter.ContainsKey(unit.UnitParameter.ObjectID) == false)
                    {
                        UnitLevelMaintParameter unitLevel = new UnitLevelMaintParameter(ObjectContext);
                        unitLevel.UnitParameter = unit.UnitParameter;
                        matchFixedAsset.FixedAssetDefinition.UnitLevelMaintParameters.Add(unitLevel);
                    }
                }

            }

#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FixedAssetParameterMatch).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FixedAssetParameterMatch.States.New && toState == FixedAssetParameterMatch.States.Completed)
                PreTransition_New2Completed();
        }

    }
}