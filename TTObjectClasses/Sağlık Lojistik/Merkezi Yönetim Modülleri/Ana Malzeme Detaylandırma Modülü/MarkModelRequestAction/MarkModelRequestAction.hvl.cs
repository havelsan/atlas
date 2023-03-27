
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MarkModelRequestAction")] 

    /// <summary>
    /// Marka/Model/Gövde Yapısı/ Uç Yapısı / Uzunluk İstek  
    /// </summary>
    public  partial class MarkModelRequestAction : BaseCentralAction
    {
        public class MarkModelRequestActionList : TTObjectCollection<MarkModelRequestAction> { }
                    
        public class ChildMarkModelRequestActionCollection : TTObject.TTChildObjectCollection<MarkModelRequestAction>
        {
            public ChildMarkModelRequestActionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMarkModelRequestActionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid Cancelled { get { return new Guid("b8f8d161-4704-4e56-9759-a44b730d7aeb"); } }
            public static Guid Completed { get { return new Guid("1ad85e09-6d98-4334-bdd3-e355977a8c07"); } }
    /// <summary>
    /// İstek
    /// </summary>
            public static Guid New { get { return new Guid("b0195363-a8c8-4ef1-ad78-f2214fb8ca03"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid Approval { get { return new Guid("46e5ca5b-e9b9-4500-ae15-38d8341582e2"); } }
        }

        public string MarkName
        {
            get { return (string)this["MARKNAME"]; }
            set { this["MARKNAME"] = value; }
        }

        public string ModelName
        {
            get { return (string)this["MODELNAME"]; }
            set { this["MODELNAME"] = value; }
        }

        public string BodyName
        {
            get { return (string)this["BODYNAME"]; }
            set { this["BODYNAME"] = value; }
        }

        public string EdgeName
        {
            get { return (string)this["EDGENAME"]; }
            set { this["EDGENAME"] = value; }
        }

        public string Length
        {
            get { return (string)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// İstek Açıklaması
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Marka Yok
    /// </summary>
        public bool? NoMark
        {
            get { return (bool?)this["NOMARK"]; }
            set { this["NOMARK"] = value; }
        }

    /// <summary>
    /// Model Yok
    /// </summary>
        public bool? NoModel
        {
            get { return (bool?)this["NOMODEL"]; }
            set { this["NOMODEL"] = value; }
        }

    /// <summary>
    /// Gövde Yapısı Yok
    /// </summary>
        public bool? NoBody
        {
            get { return (bool?)this["NOBODY"]; }
            set { this["NOBODY"] = value; }
        }

    /// <summary>
    /// Uç Yapısı Yok
    /// </summary>
        public bool? NoEdge
        {
            get { return (bool?)this["NOEDGE"]; }
            set { this["NOEDGE"] = value; }
        }

    /// <summary>
    /// Uzunluk Yok
    /// </summary>
        public bool? NoLength
        {
            get { return (bool?)this["NOLENGTH"]; }
            set { this["NOLENGTH"] = value; }
        }

    /// <summary>
    /// Marka Model İstek
    /// </summary>
        public bool? MarkModelReason
        {
            get { return (bool?)this["MARKMODELREASON"]; }
            set { this["MARKMODELREASON"] = value; }
        }

    /// <summary>
    /// Gövde Uç Uzunluk İstek
    /// </summary>
        public bool? BodyEdgeLengt
        {
            get { return (bool?)this["BODYEDGELENGT"]; }
            set { this["BODYEDGELENGT"] = value; }
        }

        public FixedAssetDetailMainClassDefinition FixedAssetDetailMainClassDef
        {
            get { return (FixedAssetDetailMainClassDefinition)((ITTObject)this).GetParent("FIXEDASSETDETAILMAINCLASSDEF"); }
            set { this["FIXEDASSETDETAILMAINCLASSDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailMarkDef FixedAssetDetailMarkDef
        {
            get { return (FixedAssetDetailMarkDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMARKDEF"); }
            set { this["FIXEDASSETDETAILMARKDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailModelDef FixedAssetDetailModelDef
        {
            get { return (FixedAssetDetailModelDef)((ITTObject)this).GetParent("FIXEDASSETDETAILMODELDEF"); }
            set { this["FIXEDASSETDETAILMODELDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailBodyDef FixedAssetDetailBodyDef
        {
            get { return (FixedAssetDetailBodyDef)((ITTObject)this).GetParent("FIXEDASSETDETAILBODYDEF"); }
            set { this["FIXEDASSETDETAILBODYDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailEdgeDef FixedAssetDetailEdgeDef
        {
            get { return (FixedAssetDetailEdgeDef)((ITTObject)this).GetParent("FIXEDASSETDETAILEDGEDEF"); }
            set { this["FIXEDASSETDETAILEDGEDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public FixedAssetDetailLengthDef FixedAssetDetailLengthDef
        {
            get { return (FixedAssetDetailLengthDef)((ITTObject)this).GetParent("FIXEDASSETDETAILLENGTHDEF"); }
            set { this["FIXEDASSETDETAILLENGTHDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected MarkModelRequestAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MarkModelRequestAction(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MarkModelRequestAction(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MarkModelRequestAction(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MarkModelRequestAction(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MARKMODELREQUESTACTION", dataRow) { }
        protected MarkModelRequestAction(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MARKMODELREQUESTACTION", dataRow, isImported) { }
        public MarkModelRequestAction(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MarkModelRequestAction(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MarkModelRequestAction() : base() { }

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