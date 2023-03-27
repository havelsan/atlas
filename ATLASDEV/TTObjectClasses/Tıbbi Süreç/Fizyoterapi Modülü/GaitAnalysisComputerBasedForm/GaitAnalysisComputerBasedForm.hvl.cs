
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="GaitAnalysisComputerBasedForm")] 

    /// <summary>
    /// Yürüme Analizi (Bilgisayar Sistemli Kinetik-Kinematik Analiz)
    /// </summary>
    public  partial class GaitAnalysisComputerBasedForm : BaseAdditionalInfo
    {
        public class GaitAnalysisComputerBasedFormList : TTObjectCollection<GaitAnalysisComputerBasedForm> { }
                    
        public class ChildGaitAnalysisComputerBasedFormCollection : TTObject.TTChildObjectCollection<GaitAnalysisComputerBasedForm>
        {
            public ChildGaitAnalysisComputerBasedFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildGaitAnalysisComputerBasedFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Yürüme Analizi
    /// </summary>
        public string GaitAnalysis
        {
            get { return (string)this["GAITANALYSIS"]; }
            set { this["GAITANALYSIS"] = value; }
        }

        protected GaitAnalysisComputerBasedForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected GaitAnalysisComputerBasedForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected GaitAnalysisComputerBasedForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected GaitAnalysisComputerBasedForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected GaitAnalysisComputerBasedForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "GAITANALYSISCOMPUTERBASEDFORM", dataRow) { }
        protected GaitAnalysisComputerBasedForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "GAITANALYSISCOMPUTERBASEDFORM", dataRow, isImported) { }
        public GaitAnalysisComputerBasedForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public GaitAnalysisComputerBasedForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public GaitAnalysisComputerBasedForm() : base() { }

    }
}