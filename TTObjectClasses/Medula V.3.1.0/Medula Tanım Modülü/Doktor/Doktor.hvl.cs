
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Doktor")] 

    /// <summary>
    /// Doktor
    /// </summary>
    public  partial class Doktor : BaseMedulaDefinition
    {
        public class DoktorList : TTObjectCollection<Doktor> { }
                    
        public class ChildDoktorCollection : TTObject.TTChildObjectCollection<Doktor>
        {
            public ChildDoktorCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDoktorCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDoktorDefinitionQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string drTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRTESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOKTOR"].AllPropertyDefs["DRTESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOKTOR"].AllPropertyDefs["DRADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string drSoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRSOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOKTOR"].AllPropertyDefs["DRSOYADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Brans
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BRANS"]);
                }
            }

            public string tesisAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TESISADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SAGLIKTESISI"].AllPropertyDefs["TESISADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDoktorDefinitionQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDoktorDefinitionQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDoktorDefinitionQuery_Class() : base() { }
        }

        public static BindingList<Doktor.GetDoktorDefinitionQuery_Class> GetDoktorDefinitionQuery(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOKTOR"].QueryDefs["GetDoktorDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Doktor.GetDoktorDefinitionQuery_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Doktor.GetDoktorDefinitionQuery_Class> GetDoktorDefinitionQuery(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOKTOR"].QueryDefs["GetDoktorDefinitionQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Doktor.GetDoktorDefinitionQuery_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Doktor Adı
    /// </summary>
        public string drAdi
        {
            get { return (string)this["DRADI"]; }
            set { this["DRADI"] = value; }
        }

    /// <summary>
    /// Doktor Soyadı
    /// </summary>
        public string drSoyadi
        {
            get { return (string)this["DRSOYADI"]; }
            set { this["DRSOYADI"] = value; }
        }

    /// <summary>
    /// Doktor Diploma No
    /// </summary>
        public string drDiplomaNo
        {
            get { return (string)this["DRDIPLOMANO"]; }
            set { this["DRDIPLOMANO"] = value; }
        }

    /// <summary>
    /// Doktor Tescil No
    /// </summary>
        public string drTescilNo
        {
            get { return (string)this["DRTESCILNO"]; }
            set { this["DRTESCILNO"] = value; }
        }

        public string drAdi_Shadow
        {
            get { return (string)this["DRADI_SHADOW"]; }
        }

        public string drSoyadi_Shadow
        {
            get { return (string)this["DRSOYADI_SHADOW"]; }
        }

        public string drTescilNo_Shadow
        {
            get { return (string)this["DRTESCILNO_SHADOW"]; }
        }

        public SpecialityDefinition Brans
        {
            get { return (SpecialityDefinition)((ITTObject)this).GetParent("BRANS"); }
            set { this["BRANS"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public SaglikTesisi SaglikTesisi
        {
            get { return (SaglikTesisi)((ITTObject)this).GetParent("SAGLIKTESISI"); }
            set { this["SAGLIKTESISI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected Doktor(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Doktor(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Doktor(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Doktor(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Doktor(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOKTOR", dataRow) { }
        protected Doktor(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOKTOR", dataRow, isImported) { }
        public Doktor(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Doktor(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Doktor() : base() { }

    }
}