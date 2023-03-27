
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FixedAssetParameterMatch")] 

    /// <summary>
    /// Tıbbi Cihaz - Parametre Eşleştirme
    /// </summary>
    public  partial class FixedAssetParameterMatch : BaseAction, IWorkListBaseAction
    {
        public class FixedAssetParameterMatchList : TTObjectCollection<FixedAssetParameterMatch> { }
                    
        public class ChildFixedAssetParameterMatchCollection : TTObject.TTChildObjectCollection<FixedAssetParameterMatch>
        {
            public ChildFixedAssetParameterMatchCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFixedAssetParameterMatchCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("e4ca4524-da1e-4490-b644-b60301407b05"); } }
    /// <summary>
    /// Tamamlandı
    /// </summary>
            public static Guid Completed { get { return new Guid("5ac42787-5a28-4d8b-843f-2265e3cfc7dc"); } }
        }

        virtual protected void CreateMatchUnitParametersCollection()
        {
            _MatchUnitParameters = new MatchUnitParameter.ChildMatchUnitParameterCollection(this, new Guid("0f72890e-c680-48ac-93d7-38e6eb21f4f0"));
            ((ITTChildObjectCollection)_MatchUnitParameters).GetChildren();
        }

        protected MatchUnitParameter.ChildMatchUnitParameterCollection _MatchUnitParameters = null;
        public MatchUnitParameter.ChildMatchUnitParameterCollection MatchUnitParameters
        {
            get
            {
                if (_MatchUnitParameters == null)
                    CreateMatchUnitParametersCollection();
                return _MatchUnitParameters;
            }
        }

        virtual protected void CreateMatchUserParametersCollection()
        {
            _MatchUserParameters = new MatchUserParameter.ChildMatchUserParameterCollection(this, new Guid("7b279d93-6aa6-4a6a-8ce2-39f611fe5b05"));
            ((ITTChildObjectCollection)_MatchUserParameters).GetChildren();
        }

        protected MatchUserParameter.ChildMatchUserParameterCollection _MatchUserParameters = null;
        public MatchUserParameter.ChildMatchUserParameterCollection MatchUserParameters
        {
            get
            {
                if (_MatchUserParameters == null)
                    CreateMatchUserParametersCollection();
                return _MatchUserParameters;
            }
        }

        virtual protected void CreateMatchFixedAssetsCollection()
        {
            _MatchFixedAssets = new MatchFixedAsset.ChildMatchFixedAssetCollection(this, new Guid("b39dba70-c74f-4c8d-920e-40f501c37c6b"));
            ((ITTChildObjectCollection)_MatchFixedAssets).GetChildren();
        }

        protected MatchFixedAsset.ChildMatchFixedAssetCollection _MatchFixedAssets = null;
        public MatchFixedAsset.ChildMatchFixedAssetCollection MatchFixedAssets
        {
            get
            {
                if (_MatchFixedAssets == null)
                    CreateMatchFixedAssetsCollection();
                return _MatchFixedAssets;
            }
        }

        protected FixedAssetParameterMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FixedAssetParameterMatch(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FixedAssetParameterMatch(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FixedAssetParameterMatch(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FixedAssetParameterMatch(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FIXEDASSETPARAMETERMATCH", dataRow) { }
        protected FixedAssetParameterMatch(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FIXEDASSETPARAMETERMATCH", dataRow, isImported) { }
        public FixedAssetParameterMatch(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FixedAssetParameterMatch(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FixedAssetParameterMatch() : base() { }

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