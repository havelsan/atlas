
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ActiveIngredientSUTRuleDef")] 

    /// <summary>
    /// Etken Madde SUT Kuralları
    /// </summary>
    public  partial class ActiveIngredientSUTRuleDef : TerminologyManagerDef
    {
        public class ActiveIngredientSUTRuleDefList : TTObjectCollection<ActiveIngredientSUTRuleDef> { }
                    
        public class ChildActiveIngredientSUTRuleDefCollection : TTObject.TTChildObjectCollection<ActiveIngredientSUTRuleDef>
        {
            public ChildActiveIngredientSUTRuleDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildActiveIngredientSUTRuleDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetActiveIngredientSUTRuleDefs_Class : TTReportNqlObject 
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

            public string Icerik
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ICERIK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["ICERIK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Formu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FORMU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["FORMU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Rapor_ICD10Kodu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPOR_ICD10KODU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["RAPOR_ICD10KODU"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Uzman_Heyet
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UZMAN_HEYET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["UZMAN_HEYET"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Brans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["BRANS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaksimumRaporSuresi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKSIMUMRAPORSURESI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["MAKSIMUMRAPORSURESI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cinsiyeti
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CINSIYETI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["CINSIYETI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MinimumYasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINIMUMYASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["MINIMUMYASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MaksimumYasi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAKSIMUMYASI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["MAKSIMUMYASI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OzelAciklama
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OZELACIKLAMA"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].AllPropertyDefs["OZELACIKLAMA"].DataType;
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

            public GetActiveIngredientSUTRuleDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetActiveIngredientSUTRuleDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetActiveIngredientSUTRuleDefs_Class() : base() { }
        }

        public static BindingList<ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs_Class> GetActiveIngredientSUTRuleDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].QueryDefs["GetActiveIngredientSUTRuleDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs_Class> GetActiveIngredientSUTRuleDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACTIVEINGREDIENTSUTRULEDEF"].QueryDefs["GetActiveIngredientSUTRuleDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ActiveIngredientSUTRuleDef.GetActiveIngredientSUTRuleDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// İçerik
    /// </summary>
        public string Icerik
        {
            get { return (string)this["ICERIK"]; }
            set { this["ICERIK"] = value; }
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
    /// Rapor_ICD10Kodu
    /// </summary>
        public string Rapor_ICD10Kodu
        {
            get { return (string)this["RAPOR_ICD10KODU"]; }
            set { this["RAPOR_ICD10KODU"] = value; }
        }

    /// <summary>
    /// Uzman_Heyet
    /// </summary>
        public string Uzman_Heyet
        {
            get { return (string)this["UZMAN_HEYET"]; }
            set { this["UZMAN_HEYET"] = value; }
        }

    /// <summary>
    /// Brans
    /// </summary>
        public string Brans
        {
            get { return (string)this["BRANS"]; }
            set { this["BRANS"] = value; }
        }

    /// <summary>
    /// MaksimumRaporSuresi
    /// </summary>
        public string MaksimumRaporSuresi
        {
            get { return (string)this["MAKSIMUMRAPORSURESI"]; }
            set { this["MAKSIMUMRAPORSURESI"] = value; }
        }

    /// <summary>
    /// Cinsiyeti
    /// </summary>
        public string Cinsiyeti
        {
            get { return (string)this["CINSIYETI"]; }
            set { this["CINSIYETI"] = value; }
        }

    /// <summary>
    /// MinimumYasi
    /// </summary>
        public string MinimumYasi
        {
            get { return (string)this["MINIMUMYASI"]; }
            set { this["MINIMUMYASI"] = value; }
        }

    /// <summary>
    /// MaksimumYasi
    /// </summary>
        public string MaksimumYasi
        {
            get { return (string)this["MAKSIMUMYASI"]; }
            set { this["MAKSIMUMYASI"] = value; }
        }

    /// <summary>
    /// Kurallar
    /// </summary>
        public string OzelAciklama
        {
            get { return (string)this["OZELACIKLAMA"]; }
            set { this["OZELACIKLAMA"] = value; }
        }

        public EtkinMadde EtkinMadde
        {
            get { return (EtkinMadde)((ITTObject)this).GetParent("ETKINMADDE"); }
            set { this["ETKINMADDE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ActiveIngredientSUTRuleDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ActiveIngredientSUTRuleDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ActiveIngredientSUTRuleDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ActiveIngredientSUTRuleDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ActiveIngredientSUTRuleDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACTIVEINGREDIENTSUTRULEDEF", dataRow) { }
        protected ActiveIngredientSUTRuleDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACTIVEINGREDIENTSUTRULEDEF", dataRow, isImported) { }
        public ActiveIngredientSUTRuleDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ActiveIngredientSUTRuleDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ActiveIngredientSUTRuleDef() : base() { }

    }
}