
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
    /// İkame Tedavisi Görme Durumu
    /// </summary>
    public partial class TTList_SKRSIkameTedavisiGormeDurumuList : TTList
    {
        public TTList_SKRSIkameTedavisiGormeDurumuList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SKRSIkameTedavisiGormeDurumuList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            SKRSIkameTedavisiGormeDurumu o = ttObj as SKRSIkameTedavisiGormeDurumu;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.ADI;
        }
    }
}