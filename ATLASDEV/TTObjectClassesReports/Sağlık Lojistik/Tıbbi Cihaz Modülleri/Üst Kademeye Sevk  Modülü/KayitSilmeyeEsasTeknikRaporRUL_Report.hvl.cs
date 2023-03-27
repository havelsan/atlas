
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
    /// Kayıt Silmeye Esas Teknik Rapor ( HEK Raporu )
    /// </summary>
    public partial class KayitSilmeyeEsasTeknikRaporRUL : TTReport
    {
        public class ReportRuntimeParameters 
        {
            public Guid? TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue("00000000-0000-0000-0000-000000000000");
        }

        public partial class PARTCGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
            }

            new public PARTCGroupHeader Header()
            {
                return (PARTCGroupHeader)_header;
            }

            new public PARTCGroupFooter Footer()
            {
                return (PARTCGroupFooter)_footer;
            }

            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1121 { get {return Header().NewField1121;} }
            public TTReportField NewField111151111 { get {return Header().NewField111151111;} }
            public TTReportField NewField1141 { get {return Header().NewField1141;} }
            public TTReportField SENDERSECTION { get {return Header().SENDERSECTION;} }
            public TTReportField NewField1111151111 { get {return Header().NewField1111151111;} }
            public TTReportField MATERIALNAME { get {return Header().MATERIALNAME;} }
            public TTReportField SERIALNO { get {return Header().SERIALNO;} }
            public TTReportField NATOSTOCKNO { get {return Header().NATOSTOCKNO;} }
            public TTReportField AMOUNT1 { get {return Header().AMOUNT1;} }
            public TTReportField AMOUNT111 { get {return Header().AMOUNT111;} }
            public TTReportField REQUESTNO { get {return Header().REQUESTNO;} }
            public TTReportField DISTYPE { get {return Header().DISTYPE;} }
            public TTReportField AMOUNT1111 { get {return Header().AMOUNT1111;} }
            public TTReportField AMOUNT11111 { get {return Header().AMOUNT11111;} }
            public TTReportField AMOUNT111111 { get {return Header().AMOUNT111111;} }
            public TTReportField AMOUNT1111111 { get {return Header().AMOUNT1111111;} }
            public TTReportField AMOUNT11111111 { get {return Header().AMOUNT11111111;} }
            public TTReportField AMOUNT111111111 { get {return Header().AMOUNT111111111;} }
            public TTReportShape NewLine11 { get {return Header().NewLine11;} }
            public TTReportShape NewLine12 { get {return Header().NewLine12;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportField MARK { get {return Header().MARK;} }
            public TTReportField MODEL { get {return Header().MODEL;} }
            public TTReportField SERIALNUMBER { get {return Header().SERIALNUMBER;} }
            public TTReportField NewField1131 { get {return Footer().NewField1131;} }
            public TTReportField NewField141 { get {return Footer().NewField141;} }
            public TTReportField NewField11711 { get {return Footer().NewField11711;} }
            public TTReportField NewField11721 { get {return Footer().NewField11721;} }
            public TTReportShape NewLine111221 { get {return Footer().NewLine111221;} }
            public TTReportField NewField1181 { get {return Footer().NewField1181;} }
            public TTReportField BOLUMAMIRI { get {return Footer().BOLUMAMIRI;} }
            public TTReportField KISIMAMIRI { get {return Footer().KISIMAMIRI;} }
            public TTReportField TEKNIKMUDUR { get {return Footer().TEKNIKMUDUR;} }
            public TTReportField KLTKONT { get {return Footer().KLTKONT;} }
            public TTReportField ONAY { get {return Footer().ONAY;} }
            public TTReportShape NewLine1122111 { get {return Footer().NewLine1122111;} }
            public TTReportField NewField12711 { get {return Footer().NewField12711;} }
            public TTReportField NewField111721 { get {return Footer().NewField111721;} }
            public TTReportShape NewLine1222111 { get {return Footer().NewLine1222111;} }
            public TTReportShape NewLine1322111 { get {return Footer().NewLine1322111;} }
            public TTReportField NewField1127111 { get {return Footer().NewField1127111;} }
            public TTReportShape NewLine11112221 { get {return Footer().NewLine11112221;} }
            public TTReportField NewField11117211 { get {return Footer().NewField11117211;} }
            public TTReportShape NewLine112221111 { get {return Footer().NewLine112221111;} }
            public TTReportField TEKNISYEN1 { get {return Footer().TEKNISYEN1;} }
            public TTReportShape NewLine12112221 { get {return Footer().NewLine12112221;} }
            public TTReportField TEKNISYEN12 { get {return Footer().TEKNISYEN12;} }
            public PARTCGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTCGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReferToUpperLevel.RUL_HEKReportQuery_Class>("RUL_HEKReportQuery", ReferToUpperLevel.RUL_HEKReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTCGroupHeader(this);
                _footer = new PARTCGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTCGroupHeader : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                
                public TTReportField NewField111;
                public TTReportField NewField1121;
                public TTReportField NewField111151111;
                public TTReportField NewField1141;
                public TTReportField SENDERSECTION;
                public TTReportField NewField1111151111;
                public TTReportField MATERIALNAME;
                public TTReportField SERIALNO;
                public TTReportField NATOSTOCKNO;
                public TTReportField AMOUNT1;
                public TTReportField AMOUNT111;
                public TTReportField REQUESTNO;
                public TTReportField DISTYPE;
                public TTReportField AMOUNT1111;
                public TTReportField AMOUNT11111;
                public TTReportField AMOUNT111111;
                public TTReportField AMOUNT1111111;
                public TTReportField AMOUNT11111111;
                public TTReportField AMOUNT111111111;
                public TTReportShape NewLine11;
                public TTReportShape NewLine12;
                public TTReportShape NewLine121;
                public TTReportField MARK;
                public TTReportField MODEL;
                public TTReportField SERIALNUMBER; 
                public PARTCGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 68;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 210, 10, 240, 15, false);
                    NewField111.Name = "NewField111";
                    NewField111.Visible = EvetHayirEnum.ehHayir;
                    NewField111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"HİZMETE ÖZEL";

                    NewField1121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 10, 199, 21, false);
                    NewField1121.Name = "NewField1121";
                    NewField1121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1121.MultiLine = EvetHayirEnum.ehEvet;
                    NewField1121.ExpandTabs = EvetHayirEnum.ehEvet;
                    NewField1121.TextFont.Size = 12;
                    NewField1121.TextFont.Bold = true;
                    NewField1121.Value = @"HASAR VE DURUM TESPİT RAPORU / TEKNİK RAPOR / HEK RAPORU";

                    NewField111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 25, 102, 31, false);
                    NewField111151111.Name = "NewField111151111";
                    NewField111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111151111.TextFont.Size = 10;
                    NewField111151111.TextFont.Bold = true;
                    NewField111151111.Value = @"A. MALZEMENİN AİT OLDUĞU BİRLİK / BAŞKANLIK";

                    NewField1141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 25, 106, 31, false);
                    NewField1141.Name = "NewField1141";
                    NewField1141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1141.TextFont.Size = 10;
                    NewField1141.TextFont.Bold = true;
                    NewField1141.Value = @":";

                    SENDERSECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 25, 199, 31, false);
                    SENDERSECTION.Name = "SENDERSECTION";
                    SENDERSECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SENDERSECTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    SENDERSECTION.MultiLine = EvetHayirEnum.ehEvet;
                    SENDERSECTION.WordBreak = EvetHayirEnum.ehEvet;
                    SENDERSECTION.TextFont.Size = 10;
                    SENDERSECTION.Value = @"{#SENDERMILITARYUNIT#}";

                    NewField1111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 33, 102, 39, false);
                    NewField1111151111.Name = "NewField1111151111";
                    NewField1111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111151111.TextFont.Size = 10;
                    NewField1111151111.TextFont.Bold = true;
                    NewField1111151111.Value = @"B. MALZEMENIN TANIMI :";

                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 57, 145, 68, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.MultiLine = EvetHayirEnum.ehEvet;
                    MATERIALNAME.WordBreak = EvetHayirEnum.ehEvet;
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.Value = @"{#FANAME#}";

                    SERIALNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 57, 176, 68, false);
                    SERIALNO.Name = "SERIALNO";
                    SERIALNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNO.MultiLine = EvetHayirEnum.ehEvet;
                    SERIALNO.WordBreak = EvetHayirEnum.ehEvet;
                    SERIALNO.TextFont.Size = 8;
                    SERIALNO.Value = @"";

                    NATOSTOCKNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 57, 70, 68, false);
                    NATOSTOCKNO.Name = "NATOSTOCKNO";
                    NATOSTOCKNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    NATOSTOCKNO.TextFont.Size = 10;
                    NATOSTOCKNO.Value = @"{#NATOSTOCKNO#}";

                    AMOUNT1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 57, 185, 68, false);
                    AMOUNT1.Name = "AMOUNT1";
                    AMOUNT1.DrawStyle = DrawStyleConstants.vbInvisible;
                    AMOUNT1.FieldType = ReportFieldTypeEnum.ftVariable;
                    AMOUNT1.TextFont.Size = 10;
                    AMOUNT1.Value = @"{#AMOUNT#}";

                    AMOUNT111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 57, 23, 68, false);
                    AMOUNT111.Name = "AMOUNT111";
                    AMOUNT111.TextFont.Size = 10;
                    AMOUNT111.Value = @"1";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 57, 44, 68, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.Value = @"{#REQUESTNO#}";

                    DISTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 57, 200, 68, false);
                    DISTYPE.Name = "DISTYPE";
                    DISTYPE.DrawStyle = DrawStyleConstants.vbInvisible;
                    DISTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTYPE.TextFont.Size = 8;
                    DISTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    AMOUNT1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 43, 23, 57, false);
                    AMOUNT1111.Name = "AMOUNT1111";
                    AMOUNT1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111.TextFont.Size = 10;
                    AMOUNT1111.TextFont.Bold = true;
                    AMOUNT1111.Value = @"S.Nu.";

                    AMOUNT11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 43, 44, 57, false);
                    AMOUNT11111.Name = "AMOUNT11111";
                    AMOUNT11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111.TextFont.Size = 10;
                    AMOUNT11111.TextFont.Bold = true;
                    AMOUNT11111.Value = @"Sipariş Nu.";

                    AMOUNT111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 43, 70, 57, false);
                    AMOUNT111111.Name = "AMOUNT111111";
                    AMOUNT111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111111.TextFont.Size = 10;
                    AMOUNT111111.TextFont.Bold = true;
                    AMOUNT111111.Value = @"Stok Nu.";

                    AMOUNT1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 43, 145, 57, false);
                    AMOUNT1111111.Name = "AMOUNT1111111";
                    AMOUNT1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT1111111.TextFont.Size = 10;
                    AMOUNT1111111.TextFont.Bold = true;
                    AMOUNT1111111.Value = @"Malzemenin Cinsi";

                    AMOUNT11111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 43, 176, 57, false);
                    AMOUNT11111111.Name = "AMOUNT11111111";
                    AMOUNT11111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT11111111.MultiLine = EvetHayirEnum.ehEvet;
                    AMOUNT11111111.TextFont.Size = 10;
                    AMOUNT11111111.TextFont.Bold = true;
                    AMOUNT11111111.Value = @"Marka
Model
Seri Nu.";

                    AMOUNT111111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 43, 200, 57, false);
                    AMOUNT111111111.Name = "AMOUNT111111111";
                    AMOUNT111111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    AMOUNT111111111.TextFont.Size = 10;
                    AMOUNT111111111.TextFont.Bold = true;
                    AMOUNT111111111.Value = @"Miktarı";

                    NewLine11 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 68, 200, 68, false);
                    NewLine11.Name = "NewLine11";

                    NewLine12 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 57, 200, 68, false);
                    NewLine12.Name = "NewLine12";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 57, 176, 68, false);
                    NewLine121.Name = "NewLine121";

                    MARK = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 212, 26, 237, 31, false);
                    MARK.Name = "MARK";
                    MARK.Visible = EvetHayirEnum.ehHayir;
                    MARK.DrawStyle = DrawStyleConstants.vbInvisible;
                    MARK.FieldType = ReportFieldTypeEnum.ftVariable;
                    MARK.VertAlign = VerticalAlignmentEnum.vaTop;
                    MARK.TextFont.Name = "Arial Narrow";
                    MARK.TextFont.Size = 10;
                    MARK.TextFont.CharSet = 1;
                    MARK.Value = @"{#MARK#}";

                    MODEL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 238, 26, 263, 31, false);
                    MODEL.Name = "MODEL";
                    MODEL.Visible = EvetHayirEnum.ehHayir;
                    MODEL.DrawStyle = DrawStyleConstants.vbInvisible;
                    MODEL.FieldType = ReportFieldTypeEnum.ftVariable;
                    MODEL.VertAlign = VerticalAlignmentEnum.vaTop;
                    MODEL.TextFont.Name = "Arial Narrow";
                    MODEL.TextFont.Size = 10;
                    MODEL.TextFont.CharSet = 1;
                    MODEL.Value = @"{#MODEL#}";

                    SERIALNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 264, 26, 289, 31, false);
                    SERIALNUMBER.Name = "SERIALNUMBER";
                    SERIALNUMBER.Visible = EvetHayirEnum.ehHayir;
                    SERIALNUMBER.DrawStyle = DrawStyleConstants.vbInvisible;
                    SERIALNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    SERIALNUMBER.VertAlign = VerticalAlignmentEnum.vaTop;
                    SERIALNUMBER.TextFont.Name = "Arial Narrow";
                    SERIALNUMBER.TextFont.Size = 10;
                    SERIALNUMBER.TextFont.CharSet = 1;
                    SERIALNUMBER.Value = @"{#SERIALNUMBER#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.RUL_HEKReportQuery_Class dataset_RUL_HEKReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.RUL_HEKReportQuery_Class>(0);
                    NewField111.CalcValue = NewField111.Value;
                    NewField1121.CalcValue = NewField1121.Value;
                    NewField111151111.CalcValue = NewField111151111.Value;
                    NewField1141.CalcValue = NewField1141.Value;
                    SENDERSECTION.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.Sendermilitaryunit) : "");
                    NewField1111151111.CalcValue = NewField1111151111.Value;
                    MATERIALNAME.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.Faname) : "");
                    SERIALNO.CalcValue = @"";
                    NATOSTOCKNO.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.NATOStockNO) : "");
                    AMOUNT1.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.Amount) : "");
                    AMOUNT111.CalcValue = AMOUNT111.Value;
                    REQUESTNO.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.RequestNo) : "");
                    DISTYPE.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.DistributionType) : "");
                    DISTYPE.PostFieldValueCalculation();
                    AMOUNT1111.CalcValue = AMOUNT1111.Value;
                    AMOUNT11111.CalcValue = AMOUNT11111.Value;
                    AMOUNT111111.CalcValue = AMOUNT111111.Value;
                    AMOUNT1111111.CalcValue = AMOUNT1111111.Value;
                    AMOUNT11111111.CalcValue = AMOUNT11111111.Value;
                    AMOUNT111111111.CalcValue = AMOUNT111111111.Value;
                    MARK.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.Mark) : "");
                    MODEL.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.Model) : "");
                    SERIALNUMBER.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.SerialNumber) : "");
                    return new TTReportObject[] { NewField111,NewField1121,NewField111151111,NewField1141,SENDERSECTION,NewField1111151111,MATERIALNAME,SERIALNO,NATOSTOCKNO,AMOUNT1,AMOUNT111,REQUESTNO,DISTYPE,AMOUNT1111,AMOUNT11111,AMOUNT111111,AMOUNT1111111,AMOUNT11111111,AMOUNT111111111,MARK,MODEL,SERIALNUMBER};
                }

                public override void RunScript()
                {
#region PARTC HEADER_Script
                    SERIALNO.CalcValue = MARK.CalcValue +"\r\n"+MODEL.CalcValue+"\r\n" + SERIALNUMBER.CalcValue ;
#endregion PARTC HEADER_Script
                }
            }
            public partial class PARTCGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                
                public TTReportField NewField1131;
                public TTReportField NewField141;
                public TTReportField NewField11711;
                public TTReportField NewField11721;
                public TTReportShape NewLine111221;
                public TTReportField NewField1181;
                public TTReportField BOLUMAMIRI;
                public TTReportField KISIMAMIRI;
                public TTReportField TEKNIKMUDUR;
                public TTReportField KLTKONT;
                public TTReportField ONAY;
                public TTReportShape NewLine1122111;
                public TTReportField NewField12711;
                public TTReportField NewField111721;
                public TTReportShape NewLine1222111;
                public TTReportShape NewLine1322111;
                public TTReportField NewField1127111;
                public TTReportShape NewLine11112221;
                public TTReportField NewField11117211;
                public TTReportShape NewLine112221111;
                public TTReportField TEKNISYEN1;
                public TTReportShape NewLine12112221;
                public TTReportField TEKNISYEN12; 
                public PARTCGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 128;
                    RepeatCount = 0;
                    
                    NewField1131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 214, 32, 244, 37, false);
                    NewField1131.Name = "NewField1131";
                    NewField1131.Visible = EvetHayirEnum.ehHayir;
                    NewField1131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1131.TextFont.Size = 10;
                    NewField1131.TextFont.Bold = true;
                    NewField1131.Value = @"HİZMETE ÖZEL";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 7, 203, 13, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @"RAPORU DÜZENLEYENLER";

                    NewField11711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 135, 27, 158, 33, false);
                    NewField11711.Name = "NewField11711";
                    NewField11711.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11711.TextFont.Size = 10;
                    NewField11711.TextFont.Bold = true;
                    NewField11711.Value = @"KISIM AMİRİ";

                    NewField11721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 170, 27, 203, 33, false);
                    NewField11721.Name = "NewField11721";
                    NewField11721.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11721.TextFont.Size = 10;
                    NewField11721.TextFont.Bold = true;
                    NewField11721.Value = @"TEKNİK MÜDÜR";

                    NewLine111221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 55, 33, 88, 33, false);
                    NewLine111221.Name = "NewLine111221";
                    NewLine111221.Visible = EvetHayirEnum.ehHayir;

                    NewField1181 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 81, 203, 87, false);
                    NewField1181.Name = "NewField1181";
                    NewField1181.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1181.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1181.TextFont.Size = 10;
                    NewField1181.TextFont.Bold = true;
                    NewField1181.Value = @"ONAY";

                    BOLUMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 55, 45, 88, 77, false);
                    BOLUMAMIRI.Name = "BOLUMAMIRI";
                    BOLUMAMIRI.DrawStyle = DrawStyleConstants.vbInvisible;
                    BOLUMAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    BOLUMAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    BOLUMAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    BOLUMAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    BOLUMAMIRI.TextFont.Size = 10;
                    BOLUMAMIRI.Value = @"";

                    KISIMAMIRI = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 131, 45, 163, 77, false);
                    KISIMAMIRI.Name = "KISIMAMIRI";
                    KISIMAMIRI.DrawStyle = DrawStyleConstants.vbInvisible;
                    KISIMAMIRI.FieldType = ReportFieldTypeEnum.ftVariable;
                    KISIMAMIRI.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KISIMAMIRI.MultiLine = EvetHayirEnum.ehEvet;
                    KISIMAMIRI.WordBreak = EvetHayirEnum.ehEvet;
                    KISIMAMIRI.TextFont.Size = 10;
                    KISIMAMIRI.Value = @"";

                    TEKNIKMUDUR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 45, 203, 77, false);
                    TEKNIKMUDUR.Name = "TEKNIKMUDUR";
                    TEKNIKMUDUR.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNIKMUDUR.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNIKMUDUR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNIKMUDUR.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNIKMUDUR.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNIKMUDUR.TextFont.Size = 10;
                    TEKNIKMUDUR.Value = @"";

                    KLTKONT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 45, 48, 77, false);
                    KLTKONT.Name = "KLTKONT";
                    KLTKONT.DrawStyle = DrawStyleConstants.vbInvisible;
                    KLTKONT.FieldType = ReportFieldTypeEnum.ftVariable;
                    KLTKONT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    KLTKONT.MultiLine = EvetHayirEnum.ehEvet;
                    KLTKONT.WordBreak = EvetHayirEnum.ehEvet;
                    KLTKONT.TextFont.Size = 10;
                    KLTKONT.Value = @"";

                    ONAY = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 77, 97, 142, 118, false);
                    ONAY.Name = "ONAY";
                    ONAY.DrawStyle = DrawStyleConstants.vbInvisible;
                    ONAY.FieldType = ReportFieldTypeEnum.ftVariable;
                    ONAY.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ONAY.MultiLine = EvetHayirEnum.ehEvet;
                    ONAY.WordBreak = EvetHayirEnum.ehEvet;
                    ONAY.TextFont.Size = 10;
                    ONAY.Value = @"";

                    NewLine1122111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 33, 50, 33, false);
                    NewLine1122111.Name = "NewLine1122111";
                    NewLine1122111.Visible = EvetHayirEnum.ehHayir;

                    NewField12711 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 27, 48, 33, false);
                    NewField12711.Name = "NewField12711";
                    NewField12711.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12711.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12711.TextFont.Size = 10;
                    NewField12711.TextFont.Bold = true;
                    NewField12711.Value = @"KLT.KONT.ASTSB.";

                    NewField111721 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 56, 27, 86, 33, false);
                    NewField111721.Name = "NewField111721";
                    NewField111721.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111721.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111721.TextFont.Size = 10;
                    NewField111721.TextFont.Bold = true;
                    NewField111721.Value = @"BÖLÜM AMİRİ";

                    NewLine1222111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 132, 33, 160, 33, false);
                    NewLine1222111.Name = "NewLine1222111";
                    NewLine1222111.Visible = EvetHayirEnum.ehHayir;

                    NewLine1322111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 170, 33, 203, 33, false);
                    NewLine1322111.Name = "NewLine1322111";
                    NewLine1322111.Visible = EvetHayirEnum.ehHayir;

                    NewField1127111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 21, 15, 81, 21, false);
                    NewField1127111.Name = "NewField1127111";
                    NewField1127111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1127111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1127111.TextFont.Size = 10;
                    NewField1127111.TextFont.Bold = true;
                    NewField1127111.Value = @"MUA.KONT.VE KLT.YNT.BL.A.";

                    NewLine11112221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 14, 22, 88, 22, false);
                    NewLine11112221.Name = "NewLine11112221";
                    NewLine11112221.Visible = EvetHayirEnum.ehHayir;

                    NewField11117211 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 118, 15, 178, 21, false);
                    NewField11117211.Name = "NewField11117211";
                    NewField11117211.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11117211.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11117211.TextFont.Size = 10;
                    NewField11117211.TextFont.Bold = true;
                    NewField11117211.Value = @"TEKNİK MÜDÜRLÜK";

                    NewLine112221111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 95, 22, 203, 22, false);
                    NewLine112221111.Name = "NewLine112221111";
                    NewLine112221111.Visible = EvetHayirEnum.ehHayir;

                    TEKNISYEN1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 100, 27, 123, 33, false);
                    TEKNISYEN1.Name = "TEKNISYEN1";
                    TEKNISYEN1.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNISYEN1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNISYEN1.TextFont.Size = 10;
                    TEKNISYEN1.TextFont.Bold = true;
                    TEKNISYEN1.Value = @"TEKNİSYEN";

                    NewLine12112221 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 97, 33, 125, 33, false);
                    NewLine12112221.Name = "NewLine12112221";
                    NewLine12112221.Visible = EvetHayirEnum.ehHayir;

                    TEKNISYEN12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 95, 45, 127, 77, false);
                    TEKNISYEN12.Name = "TEKNISYEN12";
                    TEKNISYEN12.DrawStyle = DrawStyleConstants.vbInvisible;
                    TEKNISYEN12.FieldType = ReportFieldTypeEnum.ftVariable;
                    TEKNISYEN12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    TEKNISYEN12.MultiLine = EvetHayirEnum.ehEvet;
                    TEKNISYEN12.WordBreak = EvetHayirEnum.ehEvet;
                    TEKNISYEN12.TextFont.Size = 10;
                    TEKNISYEN12.Value = @"";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.RUL_HEKReportQuery_Class dataset_RUL_HEKReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.RUL_HEKReportQuery_Class>(0);
                    NewField1131.CalcValue = NewField1131.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField11711.CalcValue = NewField11711.Value;
                    NewField11721.CalcValue = NewField11721.Value;
                    NewField1181.CalcValue = NewField1181.Value;
                    BOLUMAMIRI.CalcValue = @"";
                    KISIMAMIRI.CalcValue = @"";
                    TEKNIKMUDUR.CalcValue = @"";
                    KLTKONT.CalcValue = @"";
                    ONAY.CalcValue = @"";
                    NewField12711.CalcValue = NewField12711.Value;
                    NewField111721.CalcValue = NewField111721.Value;
                    NewField1127111.CalcValue = NewField1127111.Value;
                    NewField11117211.CalcValue = NewField11117211.Value;
                    TEKNISYEN1.CalcValue = TEKNISYEN1.Value;
                    TEKNISYEN12.CalcValue = @"";
                    return new TTReportObject[] { NewField1131,NewField141,NewField11711,NewField11721,NewField1181,BOLUMAMIRI,KISIMAMIRI,TEKNIKMUDUR,KLTKONT,ONAY,NewField12711,NewField111721,NewField1127111,NewField11117211,TEKNISYEN1,TEKNISYEN12};
                }

                public override void RunScript()
                {
#region PARTC FOOTER_Script
                    ReferToUpperLevel  referToUpperLevel = (ReferToUpperLevel)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ReferToUpperLevel));
            
            bool tecnicalMember = false;
            string chefString = string.Empty;
            string techMember1 = string.Empty;
            string techMember2 = string.Empty;
            string sMember = string.Empty;
            string sMember2 = string.Empty;
            string sMember3 = string.Empty;
            string approvalMember = string.Empty;
            
            if(referToUpperLevel.RULHekCommisionMembers.Count > 0)
            {
                foreach(RULHekCommisionMember hekCommision in   referToUpperLevel.RULHekCommisionMembers)
                {
                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
                    {
                        chefString += hekCommision.ResUser.Name +"\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            chefString += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            chefString += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        chefString += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.TEKNISYEN12.CalcValue = chefString;
                        
                    }
                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.TechnicalHead)
                    {
                        if (tecnicalMember == false)
                        {
                            techMember1 += hekCommision.ResUser.Name + "\r\n";
                            if (hekCommision.ResUser.MilitaryClass != null)
                                techMember1 += hekCommision.ResUser.MilitaryClass.ShortName;
                            if (hekCommision.ResUser.Rank != null)
                                techMember1 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                            techMember1 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                            this.TEKNIKMUDUR.CalcValue = techMember1;
                            tecnicalMember = true;
                        }
                        else
                        {
                            techMember2 += hekCommision.ResUser.Name + "\r\n";
                            if (hekCommision.ResUser.MilitaryClass != null)
                                techMember2 += hekCommision.ResUser.MilitaryClass.ShortName;
                            if (hekCommision.ResUser.Rank != null)
                                techMember2 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                            techMember2 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                            this.TEKNIKMUDUR.CalcValue = techMember2;
                        }
                    }
                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.SectionHead)
                    {
                        sMember += hekCommision.ResUser.Name + "\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            sMember += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            sMember += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        sMember += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.BOLUMAMIRI.CalcValue = sMember;
                        
                    }

                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.SectionChief)
                    {
                        sMember2 += hekCommision.ResUser.Name + "\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            sMember2 += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            sMember2 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        sMember2 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.KISIMAMIRI.CalcValue = sMember2;

                    }
                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.Assay)
                    {
                        sMember3 += hekCommision.ResUser.Name + "\r\n";
                        if (hekCommision.ResUser.MilitaryClass != null)
                            sMember3 += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            sMember3 += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        sMember3 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
                        this.KLTKONT.CalcValue = sMember3;

                    }

                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.Approval)
                    {
                        approvalMember += hekCommision.ResUser.Name + "\r\n";
                        if(hekCommision.ResUser.Title.HasValue)
                        {
                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
                            approvalMember += dataType.EnumValueDefs[(int)hekCommision.ResUser.Title.Value].DisplayText;
                        }
                        if (hekCommision.ResUser.MilitaryClass != null)
                            approvalMember += hekCommision.ResUser.MilitaryClass.ShortName;
                        if (hekCommision.ResUser.Rank != null)
                            approvalMember += hekCommision.ResUser.Rank.ShortName + "\r\n";
                        approvalMember += "(" + hekCommision.ResUser.EmploymentRecordID + ")\r\n";
                        if (hekCommision.ResUser.Work != string.Empty)
                        {
                            approvalMember += hekCommision.ResUser.Work;
                        }
                        ONAY.CalcValue = approvalMember;
                    }
                }
            }
#endregion PARTC FOOTER_Script
                }
            }

        }

        public PARTCGroup PARTC;

        public partial class FooterGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
            }

            new public FooterGroupHeader Header()
            {
                return (FooterGroupHeader)_header;
            }

            new public FooterGroupFooter Footer()
            {
                return (FooterGroupFooter)_footer;
            }

            public TTReportField ITEMNAME { get {return Header().ITEMNAME;} }
            public TTReportField ITEMAMOUNT { get {return Header().ITEMAMOUNT;} }
            public TTReportField MUHTEVİYATTIR { get {return Header().MUHTEVİYATTIR;} }
            public TTReportField text1 { get {return Header().text1;} }
            public TTReportField text11 { get {return Header().text11;} }
            public TTReportField text12 { get {return Header().text12;} }
            public TTReportField DISTRIBUTIONTYPE { get {return Header().DISTRIBUTIONTYPE;} }
            public TTReportShape NewLine111 { get {return Header().NewLine111;} }
            public TTReportShape NewLine121 { get {return Header().NewLine121;} }
            public TTReportShape NewLine1111 { get {return Header().NewLine1111;} }
            public FooterGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public FooterGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class>("HEKReportToItemEquipmentsReportQuery", ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new FooterGroupHeader(this);
                _footer = new FooterGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class FooterGroupHeader : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                
                public TTReportField ITEMNAME;
                public TTReportField ITEMAMOUNT;
                public TTReportField MUHTEVİYATTIR;
                public TTReportField text1;
                public TTReportField text11;
                public TTReportField text12;
                public TTReportField DISTRIBUTIONTYPE;
                public TTReportShape NewLine111;
                public TTReportShape NewLine121;
                public TTReportShape NewLine1111; 
                public FooterGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 10;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    ITEMNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 70, 0, 145, 10, false);
                    ITEMNAME.Name = "ITEMNAME";
                    ITEMNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMNAME.TextFont.Name = "Arial Narrow";
                    ITEMNAME.TextFont.Size = 10;
                    ITEMNAME.TextFont.CharSet = 1;
                    ITEMNAME.Value = @"{#ITEMNAME#}";

                    ITEMAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 176, 0, 185, 10, false);
                    ITEMAMOUNT.Name = "ITEMAMOUNT";
                    ITEMAMOUNT.DrawStyle = DrawStyleConstants.vbInvisible;
                    ITEMAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    ITEMAMOUNT.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    ITEMAMOUNT.TextFont.Name = "Arial Narrow";
                    ITEMAMOUNT.TextFont.Size = 10;
                    ITEMAMOUNT.TextFont.CharSet = 1;
                    ITEMAMOUNT.Value = @"{#ITEMAMOUNT#}";

                    MUHTEVİYATTIR = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 145, 0, 176, 10, false);
                    MUHTEVİYATTIR.Name = "MUHTEVİYATTIR";
                    MUHTEVİYATTIR.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    MUHTEVİYATTIR.TextFont.Name = "Arial Narrow";
                    MUHTEVİYATTIR.TextFont.Size = 10;
                    MUHTEVİYATTIR.TextFont.CharSet = 1;
                    MUHTEVİYATTIR.Value = @"MUHTEVİYATTIR";

                    text1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 44, 0, 70, 10, false);
                    text1.Name = "text1";
                    text1.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    text1.TextFont.Name = "Arial Narrow";
                    text1.TextFont.Size = 10;
                    text1.TextFont.CharSet = 1;
                    text1.Value = @"";

                    text11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 0, 23, 10, false);
                    text11.Name = "text11";
                    text11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    text11.TextFont.Name = "Arial Narrow";
                    text11.TextFont.Size = 10;
                    text11.TextFont.CharSet = 1;
                    text11.Value = @"";

                    text12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 23, 0, 44, 10, false);
                    text12.Name = "text12";
                    text12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    text12.TextFont.Name = "Arial Narrow";
                    text12.TextFont.Size = 10;
                    text12.TextFont.CharSet = 1;
                    text12.Value = @"";

                    DISTRIBUTIONTYPE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 200, 10, false);
                    DISTRIBUTIONTYPE.Name = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.DrawStyle = DrawStyleConstants.vbInvisible;
                    DISTRIBUTIONTYPE.FieldType = ReportFieldTypeEnum.ftVariable;
                    DISTRIBUTIONTYPE.ObjectDefName = "DistributionTypeDefinition";
                    DISTRIBUTIONTYPE.DataMember = "DISTRIBUTIONTYPE";
                    DISTRIBUTIONTYPE.TextFont.Name = "Arial Narrow";
                    DISTRIBUTIONTYPE.TextFont.Size = 8;
                    DISTRIBUTIONTYPE.Value = @"{#DISTRIBUTIONTYPE#}";

                    NewLine111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 10, 200, 10, false);
                    NewLine111.Name = "NewLine111";

                    NewLine121 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 200, 0, 200, 10, false);
                    NewLine121.Name = "NewLine121";

                    NewLine1111 = ReportObjects.AddNewShape(MyParentReport.SetShapeDefaultProperties(), ShapeTypeEnum.shtLine, 176, 0, 200, 0, false);
                    NewLine1111.Name = "NewLine1111";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class dataset_HEKReportToItemEquipmentsReportQuery = ParentGroup.rsGroup.GetCurrentRecord<ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class>(0);
                    ITEMNAME.CalcValue = (dataset_HEKReportToItemEquipmentsReportQuery != null ? Globals.ToStringCore(dataset_HEKReportToItemEquipmentsReportQuery.ItemName) : "");
                    ITEMAMOUNT.CalcValue = (dataset_HEKReportToItemEquipmentsReportQuery != null ? Globals.ToStringCore(dataset_HEKReportToItemEquipmentsReportQuery.Itemamount) : "");
                    MUHTEVİYATTIR.CalcValue = MUHTEVİYATTIR.Value;
                    text1.CalcValue = text1.Value;
                    text11.CalcValue = text11.Value;
                    text12.CalcValue = text12.Value;
                    DISTRIBUTIONTYPE.CalcValue = (dataset_HEKReportToItemEquipmentsReportQuery != null ? Globals.ToStringCore(dataset_HEKReportToItemEquipmentsReportQuery.DistributionType) : "");
                    DISTRIBUTIONTYPE.PostFieldValueCalculation();
                    return new TTReportObject[] { ITEMNAME,ITEMAMOUNT,MUHTEVİYATTIR,text1,text11,text12,DISTRIBUTIONTYPE};
                }

                public override void RunScript()
                {
#region FOOTER HEADER_Script
                    //            SERIALNO.CalcValue = MARK.CalcValue +"\r\n"+MODEL.CalcValue+"\r\n" + SERIALNUMBER.CalcValue ;
#endregion FOOTER HEADER_Script
                }
            }
            public partial class FooterGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                 
                public FooterGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 1;
                    IsVisible = EvetHayirEnum.ehHayir;
                    RepeatCount = 0;
                    
                }
                

                public override void RunScript()
                {
#region FOOTER FOOTER_Script
                    //            ReferToUpperLevel  referToUpperLevel = (ReferToUpperLevel)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ReferToUpperLevel));
//            
//            bool tecnicalMember = false;
//            string chefString = string.Empty;
//            string techMember1 = string.Empty;
//            string techMember2 = string.Empty;
//            string sMember = string.Empty;
//            string sMember2 = string.Empty;
//            string sMember3 = string.Empty;
//            string approvalMember = string.Empty;
//            
//            if(referToUpperLevel.RULHekCommisionMembers.Count > 0)
//            {
//                foreach(RULHekCommisionMember hekCommision in   referToUpperLevel.RULHekCommisionMembers)
//                {
//                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.TechnicalMember)
//                    {
//                        chefString += hekCommision.ResUser.Name +"\r\n";
//                        if (hekCommision.ResUser.MilitaryClass != null)
//                            chefString += hekCommision.ResUser.MilitaryClass.ShortName;
//                        if (hekCommision.ResUser.Rank != null)
//                            chefString += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                        chefString += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
//                        this.TEKNISYEN12.CalcValue = chefString;
//                        
//                    }
//                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.TechnicalHead)
//                    {
//                        if (tecnicalMember == false)
//                        {
//                            techMember1 += hekCommision.ResUser.Name + "\r\n";
//                            if (hekCommision.ResUser.MilitaryClass != null)
//                                techMember1 += hekCommision.ResUser.MilitaryClass.ShortName;
//                            if (hekCommision.ResUser.Rank != null)
//                                techMember1 += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                            techMember1 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
//                            this.TEKNIKMUDUR.CalcValue = techMember1;
//                            tecnicalMember = true;
//                        }
//                        else
//                        {
//                            techMember2 += hekCommision.ResUser.Name + "\r\n";
//                            if (hekCommision.ResUser.MilitaryClass != null)
//                                techMember2 += hekCommision.ResUser.MilitaryClass.ShortName;
//                            if (hekCommision.ResUser.Rank != null)
//                                techMember2 += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                            techMember2 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
//                            this.TEKNIKMUDUR.CalcValue = techMember2;
//                        }
//                    }
//                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.SectionHead)
//                    {
//                        sMember += hekCommision.ResUser.Name + "\r\n";
//                        if (hekCommision.ResUser.MilitaryClass != null)
//                            sMember += hekCommision.ResUser.MilitaryClass.ShortName;
//                        if (hekCommision.ResUser.Rank != null)
//                            sMember += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                        sMember += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
//                        this.BOLUMAMIRI.CalcValue = sMember;
//                        
//                    }
//
//                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.SectionChief)
//                    {
//                        sMember2 += hekCommision.ResUser.Name + "\r\n";
//                        if (hekCommision.ResUser.MilitaryClass != null)
//                            sMember2 += hekCommision.ResUser.MilitaryClass.ShortName;
//                        if (hekCommision.ResUser.Rank != null)
//                            sMember2 += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                        sMember2 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
//                        this.KISIMAMIRI.CalcValue = sMember2;
//
//                    }
//                    if (hekCommision.MemberDuty == CommisionMemberDutyEnum.Assay)
//                    {
//                        sMember3 += hekCommision.ResUser.Name + "\r\n";
//                        if (hekCommision.ResUser.MilitaryClass != null)
//                            sMember3 += hekCommision.ResUser.MilitaryClass.ShortName;
//                        if (hekCommision.ResUser.Rank != null)
//                            sMember3 += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                        sMember3 += "(" + hekCommision.ResUser.EmploymentRecordID + ")";
//                        this.KLTKONT.CalcValue = sMember3;
//
//                    }
//
//                    if(hekCommision.MemberDuty == CommisionMemberDutyEnum.Approval)
//                    {
//                        approvalMember += hekCommision.ResUser.Name + "\r\n";
//                        if(hekCommision.ResUser.Title.HasValue)
//                        {
//                            TTDataType dataType = TTObjectDefManager.Instance.DataTypes[typeof(UserTitleEnum).Name];
//                            approvalMember += dataType.EnumValueDefs[(int)hekCommision.ResUser.Title.Value].DisplayText;
//                        }
//                        if (hekCommision.ResUser.MilitaryClass != null)
//                            approvalMember += hekCommision.ResUser.MilitaryClass.ShortName;
//                        if (hekCommision.ResUser.Rank != null)
//                            approvalMember += hekCommision.ResUser.Rank.ShortName + "\r\n";
//                        approvalMember += "(" + hekCommision.ResUser.EmploymentRecordID + ")\r\n";
//                        if (hekCommision.ResUser.Work != string.Empty)
//                        {
//                            approvalMember += hekCommision.ResUser.Work;
//                        }
//                        ONAY.CalcValue = approvalMember;
//                    }
//                }
//            }
#endregion FOOTER FOOTER_Script
                }
            }

        }

        public FooterGroup Footer;

        public partial class PARTAGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
            }

            new public PARTAGroupHeader Header()
            {
                return (PARTAGroupHeader)_header;
            }

            new public PARTAGroupFooter Footer()
            {
                return (PARTAGroupFooter)_footer;
            }

            public TTReportField NewField1111151111 { get {return Header().NewField1111151111;} }
            public TTReportField NewField11511 { get {return Header().NewField11511;} }
            public TTReportField NewField3 { get {return Header().NewField3;} }
            public TTReportField NewField111511 { get {return Header().NewField111511;} }
            public TTReportField FAULTDESCRIPTION { get {return Header().FAULTDESCRIPTION;} }
            public TTReportField REQUESTDATE { get {return Header().REQUESTDATE;} }
            public TTReportField NewField13 { get {return Header().NewField13;} }
            public TTReportField NewField1115111 { get {return Header().NewField1115111;} }
            public TTReportField NewField131 { get {return Header().NewField131;} }
            public TTReportField NewField4 { get {return Header().NewField4;} }
            public TTReportField NewField111512 { get {return Header().NewField111512;} }
            public TTReportField NewField14 { get {return Header().NewField14;} }
            public TTReportField MATERIALPRICE { get {return Header().MATERIALPRICE;} }
            public TTReportField NewField1215111 { get {return Header().NewField1215111;} }
            public TTReportField NewField141 { get {return Header().NewField141;} }
            public TTReportField NewField11 { get {return Header().NewField11;} }
            public TTReportField NewField111 { get {return Header().NewField111;} }
            public TTReportField NewField1111 { get {return Header().NewField1111;} }
            public TTReportField NewField11111 { get {return Header().NewField11111;} }
            public TTReportField NewField111111 { get {return Header().NewField111111;} }
            public TTReportField NewField1111111 { get {return Header().NewField1111111;} }
            public TTReportRTF REPAIRNOTESRTF { get {return Header().REPAIRNOTESRTF;} }
            public TTReportField HEKDESCRIPTION { get {return Header().HEKDESCRIPTION;} }
            public TTReportField REPORTDATE { get {return Footer().REPORTDATE;} }
            public TTReportField NewField11512 { get {return Footer().NewField11512;} }
            public TTReportField NewField1115112 { get {return Footer().NewField1115112;} }
            public TTReportField NewField5 { get {return Footer().NewField5;} }
            public TTReportField NewField12 { get {return Footer().NewField12;} }
            public TTReportField NewField1161 { get {return Footer().NewField1161;} }
            public TTReportField NewField121511 { get {return Footer().NewField121511;} }
            public TTReportField NewField15 { get {return Footer().NewField15;} }
            public TTReportField NewField1115121 { get {return Footer().NewField1115121;} }
            public TTReportField NewField152 { get {return Footer().NewField152;} }
            public TTReportField NewField121512 { get {return Footer().NewField121512;} }
            public TTReportField NewField121513 { get {return Footer().NewField121513;} }
            public TTReportField NewField1251 { get {return Footer().NewField1251;} }
            public TTReportField NewField1315121 { get {return Footer().NewField1315121;} }
            public TTReportField NewField11521 { get {return Footer().NewField11521;} }
            public TTReportField NewField12115111 { get {return Footer().NewField12115111;} }
            public TTReportField NewField121 { get {return Footer().NewField121;} }
            public TTReportField REQUESTDATE1 { get {return Footer().REQUESTDATE1;} }
            public TTReportField LABORTOTALCOST { get {return Footer().LABORTOTALCOST;} }
            public TTReportField REPAIRTOTALCOST { get {return Footer().REPAIRTOTALCOST;} }
            public TTReportField SECTION { get {return Footer().SECTION;} }
            public TTReportField HEKREPORTNO { get {return Footer().HEKREPORTNO;} }
            public TTReportField REQUESTNO { get {return Footer().REQUESTNO;} }
            public TTReportRTF DESCRIPTIONRTF { get {return Footer().DESCRIPTIONRTF;} }
            public TTReportField HEKDESCRIPTION1 { get {return Footer().HEKDESCRIPTION1;} }
            public TTReportField NEEDTOTAL { get {return Footer().NEEDTOTAL;} }
            public TTReportField NewField1 { get {return Footer().NewField1;} }
            public PARTAGroup(TTReport parentReport, string name) : base(parentReport, name)
            {
                onConstruct();
            }
            public PARTAGroup(TTReportGroup parentGroup, string name) : base(parentGroup, name)
            {
                onConstruct();
            }

             
            protected override TTReportNqlDataSet GetReportNqlDataSet()
            {
                TTBaseReportNqlData[] list = new TTBaseReportNqlData[1];
                list[0] = new TTReportNqlData<ReferToUpperLevel.RUL_HEKReportQuery_Class>("RUL_HEKReportQuery", ReferToUpperLevel.RUL_HEKReportQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
                return new TTReportNqlDataSet(ParentGroup, list);
            }

            private void onConstruct()
            {
                _body = null;
                _header = new PARTAGroupHeader(this);
                _footer = new PARTAGroupFooter(this);

                DataSourceType = DataSourceTypeEnum.dstSelfRS;
            }

            public partial class PARTAGroupHeader : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                
                public TTReportField NewField1111151111;
                public TTReportField NewField11511;
                public TTReportField NewField3;
                public TTReportField NewField111511;
                public TTReportField FAULTDESCRIPTION;
                public TTReportField REQUESTDATE;
                public TTReportField NewField13;
                public TTReportField NewField1115111;
                public TTReportField NewField131;
                public TTReportField NewField4;
                public TTReportField NewField111512;
                public TTReportField NewField14;
                public TTReportField MATERIALPRICE;
                public TTReportField NewField1215111;
                public TTReportField NewField141;
                public TTReportField NewField11;
                public TTReportField NewField111;
                public TTReportField NewField1111;
                public TTReportField NewField11111;
                public TTReportField NewField111111;
                public TTReportField NewField1111111;
                public TTReportRTF REPAIRNOTESRTF;
                public TTReportField HEKDESCRIPTION; 
                public PARTAGroupHeader(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stHeader;
                    
                    Height = 91;
                    KeepTogether = EvetHayirEnum.ehEvet;
                    RepeatCount = 0;
                    
                    NewField1111151111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 1, 102, 7, false);
                    NewField1111151111.Name = "NewField1111151111";
                    NewField1111151111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1111151111.TextFont.Size = 10;
                    NewField1111151111.TextFont.Bold = true;
                    NewField1111151111.Value = @"C. HASAR / ARIZA BİLGİLERİ :";

                    NewField11511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 8, 102, 14, false);
                    NewField11511.Name = "NewField11511";
                    NewField11511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11511.TextFont.Size = 10;
                    NewField11511.TextFont.Bold = true;
                    NewField11511.Value = @"1. HASARIN / ARIZANIN TANIMI";

                    NewField3 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 8, 106, 14, false);
                    NewField3.Name = "NewField3";
                    NewField3.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField3.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField3.TextFont.Size = 10;
                    NewField3.TextFont.Bold = true;
                    NewField3.Value = @":";

                    NewField111511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 30, 102, 36, false);
                    NewField111511.Name = "NewField111511";
                    NewField111511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111511.TextFont.Size = 10;
                    NewField111511.TextFont.Bold = true;
                    NewField111511.Value = @"2. HASARIN / ARIZANIN NEDENLERİ";

                    FAULTDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 8, 203, 29, false);
                    FAULTDESCRIPTION.Name = "FAULTDESCRIPTION";
                    FAULTDESCRIPTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    FAULTDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    FAULTDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    FAULTDESCRIPTION.MultiLine = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.WordBreak = EvetHayirEnum.ehEvet;
                    FAULTDESCRIPTION.TextFont.Name = "Arial Narrow";
                    FAULTDESCRIPTION.TextFont.Size = 10;
                    FAULTDESCRIPTION.TextFont.CharSet = 1;
                    FAULTDESCRIPTION.Value = @"{#PARTC.BREAKDOWN#}";

                    REQUESTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 107, 54, 132, 60, false);
                    REQUESTDATE.Name = "REQUESTDATE";
                    REQUESTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE.TextFont.Name = "Arial Narrow";
                    REQUESTDATE.TextFont.Size = 10;
                    REQUESTDATE.TextFont.CharSet = 1;
                    REQUESTDATE.Value = @"{#PARTC.ARRIVALDATE#}";

                    NewField13 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 30, 106, 36, false);
                    NewField13.Name = "NewField13";
                    NewField13.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField13.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField13.TextFont.Size = 10;
                    NewField13.TextFont.Bold = true;
                    NewField13.Value = @":";

                    NewField1115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 54, 102, 60, false);
                    NewField1115111.Name = "NewField1115111";
                    NewField1115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115111.TextFont.Size = 10;
                    NewField1115111.TextFont.Bold = true;
                    NewField1115111.Value = @"3. HASARIN / ARIZANIN TARİHİ";

                    NewField131 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 54, 106, 60, false);
                    NewField131.Name = "NewField131";
                    NewField131.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField131.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField131.TextFont.Size = 10;
                    NewField131.TextFont.Bold = true;
                    NewField131.Value = @":";

                    NewField4 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 12, 61, 102, 67, false);
                    NewField4.Name = "NewField4";
                    NewField4.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField4.TextFont.Size = 10;
                    NewField4.TextFont.Bold = true;
                    NewField4.Value = @"Ç. ONARIMA ESAS BİLGİLER :";

                    NewField111512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 69, 102, 75, false);
                    NewField111512.Name = "NewField111512";
                    NewField111512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField111512.TextFont.Size = 10;
                    NewField111512.TextFont.Bold = true;
                    NewField111512.Value = @"1. MALZEMENİN RAPOR TARİHİNDEKİ DEĞERİ";

                    NewField14 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 102, 69, 106, 75, false);
                    NewField14.Name = "NewField14";
                    NewField14.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField14.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField14.TextFont.Size = 10;
                    NewField14.TextFont.Bold = true;
                    NewField14.Value = @":";

                    MATERIALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 106, 69, 131, 75, false);
                    MATERIALPRICE.Name = "MATERIALPRICE";
                    MATERIALPRICE.DrawStyle = DrawStyleConstants.vbInvisible;
                    MATERIALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALPRICE.TextFont.Size = 10;
                    MATERIALPRICE.TextFont.CharSet = 1;
                    MATERIALPRICE.Value = @"{#PARTC.MATERIALPRICE#}";

                    NewField1215111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 17, 78, 124, 84, false);
                    NewField1215111.Name = "NewField1215111";
                    NewField1215111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1215111.TextFont.Size = 10;
                    NewField1215111.TextFont.Bold = true;
                    NewField1215111.Value = @"2. ONARIM İÇİN İHTİYAÇ DUYULAN MALZEMELER VE DEĞERİ";

                    NewField141 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 78, 128, 84, false);
                    NewField141.Name = "NewField141";
                    NewField141.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField141.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField141.TextFont.Size = 10;
                    NewField141.TextFont.Bold = true;
                    NewField141.Value = @":";

                    NewField11 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 86, 26, 91, false);
                    NewField11.Name = "NewField11";
                    NewField11.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11.TextFont.Name = "Arial Narrow";
                    NewField11.TextFont.Size = 10;
                    NewField11.TextFont.Bold = true;
                    NewField11.Value = @"S.Nu.";

                    NewField111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 86, 124, 91, false);
                    NewField111.Name = "NewField111";
                    NewField111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111.TextFont.Name = "Arial Narrow";
                    NewField111.TextFont.Size = 10;
                    NewField111.TextFont.Bold = true;
                    NewField111.Value = @"Malzemenin Cinsi";

                    NewField1111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 86, 149, 91, false);
                    NewField1111.Name = "NewField1111";
                    NewField1111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111.TextFont.Name = "Arial Narrow";
                    NewField1111.TextFont.Size = 10;
                    NewField1111.TextFont.Bold = true;
                    NewField1111.Value = @"Parça Nu.";

                    NewField11111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 86, 167, 91, false);
                    NewField11111.Name = "NewField11111";
                    NewField11111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11111.TextFont.Name = "Arial Narrow";
                    NewField11111.TextFont.Size = 10;
                    NewField11111.TextFont.Bold = true;
                    NewField11111.Value = @"Miktarı";

                    NewField111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 86, 185, 91, false);
                    NewField111111.Name = "NewField111111";
                    NewField111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField111111.TextFont.Name = "Arial Narrow";
                    NewField111111.TextFont.Size = 10;
                    NewField111111.TextFont.Bold = true;
                    NewField111111.Value = @"B. Fiyatı";

                    NewField1111111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 86, 203, 91, false);
                    NewField1111111.Name = "NewField1111111";
                    NewField1111111.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1111111.TextFont.Name = "Arial Narrow";
                    NewField1111111.TextFont.Size = 10;
                    NewField1111111.TextFont.Bold = true;
                    NewField1111111.Value = @"Tutarı";

                    REPAIRNOTESRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 107, 30, 203, 53, false);
                    REPAIRNOTESRTF.Name = "REPAIRNOTESRTF";
                    REPAIRNOTESRTF.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRNOTESRTF.Value = @"";

                    HEKDESCRIPTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 9, 248, 14, false);
                    HEKDESCRIPTION.Name = "HEKDESCRIPTION";
                    HEKDESCRIPTION.Visible = EvetHayirEnum.ehHayir;
                    HEKDESCRIPTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    HEKDESCRIPTION.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKDESCRIPTION.VertAlign = VerticalAlignmentEnum.vaTop;
                    HEKDESCRIPTION.TextFont.Name = "Arial Narrow";
                    HEKDESCRIPTION.TextFont.Size = 10;
                    HEKDESCRIPTION.TextFont.CharSet = 1;
                    HEKDESCRIPTION.Value = @"{#PARTC.HEKDESCRIPTION#}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.RUL_HEKReportQuery_Class dataset_RUL_HEKReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<ReferToUpperLevel.RUL_HEKReportQuery_Class>(0);
                    NewField1111151111.CalcValue = NewField1111151111.Value;
                    NewField11511.CalcValue = NewField11511.Value;
                    NewField3.CalcValue = NewField3.Value;
                    NewField111511.CalcValue = NewField111511.Value;
                    FAULTDESCRIPTION.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.BreakDown) : "");
                    REQUESTDATE.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.ArrivalDate) : "");
                    NewField13.CalcValue = NewField13.Value;
                    NewField1115111.CalcValue = NewField1115111.Value;
                    NewField131.CalcValue = NewField131.Value;
                    NewField4.CalcValue = NewField4.Value;
                    NewField111512.CalcValue = NewField111512.Value;
                    NewField14.CalcValue = NewField14.Value;
                    MATERIALPRICE.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.MaterialPrice) : "");
                    NewField1215111.CalcValue = NewField1215111.Value;
                    NewField141.CalcValue = NewField141.Value;
                    NewField11.CalcValue = NewField11.Value;
                    NewField111.CalcValue = NewField111.Value;
                    NewField1111.CalcValue = NewField1111.Value;
                    NewField11111.CalcValue = NewField11111.Value;
                    NewField111111.CalcValue = NewField111111.Value;
                    NewField1111111.CalcValue = NewField1111111.Value;
                    REPAIRNOTESRTF.CalcValue = REPAIRNOTESRTF.Value;
                    HEKDESCRIPTION.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.HEKDescription) : "");
                    return new TTReportObject[] { NewField1111151111,NewField11511,NewField3,NewField111511,FAULTDESCRIPTION,REQUESTDATE,NewField13,NewField1115111,NewField131,NewField4,NewField111512,NewField14,MATERIALPRICE,NewField1215111,NewField141,NewField11,NewField111,NewField1111,NewField11111,NewField111111,NewField1111111,REPAIRNOTESRTF,HEKDESCRIPTION};
                }

                public override void RunScript()
                {
#region PARTA HEADER_Script
                    string faultDesc = "Cihazın yapılan incelemesinde; "+ HEKDESCRIPTION.CalcValue +" tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.";
            REPAIRNOTESRTF.CalcValue = TTObjectClasses.Common.GetRTFOfTextString (faultDesc);
#endregion PARTA HEADER_Script
                }
            }
            public partial class PARTAGroupFooter : TTReportSection
            {
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                
                public TTReportField REPORTDATE;
                public TTReportField NewField11512;
                public TTReportField NewField1115112;
                public TTReportField NewField5;
                public TTReportField NewField12;
                public TTReportField NewField1161;
                public TTReportField NewField121511;
                public TTReportField NewField15;
                public TTReportField NewField1115121;
                public TTReportField NewField152;
                public TTReportField NewField121512;
                public TTReportField NewField121513;
                public TTReportField NewField1251;
                public TTReportField NewField1315121;
                public TTReportField NewField11521;
                public TTReportField NewField12115111;
                public TTReportField NewField121;
                public TTReportField REQUESTDATE1;
                public TTReportField LABORTOTALCOST;
                public TTReportField REPAIRTOTALCOST;
                public TTReportField SECTION;
                public TTReportField HEKREPORTNO;
                public TTReportField REQUESTNO;
                public TTReportRTF DESCRIPTIONRTF;
                public TTReportField HEKDESCRIPTION1;
                public TTReportField NEEDTOTAL;
                public TTReportField NewField1; 
                public PARTAGroupFooter(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stFooter;

                    Height = 105;
                    RepeatCount = 0;
                    
                    REPORTDATE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 90, 134, 96, false);
                    REPORTDATE.Name = "REPORTDATE";
                    REPORTDATE.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPORTDATE.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPORTDATE.TextFormat = @"dd/MM/yyyy";
                    REPORTDATE.TextFont.Size = 10;
                    REPORTDATE.Value = @"{@printdate@}";

                    NewField11512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 2, 105, 8, false);
                    NewField11512.Name = "NewField11512";
                    NewField11512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11512.TextFont.Size = 10;
                    NewField11512.TextFont.Bold = true;
                    NewField11512.Value = @"3. İŞCİLİK MALİYETİ";

                    NewField1115112 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 90, 105, 96, false);
                    NewField1115112.Name = "NewField1115112";
                    NewField1115112.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115112.TextFont.Size = 10;
                    NewField1115112.TextFont.Bold = true;
                    NewField1115112.Value = @"3. RAPORUN VERİLDİĞİ TARİH";

                    NewField5 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 2, 109, 8, false);
                    NewField5.Name = "NewField5";
                    NewField5.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField5.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField5.TextFont.Size = 10;
                    NewField5.TextFont.Bold = true;
                    NewField5.Value = @":";

                    NewField12 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 90, 109, 96, false);
                    NewField12.Name = "NewField12";
                    NewField12.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField12.TextFont.Size = 10;
                    NewField12.TextFont.Bold = true;
                    NewField12.Value = @":";

                    NewField1161 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 98, 138, 104, false);
                    NewField1161.Name = "NewField1161";
                    NewField1161.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1161.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1161.TextFont.Size = 10;
                    NewField1161.TextFont.Bold = true;
                    NewField1161.Value = @"/";

                    NewField121511 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 10, 105, 16, false);
                    NewField121511.Name = "NewField121511";
                    NewField121511.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121511.TextFont.Size = 10;
                    NewField121511.TextFont.Bold = true;
                    NewField121511.Value = @"4. ONARIM TOPLAM MALİYETİ";

                    NewField15 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 10, 109, 16, false);
                    NewField15.Name = "NewField15";
                    NewField15.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField15.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField15.TextFont.Size = 10;
                    NewField15.TextFont.Bold = true;
                    NewField15.Value = @":";

                    NewField1115121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 18, 105, 24, false);
                    NewField1115121.Name = "NewField1115121";
                    NewField1115121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1115121.TextFont.Size = 10;
                    NewField1115121.TextFont.Bold = true;
                    NewField1115121.Value = @"5. ONARIMIN YAPILIP YAPILAMAYACAĞI";

                    NewField152 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 18, 109, 24, false);
                    NewField152.Name = "NewField152";
                    NewField152.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField152.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField152.TextFont.Size = 10;
                    NewField152.TextFont.Bold = true;
                    NewField152.Value = @":";

                    NewField121512 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 66, 100, 72, false);
                    NewField121512.Name = "NewField121512";
                    NewField121512.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121512.TextFont.Size = 10;
                    NewField121512.TextFont.Bold = true;
                    NewField121512.Value = @"D. RAPORA AİT BİLGİLER :";

                    NewField121513 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 74, 105, 80, false);
                    NewField121513.Name = "NewField121513";
                    NewField121513.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121513.TextFont.Size = 10;
                    NewField121513.TextFont.Bold = true;
                    NewField121513.Value = @"1. RAPORUN TANZİM EDİLDİĞİ BİRLİK";

                    NewField1251 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 74, 109, 80, false);
                    NewField1251.Name = "NewField1251";
                    NewField1251.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1251.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField1251.TextFont.Size = 10;
                    NewField1251.TextFont.Bold = true;
                    NewField1251.Value = @":";

                    NewField1315121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 82, 105, 88, false);
                    NewField1315121.Name = "NewField1315121";
                    NewField1315121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1315121.TextFont.Size = 10;
                    NewField1315121.TextFont.Bold = true;
                    NewField1315121.Value = @"2. RAPOR NUMARASI";

                    NewField11521 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 82, 109, 88, false);
                    NewField11521.Name = "NewField11521";
                    NewField11521.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField11521.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField11521.TextFont.Size = 10;
                    NewField11521.TextFont.Bold = true;
                    NewField11521.Value = @":";

                    NewField12115111 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 20, 98, 105, 104, false);
                    NewField12115111.Name = "NewField12115111";
                    NewField12115111.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField12115111.TextFont.Size = 10;
                    NewField12115111.TextFont.Bold = true;
                    NewField12115111.Value = @"4. BAKIM KADEMESİ KAYIT VE TARİHİ";

                    NewField121 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 105, 98, 109, 104, false);
                    NewField121.Name = "NewField121";
                    NewField121.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField121.HorzAlign = HorizontalAlignmentEnum.haCenter;
                    NewField121.TextFont.Size = 10;
                    NewField121.TextFont.Bold = true;
                    NewField121.Value = @":";

                    REQUESTDATE1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 138, 98, 163, 104, false);
                    REQUESTDATE1.Name = "REQUESTDATE1";
                    REQUESTDATE1.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTDATE1.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTDATE1.TextFormat = @"dd/MM/yyyy";
                    REQUESTDATE1.TextFont.Name = "Arial Narrow";
                    REQUESTDATE1.TextFont.Size = 10;
                    REQUESTDATE1.TextFont.CharSet = 1;
                    REQUESTDATE1.Value = @"{#PARTC.REQUESTDATE#}";

                    LABORTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 2, 134, 8, false);
                    LABORTOTALCOST.Name = "LABORTOTALCOST";
                    LABORTOTALCOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    LABORTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    LABORTOTALCOST.TextFont.Name = "Arial Narrow";
                    LABORTOTALCOST.TextFont.Size = 10;
                    LABORTOTALCOST.TextFont.CharSet = 1;
                    LABORTOTALCOST.Value = @"{#PARTC.TOTALWORKLOADPRICE#}";

                    REPAIRTOTALCOST = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 10, 134, 16, false);
                    REPAIRTOTALCOST.Name = "REPAIRTOTALCOST";
                    REPAIRTOTALCOST.DrawStyle = DrawStyleConstants.vbInvisible;
                    REPAIRTOTALCOST.FieldType = ReportFieldTypeEnum.ftVariable;
                    REPAIRTOTALCOST.VertAlign = VerticalAlignmentEnum.vaTop;
                    REPAIRTOTALCOST.TextFont.Name = "Arial Narrow";
                    REPAIRTOTALCOST.TextFont.Size = 10;
                    REPAIRTOTALCOST.TextFont.CharSet = 1;
                    REPAIRTOTALCOST.Value = @"";

                    SECTION = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 74, 203, 80, false);
                    SECTION.Name = "SECTION";
                    SECTION.DrawStyle = DrawStyleConstants.vbInvisible;
                    SECTION.TextFont.Name = "Arial Narrow";
                    SECTION.TextFont.Size = 10;
                    SECTION.TextFont.CharSet = 1;
                    SECTION.Value = @"XXXXXX Shh.İkm. ve Bkm.Mrk.K.lığı XXXXXX/XXXXXX";

                    HEKREPORTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 82, 134, 88, false);
                    HEKREPORTNO.Name = "HEKREPORTNO";
                    HEKREPORTNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    HEKREPORTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKREPORTNO.VertAlign = VerticalAlignmentEnum.vaTop;
                    HEKREPORTNO.TextFont.Name = "Arial Narrow";
                    HEKREPORTNO.TextFont.Size = 10;
                    HEKREPORTNO.TextFont.CharSet = 1;
                    HEKREPORTNO.Value = @"{#PARTC.REQUESTNO#}";

                    REQUESTNO = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 109, 98, 134, 104, false);
                    REQUESTNO.Name = "REQUESTNO";
                    REQUESTNO.DrawStyle = DrawStyleConstants.vbInvisible;
                    REQUESTNO.FieldType = ReportFieldTypeEnum.ftVariable;
                    REQUESTNO.TextFont.Name = "Arial Narrow";
                    REQUESTNO.TextFont.Size = 10;
                    REQUESTNO.TextFont.CharSet = 1;
                    REQUESTNO.Value = @"{#PARTC.REQUESTNO#}";

                    DESCRIPTIONRTF = ReportObjects.AddNewRTF(MyParentReport.SetRTFDefaultProperties(), 20, 26, 203, 64, false);
                    DESCRIPTIONRTF.Name = "DESCRIPTIONRTF";
                    DESCRIPTIONRTF.DrawStyle = DrawStyleConstants.vbInvisible;
                    DESCRIPTIONRTF.Value = @"";

                    HEKDESCRIPTION1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 223, 7, 249, 13, false);
                    HEKDESCRIPTION1.Name = "HEKDESCRIPTION1";
                    HEKDESCRIPTION1.Visible = EvetHayirEnum.ehHayir;
                    HEKDESCRIPTION1.DrawStyle = DrawStyleConstants.vbInvisible;
                    HEKDESCRIPTION1.FieldType = ReportFieldTypeEnum.ftVariable;
                    HEKDESCRIPTION1.VertAlign = VerticalAlignmentEnum.vaTop;
                    HEKDESCRIPTION1.TextFont.Name = "Arial Narrow";
                    HEKDESCRIPTION1.TextFont.Size = 10;
                    HEKDESCRIPTION1.TextFont.CharSet = 1;
                    HEKDESCRIPTION1.Value = @"{#PARTC.HEKDESCRIPTION#}";

                    NEEDTOTAL = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 227, 22, 252, 27, false);
                    NEEDTOTAL.Name = "NEEDTOTAL";
                    NEEDTOTAL.Visible = EvetHayirEnum.ehHayir;
                    NEEDTOTAL.DrawStyle = DrawStyleConstants.vbInvisible;
                    NEEDTOTAL.FieldType = ReportFieldTypeEnum.ftVariable;
                    NEEDTOTAL.VertAlign = VerticalAlignmentEnum.vaTop;
                    NEEDTOTAL.TextFont.Name = "Arial Narrow";
                    NEEDTOTAL.TextFont.Size = 10;
                    NEEDTOTAL.TextFont.CharSet = 1;
                    NEEDTOTAL.Value = @"{@sumof(MATERIALTOTALPRICE)@}";

                    NewField1 = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 134, 82, 159, 88, false);
                    NewField1.Name = "NewField1";
                    NewField1.DrawStyle = DrawStyleConstants.vbInvisible;
                    NewField1.VertAlign = VerticalAlignmentEnum.vaTop;
                    NewField1.TextFont.Name = "Arial Narrow";
                    NewField1.TextFont.Size = 10;
                    NewField1.TextFont.CharSet = 1;
                    NewField1.Value = @"-İMH";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    ReferToUpperLevel.RUL_HEKReportQuery_Class dataset_RUL_HEKReportQuery = MyParentReport.PARTC.rsGroup.GetCurrentRecord<ReferToUpperLevel.RUL_HEKReportQuery_Class>(0);
                    REPORTDATE.CalcValue = DateTime.Now.ToShortDateString();
                    NewField11512.CalcValue = NewField11512.Value;
                    NewField1115112.CalcValue = NewField1115112.Value;
                    NewField5.CalcValue = NewField5.Value;
                    NewField12.CalcValue = NewField12.Value;
                    NewField1161.CalcValue = NewField1161.Value;
                    NewField121511.CalcValue = NewField121511.Value;
                    NewField15.CalcValue = NewField15.Value;
                    NewField1115121.CalcValue = NewField1115121.Value;
                    NewField152.CalcValue = NewField152.Value;
                    NewField121512.CalcValue = NewField121512.Value;
                    NewField121513.CalcValue = NewField121513.Value;
                    NewField1251.CalcValue = NewField1251.Value;
                    NewField1315121.CalcValue = NewField1315121.Value;
                    NewField11521.CalcValue = NewField11521.Value;
                    NewField12115111.CalcValue = NewField12115111.Value;
                    NewField121.CalcValue = NewField121.Value;
                    REQUESTDATE1.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.RequestDate) : "");
                    LABORTOTALCOST.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.TotalWorkLoadPrice) : "");
                    REPAIRTOTALCOST.CalcValue = @"";
                    SECTION.CalcValue = SECTION.Value;
                    HEKREPORTNO.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.RequestNo) : "");
                    REQUESTNO.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.RequestNo) : "");
                    DESCRIPTIONRTF.CalcValue = DESCRIPTIONRTF.Value;
                    HEKDESCRIPTION1.CalcValue = (dataset_RUL_HEKReportQuery != null ? Globals.ToStringCore(dataset_RUL_HEKReportQuery.HEKDescription) : "");
                    NEEDTOTAL.CalcValue = ParentGroup.FieldSums["MATERIALTOTALPRICE"].Value.ToString();;
                    NewField1.CalcValue = NewField1.Value;
                    return new TTReportObject[] { REPORTDATE,NewField11512,NewField1115112,NewField5,NewField12,NewField1161,NewField121511,NewField15,NewField1115121,NewField152,NewField121512,NewField121513,NewField1251,NewField1315121,NewField11521,NewField12115111,NewField121,REQUESTDATE1,LABORTOTALCOST,REPAIRTOTALCOST,SECTION,HEKREPORTNO,REQUESTNO,DESCRIPTIONRTF,HEKDESCRIPTION1,NEEDTOTAL,NewField1};
                }

                public override void RunScript()
                {
#region PARTA FOOTER_Script
                    ReferToUpperLevel  referToUpperLevel = (ReferToUpperLevel)MyParentReport.ReportObjectContext.GetObject(MyParentReport.RuntimeParameters.TTOBJECTID.Value, typeof(ReferToUpperLevel));
            
            string description;
            string hekNedeni="";
            string aciklama= "    Yukarıda marka modeli belirtilen cihaz, uzun süreli kullanımdan dolayı kullanıcı hatası olmaksızın normal aşınma ve yıpranma sonucu nitelik ve özelliklerini kaybetmiştir.\n Cihazın yapılan incelemesinde; ";
            string aciklama2= " tespit edilmiştir. Cihazın mevcut durumu nedeniyle onarılmasının mümkün olmayacağı değerlendirilmiştir.\n   Cihazın eski model ve eski teknoloji ürünü olması nedeniyle yenileştirilmesi mümkün değildir.";
            string aciklama3="\n    Yukarıda belirtilen nedenlerden dolayı; MSY 59-2(A) XXXXXX Taşınır Mal Yönergesinin 5.ncü bölüm 1.inci maddesi I-";

            foreach (RULHEKReason rULHEKReason in referToUpperLevel.RULHEKReasons)
            {
                if (rULHEKReason.Check == true)
                {
                    hekNedeni = rULHEKReason.CousesOfTheHekDefinition.Counter + " fıkrasında belirtildiği üzere " + rULHEKReason.CousesOfTheHekDefinition.Description;
                    break;
                }
            }
            
            string aciklama4= " -dan dolayı kayıt silme işlemine tabi tutulmasının uygun olacağı değerlendirilmiştir.";

            description= aciklama + HEKDESCRIPTION1.CalcValue + aciklama2 + aciklama3  + hekNedeni + aciklama4;
            
            DESCRIPTIONRTF.CalcValue = TTObjectClasses.Common.GetRTFOfTextString(description);
            
            double totalCost = 0 ;
            if(string.IsNullOrEmpty(LABORTOTALCOST.CalcValue) == false)
                totalCost = Convert.ToDouble(LABORTOTALCOST.CalcValue) + Convert.ToDouble(NEEDTOTAL.CalcValue);
            else
                totalCost = Convert.ToDouble(NEEDTOTAL.CalcValue) ;
            
            REPAIRTOTALCOST.CalcValue =  totalCost.ToString();
#endregion PARTA FOOTER_Script
                }
            }

        }

        public PARTAGroup PARTA;

        public partial class MAINGroup : TTReportGroup
        {
            public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
            {
                get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
            }

            new public MAINGroupBody Body()
            {
                return (MAINGroupBody)_body;
            }
            public TTReportField MATERIALNAME { get {return Body().MATERIALNAME;} }
            public TTReportField PARTNUMBER { get {return Body().PARTNUMBER;} }
            public TTReportField MATERIALAMOUNT { get {return Body().MATERIALAMOUNT;} }
            public TTReportField MATERIALUNITPRICE { get {return Body().MATERIALUNITPRICE;} }
            public TTReportField MATERIALTOTALPRICE { get {return Body().MATERIALTOTALPRICE;} }
            public TTReportField SNU { get {return Body().SNU;} }
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
                list[0] = new TTReportNqlData<NeededMaterials.RULNeededMaterialQuery_Class>("RULNeededMaterialQuery", NeededMaterials.RULNeededMaterialQuery((Guid)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(MyParentReport.RuntimeParameters.TTOBJECTID)));
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
                public KayitSilmeyeEsasTeknikRaporRUL MyParentReport
                {
                    get { return (KayitSilmeyeEsasTeknikRaporRUL)ParentReport; }
                }
                
                public TTReportField MATERIALNAME;
                public TTReportField PARTNUMBER;
                public TTReportField MATERIALAMOUNT;
                public TTReportField MATERIALUNITPRICE;
                public TTReportField MATERIALTOTALPRICE;
                public TTReportField SNU; 
                public MAINGroupBody(TTReportGroup parentGroup) : base(parentGroup)
                {
                    SectionType = SectionTypeEnum.stBody;

                    Height = 5;
                    RepeatCount = 0;
                    
                    MATERIALNAME = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 26, 0, 124, 5, false);
                    MATERIALNAME.Name = "MATERIALNAME";
                    MATERIALNAME.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALNAME.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALNAME.TextFont.Name = "Arial Narrow";
                    MATERIALNAME.TextFont.Size = 10;
                    MATERIALNAME.TextFont.CharSet = 1;
                    MATERIALNAME.Value = @"{#MATERIALNAME#}";

                    PARTNUMBER = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 124, 0, 149, 5, false);
                    PARTNUMBER.Name = "PARTNUMBER";
                    PARTNUMBER.FieldType = ReportFieldTypeEnum.ftVariable;
                    PARTNUMBER.VertAlign = VerticalAlignmentEnum.vaTop;
                    PARTNUMBER.TextFont.Name = "Arial Narrow";
                    PARTNUMBER.TextFont.Size = 10;
                    PARTNUMBER.TextFont.CharSet = 1;
                    PARTNUMBER.Value = @"{#PARTNUMBER#}";

                    MATERIALAMOUNT = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 149, 0, 167, 5, false);
                    MATERIALAMOUNT.Name = "MATERIALAMOUNT";
                    MATERIALAMOUNT.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALAMOUNT.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALAMOUNT.TextFont.Name = "Arial Narrow";
                    MATERIALAMOUNT.TextFont.Size = 10;
                    MATERIALAMOUNT.TextFont.CharSet = 1;
                    MATERIALAMOUNT.Value = @"{#MATERIALAMOUNT#}";

                    MATERIALUNITPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 167, 0, 185, 5, false);
                    MATERIALUNITPRICE.Name = "MATERIALUNITPRICE";
                    MATERIALUNITPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALUNITPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALUNITPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALUNITPRICE.TextFont.Size = 10;
                    MATERIALUNITPRICE.TextFont.CharSet = 1;
                    MATERIALUNITPRICE.Value = @"{#MATERIALUNITPRICE#}";

                    MATERIALTOTALPRICE = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 185, 0, 203, 5, false);
                    MATERIALTOTALPRICE.Name = "MATERIALTOTALPRICE";
                    MATERIALTOTALPRICE.FieldType = ReportFieldTypeEnum.ftVariable;
                    MATERIALTOTALPRICE.VertAlign = VerticalAlignmentEnum.vaTop;
                    MATERIALTOTALPRICE.TextFont.Name = "Arial Narrow";
                    MATERIALTOTALPRICE.TextFont.Size = 10;
                    MATERIALTOTALPRICE.TextFont.CharSet = 1;
                    MATERIALTOTALPRICE.Value = @"{#MATERIALTOTALPRICE#}";

                    SNU = ReportObjects.AddNewField(MyParentReport.SetFieldDefaultProperties(), 15, 0, 26, 5, false);
                    SNU.Name = "SNU";
                    SNU.FieldType = ReportFieldTypeEnum.ftVariable;
                    SNU.VertAlign = VerticalAlignmentEnum.vaTop;
                    SNU.TextFont.Name = "Arial Narrow";
                    SNU.TextFont.Size = 10;
                    SNU.TextFont.CharSet = 1;
                    SNU.Value = @"{@counter@}";

                }
                
                    
                override public TTReportObject[] GetCalculatedFields()
                {
                    NeededMaterials.RULNeededMaterialQuery_Class dataset_RULNeededMaterialQuery = ParentGroup.rsGroup.GetCurrentRecord<NeededMaterials.RULNeededMaterialQuery_Class>(0);
                    MATERIALNAME.CalcValue = (dataset_RULNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RULNeededMaterialQuery.MaterialName) : "");
                    PARTNUMBER.CalcValue = (dataset_RULNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RULNeededMaterialQuery.PartNumber) : "");
                    MATERIALAMOUNT.CalcValue = (dataset_RULNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RULNeededMaterialQuery.MaterialAmount) : "");
                    MATERIALUNITPRICE.CalcValue = (dataset_RULNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RULNeededMaterialQuery.MaterialUnitPrice) : "");
                    MATERIALTOTALPRICE.CalcValue = (dataset_RULNeededMaterialQuery != null ? Globals.ToStringCore(dataset_RULNeededMaterialQuery.MaterialTotalPrice) : "");
                    SNU.CalcValue = ParentGroup.Counter.ToString();
                    return new TTReportObject[] { MATERIALNAME,PARTNUMBER,MATERIALAMOUNT,MATERIALUNITPRICE,MATERIALTOTALPRICE,SNU};
                }
            }

        }

        public MAINGroup MAIN;

        private ReportRuntimeParameters _runtimeParameters;
        public ReportRuntimeParameters RuntimeParameters
        {
            get { return _runtimeParameters; }
        }

        public KayitSilmeyeEsasTeknikRaporRUL()
        {
            PARTC = new PARTCGroup(this,"PARTC");
            Footer = new FooterGroup(PARTC,"Footer");
            PARTA = new PARTAGroup(Footer,"PARTA");
            MAIN = new MAINGroup(PARTA,"MAIN");
            _runtimeParameters = new ReportRuntimeParameters();
            
            ReportParameter reportParameter;
            reportParameter = Parameters.Add("TTOBJECTID", "00000000-0000-0000-0000-000000000000", "Onarım", @"", true, true, false, new Guid("b91c9866-f2fe-44bc-9d36-ae524ee4d2ef"));
        }

        public override void PrepareTTReport(Dictionary<string, object> parameters)
        {
            if (parameters.ContainsKey("TTOBJECTID"))
                _runtimeParameters.TTOBJECTID = (Guid?)TTObjectDefManager.Instance.DataTypes["Guid"].ConvertValue(parameters["TTOBJECTID"]);
            Name = "KAYITSILMEYEESASTEKNIKRAPORRUL";
            Caption = "Kayıt Silmeye Esas Teknik Rapor ( HEK Raporu )";
            FieldDefaults = SetFieldDefaultProperties();
            RTFDefaults = SetRTFDefaultProperties();
            HTMLDefaults = SetHTMLDefaultProperties();
            ShapeDefaults = SetShapeDefaultProperties();
            Orientation = OrientationEnum.oePortrait;
        }

        protected TTReportField SetFieldDefaultProperties()
        {
            TTReportField fd = new TTReportField();

            fd.Visible = EvetHayirEnum.ehEvet;
            fd.ForeColor = System.Drawing.Color.Black;
            fd.FillColor = System.Drawing.Color.White;
            fd.DrawStyle = DrawStyleConstants.vbSolid;
            fd.FillStyle = FillStyleConstants.vbFSSolid;
            fd.DrawWidth = 1;

            fd.FieldType = ReportFieldTypeEnum.ftConstant;
            fd.CaseFormat = CaseFormatEnum.fcNoChange;
            fd.TextFormat = "";
            fd.TextColor = System.Drawing.Color.Black;
            fd.FontAngle = 0;
            fd.HorzAlign = HorizontalAlignmentEnum.haleft;
            fd.VertAlign = VerticalAlignmentEnum.vaMiddle;
            fd.MultiLine = EvetHayirEnum.ehHayir;
            fd.NoClip = EvetHayirEnum.ehHayir;
            fd.WordBreak = EvetHayirEnum.ehHayir;
            fd.ExpandTabs = EvetHayirEnum.ehHayir;
            fd.CrossTabRole = CrosstabRoleEnum.ctrNone;
            fd.CrossTabValues = "";
            fd.ExcelCol = 0;
            fd.ObjectDefName = "";
            fd.DataMember = "";
            fd.TextFont.Name = "Arial";
            fd.TextFont.Size = 9;
            fd.TextFont.Bold = false;
            fd.TextFont.Italic = false;
            fd.TextFont.Underline = false;
            fd.TextFont.Strikethrough = false;
            fd.TextFont.CharSet = 162;
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