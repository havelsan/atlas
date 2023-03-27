
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PainFrequencyDefiniton")] 

    public  partial class PainFrequencyDefiniton : TerminologyManagerDef
    {
        public class PainFrequencyDefinitonList : TTObjectCollection<PainFrequencyDefiniton> { }
                    
        public class ChildPainFrequencyDefinitonCollection : TTObject.TTChildObjectCollection<PainFrequencyDefiniton>
        {
            public ChildPainFrequencyDefinitonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPainFrequencyDefinitonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPainFrequency_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAINFREQUENCYDEFINITON"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPainFrequency_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPainFrequency_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPainFrequency_Class() : base() { }
        }

        public static BindingList<PainFrequencyDefiniton.GetPainFrequency_Class> GetPainFrequency(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINFREQUENCYDEFINITON"].QueryDefs["GetPainFrequency"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainFrequencyDefiniton.GetPainFrequency_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PainFrequencyDefiniton.GetPainFrequency_Class> GetPainFrequency(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAINFREQUENCYDEFINITON"].QueryDefs["GetPainFrequency"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PainFrequencyDefiniton.GetPainFrequency_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
            set { this["NAME_SHADOW"] = value; }
        }

    /// <summary>
    /// Ağrı Sıklığı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected PainFrequencyDefiniton(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PainFrequencyDefiniton(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PainFrequencyDefiniton(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PainFrequencyDefiniton(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PainFrequencyDefiniton(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAINFREQUENCYDEFINITON", dataRow) { }
        protected PainFrequencyDefiniton(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAINFREQUENCYDEFINITON", dataRow, isImported) { }
        public PainFrequencyDefiniton(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PainFrequencyDefiniton(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PainFrequencyDefiniton() : base() { }

    }
}