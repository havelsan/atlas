
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
    /// Problem / Hata Bildirimi
    /// </summary>
    public partial class ErrorReportNewForm : BaseErrorReportForm
    {
    /// <summary>
    /// Problem / Hata Bildirimi
    /// </summary>
        protected TTObjectClasses.ErrorReportAction _ErrorReportAction
        {
            get { return (TTObjectClasses.ErrorReportAction)_ttObject; }
        }

        public ErrorReportNewForm() : base("ERRORREPORTACTION", "ErrorReportNewForm")
        {
        }

        protected ErrorReportNewForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}