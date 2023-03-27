
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseAdditionalApplication")] 

    /// <summary>
    /// Ek Uygulamalar
    /// </summary>
    public  partial class BaseAdditionalApplication : BaseSurgeryAndManipulationProcedure
    {
        public class BaseAdditionalApplicationList : TTObjectCollection<BaseAdditionalApplication> { }
                    
        public class ChildBaseAdditionalApplicationCollection : TTObject.TTChildObjectCollection<BaseAdditionalApplication>
        {
            public ChildBaseAdditionalApplicationCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseAdditionalApplicationCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

    /// <summary>
    /// Hemşire Notu
    /// </summary>
        public string NurseNotes
        {
            get { return (string)this["NURSENOTES"]; }
            set { this["NURSENOTES"] = value; }
        }

    /// <summary>
    /// Sonuç
    /// </summary>
        public string Result
        {
            get { return (string)this["RESULT"]; }
            set { this["RESULT"] = value; }
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
    /// FTR Vucut Bolgesi bilgisi
    /// </summary>
        public FTRVucutBolgesi ReportApplicationArea
        {
            get { return (FTRVucutBolgesi)((ITTObject)this).GetParent("REPORTAPPLICATIONAREA"); }
            set { this["REPORTAPPLICATIONAREA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBaseAdditionalInfoFormCollection()
        {
            _BaseAdditionalInfoForm = new BaseAdditionalInfo.ChildBaseAdditionalInfoCollection(this, new Guid("2e5c1163-6243-4264-bc1b-19658a7eac53"));
            ((ITTChildObjectCollection)_BaseAdditionalInfoForm).GetChildren();
        }

        protected BaseAdditionalInfo.ChildBaseAdditionalInfoCollection _BaseAdditionalInfoForm = null;
        public BaseAdditionalInfo.ChildBaseAdditionalInfoCollection BaseAdditionalInfoForm
        {
            get
            {
                if (_BaseAdditionalInfoForm == null)
                    CreateBaseAdditionalInfoFormCollection();
                return _BaseAdditionalInfoForm;
            }
        }

        virtual protected void CreateSkinPrickTestDetailCollection()
        {
            _SkinPrickTestDetail = new SkinPrickTestDetail.ChildSkinPrickTestDetailCollection(this, new Guid("26b73491-560a-4598-8940-a4a28672163f"));
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

        protected BaseAdditionalApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseAdditionalApplication(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseAdditionalApplication(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseAdditionalApplication(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseAdditionalApplication(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEADDITIONALAPPLICATION", dataRow) { }
        protected BaseAdditionalApplication(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEADDITIONALAPPLICATION", dataRow, isImported) { }
        public BaseAdditionalApplication(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseAdditionalApplication(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseAdditionalApplication() : base() { }

    }
}