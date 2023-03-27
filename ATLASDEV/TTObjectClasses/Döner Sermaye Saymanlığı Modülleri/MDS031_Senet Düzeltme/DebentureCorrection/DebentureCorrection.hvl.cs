
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DebentureCorrection")] 

    /// <summary>
    /// Senet Düzeltme İşlemi
    /// </summary>
    public  partial class DebentureCorrection : EpisodeAccountAction
    {
        public class DebentureCorrectionList : TTObjectCollection<DebentureCorrection> { }
                    
        public class ChildDebentureCorrectionCollection : TTObject.TTChildObjectCollection<DebentureCorrection>
        {
            public ChildDebentureCorrectionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDebentureCorrectionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNewDebentures_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetNewDebentures_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNewDebentures_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNewDebentures_Class() : base() { }
        }

        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("630afa3f-6029-4257-a4da-76714a576384"); } }
            public static Guid Completed { get { return new Guid("820b758d-cf20-46db-baf2-9b0b470ac774"); } }
        }

        public static BindingList<DebentureCorrection.GetNewDebentures_Class> GetNewDebentures(string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURECORRECTION"].QueryDefs["GetNewDebentures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<DebentureCorrection.GetNewDebentures_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DebentureCorrection.GetNewDebentures_Class> GetNewDebentures(TTObjectContext objectContext, string PARAMOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEBENTURECORRECTION"].QueryDefs["GetNewDebentures"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMOBJECTID", PARAMOBJECTID);

            return TTReportNqlObject.QueryObjects<DebentureCorrection.GetNewDebentures_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Veznedar
    /// </summary>
        public string CashierName
        {
            get { return (string)this["CASHIERNAME"]; }
            set { this["CASHIERNAME"] = value; }
        }

    /// <summary>
    /// Yeni oluşturulan toplam Senet tutarı
    /// </summary>
        public Currency? NewCreatedTotalPrice
        {
            get { return (Currency?)this["NEWCREATEDTOTALPRICE"]; }
            set { this["NEWCREATEDTOTALPRICE"] = value; }
        }

    /// <summary>
    /// Toplam İptal edilen Senet Tutarı
    /// </summary>
        public Currency? CancelledTotalPrice
        {
            get { return (Currency?)this["CANCELLEDTOTALPRICE"]; }
            set { this["CANCELLEDTOTALPRICE"] = value; }
        }

    /// <summary>
    /// İptal edilmiş Senetlerin ObjectID 
    /// </summary>
        public string CancelledDebDocObjectId
        {
            get { return (string)this["CANCELLEDDEBDOCOBJECTID"]; }
            set { this["CANCELLEDDEBDOCOBJECTID"] = value; }
        }

        virtual protected void CreateCancellableDebenturesCollection()
        {
            _CancellableDebentures = new DebentureCorrectionCancellableDebentures.ChildDebentureCorrectionCancellableDebenturesCollection(this, new Guid("f0771748-4235-4279-8bd8-02f88e04f61e"));
            ((ITTChildObjectCollection)_CancellableDebentures).GetChildren();
        }

        protected DebentureCorrectionCancellableDebentures.ChildDebentureCorrectionCancellableDebenturesCollection _CancellableDebentures = null;
        public DebentureCorrectionCancellableDebentures.ChildDebentureCorrectionCancellableDebenturesCollection CancellableDebentures
        {
            get
            {
                if (_CancellableDebentures == null)
                    CreateCancellableDebenturesCollection();
                return _CancellableDebentures;
            }
        }

        virtual protected void CreateDebenturesCollection()
        {
            _Debentures = new Debenture.ChildDebentureCollection(this, new Guid("669eb2fc-21fe-41cf-842a-6304603976c3"));
            ((ITTChildObjectCollection)_Debentures).GetChildren();
        }

        protected Debenture.ChildDebentureCollection _Debentures = null;
    /// <summary>
    /// Child collection for Senet Düzeltme ile relation
    /// </summary>
        public Debenture.ChildDebentureCollection Debentures
        {
            get
            {
                if (_Debentures == null)
                    CreateDebenturesCollection();
                return _Debentures;
            }
        }

        protected DebentureCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DebentureCorrection(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DebentureCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DebentureCorrection(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DebentureCorrection(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEBENTURECORRECTION", dataRow) { }
        protected DebentureCorrection(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEBENTURECORRECTION", dataRow, isImported) { }
        public DebentureCorrection(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DebentureCorrection(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DebentureCorrection() : base() { }

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