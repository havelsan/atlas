
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
    public partial class StockOutTreatmentMaterialOnSaveAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
            #region Body

            /*Guid malzemeObjectID = new Guid(SystemParameter.GetParameterValue("22F_MALZEMEOBJECTID", Guid.Empty.ToString()));
            Guid setMalzemeObjectID = new Guid(SystemParameter.GetParameterValue("SETMATERIALOBJECTID", Guid.Empty.ToString()));
            foreach (BaseTreatmentMaterial treatmentMaterial in Interface.TreatmentMaterials)
            {
                if (treatmentMaterial.Material.ObjectID != malzemeObjectID && treatmentMaterial.Material.ObjectID != setMalzemeObjectID)
                {
                    if (SystemParameter.IsWorkWithOutStock == false && treatmentMaterial.StockActionDetail == null)
                    {
                        Stock stock = treatmentMaterial.Store.GetStock(treatmentMaterial.Material);
                        if (stock.Inheld != null)
                        {
                            if (stock.Inheld > 0 && stock.Inheld >= treatmentMaterial.Amount)
                            {
                                TTObjectContext context = new TTObjectContext(false);
                                StockOut stockOut = new StockOut(context);
                                stockOut.CurrentStateDefID = StockOut.States.New;
                                stockOut.Store = treatmentMaterial.Store;

                                StockActionDetailOut stockActionDetailOut = (StockActionDetailOut)stockOut.StockOutMaterials.AddNew();
                                stockActionDetailOut.Material = treatmentMaterial.Material;
                                stockActionDetailOut.Amount = treatmentMaterial.Amount;
                                stockActionDetailOut.StockLevelType = StockLevelType.NewStockLevel;
                                stockActionDetailOut.Status = StockActionDetailStatusEnum.New;
                                treatmentMaterial.StockActionDetail = stockActionDetailOut;
                                stockOut.Update();
                                stockOut.CurrentStateDefID = StockOut.States.Completed;
                                context.Save();
                            }
                            else
                            {
                                string message = "Yeterli Mevcut yoktur." + " Malzeme : " + treatmentMaterial.Material.Name.ToString() + " " + treatmentMaterial.Material.NATOStockNO.ToString() + " İşlem No :  " + treatmentMaterial.EpisodeAction.ID.ToString();
                                throw new TTException(message);
                            }
                        }

                    }
                }
            }*/


            #endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
            #region CheckBody

            #endregion CheckBody
        }
    }
}