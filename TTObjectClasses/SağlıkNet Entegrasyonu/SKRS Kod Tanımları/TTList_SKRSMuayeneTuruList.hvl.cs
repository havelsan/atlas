
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
    /// Muayene Türü
    /// </summary>
    public partial class TTList_SKRSMuayeneTuruList : TTList
    {
        public TTList_SKRSMuayeneTuruList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SKRSMuayeneTuruList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            SKRSMuayeneTuru o = ttObj as SKRSMuayeneTuru;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.ADI;
        }
    }
}