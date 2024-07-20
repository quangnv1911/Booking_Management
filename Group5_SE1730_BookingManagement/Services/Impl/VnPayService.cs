using Group5_SE1730_BookingManagement.Models.VnPay;
using Group5_SE1730_BookingManagement.Libraries;
using System.Security.Cryptography;
using System.Text;

namespace Group5_SE1730_BookingManagement.Services.Impl
{
    public class VnPayService : IVnPayService
    {
        private readonly IConfiguration _configuration;

        public VnPayService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreatePaymentUrl(PaymentInfoModel model, HttpContext context, string bookingId)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = _configuration["PaymentCallBack:ReturnUrl"];

            pay.AddRequestData("vnp_Version", _configuration["Vnpay:Version"]);
            pay.AddRequestData("vnp_Command", _configuration["Vnpay:Command"]);
            pay.AddRequestData("vnp_TmnCode", _configuration["Vnpay:TmnCode"]);
            pay.AddRequestData("vnp_Amount", ((int)model.Amount * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _configuration["Vnpay:CurrCode"]);
            pay.AddRequestData("vnp_IpAddr", context.Connection.RemoteIpAddress.ToString());
            pay.AddRequestData("vnp_Locale", _configuration["Vnpay:Locale"]);
            pay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang: {model.Name}");
            pay.AddRequestData("vnp_OrderType", model.OrderType);
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_configuration["Vnpay:BaseUrl"], _configuration["Vnpay:HashSecret"]);

            return paymentUrl;
        }

        public string CreateVnPayUrl(PaymentInfoModel model, HttpContext context)
        {
            string vnp_HashSecret = "YOUR_HASH_SECRET"; // Chuỗi bí mật được cung cấp bởi VNPay
            string vnp_Url = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
            string vnp_Returnurl = "YOUR_RETURN_URL";

            SortedList<string, string> requestData = new SortedList<string, string>();
            requestData.Add("vnp_Version", "2.1.0");
            requestData.Add("vnp_Command", "pay");
            requestData.Add("vnp_TmnCode", "UOW6PZ4V");
            requestData.Add("vnp_Amount", "180600000"); // Đảm bảo số tiền nhân với 100
            requestData.Add("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            requestData.Add("vnp_CurrCode", "VND");
            requestData.Add("vnp_IpAddr", context.Connection.RemoteIpAddress?.ToString());
            requestData.Add("vnp_Locale", "vn");
            requestData.Add("vnp_OrderInfo", "Nguyen Van A Just booking bro 1806000");
            requestData.Add("vnp_OrderType", "other");
            requestData.Add("vnp_ReturnUrl", vnp_Returnurl);
            requestData.Add("vnp_TxnRef", DateTime.Now.Ticks.ToString());

            string hashData = string.Join("&", requestData.Select(kvp => kvp.Key + "=" + kvp.Value));
            string vnp_SecureHash = CreateHmacSHA512(vnp_HashSecret, hashData);

            requestData.Add("vnp_SecureHash", vnp_SecureHash);

            string paymentUrl = vnp_Url + "?" + string.Join("&", requestData.Select(kvp => kvp.Key + "=" + kvp.Value));

            return paymentUrl;
        }

        public static string CreateHmacSHA512(string key, string data)
        {
            using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashValue = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(data));
                return string.Concat(hashValue.Select(b => b.ToString("x2")));
            }
        }

        public PaymentResponseModel PaymentExecute(IQueryCollection collections)
        {
            var pay = new VnPayLibrary();
            var response = pay.GetFullResponseData(collections, _configuration["Vnpay:HashSecret"]);

            return response;
        }
    }
}
