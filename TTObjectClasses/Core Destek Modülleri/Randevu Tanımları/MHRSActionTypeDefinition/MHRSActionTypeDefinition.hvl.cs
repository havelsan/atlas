
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MHRSActionTypeDefinition")] 

    /// <summary>
    /// MHRS Aksiyon Tipi Tanımları
    /// </summary>
    public  partial class MHRSActionTypeDefinition : TerminologyManagerDef
    {
        public class MHRSActionTypeDefinitionList : TTObjectCollection<MHRSActionTypeDefinition> { }
                    
        public class ChildMHRSActionTypeDefinitionCollection : TTObject.TTChildObjectCollection<MHRSActionTypeDefinition>
        {
            public ChildMHRSActionTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMHRSActionTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMHRSActionTypeDefinition_Class : TTReportNqlObject 
        {
            public string ActionCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].AllPropertyDefs["ACTIONCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ActionName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].AllPropertyDefs["ACTIONNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsDocumentRequired
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDOCUMENTREQUIRED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].AllPropertyDefs["ISDOCUMENTREQUIRED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsIstisnaType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISISTISNATYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].AllPropertyDefs["ISISTISNATYPE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetMHRSActionTypeDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMHRSActionTypeDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMHRSActionTypeDefinition_Class() : base() { }
        }

        public static BindingList<MHRSActionTypeDefinition> GetMHRSActionTypeDefByActionCode(TTObjectContext objectContext, string ACTIONCODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].QueryDefs["GetMHRSActionTypeDefByActionCode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ACTIONCODE", ACTIONCODE);

            return ((ITTQuery)objectContext).QueryObjects<MHRSActionTypeDefinition>(queryDef, paramList);
        }

        public static BindingList<MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class> GetMHRSActionTypeDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].QueryDefs["GetMHRSActionTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class> GetMHRSActionTypeDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MHRSACTIONTYPEDEFINITION"].QueryDefs["GetMHRSActionTypeDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MHRSActionTypeDefinition.GetMHRSActionTypeDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İstisnada Dökümanı Gerektirir
    /// </summary>
        public bool? IsDocumentRequired
        {
            get { return (bool?)this["ISDOCUMENTREQUIRED"]; }
            set { this["ISDOCUMENTREQUIRED"] = value; }
        }

    /// <summary>
    /// İstisna
    /// </summary>
        public bool? IsIstisnaType
        {
            get { return (bool?)this["ISISTISNATYPE"]; }
            set { this["ISISTISNATYPE"] = value; }
        }

    /// <summary>
    /// Aksiyon Adı
    /// </summary>
        public string ActionName
        {
            get { return (string)this["ACTIONNAME"]; }
            set { this["ACTIONNAME"] = value; }
        }

    /// <summary>
    /// Aksiyon Kodu
    /// </summary>
        public string ActionCode
        {
            get { return (string)this["ACTIONCODE"]; }
            set { this["ACTIONCODE"] = value; }
        }

    /// <summary>
    /// MHRS Açık
    /// </summary>
        public bool? OpenMHRS
        {
            get { return (bool?)this["OPENMHRS"]; }
            set { this["OPENMHRS"] = value; }
        }

    /// <summary>
    /// Müstesna
    /// </summary>
        public bool? Mustesna
        {
            get { return (bool?)this["MUSTESNA"]; }
            set { this["MUSTESNA"] = value; }
        }

    /// <summary>
    /// Gün
    /// </summary>
        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

    /// <summary>
    /// Çalışma Saati
    /// </summary>
        public bool? IsWorkingHour
        {
            get { return (bool?)this["ISWORKINGHOUR"]; }
            set { this["ISWORKINGHOUR"] = value; }
        }

        protected MHRSActionTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MHRSActionTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MHRSActionTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MHRSActionTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MHRSActionTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MHRSACTIONTYPEDEFINITION", dataRow) { }
        protected MHRSActionTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MHRSACTIONTYPEDEFINITION", dataRow, isImported) { }
        public MHRSActionTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MHRSActionTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MHRSActionTypeDefinition() : base() { }

    }
}