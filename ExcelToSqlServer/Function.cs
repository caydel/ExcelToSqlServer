// ***********************************************************************
// Assembly				: ExcelToSqlServer
// File						: Function
// Author					: caydel
// Created				: 2019/7/16 10:33:28
//
// Last Modified By 	: caydel
// Last Modified On 	: 2019/7/16 10:33:28
// Remarks 				: Excel内容导入到数据库方法
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;    //用于SqlServer数据库操作
using System.Data.OleDb;        //用于Excel数据库操作
using System.Data;
using System.Windows.Forms;

namespace ExcelToSqlServer
{
    public class Function
    {
        #region Excel导入到Sqlserver

        #region 私有变量
        /// <summary>
        /// 指定的Excel文件名
        /// </summary>
        public string strFileName { get; set; }
        /// <summary>
        /// 从Excel中读取到内容
        /// </summary>
        public DataSet dsExcel { get; set; }
        /// <summary>
        /// 是否已经获取到Excel文件的路径
        /// 默认：False
        /// </summary>
        public bool hasFile { get; set; }
        /// <summary>
        /// 是否已经把Excel读取到DataSet中
        /// 默认：False
        /// </summary>
        public bool hasContent { get; set; }
        #endregion

        /// <summary>
        /// 读取Excel内容
        /// </summary>
        public void ShowExcelContent()
        {
            //下面是Excel数据库访问操作：
            //连接字符串
            //string strCon = @"Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = '" + strFileName + "';Extended Properties=Excel 8.0";
            string strCon = @"Provider = Microsoft.ACE.OLEDB.12.0 ; Data Source = '" + strFileName + "';Extended Properties=Excel 8.0";
            //要执行的sql语句
            string strSql = "select * from [Sheet1$]";
            //创建OleDb连接对象
            OleDbConnection oleDbCon = new OleDbConnection(strCon);
            //创建OleDbDataAdapter
            OleDbDataAdapter oleDbDa = new OleDbDataAdapter(strSql, oleDbCon);
            //实例化ds
            dsExcel = new DataSet();
            //打开连接
            oleDbCon.Open();
            //从数据库读取内容并填充到ds中
            oleDbDa.Fill(dsExcel, "Info");
            //关闭连接
            oleDbCon.Close();
            //标记ds有内容
            hasContent = true;
        }

        /// <summary>
        /// 存储到数据库中
        /// </summary>
        public void ToSqlServer()
        {
            //要执行的sql语句，暂时无.这里采用Stringbuilder类，因为接下来字符串连接操作比较多
            StringBuilder strbSql = new StringBuilder();
            //SqlServer连接语句，该实例数据库为“Zongti”
            string strCon = @"Data Source=.;Initial Catalog=Zongti;Integrated Security=True;User ID=sa;Password=123456";
            //创建连接
            SqlConnection sqlCon = new SqlConnection(strCon);
            //创建一个空的sql执行对象
            SqlCommand sqlCom = new SqlCommand();
            //把连接对象赋予sqlCom
            sqlCom.Connection = sqlCon;
            //打开连接
            sqlCon.Open();
            //用try catch 语句，捕抓错误
            try
            {
                //连续往SqlServer表里插入数据
                for (int i = 0; i < dsExcel.Tables[0].Rows.Count; i++)
                {
                    //要执行的insert语句：有一点要注意，在SqlServer中用  '' 标记字符串，这里记得要添加
                    strbSql.Append("insert into [Zongti].[dbo].[VehicleParameterTemplateDetail] ([ID],[VehicleParameterTemplateID],[Caption],[Fuhao],[Danwei],[MappingParamterID],[MappingParamterCaption],[ParameterFlowType],[SourceDepartment],[DestinationDepartmentIds],[DestinationDepartmentCaptions],[Bianhao],[Jishuzhibiao],[SpecialProcessingMode],[TagertType],[SpecialFlag],[Remark],[ComponentCaption],[ComboBoxDataSource],[CustomDataType],[InputType],[ReceiveSpecialProcessingMode],[JobDetailID],[JobDetailCaption]) values('");
                    for (int j = 0; j < 23; j++)
                    {
                        strbSql.Append(dsExcel.Tables[0].Rows[i].ItemArray[j].ToString() + "','");
                    }
                    strbSql.Append(dsExcel.Tables[0].Rows[i].ItemArray[23].ToString() + "')");

                    //执行sql语句
                    string strSql = strbSql.ToString();
                    sqlCom.CommandText = strSql;
                    sqlCom.ExecuteNonQuery();
                    //strbSql里面内容要清除，否则会叠加的，提示信息重复插入等信息
                    strbSql.Remove(0, strbSql.Length);
                }
                //插入成功提示
                MessageBox.Show("导入SqlServer成功！请查看！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                //失败提示
                MessageBox.Show("导入SqlServer过程中发生错误！/n错误提示：" + ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //关闭连接
                sqlCon.Close();
            }
        }


        private void bntShowExcel_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
