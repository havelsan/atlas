
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Bond")] 

    /// <summary>
    /// Senet İşlemleri
    /// </summary>
    public  partial class Bond : EpisodeAccountAction
    {
        public class BondList : TTObjectCollection<Bond> { }
                    
        public class ChildBondCollection : TTObject.TTChildObjectCollection<Bond>
        {
            public ChildBondCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBondCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class BondWorkListNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOND"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Object Documentdate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTDATE"]);
                }
            }

            public String Objdisplaytext
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJDISPLAYTEXT"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Objname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public Object Currentstate
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                }
            }

            public Object Documentno
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["DOCUMENTNO"]);
                }
            }

            public Currency? TotalPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BOND"].AllPropertyDefs["TOTALPRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string Patientname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Patientsurname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTSURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Cashiername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Episodeno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["HOSPITALPROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public long? Episodeid
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EPISODEID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EPISODE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? Episodeobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEOBJECTID"]);
                }
            }

            public BondWorkListNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public BondWorkListNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected BondWorkListNQL_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("9fa90413-e8c9-4f04-8f8a-3462b7ee02a5"); } }
    /// <summary>
    /// Ödendi
    /// </summary>
            public static Guid Paid { get { return new Guid("7bb766a3-ebac-4ae1-85b4-5fb084b5338f"); } }
    /// <summary>
    /// Yasal İşlem Başlatıldı
    /// </summary>
            public static Guid LegalProcess { get { return new Guid("6bc7d884-049a-4d5f-b127-a454faa95146"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("97944159-19ef-4b8a-8c75-1727f45dd276"); } }
    /// <summary>
    /// Ödenmedi
    /// </summary>
            public static Guid UnPaid { get { return new Guid("8deccc29-775b-4226-94fe-56be730dbde1"); } }
    /// <summary>
    /// Kısmen Ödendi
    /// </summary>
            public static Guid PartialPaid { get { return new Guid("36145ec5-f67f-49de-b2ce-521b83aa76fd"); } }
    /// <summary>
    /// Yapılandırıldı
    /// </summary>
            public static Guid Restructured { get { return new Guid("0efa14b0-438c-4d38-9175-3e16980f172a"); } }
        }

        public static BindingList<Bond.BondWorkListNQL_Class> BondWorkListNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BOND"].QueryDefs["BondWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Bond.BondWorkListNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Bond.BondWorkListNQL_Class> BondWorkListNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BOND"].QueryDefs["BondWorkListNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Bond.BondWorkListNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// 2. İhbarname Tarihi
    /// </summary>
        public DateTime? SecondNotificationDate
        {
            get { return (DateTime?)this["SECONDNOTIFICATIONDATE"]; }
            set { this["SECONDNOTIFICATIONDATE"] = value; }
        }

    /// <summary>
    /// Düzenleme Tarihi
    /// </summary>
        public DateTime? Date
        {
            get { return (DateTime?)this["DATE"]; }
            set { this["DATE"] = value; }
        }

    /// <summary>
    /// 1. İhbarname Tarihi
    /// </summary>
        public DateTime? FirstNotificationDate
        {
            get { return (DateTime?)this["FIRSTNOTIFICATIONDATE"]; }
            set { this["FIRSTNOTIFICATIONDATE"] = value; }
        }

    /// <summary>
    /// Senet Türü
    /// </summary>
        public BondTypeEnum? Type
        {
            get { return (BondTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Daha önce Alınmış Avans Tutarı
    /// </summary>
        public Currency? AdvanceTaken
        {
            get { return (Currency?)this["ADVANCETAKEN"]; }
            set { this["ADVANCETAKEN"] = value; }
        }

        public BondDocument BondDocument
        {
            get { return (BondDocument)((ITTObject)this).GetParent("BONDDOCUMENT"); }
            set { this["BONDDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Bond OriginalBond
        {
            get { return (Bond)((ITTObject)this).GetParent("ORIGINALBOND"); }
            set { this["ORIGINALBOND"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Birinci kefil
    /// </summary>
        public BondPerson FirstBondGuarantor
        {
            get { return (BondPerson)((ITTObject)this).GetParent("FIRSTBONDGUARANTOR"); }
            set { this["FIRSTBONDGUARANTOR"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public BondPerson BondPayer
        {
            get { return (BondPerson)((ITTObject)this).GetParent("BONDPAYER"); }
            set { this["BONDPAYER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        override protected void CreateAccountDocumentsCollection()
        {
            _AccountDocuments = new AccountDocument.ChildAccountDocumentCollection(this, new Guid("cc5caddb-eebd-4275-abcf-6c9c63be8478"));
            ((ITTChildObjectCollection)_AccountDocuments).GetChildren();
        }

        virtual protected void CreateBondProceduresCollection()
        {
            _BondProcedures = new BondProcedure.ChildBondProcedureCollection(this, new Guid("1909c060-3355-497f-b600-a057eb6e9459"));
            ((ITTChildObjectCollection)_BondProcedures).GetChildren();
        }

        protected BondProcedure.ChildBondProcedureCollection _BondProcedures = null;
        public BondProcedure.ChildBondProcedureCollection BondProcedures
        {
            get
            {
                if (_BondProcedures == null)
                    CreateBondProceduresCollection();
                return _BondProcedures;
            }
        }

        virtual protected void CreateRestructuredBondsCollection()
        {
            _RestructuredBonds = new Bond.ChildBondCollection(this, new Guid("74edc25b-6c93-4139-adeb-87b518fa1363"));
            ((ITTChildObjectCollection)_RestructuredBonds).GetChildren();
        }

        protected Bond.ChildBondCollection _RestructuredBonds = null;
        public Bond.ChildBondCollection RestructuredBonds
        {
            get
            {
                if (_RestructuredBonds == null)
                    CreateRestructuredBondsCollection();
                return _RestructuredBonds;
            }
        }

        virtual protected void CreateBondDetailsCollection()
        {
            _BondDetails = new BondDetail.ChildBondDetailCollection(this, new Guid("a948ddaa-2829-4f6f-8b3d-4429e7c9fe3a"));
            ((ITTChildObjectCollection)_BondDetails).GetChildren();
        }

        protected BondDetail.ChildBondDetailCollection _BondDetails = null;
        public BondDetail.ChildBondDetailCollection BondDetails
        {
            get
            {
                if (_BondDetails == null)
                    CreateBondDetailsCollection();
                return _BondDetails;
            }
        }

        virtual protected void CreateBondClosedSepsCollection()
        {
            _BondClosedSeps = new BondClosedSeps.ChildBondClosedSepsCollection(this, new Guid("aeff2a00-263f-49fd-b9a7-47d18a1bc17a"));
            ((ITTChildObjectCollection)_BondClosedSeps).GetChildren();
        }

        protected BondClosedSeps.ChildBondClosedSepsCollection _BondClosedSeps = null;
        public BondClosedSeps.ChildBondClosedSepsCollection BondClosedSeps
        {
            get
            {
                if (_BondClosedSeps == null)
                    CreateBondClosedSepsCollection();
                return _BondClosedSeps;
            }
        }

        protected Bond(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Bond(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Bond(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Bond(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Bond(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BOND", dataRow) { }
        protected Bond(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BOND", dataRow, isImported) { }
        public Bond(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Bond(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Bond() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}