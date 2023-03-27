
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Ilce")] 

    public  partial class Ilce : BaseMedulaDefinition
    {
        public class IlceList : TTObjectCollection<Ilce> { }
                    
        public class ChildIlceCollection : TTObject.TTChildObjectCollection<Ilce>
        {
            public ChildIlceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlceDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? ilceKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILCEKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ILCE"].AllPropertyDefs["ILCEKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ilceAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILCEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ILCE"].AllPropertyDefs["ILCEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ilAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IL"].AllPropertyDefs["ILADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetIlceDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlceDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlceDefinitionQuery_Class() : base() { }
        }

        public static BindingList<Ilce.GetIlceDefinitionQuery_Class> GetIlceDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILCE"].QueryDefs["GetIlceDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Ilce.GetIlceDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Ilce.GetIlceDefinitionQuery_Class> GetIlceDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILCE"].QueryDefs["GetIlceDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Ilce.GetIlceDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Ilce> IlceListQuery(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ILCE"].QueryDefs["IlceListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Ilce>(queryDef, paramList, injectionSQL);
        }

        public int? ilceKodu
        {
            get { return (int?)this["ILCEKODU"]; }
            set { this["ILCEKODU"] = value; }
        }

        public string ilceAdi
        {
            get { return (string)this["ILCEADI"]; }
            set { this["ILCEADI"] = value; }
        }

        public string ilceAdi_Shadow
        {
            get { return (string)this["ILCEADI_SHADOW"]; }
        }

        public Il Il
        {
            get { return (Il)((ITTObject)this).GetParent("IL"); }
            set { this["IL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Ilce(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Ilce(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Ilce(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Ilce(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Ilce(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ILCE", dataRow) { }
        protected Ilce(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ILCE", dataRow, isImported) { }
        public Ilce(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Ilce(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Ilce() : base() { }

    }
}