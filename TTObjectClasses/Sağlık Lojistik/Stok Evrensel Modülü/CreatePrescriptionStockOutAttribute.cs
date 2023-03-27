
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
    public partial class CreatePrescriptionStockOutAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if (Interface.GetPrescriptionPaper() != null)
            {
                if (Interface.GetFromResource().Store == null)
                    throw new TTException(Interface.GetFromResource().Name + " bölümünün deposu bulunmamaktadır. Bilgi işleme haber veriniz.");
                Store store = Interface.GetFromResource().Store;
                Material material = null;
                IList presTypeMaterialMatch = ObjectContext.QueryObjects("PRESTYPEMATERIALMATCHDEF", "PRESCRIPTIONTYPE =" + ((int)Interface.GetPrescriptionType()).ToString());
                if (presTypeMaterialMatch.Count > 0)
                    material = ((PresTypeMaterialMatchDef)presTypeMaterialMatch[0]).Material;
                else
                    throw new TTException(TTUtils.CultureService.GetText("M26833", "Seçtiğiniz reçete tipi malzeme ile eşleşmemiş"));
                Prescription prescription = (Prescription)ObjectContext.GetObject(Interface.GetObjectID(), typeof(Prescription));
                IList stockPrescriptionOuts = ObjectContext.QueryObjects("STOCKPRESCRIPTIONOUT", "PRESCRIPTION =" + ConnectionManager.GuidToString(prescription.ObjectID));
                foreach(StockPrescriptionOut presOut in stockPrescriptionOuts)
                    if(presOut.CurrentStateDefID == StockPrescriptionOut.States.Completed)
                        throw new TTException("Bu reçete ile daha önce " + presOut.StockActionID.ToString() + " işlem numarası ile " + presOut.PrescriptionPaper.SerialNo + "-" + presOut.PrescriptionPaper.VolumeNo + " seri numaralı reçete sarf edilmiştir. Önce o işlemi iptal etmeniz gerekmektedir");

                StockPrescriptionOut stockPrescriptionOut = new StockPrescriptionOut(ObjectContext);
                stockPrescriptionOut.CurrentStateDefID = StockPrescriptionOut.States.New;
                stockPrescriptionOut.Store = store;
                stockPrescriptionOut.PrescriptionPaper = Interface.GetPrescriptionPaper();
                stockPrescriptionOut.Prescription = prescription;
                
                StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockPrescriptionOut.StockPrescriptionOutMaterials.AddNew();
                stockActionDetailOut.Material = material;
                stockActionDetailOut.Amount = 1;
                stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
                PrescriptionPaperOutDetail prescriptionPaperOutDetail = new PrescriptionPaperOutDetail(ObjectContext);
                prescriptionPaperOutDetail.PrescriptionPaper = Interface.GetPrescriptionPaper();
                prescriptionPaperOutDetail.StockActionDetailOut = stockActionDetailOut;
                stockPrescriptionOut.Update();
                stockPrescriptionOut.CurrentStateDefID = StockPrescriptionOut.States.Completed;
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}