
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

using TTReportTool;
using TTVisual;
namespace TTReportClasses
{
    /// <summary>
    /// Saymanlık Toplam Sarf Raporu (Tarih Aralığında)
    /// </summary>
    public partial class TotalConsumptionAmountForAllStoreReport : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public DateTime? STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public DateTime? ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue("");
            public Guid? CARDDRAWER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public Guid? MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
            public int? ALLCARDDRAWER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
            public int? ALLMATERIAL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue("");
        }

        public partial class PARTAGroup : TTReportGroup
        {
            public TotalConsumptionAmountForAllStoreReport MyParentReport
            {
                get { return (TotalConsumptionAmountForAllStoreReport)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField STARTDATE1 { get {return Header().STARTDATE1;} }
            public TTReportField STARTDATE { get {return Header().STARTDATE;} }
            public TTReportField NewField1 { get {return Header().NewField1;} }
            public TTReportField ENDDATE1 { get {return Header().ENDDATE1;} }
            public TTReportField ENDDATE { get {return Header().ENDDATE;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField CARDDRAWER1 { get {return Header().CARDDRAWER1;} }
            public TTReportField CARDDRAWER { get {return Header().CARDDRAWER;} }
            public TTReportField NewField112 { get {return Header().NewField112;} }
            public TTReportField MATERIAL1 { get {return Header().MATERIAL1;} }
            public TTReportField MATERIAL { get {return Header().MATERIAL;} }
            public TTReportField NewField1211 { get {return Header().NewField1211;} }
            public TTReportField ReportName11 { get {return Header().ReportName11;} }
            public TTReportField MATERIAL2 { get {return Header().MATERIAL2;} }
            public TTReportField MATERIAL12 { get {return Header().MATERIAL12;} }
            public TTReportField MATERIAL121 { get {return Header().MATERIAL121;} }
            public TTReportField MATERIAL122 { get {return Header().MATERIAL122;} }
            public TTReportField PrintDate1 { get {return Footer().PrintDate1;} }
            public TTReportField PageNumber1 { get {return Footer().PageNumber1;} }
            public TTReportField CurrentUser1 { get {return Footer().CurrentUser1;} }
            public TTReportShape NewLine111 { get {return Footer().NewLine111;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public TotalConsumptionAmountForAllStoreReport MyParentReport
                {
                    get { return (TotalConsumptionAmountForAllStoreReport)ParentReport; }
                }
                
                public TTReportField STARTDATE1;
                public TTReportField STARTDATE;
                public TTReportField NewField1;
                public TTReportField ENDDATE1;
                public TTReportField ENDDATE;
                public TTReportField NewField11;
                public TTReportField CARDDRAWER1;
                public TTReportField CARDDRAWER;
                public TTReportField NewField112;
                public TTReportField MATERIAL1;
                public TTReportField MATERIAL;
                public TTReportField NewField1211;
                public TTReportField ReportName11;
                public TTReportField MATERIAL2;
                public TTReportField MATERIAL12;
                public TTReportField MATERIAL121;
                public TTReportField MATERIAL122; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 63;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    STARTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 32, 33, 37, false);
                    STARTDATE1.Name = "STARTDATE1";
                    STARTDATE1.TextFont.Bold = true;
                    STARTDATE1.TextFont.CharSet = 162;
                    STARTDATE1.Value = @"Başlangıç Tarihi";

                    STARTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 32, 69, 37, false);
                    STARTDATE.Name = "STARTDATE";
                    STARTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    STARTDATE.TextFormat = @"Short Date";
                    STARTDATE.TextFont.CharSet = 162;
                    STARTDATE.Value = @"{@STARTDATE@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 32, 35, 37, false);
                    NewField1.Name = "NewField1";
                    NewField1.TextFont.Bold = true;
                    NewField1.TextFont.CharSet = 162;
                    NewField1.Value = @":";

                    ENDDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 38, 33, 43, false);
                    ENDDATE1.Name = "ENDDATE1";
                    ENDDATE1.TextFont.Bold = true;
                    ENDDATE1.TextFont.CharSet = 162;
                    ENDDATE1.Value = @"Bitiş Tarihi";

                    ENDDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 38, 69, 43, false);
                    ENDDATE.Name = "ENDDATE";
                    ENDDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    ENDDATE.TextFormat = @"Short Date";
                    ENDDATE.TextFont.CharSet = 162;
                    ENDDATE.Value = @"{@ENDDATE@}";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 38, 35, 43, false);
                    NewField11.Name = "NewField11";
                    NewField11.TextFont.Bold = true;
                    NewField11.TextFont.CharSet = 162;
                    NewField11.Value = @":";

                    CARDDRAWER1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 44, 33, 49, false);
                    CARDDRAWER1.Name = "CARDDRAWER1";
                    CARDDRAWER1.TextFont.Bold = true;
                    CARDDRAWER1.TextFont.CharSet = 162;
                    CARDDRAWER1.Value = @"Masa ";

                    CARDDRAWER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 44, 200, 49, false);
                    CARDDRAWER.Name = "CARDDRAWER";
                    CARDDRAWER.FieldType = ReportFieldTypeEnum.ftVariable;
                    CARDDRAWER.TextFont.CharSet = 162;
                    CARDDRAWER.Value = @"";

                    NewField112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 44, 35, 49, false);
                    NewField112.Name = "NewField112";
                    NewField112.TextFont.Bold = true;
                    NewField112.TextFont.CharSet = 162;
                    NewField112.Value = @":";

                    MATERIAL1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 50, 33, 55, false);
                    MATERIAL1.Name = "MATERIAL1";
                    MATERIAL1.TextFont.Bold = true;
                    MATERIAL1.TextFont.CharSet = 162;
                    MATERIAL1.Value = @"Malzeme";

                    MATERIAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 36, 50, 200, 55, false);
                    MATERIAL.Name = "MATERIAL";
                    MATERIAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIAL.TextFont.CharSet = 162;
                    MATERIAL.Value = @"";

                    NewField1211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 33, 50, 35, 55, false);
                    NewField1211.Name = "NewField1211";
                    NewField1211.TextFont.Bold = true;
                    NewField1211.TextFont.CharSet = 162;
                    NewField1211.Value = @":";

                    ReportName11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 8, 200, 28, false);
                    ReportName11.Name = "ReportName11";
                    ReportName11.DrawStyle = DrawStyleConstants.vbSolid;
                    ReportName11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ReportName11.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    ReportName11.TextFont.Size = 15;
                    ReportName11.TextFont.Bold = true;
                    ReportName11.TextFont.CharSet = 162;
                    ReportName11.Value = @"SAYMANLIK TOPLAM SARF RAPORU (TARİH ARALIĞINDA)";

                    MATERIAL2 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 58, 13, 63, false);
                    MATERIAL2.Name = "MATERIAL2";
                    MATERIAL2.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL2.TextFont.Bold = true;
                    MATERIAL2.TextFont.CharSet = 162;
                    MATERIAL2.Value = @"Sıra No";

                    MATERIAL12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 58, 38, 63, false);
                    MATERIAL12.Name = "MATERIAL12";
                    MATERIAL12.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL12.TextFont.Bold = true;
                    MATERIAL12.TextFont.CharSet = 162;
                    MATERIAL12.Value = @"Nato Stok Nu.";

                    MATERIAL121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 58, 179, 63, false);
                    MATERIAL121.Name = "MATERIAL121";
                    MATERIAL121.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL121.TextFont.Bold = true;
                    MATERIAL121.TextFont.CharSet = 162;
                    MATERIAL121.Value = @"Malzeme Adı";

                    MATERIAL122 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 58, 200, 63, false);
                    MATERIAL122.Name = "MATERIAL122";
                    MATERIAL122.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIAL122.TextFont.Bold = true;
                    MATERIAL122.TextFont.CharSet = 162;
                    MATERIAL122.Value = @"Sarf Miktarı";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    STARTDATE1.CalcValue = STARTDATE1.Value;
                    STARTDATE.CalcValue = MyParentReport.RuntimeParameters.STARTDATE.ToString();
                    NewField1.CalcValue = NewField1.Value;
                    ENDDATE1.CalcValue = ENDDATE1.Value;
                    ENDDATE.CalcValue = MyParentReport.RuntimeParameters.ENDDATE.ToString();
                    NewField11.CalcValue = NewField11.Value;
                    CARDDRAWER1.CalcValue = CARDDRAWER1.Value;
                    CARDDRAWER.CalcValue = @"";
                    NewField112.CalcValue = NewField112.Value;
                    MATERIAL1.CalcValue = MATERIAL1.Value;
                    MATERIAL.CalcValue = @"";
                    NewField1211.CalcValue = NewField1211.Value;
                    ReportName11.CalcValue = ReportName11.Value;
                    MATERIAL2.CalcValue = MATERIAL2.Value;
                    MATERIAL12.CalcValue = MATERIAL12.Value;
                    MATERIAL121.CalcValue = MATERIAL121.Value;
                    MATERIAL122.CalcValue = MATERIAL122.Value;
                    return new TTReportObject[] { STARTDATE1,STARTDATE,NewField1,ENDDATE1,ENDDATE,NewField11,CARDDRAWER1,CARDDRAWER,NewField112,MATERIAL1,MATERIAL,NewField1211,ReportName11,MATERIAL2,MATERIAL12,MATERIAL121,MATERIAL122};
                }
                public override void RunPreScript()
                {
#region PARTA HEADER_PreScript
                    if (MyParentReport.RuntimeParameters.CARDDRAWER == Guid.Empty)
                        MyParentReport.RuntimeParameters.ALLCARDDRAWER = 1;
                    else
                        MyParentReport.RuntimeParameters.ALLCARDDRAWER = 0;
                   
                    if (MyParentReport.RuntimeParameters.MATERIAL == Guid.Empty)
                        MyParentReport.RuntimeParameters.ALLMATERIAL = 1;
                    else
                        MyParentReport.RuntimeParameters.ALLMATERIAL = 0;
#endregion PARTA HEADER_PreScript
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    if (MyParentReport.RuntimeParameters.CARDDRAWER != Guid.Empty)
            {
                TTObjectContext context = new TTObjectContext(true);
                ResCardDrawer resCardDrawer = (ResCardDrawer)context.GetObject((Guid)MyParentReport.RuntimeParameters.CARDDRAWER, typeof(ResCardDrawer));
                CARDDRAWER.CalcValue = resCardDrawer.Name;
            }
           
            if (MyParentReport.RuntimeParameters.MATERIAL != Guid.Empty)
            {
                TTObjectContext context = new TTObjectContext(true);
                Material material = (Material)context.GetObject((Guid)MyParentReport.RuntimeParameters.MATERIAL, typeof(Material));
                MATERIAL.CalcValue = material.Name;
            }
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public TotalConsumptionAmountForAllStoreReport MyParentReport
                {
                    get { return (TotalConsumptionAmountForAllStoreReport)ParentReport; }
                }
                
                public TTReportField PrintDate1;
                public TTReportField PageNumber1;
                public TTReportField CurrentUser1;
                public TTReportShape NewLine111; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 19;
                    IsAligned = EvetHayirEnum.ehEvet;
                    RepeatEveryPage = EvetHayirEnum.ehEvet;
                    IsAutoSize = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                    PrintDate1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 3, 0, 28, 5, false);
                    PrintDate1.Name = "PrintDate1";
                    PrintDate1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PrintDate1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PrintDate1.TextFont.Size = 8;
                    PrintDate1.TextFont.CharSet = 162;
                    PrintDate1.Value = @"{@printdate@}";

                    PageNumber1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 175, 0, 200, 5, false);
                    PageNumber1.Name = "PageNumber1";
                    PageNumber1.FieldType = ReportFieldTypeEnum.ftVariable;
                    PageNumber1.HorzAlign = HorizontalAlignmentEnum.haRight;
                    PageNumber1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    PageNumber1.TextFont.Size = 8;
                    PageNumber1.TextFont.CharSet = 162;
                    PageNumber1.Value = @"Sayfa Nu.{@pagenumber@}/{@pagecount@}";

                    CurrentUser1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 91, 0, 121, 5, false);
                    CurrentUser1.Name = "CurrentUser1";
                    CurrentUser1.FieldType = ReportFieldTypeEnum.ftExpression;
                    CurrentUser1.CaseFormat = CaseFormatEnum.fcNameSurname;
                    CurrentUser1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    CurrentUser1.VertAlign = VerticalAlignmentEnum.vaMiddle;
                    CurrentUser1.TextFont.Size = 8;
                    CurrentUser1.TextFont.CharSet = 162;
                    CurrentUser1.Value = @"TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : """"";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 2, 0, 200, 0, false);
                    NewLine111.Name = "NewLine111";
                    NewLine111.DrawStyle = DrawStyleConstants.vbSolid;
                    NewLine111.DrawWidth = 2;

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    PrintDate1.CalcValue = DateTime.Now.ToShortDateString();
                    PageNumber1.CalcValue = @"Sayfa Nu." + ParentReport.CurrentPageNumber.ToString() + @"/" + ParentReport.ReportTotalPageCount;
                    CurrentUser1.CalcValue = TTUser.CurrentUser != null ? TTUser.CurrentUser.Name : "";
                    return new TTReportObject[] { PrintDate1,PageNumber1,CurrentUser1};
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public TotalConsumptionAmountForAllStoreReport MyParentReport
            {
                get { return (TotalConsumptionAmountForAllStoreReport)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField NATOSTOCKNO { get {return Body().NATOSTOCKNO;} }
            public TTReportField MATERIALOBJECTID { get {return Body().MATERIALOBJECTID;} }
            public TTReportField TOTALAMOUNT { get {return Body().TOTALAMOUNT;} }
            public TTReportField ORDERNO { get {return Body().ORDERNO;} }
            public MAINGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public MAINGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<StockTransaction.GetTotalConsumptionAmountForAllStore_Class>("GetTotalConsumptionAmountForAllStore", StockTransaction.GetTotalConsumptionAmountForAllStore((int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ALLCARDDRAWER),(int)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(MyParentReport.RuntimeParameters.ALLMATERIAL),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.CARDDRAWER),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.ENDDATE),(Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.MATERIAL),(DateTime)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(MyParentReport.RuntimeParameters.STARTDATE)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _header = null;
                _footer = null;
                _body = new MAINGroupBody(this);
                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class MAINGroupBody : TTReportSection
            {
                public TotalConsumptionAmountForAllStoreReport MyParentReport
                {
                    get { return (TotalConsumptionAmountForAllStoreReport)ParentReport; }
                }
                
                public TTReportField NATOSTOCKNO;
                public TTReportField MATERIALOBJECTID;
                public TTReportField TOTALAMOUNT;
                public TTReportField ORDERNO; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 4;
                    RepeatCount = 0;
                    
                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 13, 0, 38, 5, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.DrawStyle = DrawStyleConstants.vbSolid;
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 9;
                    NATOSTOCKNO.TextFont.CharSet = 162;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    MATERIALOBJECTID = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 38, 0, 179, 5, false);
                    MATERIALOBJECTID.Name = "MATERIALOBJECTID";
                    MATERIALOBJECTID.DrawStyle = DrawStyleConstants.vbSolid;
                    MATERIALOBJECTID.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALOBJECTID.ObjectDefName = "Material";
                    MATERIALOBJECTID.DataMember = "NAME";
                    MATERIALOBJECTID.TextFont.Size = 9;
                    MATERIALOBJECTID.TextFont.CharSet = 162;
                    MATERIALOBJECTID.Value = @"{#MATERIALOBJECTID#}";

                    TOTALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 179, 0, 200, 5, false);
                    TOTALAMOUNT.Name = "TOTALAMOUNT";
                    TOTALAMOUNT.DrawStyle = DrawStyleConstants.vbSolid;
                    TOTALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    TOTALAMOUNT.TextFont.Size = 9;
                    TOTALAMOUNT.TextFont.CharSet = 162;
                    TOTALAMOUNT.Value = @"{#TOTALAMOUNT#}";

                    ORDERNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 2, 0, 13, 5, false);
                    ORDERNO.Name = "ORDERNO";
                    ORDERNO.DrawStyle = DrawStyleConstants.vbSolid;
                    ORDERNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    ORDERNO.TextFont.Size = 9;
                    ORDERNO.TextFont.CharSet = 162;
                    ORDERNO.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    StockTransaction.GetTotalConsumptionAmountForAllStore_Class dataset_GetTotalConsumptionAmountForAllStore = ParentGroup.rsGroup.GetCurrentRecord<StockTransaction.GetTotalConsumptionAmountForAllStore_Class>(0);
                    NATOSTOCKNO.CalcValue = (dataset_GetTotalConsumptionAmountForAllStore != null ? Globals.ToStringCore(dataset_GetTotalConsumptionAmountForAllStore.NATOStockNO) : "");
                    MATERIALOBJECTID.CalcValue = (dataset_GetTotalConsumptionAmountForAllStore != null ? Globals.ToStringCore(dataset_GetTotalConsumptionAmountForAllStore.Materialobjectid) : "");
                    MATERIALOBJECTID.PostFieldValueCalculation();
                    TOTALAMOUNT.CalcValue = (dataset_GetTotalConsumptionAmountForAllStore != null ? Globals.ToStringCore(dataset_GetTotalConsumptionAmountForAllStore.Totalamount) : "");
                    ORDERNO.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { NATOSTOCKNO,MATERIALOBJECTID,TOTALAMOUNT,ORDERNO};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public TotalConsumptionAmountForAllStoreReport()
        {
            PARTA = new PARTAGroup(this,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("STARTDATE", "", "Başlangıç Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("ENDDATE", "", "Bitiş Tarihi", @"", true, true, false, new Guid("e65c4b59-d33b-4539-97f4-27f444de5528"));
            reportParameter = Parameters.Add("CARDDRAWER", "00000000-0000-0000-0000-000000000000", "Masa Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("03e2de85-a832-4760-a20c-e921071b5c37");
            reportParameter = Parameters.Add("MATERIAL", "00000000-0000-0000-0000-000000000000", "Malzeme Seçiniz", @"", false, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
            reportParameter.ListDefID = new Guid("0e92ac5f-6125-4c67-843c-6c8a8b8a0f5c");
            reportParameter = Parameters.Add("ALLCARDDRAWER", "", "AllCarddrawer", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
            reportParameter = Parameters.Add("ALLMATERIAL", "", "AllMaterial", @"", false, false, false, new Guid("e23a630a-eb08-4621-bc97-1fc8fc93ba28"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("STARTDATE"))
                _runtimeParameters.STARTDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["STARTDATE"]);
            if (parameters.ContainsKey("ENDDATE"))
                _runtimeParameters.ENDDATE = (DateTime?)TTObjectDefManager.Instance.DataTypes["DateTime"].ConvertValue(parameters["ENDDATE"]);
            if (parameters.ContainsKey("CARDDRAWER"))
                _runtimeParameters.CARDDRAWER = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["CARDDRAWER"]);
            if (parameters.ContainsKey("MATERIAL"))
                _runtimeParameters.MATERIAL = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["MATERIAL"]);
            if (parameters.ContainsKey("ALLCARDDRAWER"))
                _runtimeParameters.ALLCARDDRAWER = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ALLCARDDRAWER"]);
            if (parameters.ContainsKey("ALLMATERIAL"))
                _runtimeParameters.ALLMATERIAL = (int?)TTObjectDefManager.Instance.DataTypes["Integer"].ConvertValue(parameters["ALLMATERIAL"]);
            Name = "TOTALCONSUMPTIONAMOUNTFORALLSTOREREPORT";
            Caption = "Saymanlık Toplam Sarf Raporu (Tarih Aralığında)";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            UsePrinterMargins = EvetHayirEnum.ehEvet;
            DontUseWatermark = EvetHayirEnum.ehEvet;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaTop;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial Narrow";
            fd.TextFont.Size = 10;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 1;
            return fd;
        }

        protected TTReportRTF SetRTFDefaultProperties()
        {
            TTReportRTF fd = new TTReportRTF();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportHTML SetHTMLDefaultProperties()
        {
            TTReportHTML fd = new TTReportHTML();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbInvisible;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.CanExpand = EvetHayirEnum.ehEvet;
            fd.CanShrink = EvetHayirEnum.ehEvet;
            fd.CanSplit = EvetHayirEnum.ehEvet;
            fd.EvaluateValue = EvetHayirEnum.ehHayir;
            return fd;
        }

        protected TTReportShape SetShapeDefaultProperties()
        {
            TTReportShape fd = new TTReportShape();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;
            return fd;
        }

    }
}