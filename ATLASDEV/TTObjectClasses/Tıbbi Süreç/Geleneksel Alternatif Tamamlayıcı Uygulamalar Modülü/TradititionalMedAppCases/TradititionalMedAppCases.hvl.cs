
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TradititionalMedAppCases")] 

    public  partial class TradititionalMedAppCases : TTObject
    {
        public class TradititionalMedAppCasesList : TTObjectCollection<TradititionalMedAppCases> { }
                    
        public class ChildTradititionalMedAppCasesCollection : TTObject.TTChildObjectCollection<TradititionalMedAppCases>
        {
            public ChildTradititionalMedAppCasesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTradititionalMedAppCasesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Getat Uygulandığı Durumlar
    /// </summary>
        public SKRSGETATUygulandigiDurumlar SKRSGetatAppliedCases
        {
            get { return (SKRSGETATUygulandigiDurumlar)((ITTObject)this).GetParent("SKRSGETATAPPLIEDCASES"); }
            set { this["SKRSGETATAPPLIEDCASES"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Traditional Medicine
    /// </summary>
        public TraditionalMedicine TraditionalMedicine
        {
            get { return (TraditionalMedicine)((ITTObject)this).GetParent("TRADITIONALMEDICINE"); }
            set { this["TRADITIONALMEDICINE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TradititionalMedAppCases(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TradititionalMedAppCases(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TradititionalMedAppCases(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TradititionalMedAppCases(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TradititionalMedAppCases(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TRADITITIONALMEDAPPCASES", dataRow) { }
        protected TradititionalMedAppCases(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TRADITITIONALMEDAPPCASES", dataRow, isImported) { }
        public TradititionalMedAppCases(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TradititionalMedAppCases(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TradititionalMedAppCases() : base() { }

    }
}