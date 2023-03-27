
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PreProposalsForFormulation")] 

    /// <summary>
    /// Yaklaşık Maliyet Hesabında Kullanılan ve Firmalardan Alınan Ön Teklifler İçin Kullanılan Sınıftır
    /// </summary>
    public  partial class PreProposalsForFormulation : TTObject
    {
        public class PreProposalsForFormulationList : TTObjectCollection<PreProposalsForFormulation> { }
                    
        public class ChildPreProposalsForFormulationCollection : TTObject.TTChildObjectCollection<PreProposalsForFormulation>
        {
            public ChildPreProposalsForFormulationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPreProposalsForFormulationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPreProposals_Class : TTReportNqlObject 
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

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREPROPOSALSFORFORMULATION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREPROPOSALSFORFORMULATION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public bool? IncludeFormulation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INCLUDEFORMULATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PREPROPOSALSFORFORMULATION"].AllPropertyDefs["INCLUDEFORMULATION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Suplliername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPLLIERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPreProposals_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPreProposals_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPreProposals_Class() : base() { }
        }

        public static BindingList<PreProposalsForFormulation.GetPreProposals_Class> GetPreProposals(string PURCHASEITEMDEF, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREPROPOSALSFORFORMULATION"].QueryDefs["GetPreProposals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEITEMDEF", PURCHASEITEMDEF);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PreProposalsForFormulation.GetPreProposals_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PreProposalsForFormulation.GetPreProposals_Class> GetPreProposals(TTObjectContext objectContext, string PURCHASEITEMDEF, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PREPROPOSALSFORFORMULATION"].QueryDefs["GetPreProposals"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEITEMDEF", PURCHASEITEMDEF);
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<PreProposalsForFormulation.GetPreProposals_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Teklif Birim Fiyat
    /// </summary>
        public double? UnitPrice
        {
            get { return (double?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Ort.Dahil
    /// </summary>
        public bool? IncludeFormulation
        {
            get { return (bool?)this["INCLUDEFORMULATION"]; }
            set { this["INCLUDEFORMULATION"] = value; }
        }

        public PurchaseProjectDetail PurchaseProjectDetail
        {
            get { return (PurchaseProjectDetail)((ITTObject)this).GetParent("PURCHASEPROJECTDETAIL"); }
            set { this["PURCHASEPROJECTDETAIL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PreProposalsForFormulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PreProposalsForFormulation(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PreProposalsForFormulation(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PreProposalsForFormulation(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PreProposalsForFormulation(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PREPROPOSALSFORFORMULATION", dataRow) { }
        protected PreProposalsForFormulation(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PREPROPOSALSFORFORMULATION", dataRow, isImported) { }
        public PreProposalsForFormulation(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PreProposalsForFormulation(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PreProposalsForFormulation() : base() { }

    }
}