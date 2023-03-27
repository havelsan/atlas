
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
    public partial class UpdatePhyOrderDetailDateForm : ScheduledTaskBaseForm
    {
    /// <summary>
    /// Fizyoterapi Tatil Günleri OrderDetail Tarihi Değiştirme
    /// </summary>
        protected TTObjectClasses.UpdatePhyOrderDetailDate _UpdatePhyOrderDetailDate
        {
            get { return (TTObjectClasses.UpdatePhyOrderDetailDate)_ttObject; }
        }

        public UpdatePhyOrderDetailDateForm() : base("UPDATEPHYORDERDETAILDATE", "UpdatePhyOrderDetailDateForm")
        {
        }

        protected UpdatePhyOrderDetailDateForm(string objectDefName, string formDefName) : base(objectDefName, formDefName)
        {
        }
    }
}