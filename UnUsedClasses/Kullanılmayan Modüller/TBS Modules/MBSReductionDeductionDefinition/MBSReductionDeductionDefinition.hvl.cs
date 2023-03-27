
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSReductionDeductionDefinition")] 

    public  partial class MBSReductionDeductionDefinition : TTObject
    {
        public class MBSReductionDeductionDefinitionList : TTObjectCollection<MBSReductionDeductionDefinition> { }
                    
        public class ChildMBSReductionDeductionDefinitionCollection : TTObject.TTChildObjectCollection<MBSReductionDeductionDefinition>
        {
            public ChildMBSReductionDeductionDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSReductionDeductionDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kişi değişken tipi
    /// </summary>
        public string UIType
        {
            get { return (string)this["UITYPE"]; }
            set { this["UITYPE"] = value; }
        }

    /// <summary>
    /// Gelir vergisi
    /// </summary>
        public bool? IncomeTax
        {
            get { return (bool?)this["INCOMETAX"]; }
            set { this["INCOMETAX"] = value; }
        }

    /// <summary>
    /// Tür
    /// </summary>
        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Formül
    /// </summary>
        public string Formula
        {
            get { return (string)this["FORMULA"]; }
            set { this["FORMULA"] = value; }
        }

    /// <summary>
    /// Damga vergisi
    /// </summary>
        public bool? StampTax
        {
            get { return (bool?)this["STAMPTAX"]; }
            set { this["STAMPTAX"] = value; }
        }

    /// <summary>
    /// Tanım
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Emekli sandığı kesintisi
    /// </summary>
        public bool? EMSANReduction
        {
            get { return (bool?)this["EMSANREDUCTION"]; }
            set { this["EMSANREDUCTION"] = value; }
        }

    /// <summary>
    /// Kişi ilişki etiketi
    /// </summary>
        public string UILabel
        {
            get { return (string)this["UILABEL"]; }
            set { this["UILABEL"] = value; }
        }

        virtual protected void CreateValuesCollection()
        {
            _Values = new MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection(this, new Guid("9f405de7-af8d-4203-943a-b76a9058551f"));
            ((ITTChildObjectCollection)_Values).GetChildren();
        }

        protected MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection _Values = null;
        public MBSReductionDeductionValue.ChildMBSReductionDeductionValueCollection Values
        {
            get
            {
                if (_Values == null)
                    CreateValuesCollection();
                return _Values;
            }
        }

        protected MBSReductionDeductionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSReductionDeductionDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSReductionDeductionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSReductionDeductionDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSReductionDeductionDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSREDUCTIONDEDUCTIONDEFINITION", dataRow) { }
        protected MBSReductionDeductionDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSREDUCTIONDEDUCTIONDEFINITION", dataRow, isImported) { }
        public MBSReductionDeductionDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSReductionDeductionDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSReductionDeductionDefinition() : base() { }

    }
}