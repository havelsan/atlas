
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
    /// İlaç Ara
    /// </summary>
    public  partial class IlacAra : BaseMedulaDefinitionAction
    {
        public partial class GetIlacAraWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Successfully2Completed()
        {
            // From State : Successfully   To State : Completed
#region PreTransition_Successfully2Completed
            
            if (ilacAraGirisDVO.ilacAraCevapDVO.ilaclar.Count > 0)
            {
                TTObjectContext readonlyObjectContext = new TTObjectContext(true);
                foreach (IlacListDVO ilacListDVO in ilacAraGirisDVO.ilacAraCevapDVO.ilaclar)
                {
                    if (string.IsNullOrEmpty(ilacListDVO.barkod) == false)
                    {
                        IList ilaclar = readonlyObjectContext.QueryObjects(typeof(Ilac).Name, "BARKOD ='" + ilacListDVO.barkod.Trim() + "'");
                        Ilac ilac = null;
                        if (ilaclar.Count <= 0)
                        {
                            ilac = (Ilac)ObjectContext.CreateObject(typeof(Ilac).Name);
                        }
                        else if (ilaclar.Count == 1)
                        {
                            Ilac readOnlyIlac = (Ilac)ilaclar[0];
                            ilac = (Ilac)ObjectContext.GetObject(readOnlyIlac.ObjectID, readOnlyIlac.ObjectDef);
                        }

                        if (ilac != null)
                        {
                            if (string.IsNullOrEmpty(ilacListDVO.barkod) == false)
                                ilac.barkod = ilacListDVO.barkod.Trim();
                            if (string.IsNullOrEmpty(ilacListDVO.ilacAdi) == false)
                                ilac.ilacAdi = ilacListDVO.ilacAdi.Trim();
                            if (ilacListDVO.kullanimBirimi.HasValue)
                                ilac.kullanimBirimi = ilacListDVO.kullanimBirimi.Value;
                            ilac.IsActive = true;
                            ilac.LastUpdate = TTObjectDefManager.ServerTime;

                            if (ilacListDVO.ilacFiyatlari.Count > 0)
                            {
                                foreach (FiyatListDVO fiyatListDVO in ilacListDVO.ilacFiyatlari)
                                {
                                    IList fiyatlar = ilac.ilacFiyatlari.Select("GECERLILIKTARIHI ='" + fiyatListDVO.gecerlilikTarihi.Trim() + "'");
                                    Fiyat fiyat = null;
                                    if (fiyatlar.Count <= 0)
                                    {
                                        fiyat = ilac.ilacFiyatlari.AddNew();
                                    }
                                    else if (fiyatlar.Count == 1)
                                    {
                                        Fiyat readOnlyFiyat = (Fiyat)fiyatlar[0];
                                        fiyat = (Fiyat)ObjectContext.GetObject(readOnlyFiyat.ObjectID, readOnlyFiyat.ObjectDef);
                                    }
                                    if (fiyat != null)
                                    {
                                        if (fiyatListDVO.fiyat.HasValue)
                                            fiyat.fiyat = fiyatListDVO.fiyat.Value;
                                        if (string.IsNullOrEmpty(fiyatListDVO.gecerlilikTarihi) == false)
                                            fiyat.gecerlilikTarihi = fiyatListDVO.gecerlilikTarihi.Trim();
                                    }
                                }

                            }
                        }
                    }
                }
                readonlyObjectContext.Dispose();
            }


#endregion PreTransition_Successfully2Completed
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
                ilacAraGirisDVO = new IlacAraGirisDVO(ObjectContext);
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(IlacAra).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == IlacAra.States.Successfully && toState == IlacAra.States.Completed)
                PreTransition_Successfully2Completed();
        }

    }
}