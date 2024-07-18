using Microsoft.Extensions.Configuration;
using MilkData.VNPay.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkBusiness.Utils.VNPayUtils
{
    public class VNPayHelper
    {
        public static VNPayConfig GetConfigData()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", true, true)
                 .Build();

            var version = config["VNPay:Version"];
            var tmnCode = config["VNPay:TmnCode"];
            var currencyCode = config["VNPay:CurrencyCode"];
            var locale = config["VNPay:Locale"];
            var returnUrl = config["VNPay:ReturnUrl"];
            var baseUrl = config["VNPay:PaymentUrl"];
            var secretKey = config["VNPay:HashSecret"];

            return new VNPayConfig()
            {
                PaymentUrl = baseUrl,
                ReturnUrl = returnUrl,
                TmnCode = tmnCode,
                HashSecret = secretKey,
                Version = version,
                CurrencyCode = currencyCode,
                Locale = locale,
            };
        }
    }
}
