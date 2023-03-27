
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FTRVucutBolgesi")] 

    public  partial class FTRVucutBolgesi : BaseMedulaDefinition
    {
        public class FTRVucutBolgesiList : TTObjectCollection<FTRVucutBolgesi> { }
                    
        public class ChildFTRVucutBolgesiCollection : TTObject.TTChildObjectCollection<FTRVucutBolgesi>
        {
            public ChildFTRVucutBolgesiCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFTRVucutBolgesiCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFTRVucutBolgesiDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? ftrVucutBolgesiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRVUCUTBOLGESIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string ftrVucutBolgesiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRVUCUTBOLGESIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetFTRVucutBolgesiDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFTRVucutBolgesiDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFTRVucutBolgesiDefinitionQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetFTRVucutBolgesiQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string ftrVucutBolgesiAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRVUCUTBOLGESIADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ftrVucutBolgesiAdi_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRVUCUTBOLGESIADI_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIADI_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ftrVucutBolgesiKodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FTRVUCUTBOLGESIKODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].AllPropertyDefs["FTRVUCUTBOLGESIKODU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetFTRVucutBolgesiQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFTRVucutBolgesiQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFTRVucutBolgesiQuery_Class() : base() { }
        }

        public static BindingList<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class> GetFTRVucutBolgesiDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].QueryDefs["GetFTRVucutBolgesiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class> GetFTRVucutBolgesiDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].QueryDefs["GetFTRVucutBolgesiDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FTRVucutBolgesi.GetFTRVucutBolgesiDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class> GetFTRVucutBolgesiQuery(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].QueryDefs["GetFTRVucutBolgesiQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class> GetFTRVucutBolgesiQuery(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].QueryDefs["GetFTRVucutBolgesiQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FTRVucutBolgesi.GetFTRVucutBolgesiQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Vücut Bölgesi Kodundan Vücut Bölgesi Sorgulama
    /// </summary>
        public static BindingList<FTRVucutBolgesi> GetFTRVucutBolgesiByCode(TTObjectContext objectContext, string CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].QueryDefs["GetFTRVucutBolgesiByCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<FTRVucutBolgesi>(queryDef, paramList);
        }

        public static BindingList<FTRVucutBolgesi> GetFTRVucutBolgesi(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FTRVUCUTBOLGESI"].QueryDefs["GetFTRVucutBolgesi"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<FTRVucutBolgesi>(queryDef, paramList);
        }

        public string ftrVucutBolgesiAdi
        {
            get { return (string)this["FTRVUCUTBOLGESIADI"]; }
            set { this["FTRVUCUTBOLGESIADI"] = value; }
        }

        public string ftrVucutBolgesiAdi_Shadow
        {
            get { return (string)this["FTRVUCUTBOLGESIADI_SHADOW"]; }
            set { this["FTRVUCUTBOLGESIADI_SHADOW"] = value; }
        }

        public int? ftrVucutBolgesiKodu
        {
            get { return (int?)this["FTRVUCUTBOLGESIKODU"]; }
            set { this["FTRVUCUTBOLGESIKODU"] = value; }
        }

        protected FTRVucutBolgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FTRVucutBolgesi(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FTRVucutBolgesi(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FTRVucutBolgesi(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FTRVucutBolgesi(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FTRVUCUTBOLGESI", dataRow) { }
        protected FTRVucutBolgesi(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FTRVUCUTBOLGESI", dataRow, isImported) { }
        public FTRVucutBolgesi(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FTRVucutBolgesi(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FTRVucutBolgesi() : base() { }

    }
}