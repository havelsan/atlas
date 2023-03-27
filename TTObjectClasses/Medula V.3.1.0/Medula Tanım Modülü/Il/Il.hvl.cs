
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Il")] 

    public  partial class Il : BaseMedulaDefinition
    {
        public class IlList : TTObjectCollection<Il> { }
                    
        public class ChildIlCollection : TTObject.TTChildObjectCollection<Il>
        {
            public ChildIlCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildIlCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetIlDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? ilKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ILKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["IL"].AllPropertyDefs["ILKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
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

            public GetIlDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetIlDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetIlDefinitionQuery_Class() : base() { }
        }

        public static BindingList<Il.GetIlDefinitionQuery_Class> GetIlDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IL"].QueryDefs["GetIlDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Il.GetIlDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Il.GetIlDefinitionQuery_Class> GetIlDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IL"].QueryDefs["GetIlDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Il.GetIlDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Il> IlListQuery(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["IL"].QueryDefs["IlListQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Il>(queryDef, paramList, injectionSQL);
        }

        public string ilAdi
        {
            get { return (string)this["ILADI"]; }
            set { this["ILADI"] = value; }
        }

        public string ilAdi_Shadow
        {
            get { return (string)this["ILADI_SHADOW"]; }
        }

        public int? ilKodu
        {
            get { return (int?)this["ILKODU"]; }
            set { this["ILKODU"] = value; }
        }

        virtual protected void CreateIlcelerCollection()
        {
            _Ilceler = new Ilce.ChildIlceCollection(this, new Guid("40c0f72d-9ecc-47a3-81e0-fade145dc16b"));
            ((ITTChildObjectCollection)_Ilceler).GetChildren();
        }

        protected Ilce.ChildIlceCollection _Ilceler = null;
        public Ilce.ChildIlceCollection Ilceler
        {
            get
            {
                if (_Ilceler == null)
                    CreateIlcelerCollection();
                return _Ilceler;
            }
        }

        protected Il(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Il(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Il(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Il(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Il(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "IL", dataRow) { }
        protected Il(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "IL", dataRow, isImported) { }
        public Il(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Il(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Il() : base() { }

    }
}