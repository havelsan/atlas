
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
    /// Ana Beslenme ve Diyet Sekmesi
    /// </summary>
    public  partial class BaseNutritionDiet : SubActionProcedure
    {
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            Eligible=false;
#endregion PreInsert
        }

#region Methods
        override public bool IsParentRelationReadonly(TTObjectRelationDef relDef)
        {
            if(relDef.RelationDefID==new Guid("ec098848-84c1-4158-8048-1cc584eff621") )
                return false;
            return base.IsParentRelationReadonly(relDef);
        }
        
#endregion Methods

    }
}