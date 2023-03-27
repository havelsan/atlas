
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
    /// Tedavi Sonucu (Madde Bağımlılığı)
    /// </summary>
    public partial class TTList_SKRSTedaviSonucuMaddeBagimliligiList : TTList
    {
        public TTList_SKRSTedaviSonucuMaddeBagimliligiList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SKRSTedaviSonucuMaddeBagimliligiList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            SKRSTedaviSonucuMaddeBagimliligi o = ttObj as SKRSTedaviSonucuMaddeBagimliligi;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.ADI;
        }
    }
}