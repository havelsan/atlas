
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
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Kayıt Silme Belgesi - Yok Edilen
    /// </summary>
    public partial class DeleteRecordDocumentDestroyableInspectionForm : BaseDeleteRecordDocumentDestroyableForm
    {
    /// <summary>
    /// Kayıt Silme Belgesi - Yok Edilen için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.DeleteRecordDocumentDestroyable _DeleteRecordDocumentDestroyable
        {
            get { return (TTObjectClasses.DeleteRecordDocumentDestroyable)_ttObject; }
        }

        public DeleteRecordDocumentDestroyableInspectionForm() : base("DELETERECORDDOCUMENTDESTROYABLE", "DeleteRecordDocumentDestroyableInspectionForm")
        {
        }

        protected DeleteRecordDocumentDestroyableInspectionForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}