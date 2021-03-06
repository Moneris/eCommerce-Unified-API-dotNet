namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestUSAResUpdatePinless
    {
        public static void Main(string[] args)
        {
            string store_id = "monusqa002";
            string api_token = "qatoken";
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string data_key = "AhcyWhamRPNnhyU8RYPxM3saK";
            string pan = "4242424242424242";
            string expdate = "1911"; //YYMM format
            string phone = "0000000000";
            string email = "bob@smith.com";
            string note = "my note";
            string cust_id = "customer1";
            string presentation_type = "W";
            string p_account_number = "23456789";
            string processing_country_code = "US";
            bool status_check = false;

            ResUpdatePinless resUpdatePinless = new ResUpdatePinless();
            resUpdatePinless.SetDataKey(data_key);
            resUpdatePinless.SetCustId(cust_id);
            resUpdatePinless.SetPan(pan);
            resUpdatePinless.SetExpDate(expdate);
            resUpdatePinless.SetPhone(phone);
            resUpdatePinless.SetEmail(email);
            resUpdatePinless.SetNote(note);
            resUpdatePinless.SetPresentationType(presentation_type);
            resUpdatePinless.SetPAccountNumber(p_account_number);

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(resUpdatePinless);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("DataKey = " + receipt.GetDataKey());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("ResSuccess = " + receipt.GetResSuccess());
                Console.WriteLine("PaymentType = " + receipt.GetPaymentType());
                Console.WriteLine("Cust ID = " + receipt.GetResDataCustId());
                Console.WriteLine("Phone = " + receipt.GetResDataPhone());
                Console.WriteLine("Email = " + receipt.GetResDataEmail());
                Console.WriteLine("Note = " + receipt.GetResDataNote());
                Console.WriteLine("MaskedPan = " + receipt.GetResDataMaskedPan());
                Console.WriteLine("Exp Date = " + receipt.GetResDataExpdate());
                Console.WriteLine("Presentation Type = " + receipt.GetResDataPresentationType());
                Console.WriteLine("P Account Number = " + receipt.GetResDataPAccountNumber());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
