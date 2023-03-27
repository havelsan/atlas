
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
    /// Kolorektal Biyopsi Sonucu
    /// </summary>
    public partial class TTList_SKRSKolorektalBiyopsiSonucuList : TTList
    {
        public TTList_SKRSKolorektalBiyopsiSonucuList(TTListDef listDef, string listFilterExpression) : base(listDef, listFilterExpression)
        {
        }

        public TTList_SKRSKolorektalBiyopsiSonucuList(TTObjectContext objectContext, TTListDef listDef, string listFilterExpression) : base(objectContext, listDef, listFilterExpression)
        {
        }

        override public string GetDisplayText(TTObject ttObj)
        {
            SKRSKolorektalBiyopsiSonucu o = ttObj as SKRSKolorektalBiyopsiSonucu;
            if (o == null)
                throw new TTException("Invalid object type.");
            return o.ADI;
        }
    }
}