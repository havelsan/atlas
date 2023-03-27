
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSPerson")] 

    public  partial class MBSPerson : TTObject
    {
        public class MBSPersonList : TTObjectCollection<MBSPerson> { }
                    
        public class ChildMBSPersonCollection : TTObject.TTChildObjectCollection<MBSPerson>
        {
            public ChildMBSPersonCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSPersonCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Soyad
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        virtual protected void CreateCOBCashsCollection()
        {
            _COBCashs = new MBSCOBCash.ChildMBSCOBCashCollection(this, new Guid("cd2ea942-3332-4cb7-87fd-0f5c2d32f212"));
            ((ITTChildObjectCollection)_COBCashs).GetChildren();
        }

        protected MBSCOBCash.ChildMBSCOBCashCollection _COBCashs = null;
        public MBSCOBCash.ChildMBSCOBCashCollection COBCashs
        {
            get
            {
                if (_COBCashs == null)
                    CreateCOBCashsCollection();
                return _COBCashs;
            }
        }

        virtual protected void CreateAssignPricesCollection()
        {
            _AssignPrices = new MBSAssignPrice.ChildMBSAssignPriceCollection(this, new Guid("1bc11a19-42b0-460a-94f2-06d33d9152ca"));
            ((ITTChildObjectCollection)_AssignPrices).GetChildren();
        }

        protected MBSAssignPrice.ChildMBSAssignPriceCollection _AssignPrices = null;
        public MBSAssignPrice.ChildMBSAssignPriceCollection AssignPrices
        {
            get
            {
                if (_AssignPrices == null)
                    CreateAssignPricesCollection();
                return _AssignPrices;
            }
        }

        virtual protected void CreateAdditionalLessonPayrollsCollection()
        {
            _AdditionalLessonPayrolls = new MBSAdditionalLessonPayroll.ChildMBSAdditionalLessonPayrollCollection(this, new Guid("f3cd2c43-5e7d-4cbf-9ca3-c71406b03511"));
            ((ITTChildObjectCollection)_AdditionalLessonPayrolls).GetChildren();
        }

        protected MBSAdditionalLessonPayroll.ChildMBSAdditionalLessonPayrollCollection _AdditionalLessonPayrolls = null;
        public MBSAdditionalLessonPayroll.ChildMBSAdditionalLessonPayrollCollection AdditionalLessonPayrolls
        {
            get
            {
                if (_AdditionalLessonPayrolls == null)
                    CreateAdditionalLessonPayrollsCollection();
                return _AdditionalLessonPayrolls;
            }
        }

        protected MBSPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSPerson(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSPerson(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSPerson(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSPerson(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSPERSON", dataRow) { }
        protected MBSPerson(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSPERSON", dataRow, isImported) { }
        public MBSPerson(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSPerson(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSPerson() : base() { }

    }
}