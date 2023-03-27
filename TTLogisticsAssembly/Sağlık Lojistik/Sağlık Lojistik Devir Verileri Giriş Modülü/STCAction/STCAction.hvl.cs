
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="STCAction")] 

    /// <summary>
    /// Sayım Tarti Çizelgesi
    /// </summary>
    public  partial class STCAction : TTObject
    {
        public class STCActionList : TTObjectCollection<STCAction> { }
                    
        public class ChildSTCActionCollection : TTObject.TTChildObjectCollection<STCAction>
        {
            public ChildSTCActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSTCActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class STCReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ResCardDrawer
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESCARDDRAWER"]);
                }
            }

            public int? SiraNu
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIRANU"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["SIRANU"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MATERIAL"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Currency? YeniMevcut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["YENIMEVCUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["YENIMEVCUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? KullanilmisMevcut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KULLANILMISMEVCUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["KULLANILMISMEVCUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? HEKMevcut
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKMEVCUT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["HEKMEVCUT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? MuvakkatenVerilen
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MUVAKKATENVERILEN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["MUVAKKATENVERILEN"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Toplam
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["TOPLAM"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? ToplamTutar
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOPLAMTUTAR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].AllPropertyDefs["TOPLAMTUTAR"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public STCReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public STCReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected STCReportQuery_Class() : base() { }
        }

        public static BindingList<STCAction.STCReportQuery_Class> STCReportQuery(string RESCARDDRAWER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].QueryDefs["STCReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESCARDDRAWER", RESCARDDRAWER);

            return TTReportNqlObject.QueryObjects<STCAction.STCReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<STCAction.STCReportQuery_Class> STCReportQuery(TTObjectContext objectContext, string RESCARDDRAWER, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["STCACTION"].QueryDefs["STCReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESCARDDRAWER", RESCARDDRAWER);

            return TTReportNqlObject.QueryObjects<STCAction.STCReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// SK Tarihi
    /// </summary>
        public DateTime? SKTarihi
        {
            get { return (DateTime?)this["SKTARIHI"]; }
            set { this["SKTARIHI"] = value; }
        }

        public Currency? MuvakkatenVerilen
        {
            get { return (Currency?)this["MUVAKKATENVERILEN"]; }
            set { this["MUVAKKATENVERILEN"] = value; }
        }

        public int? SiraNu
        {
            get { return (int?)this["SIRANU"]; }
            set { this["SIRANU"] = value; }
        }

        public Currency? YeniMevcut
        {
            get { return (Currency?)this["YENIMEVCUT"]; }
            set { this["YENIMEVCUT"] = value; }
        }

        public Currency? HEKMevcut
        {
            get { return (Currency?)this["HEKMEVCUT"]; }
            set { this["HEKMEVCUT"] = value; }
        }

        public Currency? KullanilmisMevcut
        {
            get { return (Currency?)this["KULLANILMISMEVCUT"]; }
            set { this["KULLANILMISMEVCUT"] = value; }
        }

        public BigCurrency? ToplamTutar
        {
            get { return (BigCurrency?)this["TOPLAMTUTAR"]; }
            set { this["TOPLAMTUTAR"] = value; }
        }

    /// <summary>
    /// İlk Giriş Yapılmıştır
    /// </summary>
        public bool? IsFirstIn
        {
            get { return (bool?)this["ISFIRSTIN"]; }
            set { this["ISFIRSTIN"] = value; }
        }

        public Currency? Toplam
        {
            get { return (Currency?)this["TOPLAM"]; }
            set { this["TOPLAM"] = value; }
        }

        public STCFirstInAction STCFirstInAction
        {
            get { return (STCFirstInAction)((ITTObject)this).GetParent("STCFIRSTINACTION"); }
            set { this["STCFIRSTINACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Material Material
        {
            get { return (Material)((ITTObject)this).GetParent("MATERIAL"); }
            set { this["MATERIAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResCardDrawer ResCardDrawer
        {
            get { return (ResCardDrawer)((ITTObject)this).GetParent("RESCARDDRAWER"); }
            set { this["RESCARDDRAWER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public STFAction SLFAction
        {
            get { return (STFAction)((ITTObject)this).GetParent("SLFACTION"); }
            set { this["SLFACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public MainStoreDefinition MainStoreDefinition
        {
            get { return (MainStoreDefinition)((ITTObject)this).GetParent("MAINSTOREDEFINITION"); }
            set { this["MAINSTOREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateMCActionsCollection()
        {
            _MCActions = new MCAction.ChildMCActionCollection(this, new Guid("80b93a16-4d85-43a6-a43a-cb89e605679b"));
            ((ITTChildObjectCollection)_MCActions).GetChildren();
        }

        protected MCAction.ChildMCActionCollection _MCActions = null;
        public MCAction.ChildMCActionCollection MCActions
        {
            get
            {
                if (_MCActions == null)
                    CreateMCActionsCollection();
                return _MCActions;
            }
        }

        virtual protected void CreateDCActionsCollection()
        {
            _DCActions = new DCAction.ChildDCActionCollection(this, new Guid("bfd58cc7-30a8-43d5-84cf-0043add9b6d7"));
            ((ITTChildObjectCollection)_DCActions).GetChildren();
        }

        protected DCAction.ChildDCActionCollection _DCActions = null;
        public DCAction.ChildDCActionCollection DCActions
        {
            get
            {
                if (_DCActions == null)
                    CreateDCActionsCollection();
                return _DCActions;
            }
        }

        protected STCAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected STCAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected STCAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected STCAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected STCAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "STCACTION", dataRow) { }
        protected STCAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "STCACTION", dataRow, isImported) { }
        public STCAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public STCAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public STCAction() : base() { }

    }
}