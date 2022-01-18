using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YuantaCOMLib;

namespace uanta_Envelop
{
    public partial class Form1 : Form, IYuantaAPIEvents
    {
        IYuantaAPI m_iYuantaAPI;
        ExcelManager excelmanager;

        int index = 0, mvCount = 0, envelopValue = 0;

        string[,] item;
        string[,] result;
        public Form1()
        {
            InitializeComponent();

            // 유안타 오픈 API 기본설정
            IConnectionPoint icp;
            IConnectionPointContainer icpc;
            int dwCookie = 0;
            m_iYuantaAPI = new YuantaAPI();
            icpc = (IConnectionPointContainer)m_iYuantaAPI;
            Guid IID_QueryEvents = typeof(IYuantaAPIEvents).GUID;
            icpc.FindConnectionPoint(ref IID_QueryEvents, out icp);
            icp.Advise(this, out dwCookie);

            // 디버그 로그인
            //m_iYuantaAPI.YOA_Initial("real.tradar.api.com", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\YuantaAPI");
            //m_iYuantaAPI.YOA_Login("ID", "PW", "PW2");

            // 릴리즈 로그인
            m_iYuantaAPI.YOA_Initial("real.tradar.api.com", "");
            m_iYuantaAPI.YOA_Login("ID", "PW", "PW2");

            excelmanager = new ExcelManager();
            item = excelmanager.GetWorkSheet(Application.StartupPath + "\\KOSPI_KOSDAQ.xlsx");

            result = new string[item.Length / 3, 2];
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_iYuantaAPI.YOA_UnInitial();
        }

        #region IYuantaAPIEvents 멤버

        void IYuantaAPIEvents.ReceiveSystemMessage(int nID, string strMsg)
        {
            // System Message 수신 Event
        }
        void IYuantaAPIEvents.Login(int nResult, string strMsg)
        {
            // YOA_Login 응답 Event
        }
        void IYuantaAPIEvents.ReceiveError(int nReqID, int nErrCode, string strErrMsg)
        {
            // Error 수신 Event
        }
        void IYuantaAPIEvents.ReceiveData(int nReqID, string strDSOID)
        {
            double mv;

            double todaylastprice = mv = m_iYuantaAPI.YOA_GetTRFieldDouble("401001", "OutBlock1", "lastjuka", 0);
            for(int i=1;i<int.Parse(tb_maCount.Text);i++)
            {
                mv += m_iYuantaAPI.YOA_GetTRFieldLong("401001", "OutBlock1", "lastjuka", i); // 평균선갯수 구한후
            }
            mv /= int.Parse(tb_maCount.Text); // 나눠줌

            result[index-1, 0] = item[index-1, 2];
            result[index-1, 1] = (todaylastprice / mv * 100 - (100 - envelopValue)).ToString("F");

            label3.Text = index.ToString() + " / " + (item.Length / 3).ToString();

            if (index >= item.Length / 3)
            {
                excelmanager.MakeWorkSheet(result, Application.StartupPath + "\\test.xlsx");
                index = 0;
                label3.Text = "완료!";
            }
        }
        void IYuantaAPIEvents.ReceiveRealData(int nReqID, string strAutoID)
        {
            // 실시간 TR 수신 Event
        }
        #endregion
        private void btn_start_Click(object sender, EventArgs e)
        {
            m_iYuantaAPI.YOA_SetTRInfo("401001", "InBlock1");
            m_iYuantaAPI.YOA_SetFieldString("linkgb", "0", 0);
            m_iYuantaAPI.YOA_SetFieldString("startdate", "0", 0);
            mvCount = int.Parse(tb_maCount.Text);
            envelopValue = int.Parse(tb_envelopValue.Text);

            timer1.Start();
        }

        private void btn_getError_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_iYuantaAPI.YOA_GetLastError().ToString());
            MessageBox.Show(m_iYuantaAPI.YOA_GetErrorMessage(m_iYuantaAPI.YOA_GetLastError()).ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iYuantaAPI.YOA_SetFieldString("janggubun", item[index,0], 0);
            m_iYuantaAPI.YOA_SetFieldString("jongcode", "000000"+item[index,2], 0);
            m_iYuantaAPI.YOA_SetFieldString("enddate", System.DateTime.Now.ToString("yyyyMMdd"), 0); ;
            m_iYuantaAPI.YOA_SetFieldString("readcount", tb_maCount.Text, 0);

            m_iYuantaAPI.YOA_Request("401001", true, -1);

            index++;

            if (index >= item.Length / 3)
            {
                timer1.Stop();
                m_iYuantaAPI.YOA_Request("401001", true, -1);
            }
        }
    }
}
