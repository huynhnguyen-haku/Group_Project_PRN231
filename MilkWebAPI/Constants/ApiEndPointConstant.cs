namespace MilkWebAPI.Constants
{
    public class ApiEndPointConstant
    {
        public const string RootEndPoint = "/api";
        public const string ApiVersion = "/v1";
        public const string ApiEndpoint = RootEndPoint + ApiVersion;

        public class Authentication()
        {
            public const string LoginEndpoint = ApiEndpoint + "/login";
            public const string RegisterEndpoint = ApiEndpoint + "/register";
        }

        public class Account()
        {
            public const string AccountsEndpoint = ApiEndpoint + "/accounts";
            public const string EmailAccountsEndpoint = AccountsEndpoint + "/{email}/info";
            public const string AccountEndpoint = AccountsEndpoint + "/{id}";
            public const string OrderHistoryEndpoint = AccountEndpoint + "/order-history";
        }

        public class Blog()
        {
            public const string BlogsEndpoint = ApiEndpoint + "/blogs";
            public const string BlogEndpoint = ApiEndpoint + "/blogs/{id}";
        }

        public class BlogCategory()
        {
            public const string BlogCategoriesEndpoint = ApiEndpoint + "/blog-categories";
            public const string BlogCategoryEndpoint = ApiEndpoint + "/blog-categories/{id}";
        }

        public class Voucher()
        {
			public const string VouchersEndpoint = ApiEndpoint + "/vouchers";
			public const string VoucherEndpoint = VouchersEndpoint + "/{id}";
            public const string VoucherEndpointByType = VouchersEndpoint + "/type/{type}";
		}

        public class Gift()
        {
			public const string GiftsEndpoint = ApiEndpoint + "/gifts";
			public const string GiftEndpoint = GiftsEndpoint + "/{id}";
		}

        public class Gifted()
        {
            public const string GiftedsEndpoint = ApiEndpoint + "/gifted";
            public const string GiftedEndpoint = GiftedsEndpoint + "/{id}";
        }

        public class Category()   
        {
            public const string CategoriesEndPoint = ApiEndpoint + "/categories";
            public const string CategoryEndPoint = CategoriesEndPoint + "/{id}";
        }

        public class Product()
        {
            public const string ProductsEndPoint = ApiEndpoint + "/products";
            public const string ProductEndPoint = ProductsEndPoint + "/{id}";
        }

        public class ProductImage()
        {
            public const string ProductImagesEndPoint = ApiEndpoint + "/product-images";
            public const string ProductImageEndPoint = ProductImagesEndPoint + "/{id}";
            public const string ProductImageByProductEndPoint = ProductImagesEndPoint + "/product/{productId}";
        }

        public class Order()
        {
            public const string OrdersEndPoint = ApiEndpoint + "/orders";
            public const string OrderEndPoint = OrdersEndPoint + "/{id}";
            //public const string OrderConfirmEndpoint = OrdersEndPoint + "/success";
        }

        public class OrderDetail()
        {
            public const string OrderDetailsEndPoint = ApiEndpoint + "/order-details";
            public const string OrderDetailEndPoint = OrderDetailsEndPoint + "/{id}";
        }

        public class Feedback()
        {
            public const string FeedbacksEndPoint = ApiEndpoint + "/feedbacks";
            public const string FeedbackEndPoint = FeedbacksEndPoint + "/{id}";
            public const string FeedbackOfProductEndPoint = FeedbacksEndPoint + "/product/{productId}";
        }

        public class FeedbackMedia()
        {
            public const string FeedbackMediaEndPoint = ApiEndpoint + "/feedback-media";
            public const string FeedbacMediumkEndPoint = FeedbackMediaEndPoint + "/{id}";
        }

        public class Payment()
        {
            public const string PaymentEndPoint = ApiEndpoint + "/payment";
            public const string PaymentReturnEndPoint = PaymentEndPoint + "/response";
        }
    }
}
