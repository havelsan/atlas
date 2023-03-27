
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BalanceCoordinationTestsForm")] 

    /// <summary>
    /// Denge / Koordinasyon Testleri
    /// </summary>
    public  partial class BalanceCoordinationTestsForm : BaseAdditionalInfo
    {
        public class BalanceCoordinationTestsFormList : TTObjectCollection<BalanceCoordinationTestsForm> { }
                    
        public class ChildBalanceCoordinationTestsFormCollection : TTObject.TTChildObjectCollection<BalanceCoordinationTestsForm>
        {
            public ChildBalanceCoordinationTestsFormCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBalanceCoordinationTestsFormCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Tek Bacak Üzerinde Durma
    /// </summary>
        public string StandingOnOneLeg
        {
            get { return (string)this["STANDINGONONELEG"]; }
            set { this["STANDINGONONELEG"] = value; }
        }

    /// <summary>
    /// Kalk ve Yürü Testi
    /// </summary>
        public string StandUpWalkTest
        {
            get { return (string)this["STANDUPWALKTEST"]; }
            set { this["STANDUPWALKTEST"] = value; }
        }

    /// <summary>
    /// Berg Denge Testi
    /// </summary>
        public string BergBalanceTest
        {
            get { return (string)this["BERGBALANCETEST"]; }
            set { this["BERGBALANCETEST"] = value; }
        }

    /// <summary>
    /// Falls Efficacy Scale
    /// </summary>
        public string FallsEfficacyScale
        {
            get { return (string)this["FALLSEFFICACYSCALE"]; }
            set { this["FALLSEFFICACYSCALE"] = value; }
        }

    /// <summary>
    /// Uzanma Testi
    /// </summary>
        public string LieDownTest
        {
            get { return (string)this["LIEDOWNTEST"]; }
            set { this["LIEDOWNTEST"] = value; }
        }

    /// <summary>
    /// Dört Kare Adım Testi
    /// </summary>
        public string FourSquareStepTest
        {
            get { return (string)this["FOURSQUARESTEPTEST"]; }
            set { this["FOURSQUARESTEPTEST"] = value; }
        }

    /// <summary>
    /// Beş Kere Oturup Kalkma Testi
    /// </summary>
        public string FiveTimesSitToStandTest
        {
            get { return (string)this["FIVETIMESSITTOSTANDTEST"]; }
            set { this["FIVETIMESSITTOSTANDTEST"] = value; }
        }

        protected BalanceCoordinationTestsForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BalanceCoordinationTestsForm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BalanceCoordinationTestsForm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BalanceCoordinationTestsForm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BalanceCoordinationTestsForm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BALANCECOORDINATIONTESTSFORM", dataRow) { }
        protected BalanceCoordinationTestsForm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BALANCECOORDINATIONTESTSFORM", dataRow, isImported) { }
        public BalanceCoordinationTestsForm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BalanceCoordinationTestsForm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BalanceCoordinationTestsForm() : base() { }

    }
}