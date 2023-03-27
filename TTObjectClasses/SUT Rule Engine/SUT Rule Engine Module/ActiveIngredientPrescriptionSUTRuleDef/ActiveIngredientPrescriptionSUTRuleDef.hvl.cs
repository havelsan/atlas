
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActiveIngredientPrescriptionSUTRuleDef")] 

    /// <summary>
    /// Etken Madde Reçete SUT Kuralları
    /// </summary>
    public  partial class ActiveIngredientPrescriptionSUTRuleDef : TerminologyManagerDef
    {
        public class ActiveIngredientPrescriptionSUTRuleDefList : TTObjectCollection<ActiveIngredientPrescriptionSUTRuleDef> { }
                    
        public class ChildActiveIngredientPrescriptionSUTRuleDefCollection : TTObject.TTChildObjectCollection<ActiveIngredientPrescriptionSUTRuleDef>
        {
            public ChildActiveIngredientPrescriptionSUTRuleDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActiveIngredientPrescriptionSUTRuleDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActiveIngredientPrescriptionSUTRuleDefs_Class : TTReportNqlObject 
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

            public string Formu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].AllPropertyDefs["FORMU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OdemeDurumu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ODEMEDURUMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].AllPropertyDefs["ODEMEDURUMU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ReceteEdebilenHekimler
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECETEEDEBILENHEKIMLER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].AllPropertyDefs["RECETEEDEBILENHEKIMLER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OzelTeshis
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELTESHIS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].AllPropertyDefs["OZELTESHIS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Aciklamalar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACIKLAMALAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].AllPropertyDefs["ACIKLAMALAR"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string etkinMaddeAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKINMADDEADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ETKINMADDE"].AllPropertyDefs["ETKINMADDEADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetActiveIngredientPrescriptionSUTRuleDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveIngredientPrescriptionSUTRuleDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveIngredientPrescriptionSUTRuleDefs_Class() : base() { }
        }

        public static BindingList<ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs_Class> GetActiveIngredientPrescriptionSUTRuleDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].QueryDefs["GetActiveIngredientPrescriptionSUTRuleDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs_Class> GetActiveIngredientPrescriptionSUTRuleDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF"].QueryDefs["GetActiveIngredientPrescriptionSUTRuleDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientPrescriptionSUTRuleDef.GetActiveIngredientPrescriptionSUTRuleDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Formu
    /// </summary>
        public string Formu
        {
            get { return (string)this["FORMU"]; }
            set { this["FORMU"] = value; }
        }

    /// <summary>
    /// Ödeme Durumu
    /// </summary>
        public string OdemeDurumu
        {
            get { return (string)this["ODEMEDURUMU"]; }
            set { this["ODEMEDURUMU"] = value; }
        }

    /// <summary>
    /// Reçete Edebilen Hekimler
    /// </summary>
        public string ReceteEdebilenHekimler
        {
            get { return (string)this["RECETEEDEBILENHEKIMLER"]; }
            set { this["RECETEEDEBILENHEKIMLER"] = value; }
        }

    /// <summary>
    /// Özel Teşhis
    /// </summary>
        public string OzelTeshis
        {
            get { return (string)this["OZELTESHIS"]; }
            set { this["OZELTESHIS"] = value; }
        }

    /// <summary>
    /// Açıklamalar
    /// </summary>
        public string Aciklamalar
        {
            get { return (string)this["ACIKLAMALAR"]; }
            set { this["ACIKLAMALAR"] = value; }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF", dataRow) { }
        protected ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIVEINGREDIENTPRESCRIPTIONSUTRULEDEF", dataRow, isImported) { }
        public ActiveIngredientPrescriptionSUTRuleDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActiveIngredientPrescriptionSUTRuleDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActiveIngredientPrescriptionSUTRuleDef() : base() { }

    }
}