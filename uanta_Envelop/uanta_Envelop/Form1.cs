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
        }
        void IYuantaAPIEvents.ReceiveRealData(int nReqID, string strAutoID)
        {
            // 실시간 TR 수신 Event
        }



        #endregion
        private void button1_Click(object sender, EventArgs e)
        {
            // API 등록(테스트 기본 설정)
            //int code = m_iYuantaAPI.YOA_Initial("real.tradar.api.com", Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\YuantaAPI");
            //MessageBox.Show(code.ToString());
            // API 등록(실제빌드 기본 설정)
            int code = m_iYuantaAPI.YOA_Initial("real.tradar.api.com", "");
            MessageBox.Show(code.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long login = m_iYuantaAPI.YOA_Login("dogoo3", "rhks12!@", "!rkqo1122dlk");
            MessageBox.Show(login.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string account = "";
            int n = m_iYuantaAPI.YOA_GetAccountCount();

            for(int i=0;i<n;i++)
            {
                account = m_iYuantaAPI.YOA_GetAccount(i);
            }
            MessageBox.Show(account);
        }
    }
}
