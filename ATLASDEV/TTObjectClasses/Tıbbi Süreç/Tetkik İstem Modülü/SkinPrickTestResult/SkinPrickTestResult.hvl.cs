
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SkinPrickTestResult")] 

    /// <summary>
    /// Deri Prick Test Sonuç Alanı
    /// </summary>
    public  partial class SkinPrickTestResult : BaseAdditionalInfo
    {
        public class SkinPrickTestResultList : TTObjectCollection<SkinPrickTestResult> { }
                    
        public class ChildSkinPrickTestResultCollection : TTObject.TTChildObjectCollection<SkinPrickTestResult>
        {
            public ChildSkinPrickTestResultCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSkinPrickTestResultCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        virtual protected void CreateSkinPrickTestDetailCollection()
        {
            _SkinPrickTestDetail = new SkinPrickTestDetail.ChildSkinPrickTestDetailCollection(this, new Guid("4fa90adc-e69d-4a8f-8758-9cb942d7372a"));
            ((ITTChildObjectCollection)_SkinPrickTestDetail).GetChildren();
        }

        protected SkinPrickTestDetail.ChildSkinPrickTestDetailCollection _SkinPrickTestDetail = null;
        public SkinPrickTestDetail.ChildSkinPrickTestDetailCollection SkinPrickTestDetail
        {
            get
            {
                if (_SkinPrickTestDetail == null)
                    CreateSkinPrickTestDetailCollection();
                return _SkinPrickTestDetail;
            }
        }

        protected SkinPrickTestResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SkinPrickTestResult(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SkinPrickTestResult(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SkinPrickTestResult(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SkinPrickTestResult(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKINPRICKTESTRESULT", dataRow) { }
        protected SkinPrickTestResult(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKINPRICKTESTRESULT", dataRow, isImported) { }
        public SkinPrickTestResult(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SkinPrickTestResult(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SkinPrickTestResult() : base() { }

    }
}