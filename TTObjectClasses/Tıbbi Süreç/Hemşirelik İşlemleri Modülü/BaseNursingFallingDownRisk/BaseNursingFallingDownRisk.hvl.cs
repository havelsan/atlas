
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseNursingFallingDownRisk")] 

    /// <summary>
    /// Düşme Riski Değerlendirme Formu
    /// </summary>
    public  partial class BaseNursingFallingDownRisk : BaseNursingDataEntry
    {
        public class BaseNursingFallingDownRiskList : TTObjectCollection<BaseNursingFallingDownRisk> { }
                    
        public class ChildBaseNursingFallingDownRiskCollection : TTObject.TTChildObjectCollection<BaseNursingFallingDownRisk>
        {
            public ChildBaseNursingFallingDownRiskCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseNursingFallingDownRiskCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFallingDownRisksByNursingApplicationR_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetFallingDownRisksByNursingApplicationR_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFallingDownRisksByNursingApplicationR_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFallingDownRisksByNursingApplicationR_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<BaseNursingFallingDownRisk.GetFallingDownRisksByNursingApplicationR_Class> GetFallingDownRisksByNursingApplicationR(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGFALLINGDOWNRISK"].QueryDefs["GetFallingDownRisksByNursingApplicationR"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<BaseNursingFallingDownRisk.GetFallingDownRisksByNursingApplicationR_Class>(queryDef, paramList, pi);
        }

        public static BindingList<BaseNursingFallingDownRisk.GetFallingDownRisksByNursingApplicationR_Class> GetFallingDownRisksByNursingApplicationR(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGFALLINGDOWNRISK"].QueryDefs["GetFallingDownRisksByNursingApplicationR"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<BaseNursingFallingDownRisk.GetFallingDownRisksByNursingApplicationR_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<BaseNursingFallingDownRisk> GetFallingDownRisksByNursingApplication(TTObjectContext objectContext, Guid TTOBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASENURSINGFALLINGDOWNRISK"].QueryDefs["GetFallingDownRisksByNursingApplication"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<BaseNursingFallingDownRisk>(queryDef, paramList);
        }

    /// <summary>
    /// Hemşirelik Girişimleri Uygulandı Mı
    /// </summary>
        public DateTime? NursingAppDoneDate
        {
            get { return (DateTime?)this["NURSINGAPPDONEDATE"]; }
            set { this["NURSINGAPPDONEDATE"] = value; }
        }

    /// <summary>
    /// Düşme Riski Seçim Nedeni
    /// </summary>
        public FallingDownRiskReasonEnum? FallingDownRiskReason
        {
            get { return (FallingDownRiskReasonEnum?)(int?)this["FALLINGDOWNRISKREASON"]; }
            set { this["FALLINGDOWNRISKREASON"] = value; }
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Toplam Puan
    /// </summary>
        public int? TotalScore
        {
            get { return (int?)this["TOTALSCORE"]; }
            set { this["TOTALSCORE"] = value; }
        }

        virtual protected void CreateNursingFallingDownRisksCollection()
        {
            _NursingFallingDownRisks = new NursingFallingDownRisk.ChildNursingFallingDownRiskCollection(this, new Guid("aa1e42ae-03df-4f77-be68-f4153680592c"));
            ((ITTChildObjectCollection)_NursingFallingDownRisks).GetChildren();
        }

        protected NursingFallingDownRisk.ChildNursingFallingDownRiskCollection _NursingFallingDownRisks = null;
        public NursingFallingDownRisk.ChildNursingFallingDownRiskCollection NursingFallingDownRisks
        {
            get
            {
                if (_NursingFallingDownRisks == null)
                    CreateNursingFallingDownRisksCollection();
                return _NursingFallingDownRisks;
            }
        }

        protected BaseNursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseNursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseNursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseNursingFallingDownRisk(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseNursingFallingDownRisk(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASENURSINGFALLINGDOWNRISK", dataRow) { }
        protected BaseNursingFallingDownRisk(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASENURSINGFALLINGDOWNRISK", dataRow, isImported) { }
        public BaseNursingFallingDownRisk(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseNursingFallingDownRisk(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseNursingFallingDownRisk() : base() { }

    }
}