
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PaketHaric")] 

    /// <summary>
    /// Paket Hariç
    /// </summary>
    public  partial class PaketHaric : BaseMedulaDefinition
    {
        public class PaketHaricList : TTObjectCollection<PaketHaric> { }
                    
        public class ChildPaketHaricCollection : TTObject.TTChildObjectCollection<PaketHaric>
        {
            public ChildPaketHaricCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPaketHaricCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPaketHaricDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string paketHaricKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAKETHARICKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAKETHARIC"].AllPropertyDefs["PAKETHARICKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string paketHaricAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAKETHARICADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAKETHARIC"].AllPropertyDefs["PAKETHARICADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPaketHaricDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPaketHaricDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPaketHaricDefinitionQuery_Class() : base() { }
        }

        public static BindingList<PaketHaric.GetPaketHaricDefinitionQuery_Class> GetPaketHaricDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAKETHARIC"].QueryDefs["GetPaketHaricDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PaketHaric.GetPaketHaricDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PaketHaric.GetPaketHaricDefinitionQuery_Class> GetPaketHaricDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PAKETHARIC"].QueryDefs["GetPaketHaricDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PaketHaric.GetPaketHaricDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string paketHaricAdi_Shadow
        {
            get { return (string)this["PAKETHARICADI_SHADOW"]; }
        }

    /// <summary>
    /// Paket Hariç Kodu
    /// </summary>
        public string paketHaricKodu
        {
            get { return (string)this["PAKETHARICKODU"]; }
            set { this["PAKETHARICKODU"] = value; }
        }

    /// <summary>
    /// Paket Hariç Adı
    /// </summary>
        public string paketHaricAdi
        {
            get { return (string)this["PAKETHARICADI"]; }
            set { this["PAKETHARICADI"] = value; }
        }

        protected PaketHaric(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PaketHaric(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PaketHaric(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PaketHaric(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PaketHaric(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PAKETHARIC", dataRow) { }
        protected PaketHaric(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PAKETHARIC", dataRow, isImported) { }
        public PaketHaric(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PaketHaric(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PaketHaric() : base() { }

    }
}