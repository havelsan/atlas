
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SupplyRequestPool")] 

    /// <summary>
    /// Satınalma Talep Havuzu
    /// </summary>
    public  partial class SupplyRequestPool : StockAction, ISupplyRequestPool
    {
        public class SupplyRequestPoolList : TTObjectCollection<SupplyRequestPool> { }
                    
        public class ChildSupplyRequestPoolCollection : TTObject.TTChildObjectCollection<SupplyRequestPool>
        {
            public ChildSupplyRequestPoolCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSupplyRequestPoolCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Approval { get { return new Guid("40fd8552-b285-4aea-8807-b1ff6bb2e520"); } }
            public static Guid Completed { get { return new Guid("2a6b32dc-c027-47e0-b3ec-1342ca31d273"); } }
            public static Guid New { get { return new Guid("b8ef9cf8-17dc-424b-98f8-46817dda5da9"); } }
        }

        public static BindingList<SupplyRequestPool> GetSupplyRequestPoolByDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE, Guid STORE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLYREQUESTPOOL"].QueryDefs["GetSupplyRequestPoolByDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);
            paramList.Add("STORE", STORE);

            return ((ITTQuery)objectContext).QueryObjects<SupplyRequestPool>(queryDef, paramList);
        }

    /// <summary>
    /// Acil
    /// </summary>
        public bool? IsImmediate
        {
            get { return (bool?)this["ISIMMEDIATE"]; }
            set { this["ISIMMEDIATE"] = value; }
        }

    /// <summary>
    /// Karşılanma Tarihi
    /// </summary>
        public DateTime? DateOfSupply
        {
            get { return (DateTime?)this["DATEOFSUPPLY"]; }
            set { this["DATEOFSUPPLY"] = value; }
        }

    /// <summary>
    /// XXXXXXEtkilenenAdet
    /// </summary>
        public int? XXXXXXEtkilenenAdet
        {
            get { return (int?)this["XXXXXXETKILENENADET"]; }
            set { this["XXXXXXETKILENENADET"] = value; }
        }

    /// <summary>
    /// XXXXXXIslemBasarili
    /// </summary>
        public bool? XXXXXXIslemBasarili
        {
            get { return (bool?)this["XXXXXXISLEMBASARILI"]; }
            set { this["XXXXXXISLEMBASARILI"] = value; }
        }

    /// <summary>
    /// XXXXXXMesaj
    /// </summary>
        public string XXXXXXMesaj
        {
            get { return (string)this["XXXXXXMESAJ"]; }
            set { this["XXXXXXMESAJ"] = value; }
        }

    /// <summary>
    /// XXXXXXKayitId
    /// </summary>
        public int? XXXXXXKayitId
        {
            get { return (int?)this["XXXXXXKAYITID"]; }
            set { this["XXXXXXKAYITID"] = value; }
        }

    /// <summary>
    /// Alım Türü
    /// </summary>
        public SupplyRequestTypeEnum? RequestType
        {
            get { return (SupplyRequestTypeEnum?)(int?)this["REQUESTTYPE"]; }
            set { this["REQUESTTYPE"] = value; }
        }

    /// <summary>
    /// Personelin Adı, Soyadı
    /// </summary>
        public ResUser SignUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("SIGNUSER"); }
            set { this["SIGNUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSupplyRequestPoolDetailsCollection()
        {
            _SupplyRequestPoolDetails = new SupplyRequestPoolDetail.ChildSupplyRequestPoolDetailCollection(this, new Guid("2b4f97b9-0741-4031-8f4c-0eb1abb2d2ba"));
            ((ITTChildObjectCollection)_SupplyRequestPoolDetails).GetChildren();
        }

        protected SupplyRequestPoolDetail.ChildSupplyRequestPoolDetailCollection _SupplyRequestPoolDetails = null;
        public SupplyRequestPoolDetail.ChildSupplyRequestPoolDetailCollection SupplyRequestPoolDetails
        {
            get
            {
                if (_SupplyRequestPoolDetails == null)
                    CreateSupplyRequestPoolDetailsCollection();
                return _SupplyRequestPoolDetails;
            }
        }

        protected SupplyRequestPool(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SupplyRequestPool(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SupplyRequestPool(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SupplyRequestPool(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SupplyRequestPool(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUPPLYREQUESTPOOL", dataRow) { }
        protected SupplyRequestPool(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUPPLYREQUESTPOOL", dataRow, isImported) { }
        public SupplyRequestPool(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SupplyRequestPool(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SupplyRequestPool() : base() { }

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