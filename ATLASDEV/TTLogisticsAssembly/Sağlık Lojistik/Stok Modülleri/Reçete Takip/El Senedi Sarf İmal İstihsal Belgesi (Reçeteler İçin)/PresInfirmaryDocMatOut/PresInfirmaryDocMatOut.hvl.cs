
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PresInfirmaryDocMatOut")] 

    public  partial class PresInfirmaryDocMatOut : StockActionDetailOut
    {
        public class PresInfirmaryDocMatOutList : TTObjectCollection<PresInfirmaryDocMatOut> { }
                    
        public class ChildPresInfirmaryDocMatOutCollection : TTObject.TTChildObjectCollection<PresInfirmaryDocMatOut>
        {
            public ChildPresInfirmaryDocMatOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPresInfirmaryDocMatOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Mevcut
    /// </summary>
        public double? Existing
        {
            get { return (double?)this["EXISTING"]; }
            set { this["EXISTING"] = value; }
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PresInfirmaryDocument PresInfirmaryDocument
        {
            get 
            {   
                if (StockAction is PresInfirmaryDocument)
                    return (PresInfirmaryDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        virtual protected void CreatePrescriptionConsumptionDetailsCollection()
        {
            _PrescriptionConsumptionDetails = new PrescriptionConsumptionDetail.ChildPrescriptionConsumptionDetailCollection(this, new Guid("062197a7-ee1e-4266-8f17-a3d3b562e72b"));
            ((ITTChildObjectCollection)_PrescriptionConsumptionDetails).GetChildren();
        }

        protected PrescriptionConsumptionDetail.ChildPrescriptionConsumptionDetailCollection _PrescriptionConsumptionDetails = null;
        public PrescriptionConsumptionDetail.ChildPrescriptionConsumptionDetailCollection PrescriptionConsumptionDetails
        {
            get
            {
                if (_PrescriptionConsumptionDetails == null)
                    CreatePrescriptionConsumptionDetailsCollection();
                return _PrescriptionConsumptionDetails;
            }
        }

        protected PresInfirmaryDocMatOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PresInfirmaryDocMatOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PresInfirmaryDocMatOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PresInfirmaryDocMatOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PresInfirmaryDocMatOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESINFIRMARYDOCMATOUT", dataRow) { }
        protected PresInfirmaryDocMatOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESINFIRMARYDOCMATOUT", dataRow, isImported) { }
        public PresInfirmaryDocMatOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PresInfirmaryDocMatOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PresInfirmaryDocMatOut() : base() { }

    }
}