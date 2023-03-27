
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TaniTeshisİliskisi")] 

    public  partial class TaniTeshisİliskisi : TTObject
    {
        public class TaniTeshisİliskisiList : TTObjectCollection<TaniTeshisİliskisi> { }
                    
        public class ChildTaniTeshisİliskisiCollection : TTObject.TTChildObjectCollection<TaniTeshisİliskisi>
        {
            public ChildTaniTeshisİliskisiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTaniTeshisİliskisiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public DiagnosisGrid DiagnosisGrid
        {
            get { return (DiagnosisGrid)((ITTObject)this).GetParent("DIAGNOSISGRID"); }
            set { this["DIAGNOSISGRID"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Teshis Teshis
        {
            get { return (Teshis)((ITTObject)this).GetParent("TESHIS"); }
            set { this["TESHIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ReportDiagnosis ReportDiagnosis
        {
            get { return (ReportDiagnosis)((ITTObject)this).GetParent("REPORTDIAGNOSIS"); }
            set { this["REPORTDIAGNOSIS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected TaniTeshisİliskisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TaniTeshisİliskisi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TaniTeshisİliskisi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TaniTeshisİliskisi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TaniTeshisİliskisi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TANITESHISİLISKISI", dataRow) { }
        protected TaniTeshisİliskisi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TANITESHISİLISKISI", dataRow, isImported) { }
        public TaniTeshisİliskisi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TaniTeshisİliskisi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TaniTeshisİliskisi() : base() { }

    }
}