
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
    public  partial class DirectPurchaseGrid : TTObject
    {

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            DateTime dateOfSurgery = (DateTime)EpisodeAction.ActionDate;
            if (EpisodeAction is Surgery)
            {
                dateOfSurgery = ((Surgery)EpisodeAction).GetProperSurgeryDateOrRecTime();
            }
            else if (EpisodeAction is SubSurgery)
            {
                dateOfSurgery = ((SubSurgery)EpisodeAction).Surgery.GetProperSurgeryDateOrRecTime();
            }
            else if (EpisodeAction is SurgeryExtension)
            {
                dateOfSurgery = ((SurgeryExtension)EpisodeAction).MainSurgery.GetProperSurgeryDateOrRecTime();
            }

            var directMaterialSupplyAction = new DirectMaterialSupplyAction(ObjectContext, dateOfSurgery, this);

            #endregion PostInsert
        }

    }
}