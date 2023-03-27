
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SUT")] 

    public  partial class SUT : TTDefinitionSet
    {
        public class SUTList : TTObjectCollection<SUT> { }
                    
        public class ChildSUTCollection : TTObject.TTChildObjectCollection<SUT>
        {
            public ChildSUTCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSUTCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSUTList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Ad
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUT"].AllPropertyDefs["AD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kod
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KOD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUT"].AllPropertyDefs["KOD"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSUTList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSUTList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSUTList_Class() : base() { }
        }

        public static BindingList<SUT.GetSUTList_Class> GetSUTList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUT"].QueryDefs["GetSUTList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SUT.GetSUTList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SUT.GetSUTList_Class> GetSUTList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUT"].QueryDefs["GetSUTList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SUT.GetSUTList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Fiyat
    /// </summary>
        public Currency? Fiyat
        {
            get { return (Currency?)this["FIYAT"]; }
            set { this["FIYAT"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Aciklama
        {
            get { return (string)this["ACIKLAMA"]; }
            set { this["ACIKLAMA"] = value; }
        }

    /// <summary>
    /// Ek
    /// </summary>
        public SUTHizmetEKEnum? Ek
        {
            get { return (SUTHizmetEKEnum?)(int?)this["EK"]; }
            set { this["EK"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Kod
        {
            get { return (string)this["KOD"]; }
            set { this["KOD"] = value; }
        }

    /// <summary>
    /// Puan
    /// </summary>
        public double? Puan
        {
            get { return (double?)this["PUAN"]; }
            set { this["PUAN"] = value; }
        }

    /// <summary>
    /// Tarih
    /// </summary>
        public DateTime? Tarih
        {
            get { return (DateTime?)this["TARIH"]; }
            set { this["TARIH"] = value; }
        }

    /// <summary>
    /// Ad Shadow
    /// </summary>
        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Ad
        {
            get { return (string)this["AD"]; }
            set { this["AD"] = value; }
        }

        protected SUT(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SUT(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SUT(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SUT(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SUT(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUT", dataRow) { }
        protected SUT(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUT", dataRow, isImported) { }
        public SUT(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SUT(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SUT() : base() { }

    }
}