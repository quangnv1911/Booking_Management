using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography;
using System.Text;

namespace Group5_SE1730_BookingManagement.Pages.Bookings
{
    public class SummaryModel : PageModel
    {
        public string VnpAmount { get; set; }
        public string VnpBankCode { get; set; }
        public string VnpBankTranNo { get; set; }
        public string VnpCardType { get; set; }
        public string VnpOrderInfo { get; set; }
        public string VnpPayDate { get; set; }
        public string VnpResponseCode { get; set; }
        public string VnpTmnCode { get; set; }
        public string VnpTransactionNo { get; set; }
        public string VnpTransactionStatus { get; set; }
        public string VnpTxnRef { get; set; }
        public string VnpSecureHash { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            VnpAmount = Request.Query["vnp_Amount"];
            VnpBankCode = Request.Query["vnp_BankCode"];
            VnpBankTranNo = Request.Query["vnp_BankTranNo"];
            VnpCardType = Request.Query["vnp_CardType"];
            VnpOrderInfo = Request.Query["vnp_OrderInfo"];
            VnpPayDate = Request.Query["vnp_PayDate"];
            VnpResponseCode = Request.Query["vnp_ResponseCode"];
            VnpTmnCode = Request.Query["vnp_TmnCode"];
            VnpTransactionNo = Request.Query["vnp_TransactionNo"];
            VnpTransactionStatus = Request.Query["vnp_TransactionStatus"];
            VnpTxnRef = Request.Query["vnp_TxnRef"];
            VnpSecureHash = Request.Query["vnp_SecureHash"];

            // Tạo lại chuỗi hash để xác minh tính toàn vẹn của dữ liệu
            var vnp_HashSecret = "YOUR_HASH_SECRET"; // Thay bằng chuỗi bí mật của bạn
            var hashData = $"vnp_Amount={VnpAmount}&vnp_BankCode={VnpBankCode}&vnp_BankTranNo={VnpBankTranNo}&vnp_CardType={VnpCardType}&vnp_OrderInfo={VnpOrderInfo}&vnp_PayDate={VnpPayDate}&vnp_ResponseCode={VnpResponseCode}&vnp_TmnCode={VnpTmnCode}&vnp_TransactionNo={VnpTransactionNo}&vnp_TransactionStatus={VnpTransactionStatus}&vnp_TxnRef={VnpTxnRef}&vnp_Version=2.1.0";
            var computedHash = CreateHmacSHA512(vnp_HashSecret, hashData);

            if (computedHash.Equals(VnpSecureHash))
            {
                // Xử lý đơn hàng theo thông tin nhận được
                if (VnpResponseCode == "00" && VnpTransactionStatus == "00")
                {
                    // Giao dịch thành công
                    // Cập nhật trạng thái đơn hàng trong cơ sở dữ liệu của bạn
                    // Ví dụ: await _orderService.UpdateOrderStatusAsync(VnpTxnRef, OrderStatus.Paid);
                }
                else
                {
                    // Giao dịch thất bại
                    // Ví dụ: await _orderService.UpdateOrderStatusAsync(VnpTxnRef, OrderStatus.Failed);
                }
            }
            else
            {
                // Chuỗi hash không khớp, có thể dữ liệu đã bị thay đổi
            }

            return Page();
        }

        private static string CreateHmacSHA512(string key, string data)
        {
            using (var hmacsha512 = new HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] hashValue = hmacsha512.ComputeHash(Encoding.UTF8.GetBytes(data));
                return string.Concat(hashValue.Select(b => b.ToString("x2")));
            }
        }
    }
}
