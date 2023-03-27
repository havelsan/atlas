
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SevkNedeni")] 

    /// <summary>
    /// Sevk Nedeni
    /// </summary>
    public  partial class SevkNedeni : BaseMedulaDefinition
    {
        public class SevkNedeniList : TTObjectCollection<SevkNedeni> { }
                    
        public class ChildSevkNedeniCollection : TTObject.TTChildObjectCollection<SevkNedeni>
        {
            public ChildSevkNedeniCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSevkNedeniCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSevkNedeniDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string SevkNedeniKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKNEDENIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKNEDENI"].AllPropertyDefs["SEVKNEDENIKODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SevkNedeniAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SEVKNEDENIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SEVKNEDENI"].AllPropertyDefs["SEVKNEDENIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSevkNedeniDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSevkNedeniDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSevkNedeniDefinitionQuery_Class() : base() { }
        }

        public static BindingList<SevkNedeni.GetSevkNedeniDefinitionQuery_Class> GetSevkNedeniDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKNEDENI"].QueryDefs["GetSevkNedeniDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkNedeni.GetSevkNedeniDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SevkNedeni.GetSevkNedeniDefinitionQuery_Class> GetSevkNedeniDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SEVKNEDENI"].QueryDefs["GetSevkNedeniDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SevkNedeni.GetSevkNedeniDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Sevk Nedeni Adı
    /// </summary>
        public string SevkNedeniAdi
        {
            get { return (string)this["SEVKNEDENIADI"]; }
            set { this["SEVKNEDENIADI"] = value; }
        }

    /// <summary>
    /// Sevk Nedeni Kodu
    /// </summary>
        public string SevkNedeniKodu
        {
            get { return (string)this["SEVKNEDENIKODU"]; }
            set { this["SEVKNEDENIKODU"] = value; }
        }

        public string SevkNedeniAdi_Shadow
        {
            get { return (string)this["SEVKNEDENIADI_SHADOW"]; }
            set { this["SEVKNEDENIADI_SHADOW"] = value; }
        }

        protected SevkNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SevkNedeni(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SevkNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SevkNedeni(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SevkNedeni(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SEVKNEDENI", dataRow) { }
        protected SevkNedeni(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SEVKNEDENI", dataRow, isImported) { }
        public SevkNedeni(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SevkNedeni(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SevkNedeni() : base() { }

    }
}