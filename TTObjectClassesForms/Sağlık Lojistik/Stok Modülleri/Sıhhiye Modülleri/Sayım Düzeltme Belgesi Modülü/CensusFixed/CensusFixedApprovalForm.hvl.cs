
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
    /// Sayım Düzeltme Belgesi
    /// </summary>
    public partial class CensusFixedApprovalForm : BaseCensusFixedForm
    {
    /// <summary>
    /// Sayım Düzeltme Belgesi için kullanılan temel sınıftır
    /// </summary>
        protected TTObjectClasses.CensusFixed _CensusFixed
        {
            get { return (TTObjectClasses.CensusFixed)_ttObject; }
        }

        public CensusFixedApprovalForm() : base("CENSUSFIXED", "CensusFixedApprovalForm")
        {
        }

        protected CensusFixedApprovalForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}