
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GMDNDefinition")] 

    /// <summary>
    /// GMDN Tanımları
    /// </summary>
    public  partial class GMDNDefinition : TerminologyManagerDef, ITTListObject
    {
        public class GMDNDefinitionList : TTObjectCollection<GMDNDefinition> { }
                    
        public class ChildGMDNDefinitionCollection : TTObject.TTChildObjectCollection<GMDNDefinition>
        {
            public ChildGMDNDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGMDNDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetGMDNDefinitionsReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? ConceptCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CONCEPTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].AllPropertyDefs["CONCEPTCODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name_Tr
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_TR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].AllPropertyDefs["NAME_TR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name_En
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME_EN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].AllPropertyDefs["NAME_EN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetGMDNDefinitionsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetGMDNDefinitionsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetGMDNDefinitionsReportQuery_Class() : base() { }
        }

        public static BindingList<GMDNDefinition> GetGMDNDefinitions(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].QueryDefs["GetGMDNDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<GMDNDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<GMDNDefinition.GetGMDNDefinitionsReportQuery_Class> GetGMDNDefinitionsReportQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].QueryDefs["GetGMDNDefinitionsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GMDNDefinition.GetGMDNDefinitionsReportQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<GMDNDefinition.GetGMDNDefinitionsReportQuery_Class> GetGMDNDefinitionsReportQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["GMDNDEFINITION"].QueryDefs["GetGMDNDefinitionsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<GMDNDefinition.GetGMDNDefinitionsReportQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Silinme Versiyonu
    /// </summary>
        public string DeletedVersion
        {
            get { return (string)this["DELETEDVERSION"]; }
            set { this["DELETEDVERSION"] = value; }
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public int? ConceptCode
        {
            get { return (int?)this["CONCEPTCODE"]; }
            set { this["CONCEPTCODE"] = value; }
        }

    /// <summary>
    /// İngilizce Adı
    /// </summary>
        public string Name_En
        {
            get { return (string)this["NAME_EN"]; }
            set { this["NAME_EN"] = value; }
        }

    /// <summary>
    /// Türkçe Adı
    /// </summary>
        public string Name_Tr
        {
            get { return (string)this["NAME_TR"]; }
            set { this["NAME_TR"] = value; }
        }

    /// <summary>
    /// İngilizce Anlatımı
    /// </summary>
        public object Statement_En
        {
            get { return (object)this["STATEMENT_EN"]; }
            set { this["STATEMENT_EN"] = value; }
        }

    /// <summary>
    /// Türkçe Anlatımı
    /// </summary>
        public object Statement_Tr
        {
            get { return (object)this["STATEMENT_TR"]; }
            set { this["STATEMENT_TR"] = value; }
        }

    /// <summary>
    /// Geçerli Kod
    /// </summary>
        public bool? IsValidCode
        {
            get { return (bool?)this["ISVALIDCODE"]; }
            set { this["ISVALIDCODE"] = value; }
        }

    /// <summary>
    /// Benzer Kod
    /// </summary>
        public bool? IsSynonym
        {
            get { return (bool?)this["ISSYNONYM"]; }
            set { this["ISSYNONYM"] = value; }
        }

    /// <summary>
    /// Geçerli Tercih Edilen
    /// </summary>
        public bool? IsPreferredValid
        {
            get { return (bool?)this["ISPREFERREDVALID"]; }
            set { this["ISPREFERREDVALID"] = value; }
        }

    /// <summary>
    /// Eklenme Versiyonu
    /// </summary>
        public string AddedVersion
        {
            get { return (string)this["ADDEDVERSION"]; }
            set { this["ADDEDVERSION"] = value; }
        }

        public string Name_Tr_Shadow
        {
            get { return (string)this["NAME_TR_SHADOW"]; }
        }

    /// <summary>
    /// Ana Kodu
    /// </summary>
        public int? ParentCode
        {
            get { return (int?)this["PARENTCODE"]; }
            set { this["PARENTCODE"] = value; }
        }

    /// <summary>
    /// Detay
    /// </summary>
        public object Detail
        {
            get { return (object)this["DETAIL"]; }
            set { this["DETAIL"] = value; }
        }

        public string Name_En_Shadow
        {
            get { return (string)this["NAME_EN_SHADOW"]; }
        }

    /// <summary>
    /// Tercih Edilen Kod
    /// </summary>
        public int? PreferredCode
        {
            get { return (int?)this["PREFERREDCODE"]; }
            set { this["PREFERREDCODE"] = value; }
        }

    /// <summary>
    /// Ana Tanım
    /// </summary>
        public GMDNDefinition ParentDef
        {
            get { return (GMDNDefinition)((ITTObject)this).GetParent("PARENTDEF"); }
            set { this["PARENTDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Tercih Edilen Tanım
    /// </summary>
        public GMDNDefinition PreferredDef
        {
            get { return (GMDNDefinition)((ITTObject)this).GetParent("PREFERREDDEF"); }
            set { this["PREFERREDDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected GMDNDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GMDNDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GMDNDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GMDNDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GMDNDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GMDNDEFINITION", dataRow) { }
        protected GMDNDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GMDNDEFINITION", dataRow, isImported) { }
        public GMDNDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GMDNDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GMDNDefinition() : base() { }

    }
}