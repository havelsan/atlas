
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaSUT")] 

    public  partial class MedulaSUT : BaseMedulaDefinition
    {
        public class MedulaSUTList : TTObjectCollection<MedulaSUT> { }
                    
        public class ChildMedulaSUTCollection : TTObject.TTChildObjectCollection<MedulaSUT>
        {
            public ChildMedulaSUTCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaSUTCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaSUTDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string sutKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULASUT"].AllPropertyDefs["SUTKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sutAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULASUT"].AllPropertyDefs["SUTADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetMedulaSUTDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaSUTDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaSUTDefinitionQuery_Class() : base() { }
        }

        public static BindingList<MedulaSUT.GetMedulaSUTDefinitionQuery_Class> GetMedulaSUTDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULASUT"].QueryDefs["GetMedulaSUTDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaSUT.GetMedulaSUTDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaSUT.GetMedulaSUTDefinitionQuery_Class> GetMedulaSUTDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULASUT"].QueryDefs["GetMedulaSUTDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaSUT.GetMedulaSUTDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string sutAdi_Shadow
        {
            get { return (string)this["SUTADI_SHADOW"]; }
        }

    /// <summary>
    /// SUT Adı
    /// </summary>
        public string sutAdi
        {
            get { return (string)this["SUTADI"]; }
            set { this["SUTADI"] = value; }
        }

    /// <summary>
    /// SUT Kodu
    /// </summary>
        public string sutKodu
        {
            get { return (string)this["SUTKODU"]; }
            set { this["SUTKODU"] = value; }
        }

        public bool? disTaahhutAlinmalidir
        {
            get { return (bool?)this["DISTAAHHUTALINMALIDIR"]; }
            set { this["DISTAAHHUTALINMALIDIR"] = value; }
        }

        protected MedulaSUT(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaSUT(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaSUT(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaSUT(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaSUT(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULASUT", dataRow) { }
        protected MedulaSUT(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULASUT", dataRow, isImported) { }
        public MedulaSUT(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaSUT(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaSUT() : base() { }

    }
}