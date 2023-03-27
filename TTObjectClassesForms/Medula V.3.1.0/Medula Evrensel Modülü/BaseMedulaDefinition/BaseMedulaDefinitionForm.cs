
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// Temel Tanımlama Formu
    /// </summary>
    public partial class BaseMedulaDefinitionForm : TerminologyManagerDefForm
    {
#region BaseMedulaDefinitionForm_Methods
        public void CheckTheIdentificationNumber(string identificationNumber)
        {
            if (string.IsNullOrEmpty(identificationNumber))
                throw new TTException("TC Kimlik Numarası boş olamaz.");

            string id = identificationNumber.Trim();

            if (string.IsNullOrEmpty(id))
                throw new TTException("TC Kimlik Numarası boş olamaz.");

            if (id.Length != 11)
                throw new TTException("TC Kimlik Numarası 11 rakamlı olmalıdır.\r\nGirdiğiniz rakam sayısı : " + id.Length);

            if (Globals.IsCitizenShipID(id) == false)
                throw new TTException("TC Kimlik Numarası geçerli değildir.\r\nGirdiğiniz TC Kimlik Numarası : " + id);

        }
        
#endregion BaseMedulaDefinitionForm_Methods
    }
}