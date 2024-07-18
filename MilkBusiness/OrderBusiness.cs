using Microsoft.EntityFrameworkCore;
using MilkBusiness.Utils.VNPayUtils;
using MilkData.DTOs.Order;
using MilkData.Models;
using MilkData.Repository.Implements;
using MilkData.VNPay.Config;
using MilkData.VNPay.Request;
using MilkData.VNPay.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MilkData.DTOs.Order.OrderDetailDTO;
using static MilkData.DTOs.Order.OrderDTO;
using static MilkData.DTOs.Order.PaymentDTO;

namespace MilkBusiness
{
    public class OrderBusiness
    {
        private readonly UnitOfWork _unitOfWork;

        public OrderBusiness()
        {
            _unitOfWork ??= new UnitOfWork();
        }

        #region Order

        public async Task<IMilkResult> GetAllOrders()
        {
            var ordersList = await _unitOfWork.GetRepository<Order>().GetListAsync(
                selector: o => new GetOrder()
                {
                    OrderId = o.OrderId,
                    UpdateDate = o.UpdateDate,
                    CreateDate = o.CreateDate,
                    Status = o.Status,
                    AccountId = o.AccountId,
                    Currency = o.Currency,
                    Description = o.Description,
                    Note = o.Note,
                    PaymentType = o.PaymentType,
                    TotalPrice = o.TotalPrice,
                    VoucherCode = o.VoucherCode
                });
            return new MilkResult(ordersList);
        }

        public async Task<IMilkResult> GetOrderById(int id)
        {
            var order = await _unitOfWork.GetRepository<Order>().SingleOrDefaultAsync(
                predicate: o => o.OrderId == id,
                selector: o => new GetOrder()
                {
                    OrderId = o.OrderId,
                    UpdateDate = o.UpdateDate,
                    CreateDate = o.CreateDate,
                    Status = o.Status,
                    AccountId = o.AccountId,
                    Currency = o.Currency,
                    Description = o.Description,
                    Note = o.Note,
                    PaymentType = o.PaymentType,
                    TotalPrice = o.TotalPrice,
                    VoucherCode = o.VoucherCode
                });

            if (order == null)
            {
                return new MilkResult
                {
                    Status = -1,
                    Message = "Order not found"
                };
            }

            return new MilkResult(order);
        }

        public async Task<IMilkResult> GetOrdersByAccount(int id)
        {

            var ordersList = await _unitOfWork.GetRepository<Order>().GetListAsync(
                 predicate: o => o.AccountId == id,
                 selector: o => new GetOrder()
                 {
                     OrderId = o.OrderId,
                     UpdateDate = o.UpdateDate,
                     CreateDate = o.CreateDate,
                     Status = o.Status,
                     AccountId = o.AccountId,
                     Currency = o.Currency,
                     Description = o.Description,
                     Note = o.Note,
                     PaymentType = o.PaymentType,
                     TotalPrice = o.TotalPrice,
                     VoucherCode = o.VoucherCode
                 });

            if (ordersList == null)
            {
                return new MilkResult
                {
                    Status = -1,
                    Message = "Order not found"
                };
            }

            return new MilkResult(ordersList);
        }

        public async Task<IMilkResult> CreateOrder(CreateOrder createOrder)
        {
            Order order = new Order
            {
                UpdateDate = DateTime.Now,
                CreateDate = DateTime.Now,
                Status = createOrder.Status,
                AccountId = createOrder.AccountId,
                Currency = createOrder.Currency,
                Description = createOrder.Description,
                Note = createOrder.Note,
                PaymentType = createOrder.PaymentType,
                TotalPrice = createOrder.TotalPrice,
                VoucherCode = createOrder.VoucherCode
            };
            await _unitOfWork.GetRepository<Order>().InsertAsync(order);

            MilkResult result = new MilkResult();

            bool status = await _unitOfWork.CommitAsync() > 0;
            if (status)
            {
                result.Data = order;
                result.Status = 1;
                result.Message = "Order created successfully";
            }
            else
            {
                result.Status = -1;
                result.Message = "Order creation failed";
            }
            return result;
        }

        public async Task ChangeOrderStatus(int orderId, string status)
        {
            var order = await _unitOfWork.GetRepository<Order>().SingleOrDefaultAsync(predicate: o => o.OrderId == orderId);
            order.Status = status;
            order.UpdateDate = DateTime.Now;
            _unitOfWork.GetRepository<Order>().UpdateAsync(order);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IMilkResult> UpdateOrder(int id, UpdateOrder updatedOrder)
        {
            Order currentOrder = await _unitOfWork.GetRepository<Order>()
                .SingleOrDefaultAsync(predicate: o => o.OrderId == id);
            if (currentOrder == null) return new MilkResult(-1, "Blog cannot be found");
            else
            {
                currentOrder.AccountId = updatedOrder.AccountId;
                currentOrder.Description = String.IsNullOrEmpty(updatedOrder.Description) ? currentOrder.Description : updatedOrder.Description;
                currentOrder.VoucherCode = updatedOrder.VoucherCode;
                currentOrder.TotalPrice = updatedOrder.TotalPrice;
                currentOrder.Currency = String.IsNullOrEmpty(updatedOrder.Currency) ? currentOrder.Currency : updatedOrder.Currency;
                currentOrder.Status = String.IsNullOrEmpty(updatedOrder.Status) ? currentOrder.Status : updatedOrder.Status;
                currentOrder.PaymentType = String.IsNullOrEmpty(updatedOrder.PaymentType) ? currentOrder.PaymentType : updatedOrder.PaymentType;
                currentOrder.UpdateDate = DateTime.Now;
                currentOrder.Note = String.IsNullOrEmpty(updatedOrder.Note) ? currentOrder.Note : updatedOrder.Note;

                _unitOfWork.GetRepository<Order>().UpdateAsync(currentOrder);
                await _unitOfWork.CommitAsync();
            }

            return new MilkResult(updatedOrder);
        }

        public async Task<IMilkResult> DeleteOrder(int id)
        {
            Order order = await _unitOfWork.GetRepository<Order>()
                .SingleOrDefaultAsync(predicate: o => o.OrderId == id);
            if (order == null) return new MilkResult();
            else
            {
                _unitOfWork.GetRepository<Order>().DeleteAsync(order);
                await _unitOfWork.CommitAsync();
            }
            return new MilkResult(1, "Delete Successfull");
        }

        #endregion

        #region Payment

        //public async Task<Order> GetOrderObjectById(int id)
        //{
        //    return await _unitOfWork.GetRepository<Order>().SingleOrDefaultAsync(predicate: o => o.OrderId == id);
        //}

        //private async Task<PaymentDTO.PaymentLinkResponse> CreatePayment(Order order)
        //{
        //    VNPayConfig vnPayConfig = VNPayHelper.GetConfigData();

        //    var orderInfo = await GetOrderObjectById(order.OrderId);

        //    VNPayRequest request = new VNPayRequest()
        //    {
        //        vnp_Version = vnPayConfig.Version,
        //        vnp_TmnCode = vnPayConfig.TmnCode,
        //        vnp_CreateDate = DateTime.Now.ToString("yyyyMMddHHmmss"),
        //        vnp_IpAddr = IPAddressHelper.GetLocalIPAddress(),
        //        vnp_Amount = Math.Ceiling((decimal)orderInfo.OrderPrice) * 100,
        //        vnp_CurrCode = vnPayConfig.CurrencyCode,
        //        vnp_OrderType = "other",
        //        vnp_OrderInfo = $"Ngày: {DateTime.Now.ToString("yyyyMMddHHmmss")}; Tổng giá: {orderInfo.OrderPrice}",
        //        vnp_ReturnUrl = vnPayConfig.ReturnUrl,
        //        vnp_TxnRef = order.OrderId.ToString(),
        //        vnp_Command = "pay",
        //        vnp_Locale = vnPayConfig.Locale
        //    };

        //    var paymentUrl = await _vNPayBusiness.GetPaymentLink(vnPayConfig.PaymentUrl, vnPayConfig.HashSecret, request);

        //    return new PaymentLinkResponse
        //    {
        //        OrderId = order.OrderId,
        //        PaymentUrl = paymentUrl,
        //    };
        //}

        ////private async Task<PaymentOrderInfoResponse> TakeOrderInfo(int orderId)
        ////{
        ////    decimal totalPrice = 0;
        ////    var orderDetails = await _unitOfWork.GetRepository<OrderDetail>().GetListAsync(predicate: od => od.OrderId == orderId);

        ////    if (orderDetails.Count > 0)
        ////    {
        ////        foreach (var orderDetail in orderDetails)
        ////        {
        ////            var product = await _unitOfWork.GetRepository<Product>().SingleOrDefaultAsync(predicate: p => p.ProductId == orderDetail.ProductId);
        ////            totalPrice += product.Price * orderDetail.Quantity;
        ////        }
        ////    }

        ////    return new PaymentOrderInfoResponse
        ////    {
        ////        ItemAmount = orderDetails.Count,
        ////        TotalPrice = totalPrice
        ////    };
        ////}

        //public async Task<IMilkResult> CheckPaymentResponse(VNPayResponse response)
        //{
        //    VNPayConfig vnPayConfig = VNPayHelper.GetConfigData();
        //    PaymentReturnResponse paymentResponse = new PaymentReturnResponse();

        //    paymentResponse.OrderId = int.Parse(response.vnp_TxnRef);
        //    paymentResponse.Amount = response.vnp_Amount;

        //    bool isValid = await _vNPayBusiness.IsValidSignature(vnPayConfig.HashSecret, response);
        //    if (isValid)
        //    {
        //        if (await GetOrderObjectById(int.Parse(response.vnp_TxnRef)) != null)
        //        {
        //            if (response.vnp_ResponseCode == "00")
        //            {
        //                paymentResponse.PaymentStatus = "Success";
        //            }
        //            else
        //            {
        //                paymentResponse.PaymentStatus = "Unsuccess";
        //            }

        //            switch (response.vnp_ResponseCode)
        //            {
        //                case "00":
        //                    paymentResponse.PaymentMessage = "Successful transaction.";
        //                    break;
        //                case "07":
        //                    paymentResponse.PaymentMessage = "Successful balance deduction. Suspicious transaction (Related to scam, abnormal transaction).";
        //                    break;
        //                case "09":
        //                    paymentResponse.PaymentMessage = "Card/Banking account is not registered banking services.";
        //                    break;
        //                case "10":
        //                    paymentResponse.PaymentMessage = "Incorrect Card/Banking Account infomation validation more than 3 times.";
        //                    break;
        //                case "11":
        //                    paymentResponse.PaymentMessage = "Transaction duration expired. Please redo making transaction.";
        //                    break;
        //                case "12":
        //                    paymentResponse.PaymentMessage = "Card/Banking Account is currently unavailable (Locked).";
        //                    break;
        //                case "13":
        //                    paymentResponse.PaymentMessage = "Wrong OTP Code inputed.";
        //                    break;
        //                case "24":
        //                    paymentResponse.PaymentMessage = "Transaction Canceled.";
        //                    break;
        //                case "51":
        //                    paymentResponse.PaymentMessage = "Banking Account's balance is not enough for this transaction.";
        //                    break;
        //                case "65":
        //                    paymentResponse.PaymentMessage = "Bankiing Account exceeds the transaction limitation per day.";
        //                    break;
        //                case "75":
        //                    paymentResponse.PaymentMessage = "Bank in maintanance.";
        //                    break;
        //                case "79":
        //                    paymentResponse.PaymentMessage = "Incorrect transaction's password inputed more than specified number of times.";
        //                    break;
        //                case "99":
        //                    paymentResponse.PaymentMessage = "Other Transaction Error.";
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            paymentResponse.PaymentStatus = "Unsuccess";
        //            paymentResponse.PaymentMessage = "Can't find order in DB.";
        //        }

        //    }
        //    else
        //    {
        //        paymentResponse.PaymentStatus = "Unsuccess";
        //        paymentResponse.PaymentMessage = "Invalid signature in response.";
        //    }

        //    return new MilkResult
        //    {
        //        Status = 1,
        //        Data = paymentResponse
        //    };
        //}

        #endregion
    }
}
