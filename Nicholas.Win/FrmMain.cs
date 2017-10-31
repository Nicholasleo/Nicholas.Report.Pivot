/*==============================================
*CLR版本：4.0.30319.36388
*名称：FrmMain
*命名空间名称：Nicholas.Win
*文件名称：FrmMain
*创建时间：2017/9/17 12:26:52
*作者：Nicholas Leo
*联系方式：nicholasleo1030@163.com
*==============================================*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nicholas.Business.SystemConfig;
using Nicholas.Entities;
using DevExpress.XtraPivotGrid;
using Nicholas.Business;
using Entities;

namespace Nicholas.Win
{
    public partial class FrmMain : Form
    {
        DataSet dtSet = new DataSet();
        DataTable dtDtl = new DataTable();
        string templatePath = string.Format("{0}\\report\\PivotReportFile", Application.StartupPath);
        private PivotDataBusiness _provider = new PivotDataBusiness();
        private ResultInfo<DataTable, string> resultInfo = null;

        public FrmMain()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pGridMain.OptionsPrint.PrintDataHeaders = DevExpress.Utils.DefaultBoolean.False;
            pGridMain.OptionsPrint.PrintFilterHeaders = DevExpress.Utils.DefaultBoolean.False;
            pGridMain.OptionsPrint.PrintColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            pGridMain.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Far;
            pGridMain.OptionsView.ColumnTotalsLocation = PivotTotalsLocation.Far;
            //templatePath = string.Format(@"{0}\{1}", templatePath, this.Text);
            //if (!Directory.Exists(templatePath))
            //{
            //    Directory.CreateDirectory(templatePath);
            //}
            //LoadReportTemplate();
            // 加载图表类型
            //InitChartType();
            //ChartBind();
            //bChkShowSet_CheckedChanged(null, null);
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitData();
        }

        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    //pGridMain.OptionsPrint.MergeColumnFieldValues = tsbtnColMerge1.Checked;
                    //pGridMain.OptionsPrint.MergeRowFieldValues = tsbtnRowMerge1.Checked;
                    sfd.Filter = "Excel 2003|*.xls|Excel 2007|*.xlsx|CSV 文件|*.csv";
                    sfd.FileName = string.Format("{0}_{1}", this.Text, DateTime.Now.ToString("yyyyMMddHHmmss"));
                    sfd.RestoreDirectory = true;
                    sfd.Title = "数据统计";
                    //sfd.InitialDirectory = System.Environment.CurrentDirectory;

                    sfd.InitialDirectory = Directory.Exists(Configure.Instance.Param.DirectLastExport)
                            ? Configure.Instance.Param.DirectLastExport
                            : Application.StartupPath;

                    if (DialogResult.OK == sfd.ShowDialog())
                    {
                        Configure.Instance.Param.DirectLastExport = Path.GetDirectoryName(sfd.FileName);
                        Configure.Instance.SaveConfig();

                        Application.DoEvents();
                        DevExpress.Utils.WaitDialogForm xtraform = new DevExpress.Utils.WaitDialogForm("请等待...", "数据导出中：", new Size(300, 80));
                        FileStream fs = (FileStream)sfd.OpenFile();
                        pGridMain.ExportToXlsx(fs);
                        fs.Close();
                        xtraform.Close();
                        MessageBox.Show("导出成功！");
                    }
                }
            }
            catch(Exception ex)
            { 
            }
        }

        Dictionary<string, string> fields = new Dictionary<string, string>();
        private void DictFields()
        {
            fields.Clear();
            DataTable dt = DataPool.Instance.DtFieldMapping;
            foreach (DataRow row in dt.Rows)
            {
                if (fields.ContainsKey(row[ColumnName.SysColumnName].ToString()))
                    continue;
                fields.Add(row[ColumnName.SysColumnName].ToString(), row[ColumnName.NameSc].ToString());
            }
        }

        private string MappingField(string field)
        {
            if (fields.ContainsKey(field))
                return fields[field];
            return field;
        }

        private void BindFiled(DataTable dt)
        {
            DictFields();
            int index = 0;
            //foreach (DataColumn column in dt.Columns)
            //{
            //    PivotGridField field = new PivotGridField(column.Caption, PivotArea.ColumnArea);
            //    pgField[index++] = field;
            //}
            foreach (DataColumn column in dt.Columns)
            {
                PivotGridField field = new PivotGridField();
                field.AreaIndex = pGridMain.Fields.Count;
                field.Caption = MappingField(column.ColumnName);
                field.FieldName = column.ColumnName;
                field.Name = "M" + MappingField(column.ColumnName);
                field.SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
                this.pGridMain.Fields.Add(field);
            }
        }

        private void InitData()
        {
            resultInfo = _provider.GetDataTable();
            if (resultInfo.Result != null)
            {
                pGridMain.Fields.Clear();
                pGridMain.DataSource = resultInfo.Result;
                BindFiled(resultInfo.Result);
            }
        }

        //private void ChartBind()
        //{
        //    this.chartCtrl.DataSource = this.pGrdDtl;
        //    this.chartCtrl.SeriesDataMember = "Series";
        //    this.chartCtrl.SeriesTemplate.ArgumentDataMember = "Arguments";
        //    this.chartCtrl.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "Values" });
        //    this.chartCtrl.SeriesTemplate.PointOptions.PointView = PointView.ArgumentAndValues;
        //    this.chartCtrl.SeriesTemplate.LegendPointOptions.PointView = PointView.ArgumentAndValues;
        //    this.pGrdDtl.ChartDataVertical = true;
        //}

        //private void InitChartType()
        //{
        //    lstVType.Clear();
        //    cmbChartType.Properties.Items.Clear();

        //    cmbChartType.Properties.Items.Add("柱状图");
        //    lstVType.Add(ViewType.Bar);
        //    cmbChartType.Properties.Items.Add("饼状图");
        //    lstVType.Add(ViewType.Pie);
        //    cmbChartType.Properties.Items.Add("三维柱状图");
        //    lstVType.Add(ViewType.Bar3D);
        //    cmbChartType.Properties.Items.Add("三维饼状图");
        //    lstVType.Add(ViewType.Pie3D);
        //    cmbChartType.SelectedIndex = 1;
        //    cbxDirection.SelectedIndex = 0;
        //}
    }
}
