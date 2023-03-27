
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ManualDexterityTestsForm")] 

    /// <summary>
    /// El beceri testleri
    /// </summary>
    public  partial class ManualDexterityTestsForm : BaseAdditionalInfo
    {
        public class ManualDexterityTestsFormList : TTObjectCollection<ManualDexterityTestsForm> { }
                    
        public class ChildManualDexterityTestsFormCollection : TTObject.TTChildObjectCollection<ManualDexterityTestsForm>
        {
            public ChildManualDexterityTestsFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildManualDexterityTestsFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Purdue Pegboard Testi
    /// </summary>
        public string PurduePegboardTest
        {
            get { return (string)this["PURDUEPEGBOARDTEST"]; }
            set { this["PURDUEPEGBOARDTEST"] = value; }
        }

    /// <summary>
    /// O'Connor parmak Beceri Testi
    /// </summary>
        public string OConnorFingerDexterityTest
        {
            get { return (string)this["OCONNORFINGERDEXTERITYTEST"]; }
            set { this["OCONNORFINGERDEXTERITYTEST"] = value; }
        }

    /// <summary>
    /// Nine Hole Peg Test
    /// </summary>
        public string NineHolePegTest
        {
            get { return (string)this["NINEHOLEPEGTEST"]; }
            set { this["NINEHOLEPEGTEST"] = value; }
        }

    /// <summary>
    /// Moberg Toplama Testi
    /// </summary>
        public string MobergTest
        {
            get { return (string)this["MOBERGTEST"]; }
            set { this["MOBERGTEST"] = value; }
        }

    /// <summary>
    /// Bimanuel Fine Motor Test
    /// </summary>
        public string BimanuelFineMotorTest
        {
            get { return (string)this["BIMANUELFINEMOTORTEST"]; }
            set { this["BIMANUELFINEMOTORTEST"] = value; }
        }

    /// <summary>
    /// Dellon Modifiye Toplama Test
    /// </summary>
        public string DellonTest
        {
            get { return (string)this["DELLONTEST"]; }
            set { this["DELLONTEST"] = value; }
        }

        protected ManualDexterityTestsForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ManualDexterityTestsForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ManualDexterityTestsForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ManualDexterityTestsForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ManualDexterityTestsForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MANUALDEXTERITYTESTSFORM", dataRow) { }
        protected ManualDexterityTestsForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MANUALDEXTERITYTESTSFORM", dataRow, isImported) { }
        public ManualDexterityTestsForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ManualDexterityTestsForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ManualDexterityTestsForm() : base() { }

    }
}