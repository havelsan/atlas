
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetDetailActionDet")] 

    public  partial class FixedAssetDetailActionDet : TTObject
    {
        public class FixedAssetDetailActionDetList : TTObjectCollection<FixedAssetDetailActionDet> { }
                    
        public class ChildFixedAssetDetailActionDetCollection : TTObject.TTChildObjectCollection<FixedAssetDetailActionDet>
        {
            public ChildFixedAssetDetailActionDetCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetDetailActionDetCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetFixedAssetDetailActDet_Class : TTReportNqlObject 
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

            public string BMMDesciption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BMMDESCIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["BMMDESCIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ETKMDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ETKMDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["ETKMDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsNewFixedAsset
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNEWFIXEDASSET"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["ISNEWFIXEDASSET"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsAccountancy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACCOUNTANCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["ISACCOUNTANCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsBMM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISBMM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["ISBMM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsETKM
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISETKM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["ISETKM"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OtherMainClass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERMAINCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["OTHERMAINCLASS"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OtherMark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERMARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["OTHERMARK"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OtherModel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERMODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["OTHERMODEL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OtherBody
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERBODY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["OTHERBODY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OtherEdge
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHEREDGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["OTHEREDGE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? OtherLenght
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OTHERLENGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].AllPropertyDefs["OTHERLENGHT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetFixedAssetDetailActDet_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetFixedAssetDetailActDet_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetFixedAssetDetailActDet_Class() : base() { }
        }

        public static BindingList<FixedAssetDetailActionDet.GetFixedAssetDetailActDet_Class> GetFixedAssetDetailActDet(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].QueryDefs["GetFixedAssetDetailActDet"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<FixedAssetDetailActionDet.GetFixedAssetDetailActDet_Class>(queryDef, paramList, pi);
        }

        public static BindingList<FixedAssetDetailActionDet.GetFixedAssetDetailActDet_Class> GetFixedAssetDetailActDet(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDETAILACTIONDET"].QueryDefs["GetFixedAssetDetailActDet"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<FixedAssetDetailActionDet.GetFixedAssetDetailActDet_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// 2.Aşama Açıklama
    /// </summary>
        public string BMMDesciption
        {
            get { return (string)this["BMMDESCIPTION"]; }
            set { this["BMMDESCIPTION"] = value; }
        }

    /// <summary>
    /// ETKM Açıklama
    /// </summary>
        public string ETKMDescription
        {
            get { return (string)this["ETKMDESCRIPTION"]; }
            set { this["ETKMDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Yeri Giriş İşlemi mi?
    /// </summary>
        public bool? IsNewFixedAsset
        {
            get { return (bool?)this["ISNEWFIXEDASSET"]; }
            set { this["ISNEWFIXEDASSET"] = value; }
        }

    /// <summary>
    /// Saymanlık
    /// </summary>
        public bool? IsAccountancy
        {
            get { return (bool?)this["ISACCOUNTANCY"]; }
            set { this["ISACCOUNTANCY"] = value; }
        }

    /// <summary>
    /// BMM
    /// </summary>
        public bool? IsBMM
        {
            get { return (bool?)this["ISBMM"]; }
            set { this["ISBMM"] = value; }
        }

    /// <summary>
    /// ETKM
    /// </summary>
        public bool? IsETKM
        {
            get { return (bool?)this["ISETKM"]; }
            set { this["ISETKM"] = value; }
        }

    /// <summary>
    /// Diğer Ana Malzeme Adı
    /// </summary>
        public bool? OtherMainClass
        {
            get { return (bool?)this["OTHERMAINCLASS"]; }
            set { this["OTHERMAINCLASS"] = value; }
        }

    /// <summary>
    /// Diğer Marka
    /// </summary>
        public bool? OtherMark
        {
            get { return (bool?)this["OTHERMARK"]; }
            set { this["OTHERMARK"] = value; }
        }

    /// <summary>
    /// Diğer Model
    /// </summary>
        public bool? OtherModel
        {
            get { return (bool?)this["OTHERMODEL"]; }
            set { this["OTHERMODEL"] = value; }
        }

    /// <summary>
    /// Diğer Gövde Yapısı
    /// </summary>
        public bool? OtherBody
        {
            get { return (bool?)this["OTHERBODY"]; }
            set { this["OTHERBODY"] = value; }
        }

    /// <summary>
    /// Diğer Uç Yapısı
    /// </summary>
        public bool? OtherEdge
        {
            get { return (bool?)this["OTHEREDGE"]; }
            set { this["OTHEREDGE"] = value; }
        }

    /// <summary>
    /// Diğer Uzunluk
    /// </summary>
        public bool? OtherLenght
        {
            get { return (bool?)this["OTHERLENGHT"]; }
            set { this["OTHERLENGHT"] = value; }
        }

        public FixedAssetMaterialDefinition FixedAssetMaterialDefinition
        {
            get { return (FixedAssetMaterialDefinition)((ITTObject)this).GetParent("FIXEDASSETMATERIALDEFINITION"); }
            set { this["FIXEDASSETMATERIALDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailAction FixedAssetDetailAction
        {
            get { return (FixedAssetDetailAction)((ITTObject)this).GetParent("FIXEDASSETDETAILACTION"); }
            set { this["FIXEDASSETDETAILACTION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FixedAssetDetailActionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetDetailActionDet(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetDetailActionDet(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetDetailActionDet(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetDetailActionDet(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETDETAILACTIONDET", dataRow) { }
        protected FixedAssetDetailActionDet(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETDETAILACTIONDET", dataRow, isImported) { }
        public FixedAssetDetailActionDet(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetDetailActionDet(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetDetailActionDet() : base() { }

    }
}