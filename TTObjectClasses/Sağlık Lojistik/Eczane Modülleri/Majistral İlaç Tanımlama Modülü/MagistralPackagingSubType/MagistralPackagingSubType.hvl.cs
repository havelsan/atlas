
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MagistralPackagingSubType")] 

    /// <summary>
    /// Majistral Ambalaj Tipi Eşleştirme
    /// </summary>
    public  partial class MagistralPackagingSubType : TerminologyManagerDef
    {
        public class MagistralPackagingSubTypeList : TTObjectCollection<MagistralPackagingSubType> { }
                    
        public class ChildMagistralPackagingSubTypeCollection : TTObject.TTChildObjectCollection<MagistralPackagingSubType>
        {
            public ChildMagistralPackagingSubTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMagistralPackagingSubTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMagistralPackagingSubTypeDefinition_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPACKAGINGSUBTYPE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Material
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CONSUMABLEMATERIALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMagistralPackagingSubTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMagistralPackagingSubTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMagistralPackagingSubTypeDefinition_Class() : base() { }
        }

        public static BindingList<MagistralPackagingSubType.GetMagistralPackagingSubTypeDefinition_Class> GetMagistralPackagingSubTypeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPACKAGINGSUBTYPE"].QueryDefs["GetMagistralPackagingSubTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MagistralPackagingSubType.GetMagistralPackagingSubTypeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MagistralPackagingSubType.GetMagistralPackagingSubTypeDefinition_Class> GetMagistralPackagingSubTypeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPACKAGINGSUBTYPE"].QueryDefs["GetMagistralPackagingSubTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MagistralPackagingSubType.GetMagistralPackagingSubTypeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MagistralPackagingSubType> GetMagistralPackSubTypebyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAGISTRALPACKAGINGSUBTYPE"].QueryDefs["GetMagistralPackSubTypebyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MagistralPackagingSubType>(queryDef, paramList);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// SPTS Packaging Sub Type ID
    /// </summary>
        public long? SPTSPackagingSubTypeID
        {
            get { return (long?)this["SPTSPACKAGINGSUBTYPEID"]; }
            set { this["SPTSPACKAGINGSUBTYPEID"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Malzeme
    /// </summary>
        public ConsumableMaterialDefinition Material
        {
            get { return (ConsumableMaterialDefinition)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Ambalaj Türü
    /// </summary>
        public MagistralPackagingType MagistralPackagingType
        {
            get { return (MagistralPackagingType)((ITTObject)this).GetParent("MAGISTRALPACKAGINGTYPE"); }
            set { this["MAGISTRALPACKAGINGTYPE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MagistralPackagingSubType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MagistralPackagingSubType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MagistralPackagingSubType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MagistralPackagingSubType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MagistralPackagingSubType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAGISTRALPACKAGINGSUBTYPE", dataRow) { }
        protected MagistralPackagingSubType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAGISTRALPACKAGINGSUBTYPE", dataRow, isImported) { }
        public MagistralPackagingSubType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MagistralPackagingSubType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MagistralPackagingSubType() : base() { }

    }
}