using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace ExcelToSqlServer
{
    public partial class FrMain : Form
    {
        Function function = new Function();
        public FrMain()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFindFile_Click(object sender, EventArgs e)
        {
            //文件选择对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel2003|*.xls|Excel2007-2019|*.xlsx|Excel包含宏文件|*.xlsm";
            //判断是否选择好文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                function.hasFile = true;
                function.strFileName = tbFileName.Text = openFileDialog.FileName;
            }
        }

        /// <summary>
        /// 显示Excel内容到DatagridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnShowExcel_Click(object sender, EventArgs e)
        {
            //判断是否已经选择好文件
            if (function.hasFile)
            {
                //显示Excel内容到DatagridView
                function.ShowExcelContent();
                dgv.DataSource = function.dsExcel.Tables[0];
            }
        }

        private void BtnToSqlServer_Click(object sender, EventArgs e)
        {
            //判断DataSet是否有内容
            if (function.hasContent)
            {
                //导入到SqlServer
                function.ToSqlServer();
            }
        }
    }
}
