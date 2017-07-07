//Cameron Prince
//Original 7/28/2015
//Modified 8/12/2015
//email to SMS program
//Curently working validation

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace SMS_Test3
{
    public partial class Form1 : Form
    {
        public Form1()
        {InitializeComponent();
         this.cboEmail.DropDownStyle = ComboBoxStyle.DropDownList;
         this.cboCarrier.DropDownStyle = ComboBoxStyle.DropDownList;
         FillBox();}

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            InitVars temp = new InitVars();
            Finder Find = new Finder();
            temp.froEmail = txtEmail.Text;
            temp.froSMTP = Find.FindSMTP(cboEmail.SelectedIndex.ToString());
            temp.froMessage = txtMessage.Text;
            temp.toSMSno = txtPhoneNum.Text;
            temp.toSMSgate = Find.FindGate(cboCarrier.SelectedIndex.ToString());

            //OldSend();
            NewSend(txtPhoneNum.Text, temp.toSMSgate, temp.froEmail, temp.froSMTP, txtMessage.Text);
            //NewSend(string num, string gate, string email, string froSMTP, string body)
        }//end button submit

        public void FillBox()//Fills the combo boxes
        {
        string[] Array1 = new string[] { "1&1", "Airmail", "AOL", "AT&T", "Bluewin", "BT Connect", "Comcast", "Earthlink", "Gmail", "Gmx", "HotPop", "Libero", "Lycos", "O2", "Orange", "Outlook.com/Hotmail", "Tin", "Tiscali", "Verizon", "Virgin", "Wanadoo", "Yahoo" };
        for (int i = 0; i < Array1.Length; i++)
        {cboEmail.Items.Add(Array1[i]);}//End for
        string[] Array2 = new string[] { "AT&T", "Cricket", "Sprint", "T-Mobile", "U.S. Celular", "Verizon Wireless", "Virgin"};
        for (int i = 0; i < Array2.Length; i++)
        { cboCarrier.Items.Add(Array2[i]); }//End for
        }//End fillbox

        public void OldSend()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add("6034431392@vtext.com");
                //"6034431392@sms.vtext.com" <-- bad
                //yournumber@vzwpix.com <-- for more than text
                message.From = new MailAddress("ciprince@email.neit.edu"); //See the note afterwards...
                message.Body = "Testing texting program.";

                SmtpClient smtp = new SmtpClient("Smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("ciprince@email.neit.edu", txtPass.Text);

                smtp.Send(message);
                MessageBox.Show("Message sent successfully");
            }//End try
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }
        }//End old Send



        public void NewSend(string num, string gate, string email, string froSMTP, string body)
        {
            phone_val val = new phone_val();

            if (val.ValPhNum(num))
            { }
            else
            { txtMessage.Text = "Error: Invalid phone #";
            return;}

            if(val.ValEmailAddr(email))
            {}
            else
            {txtMessage.Text = "Error: Invalid email";
             return;}

            if(val.ValEmpty(body))
            {}
            else
            {txtMessage.Text = "Error: Empty body";
            return;}

            if (val.ValEmpty(gate))
            { }
            else
            {txtMessage.Text = "Error: Empty carrier";
            return;}

            if (val.ValDot(froSMTP))
            {}
            else
            {txtMessage.Text = "Error: Empty email type";
                return;}


            try {
                MailMessage message = new MailMessage();
                string addr1 = num + gate;
                message.To.Add(addr1);
                message.From = new MailAddress(email);
                message.Body = body;

                SmtpClient smtp = new SmtpClient(froSMTP);
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(email, txtPass.Text);

                smtp.Send(message);
                MessageBox.Show("Message sent successfully");

            }//End try
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error"); }//End catch
        }//End new send


        /*public string FindSMTP(string x)
        {
        string res = "";

        if (x == "0")
        {res = "Smtp.1and1.com"; }
        else if (x == "1")
        { res = "Mail.airmail.net"; }
        else if (x == "2")
        { res = "Smtp.aol.com"; }
        else if (x == "3")
        { res = "Outbound.att.net"; }
        else if (x == "4")
        { res = "Smtp.comcast.net"; }
        else if (x == "5")
        { res = "Smtp.gmail.com"; }
        else if (x == "6")
        { res = "Smtp.live.com"; }
        else if (x == "7")
        { res = "Smtp.mail.yahoo.com"; }

        else if (x == "")
        { res = ""; }

        else
        { res = ""; }
        //"1&1", "Airmail", "AOL", "AT&T", "Comcast", "Gmail", "Outlook.com/Hotmail", "Yahoo"
            return res;}//End findsmtp*/

        /*public string FindGate(string x)
        {
            string res = "";
            //"AT&T", "Cricket", "Sprint", "T-Mobile", "U.S. Celular", "Verizon Wireless", "Virgin"
            if (x == "0")
            { res = "@txt.att.net"; }
            else if (x == "1")
            { res = "@mms.mycricket.com"; }
            else if (x == "2")
            { res = "@messaging.sprintpcs.com"; }
            else if (x == "3")
            { res = "@tmomail.net[5]"; }
            else if (x == "4")
            { res = "@email.uscc.net"; }
            else if (x == "5")
            { res = "@vtext.com"; }
            else if (x == "6")
            { res = "@vmobl.com"; }
            else
            { res = ""; }
            return res;
        }//End find gate*/


    }//End class
}//End namespace


/*
credit for base code
 * - http://stackoverflow.com/questions/19635594/how-to-send-sms-to-mobile-using-smtp-server-in-windows-application
 * 
 * 
Mobile Carrier	SMS gateway domain
AT&T	            txt.att.net
Cricket	            mms.mycricket.com
Sprint	            messaging.sprintpcs.com
T-Mobile	        tmomail.net[5]
U.S. Celular	    email.uscc.net
Verizon Wireless	vtext.com
Virgin	            vmobl.com
 * 
 * 
 * 
PROVIDER    URL         SMTP SETTINGS
1&1         1and1.com       Smtp.1and1.com
Airmail     Airmail.net     Mail.airmail.net
AOL         Aol.com         Smtp.aol.com
AT&T        Att.net         Outbound.att.net
Bluewin     Bluewin.ch      Smtpauths.bluewin.ch
BT Connect  Btconnect.com   Mail.btconnect.tom
Comcast     Comcast.net     Smtp.comcast.net
Earthlink   Earthlink.net   Smtpauth.earthlink.net
Gmail       Gmail.com       Smtp.gmail.com
Gmx         Gmx.net         Mail.gmx.net
HotPop      Hotpop.com      Mail.hotpop.com
Libero      Libero.it       Mail.libero.it
Lycos       Lycos.com       Smtp.lycos.com
O2          o2.com          Smtp.o2.com
Orange      Orange.net      Smtp.orange.net
Outlook.com (former Hotmail)Smtp.live.com
Tin         Tin.it          Mail.tin.it
Tiscali     Tiscali.co.uk   Smtp.tiscali.co.uk
Verizon     Verizon.net     Outgoing.verizon.net
Virgin      Virgin.net      Smtp.virgin.net
Wanadoo     Wanadoo.fr      Smtp.wanadoo.fr
Yahoo       Yahoo.com       Smtp.mail.yahoo.com
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
Complete sms
US & Canadian Carriers


3 River Wireless
10digitphonenumber@sms.3rivers.net
 * 
ACS Wireless
10digitphonenumber@paging.acswireless.com
 * 
Alltel
10digitphonenumber@message.alltel.com
 * 
AT&T
10digitphonenumber@txt.att.net
 * 
Bell Canada
10digitphonenumber@txt.bellmobility.ca
 * 
Bell Canada
10digitphonenumber@bellmobility.ca
 * 
Bell Mobility (Canada)
10digitphonenumber@txt.bell.ca
 * 
Bell Mobility
10digitphonenumber@txt.bellmobility.ca
 * 
Blue Sky Frog
10digitphonenumber@blueskyfrog.com
 * 
Bluegrass Cellular
10digitphonenumber@sms.bluecell.com
 * 
Boost Mobile
10digitphonenumber@myboostmobile.com
 * 
BPL Mobile
10digitphonenumber@bplmobile.com
 * 
Carolina West Wireless
10digit10digitnumber@cwwsms.com
 * 
Cellular One
10digitphonenumber@mobile.celloneusa.com
 * 
Cellular South
10digitphonenumber@csouth1.com
 * 
Centennial Wireless
10digitphonenumber@cwemail.com
 * 
CenturyTel
10digitphonenumber@messaging.centurytel.net
 * 
Cingular (Now AT&T)
10digitphonenumber@txt.att.net
 * 
Clearnet
10digitphonenumber@msg.clearnet.com
 * 
Comcast
10digitphonenumber@comcastpcs.textmsg.com
 * 
Corr Wireless Communications
10digitphonenumber@corrwireless.net
 * 
Dobson
10digitphonenumber@mobile.dobson.net
 * 
Edge Wireless
10digitphonenumber@sms.edgewireless.com
 * 
Fido
10digitphonenumber@fido.ca
 * 
Golden Telecom
10digitphonenumber@sms.goldentele.com
 * 
Helio
10digitphonenumber@messaging.sprintpcs.com
 * 
Houston Cellular
10digitphonenumber@text.houstoncellular.net
 * 
Idea Cellular
10digitphonenumber@ideacellular.net
 * 
Illinois Valley Cellular
10digitphonenumber@ivctext.com
 * 
Inland Cellular Telephone
10digitphonenumber@inlandlink.com
 * 
MCI
10digitphonenumber@pagemci.com
 * 
Metrocall
10digitpagernumber@page.metrocall.com
 * 
Metrocall 2-way
10digitpagernumber@my2way.com
 * 
Metro PCS
10digitphonenumber@mymetropcs.com
 * 
Microcell
10digitphonenumber@fido.ca
 * 
Midwest Wireless
10digitphonenumber@clearlydigital.com
 * 
Mobilcomm
10digitphonenumber@mobilecomm.net
 * 
MTS
10digitphonenumber@text.mtsmobility.com
 * 
Nextel
10digitphonenumber@messaging.nextel.com
 * 
OnlineBeep
10digitphonenumber@onlinebeep.net
 * 
PCS One
10digitphonenumber@pcsone.net
 * 
President's Choice
10digitphonenumber@txt.bell.ca
 * 
Public Service Cellular
10digitphonenumber@sms.pscel.com
Qwest
10digitphonenumber@qwestmp.com
Rogers AT&T Wireless
10digitphonenumber@pcs.rogers.com
Rogers Canada
10digitphonenumber@pcs.rogers.com
Satellink
10digitpagernumber.pageme@satellink.net
Southwestern Bell
10digitphonenumber@email.swbw.com
Sprint
10digitphonenumber@messaging.sprintpcs.com
Sumcom
10digitphonenumber@tms.suncom.com
Surewest Communicaitons
10digitphonenumber@mobile.surewest.com
T-Mobile
10digitphonenumber@tmomail.net
Telus
10digitphonenumber@msg.telus.com
Tracfone
10digitphonenumber@txt.att.net
Triton
10digitphonenumber@tms.suncom.com
Unicel
10digitphonenumber@utext.com
US Cellular
10digitphonenumber@email.uscc.net
Solo Mobile
10digitphonenumber@txt.bell.ca
Sprint
10digitphonenumber@messaging.sprintpcs.com
Sumcom
10digitphonenumber@tms.suncom.com
Surewest Communicaitons
10digitphonenumber@mobile.surewest.com
T-Mobile
10digitphonenumber@tmomail.net
Telus
10digitphonenumber@msg.telus.com
Triton
10digitphonenumber@tms.suncom.com
Unicel
10digitphonenumber@utext.com
US Cellular
10digitphonenumber@email.uscc.net
US West
10digitphonenumber@uswestdatamail.com
Verizon
10digitphonenumber@vtext.com
Virgin Mobile
10digitphonenumber@vmobl.com
Virgin Mobile Canada
10digitphonenumber@vmobile.ca
West Central Wireless
10digitphonenumber@sms.wcc.net
Western Wireless
10digitphonenumber@cellularonewest.com
*/