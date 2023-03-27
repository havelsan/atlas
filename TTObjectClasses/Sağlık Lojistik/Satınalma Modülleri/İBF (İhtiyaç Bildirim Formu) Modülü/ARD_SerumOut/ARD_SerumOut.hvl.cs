
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ARD_SerumOut")] 

    public  partial class ARD_SerumOut : AnnualRequirementDetailOutOfList
    {
        public class ARD_SerumOutList : TTObjectCollection<ARD_SerumOut> { }
                    
        public class ChildARD_SerumOutCollection : TTObject.TTChildObjectCollection<ARD_SerumOut>
        {
            public ChildARD_SerumOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildARD_SerumOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("d9fc1811-1f02-4d91-905e-96cb589bd920"); } }
            public static Guid New { get { return new Guid("b598888e-7eef-48fb-9f95-495cae2a77ca"); } }
    /// <summary>
    /// Tamam
    /// </summary>
            public static Guid Completed { get { return new Guid("81b0c9a7-849c-4b52-b4b8-acd19a2615c8"); } }
        }

    /// <summary>
    /// Toplam İstek (Kutu)
    /// </summary>
        public Currency? RequestAmountBox
        {
            get { return (Currency?)this["REQUESTAMOUNTBOX"]; }
            set { this["REQUESTAMOUNTBOX"] = value; }
        }

        protected ARD_SerumOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ARD_SerumOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ARD_SerumOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ARD_SerumOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ARD_SerumOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ARD_SERUMOUT", dataRow) { }
        protected ARD_SerumOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ARD_SERUMOUT", dataRow, isImported) { }
        public ARD_SerumOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ARD_SerumOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ARD_SerumOut() : base() { }

    }
}