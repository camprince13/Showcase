using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SMS_Test3
{
    public class phone_val
    {


        public bool ValPhNum(string phNum)
        {
            //Accepts only 10 digits
            Regex pattern = new Regex(@"(?<!\d)\d{10}(?!\d)");
            if (pattern.IsMatch(phNum))
            {return true;}
            else
            {return false;}
        }//End ValPhNum

        public bool ValEmailAddr(string email)
        {
            //Accepts valid email
            Regex pattern = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (pattern.IsMatch(email))
            { return true; }
            else
            { return false; }
        }//End ValEmailAddr

        public bool ValEmpty(string test)//Not empty
        {
            //Accepts valid email
            Regex pattern = new Regex(@"^.+$");
            if (pattern.IsMatch(test))
            { return true; }
            else
            { return false; }
        }//End ValEmpty

        public bool ValDot(string test)//not empty [more than spaces]
        {
            //Accepts valid email
            Regex pattern = new Regex(@"^(?!\s*$).+");
            if (pattern.IsMatch(test))
            { return true; }
            else
            { return false; }
        }//End ValDot



    }//end class



    public class InitVars
    {
        public string froEmail = "";
        public string froSMTP = "";
        public string froMessage = "";
        public string toSMSno = "";
        public string toSMSgate = "";
    }//End class



    public class Finder {


        public string FindSMTP(string x){
            string res = "";
            if (x == "0")
            { res = "Smtp.1and1.com"; }
            else if (x == "1")
            { res = "Mail.airmail.net"; }
            else if (x == "2")
            { res = "Smtp.aol.com"; }
            else if (x == "3")
            { res = "Outbound.att.net"; }
            else if (x == "4")
            { res = "Smtpauths.bluewin.ch"; }
            else if (x == "5")
            { res = "Mail.btconnect.tom"; }
            else if (x == "6")
            { res = "Smtp.comcast.net"; }
            else if (x == "7")
            { res = "Smtpauth.earthlink.net"; }
            else if (x == "8")
            { res = "Smtp.gmail.com"; }
            else if (x == "9")
            { res = "Mail.gmx.net"; }
            else if (x == "10")
            { res = "Mail.hotpop.com"; }
            else if (x == "11")
            { res = "Mail.libero.it"; }
            else if (x == "12")
            { res = "Smtp.lycos.com"; }
            else if (x == "13")
            { res = "Smtp.o2.com"; }
            else if (x == "14")
            { res = "Smtp.orange.net"; }
            else if (x == "15")
            { res = "Smtp.live.com"; }
            else if (x == "16")
            { res = "Mail.tin.it"; }
            else if (x == "17")
            { res = "Smtp.tiscali.co.uk"; }
            else if (x == "18")
            { res = "Outgoing.verizon.net"; }
            else if (x == "19")
            { res = "Smtp.virgin.net"; }
            else if (x == "20")
            { res = "Smtp.wanadoo.fr"; }
            else if (x == "21")
            { res = "Smtp.mail.yahoo.com"; }
            else
            { res = ""; }
            return res;}//End findsmtp



        public string FindGate(string x)
        {
            string res = "";
            //"AT&T", "Cricket", "Sprint", "T-Mobile", "U.S. Celular", "Verizon Wireless", "Virgin"   // not done
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





    }//End find class


}//End namespace






//add later if needed
/*
public string FindGateADV(string x)
        {
            string res = "";
            //3 River Wireless, ACS Wireless, Alltel, AT&T/Cingular, Blue Sky Frog, Bluegrass Cellular, Boost Mobile, BPL Mobile, Carolina West Wireless, 
            //Cellular One, Cellular South, Centennial Wireless, CenturyTel, Clearnet, Comcast, Corr Wireless Communications, Dobson, Edge Wireless, 
            //Fido, Golden Telecom, Helio
            if (x == "0")
            { res = "@sms.3rivers.net"; }
            else if (x == "1")
            { res = "@paging.acswireless.com"; }
            else if (x == "2")
            { res = "@message.alltel.com"; }
            else if (x == "3")
            { res = "@txt.att.net"; }
            else if (x == "4")
            { res = "@blueskyfrog.com"; }
            else if (x == "5")
            { res = "@sms.bluecell.com"; }
            else if (x == "6")
            { res = "@myboostmobile.com"; }
            else if (x == "7")
            { res = "@bplmobile.com"; }
            else if (x == "8")
            { res = "@cwwsms.com"; }
            else if (x == "9")
            { res = "@mobile.celloneusa.com"; }
            else if (x == "10")
            { res = "@csouth1.com"; }
            else if (x == "11")
            { res = "@cwemail.com"; }
            else if (x == "12")
            { res = "@messaging.centurytel.net"; }
            else if (x == "13")
            { res = "@msg.clearnet.com"; }
            else if (x == "14")
            { res = "@comcastpcs.textmsg.com"; }
            else if (x == "15")
            { res = "@corrwireless.net"; }
            else if (x == "16")
            { res = "@mobile.dobson.net"; }
            else if (x == "17")
            { res = "@sms.edgewireless.com"; }
            else if (x == "18")
            { res = "@fido.ca"; }
            else if (x == "19")
            { res = "@sms.goldentele.com"; }
            //else if (x == "20") //Sprint?  (Helio)
            //{ res = "@messaging.sprintpcs.com"; } //Sprint?

            else if (x == "21")
            { res = "@"; }

            else if (x == "22")
            { res = "@"; }

            else if (x == "")
            { res = "@"; }


            else
            { res = ""; }
            return res;
        }//End find gate*/



/*
Complete sms
US & Canadian Carriers



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