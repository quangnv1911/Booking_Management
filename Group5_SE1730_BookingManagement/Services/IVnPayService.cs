﻿using Group5_SE1730_BookingManagement.Models.VnPay;

namespace Group5_SE1730_BookingManagement.Services
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentInfoModel model, HttpContext context);
        PaymentResponseModel PaymentExecute(IQueryCollection collections);
    }
}
