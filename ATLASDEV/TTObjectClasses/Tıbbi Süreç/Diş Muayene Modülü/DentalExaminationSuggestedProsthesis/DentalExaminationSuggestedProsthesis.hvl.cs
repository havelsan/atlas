
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DentalExaminationSuggestedProsthesis")] 

    /// <summary>
    /// Önerilen Diş  Protezi
    /// </summary>
    public  partial class DentalExaminationSuggestedProsthesis : DentalProsthesisRequestSuggestedProsthesis
    {
        public class DentalExaminationSuggestedProsthesisList : TTObjectCollection<DentalExaminationSuggestedProsthesis> { }
                    
        public class ChildDentalExaminationSuggestedProsthesisCollection : TTObject.TTChildObjectCollection<DentalExaminationSuggestedProsthesis>
        {
            public ChildDentalExaminationSuggestedProsthesisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDentalExaminationSuggestedProsthesisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Önerilen Diş Protez
    /// </summary>
        public DentalExamination DentalExamination
        {
            get { return (DentalExamination)((ITTObject)this).GetParent("DENTALEXAMINATION"); }
            set { this["DENTALEXAMINATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önerilen Lab Diş Protez
    /// </summary>
        public DentalLaboratoryProcedure DentalLaboratoryProcedure
        {
            get { return (DentalLaboratoryProcedure)((ITTObject)this).GetParent("DENTALLABORATORYPROCEDURE"); }
            set { this["DENTALLABORATORYPROCEDURE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateDentalLaboratoryProcedureProthesisCollection()
        {
            _DentalLaboratoryProcedureProthesis = new DentalLaboratoryProcedureProthesis.ChildDentalLaboratoryProcedureProthesisCollection(this, new Guid("24e129d6-ffa5-46f9-8edf-169f934f9828"));
            ((ITTChildObjectCollection)_DentalLaboratoryProcedureProthesis).GetChildren();
        }

        protected DentalLaboratoryProcedureProthesis.ChildDentalLaboratoryProcedureProthesisCollection _DentalLaboratoryProcedureProthesis = null;
        public DentalLaboratoryProcedureProthesis.ChildDentalLaboratoryProcedureProthesisCollection DentalLaboratoryProcedureProthesis
        {
            get
            {
                if (_DentalLaboratoryProcedureProthesis == null)
                    CreateDentalLaboratoryProcedureProthesisCollection();
                return _DentalLaboratoryProcedureProthesis;
            }
        }

        protected DentalExaminationSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DentalExaminationSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DentalExaminationSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DentalExaminationSuggestedProsthesis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DentalExaminationSuggestedProsthesis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DENTALEXAMINATIONSUGGESTEDPROSTHESIS", dataRow) { }
        protected DentalExaminationSuggestedProsthesis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DENTALEXAMINATIONSUGGESTEDPROSTHESIS", dataRow, isImported) { }
        public DentalExaminationSuggestedProsthesis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DentalExaminationSuggestedProsthesis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DentalExaminationSuggestedProsthesis() : base() { }

    }
}