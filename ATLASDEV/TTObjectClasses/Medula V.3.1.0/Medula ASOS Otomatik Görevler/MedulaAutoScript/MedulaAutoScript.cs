
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
    /// <summary>
    /// Medula Otomatik Görevler
    /// </summary>
    public  partial class MedulaAutoScript : BaseScheduledTask
    {
#region Methods
        public void CreateProcedureRegistration()
        {
            // Valid state indeki PatientMedulaHastaKabul ler getirilir
            IList PatientMedulaHastaKabulList = PatientMedulaHastaKabul.GetOnValidState(ObjectContext);
            
            foreach (PatientMedulaHastaKabul MedulaHastaKabul in PatientMedulaHastaKabulList)
            {
                try
                {
                    if (MedulaHastaKabul.RegisterableItemExists() == true)
                    {
                        HizmetKayit HK = new HizmetKayit(ObjectContext);
                        HK.CurrentStateDefID = HizmetKayit.States.New;
                        MedulaHastaKabul.CreateFullHizmetKayitGirisDVO(HK);
                        HK.Update();
                        HK.CurrentStateDefID = HizmetKayit.States.SentServer;
                    }
                }
                catch (Exception ex)
                {
                    // TODOMedula : Hatalı takipleri loglayalım
                }
            }
        }
        
        public override void TaskScript()
        {
            if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
            {
                CreateProcedureRegistration();
            }
        }
        
#endregion Methods

    }
}