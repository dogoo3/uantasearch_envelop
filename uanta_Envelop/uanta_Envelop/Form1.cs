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
            m_iYuantaAPI.YOA_Initial("real.tradar.api.com", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\YuantaAPI");
            m_iYuantaAPI.YOA_Login("dogoo3", "rhks12!@", "!rkqo1122dlk");

            // 릴리즈 로그인
            //m_iYuantaAPI.YOA_Initial("real.tradar.api.com", "");
            //m_iYuantaAPI.YOA_Login("dogoo3", "rhks12!@", "!rkqo1122dlk");
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
            // 조회 TR 수신 Event
            label1.Text = nReqID.ToString();
            label2.Text = strDSOID;

            label1.Text = m_iYuantaAPI.YOA_GetTRFieldString("300001", "OutBlock1", "jongname", 0);
            label2.Text = m_iYuantaAPI.YOA_GetTRFieldString("300001", "OutBlock1", "curjuka", 0);
        }
        void IYuantaAPIEvents.ReceiveRealData(int nReqID, string strAutoID)
        {
            // 실시간 TR 수신 Event
        }



        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            // 계좌번호 조회
            //string account = "";
            //int n = m_iYuantaAPI.YOA_GetAccountCount();

            //for (int i = 0; i < n; i++)
            //{
            //    account = m_iYuantaAPI.YOA_GetAccount(i);
            //}
            //MessageBox.Show(account);

            // 종목 수 반환
            //long n = m_iYuantaAPI.YOA_GetCodeCount(0);
            //label1.Text = n.ToString();

            // 종목 정보 확인
            //int a = int.Parse(textBox1.Text);
            //string n = m_iYuantaAPI.YOA_GetCodeInfo(3, 2, "005390"); // 2로만 적용해야 종목명이 뜸
            //label1.Text = n;

            // 종목의 세부정보 얻어옴
            //m_iYuantaAPI.YOA_SetTRFieldString("300001", "InBlock1", "jang", "1", 0);
            //m_iYuantaAPI.YOA_SetTRFieldString("300001", "InBlock1", "jongcode", "005390", 0);
            //m_iYuantaAPI.YOA_SetTRFieldString("300001", "InBlock1", "outflag", "N", 0);
            //m_iYuantaAPI.YOA_SetTRFieldString("300001", "InBlock1", "tsflag", "0", 0);
            //int a = m_iYuantaAPI.YOA_Request("300001", true, -1);
            //label1.Text = a.ToString();

            // 종목의 세부정보 얻어옴 2

            m_iYuantaAPI.YOA_SetTRInfo("300001", "InBlock1");          // TR정보(TR명, Block명)를 설정합니다.

            m_iYuantaAPI.YOA_SetFieldString("jang", "1", 0);      // 장내외구분 값을 설정합니다.
            m_iYuantaAPI.YOA_SetFieldString("jongcode", "005390", 0);      // 종목코드 값을 설정합니다.
            m_iYuantaAPI.YOA_SetFieldString("outflag", "N", 0);       // 단일가여부_Y_N 값을 설정합니다.
            m_iYuantaAPI.YOA_SetFieldString("tsflag", "0", 0);		// 거래원수량_대금_평균 값을 설정합니다..

            m_iYuantaAPI.YOA_Request("300001", true, -1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 현재가 GET(getTRFieldString)
            label2.Text = m_iYuantaAPI.YOA_GetTRFieldString("300001", "OutBlock1", "jongname", 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // getlasterror
            MessageBox.Show(m_iYuantaAPI.YOA_GetLastError().ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // geterrormessage
            MessageBox.Show(m_iYuantaAPI.YOA_GetErrorMessage(m_iYuantaAPI.YOA_GetLastError()).ToString());
        }
    }
}
